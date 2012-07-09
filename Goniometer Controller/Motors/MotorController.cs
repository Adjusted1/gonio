using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Net;

namespace Goniometer_Controller.Motors
{
    /* SO yeah... you might be asking yourself: is the static/singleton really necessary here?
     * Pretty much. I'd like to have multiple consumers of the MotorController (readers and writers),
     * but I also need to support: 1) the ability to reset the connection without requiring everyone to
     * fetch new instances from a factory. Additionally, 2) some methods require a write-wait-read pattern
     * that should lock the socket for the duration of that command.
     */

    public static class MotorController
    {
        private static BaseMotor _horizontalMotor;
        private static BaseMotor _verticalMotor;

        #region configuration and initialization
        static MotorController()
        {
            _horizontalMotor = new BaseMotor(1, 2222.2);

            _verticalMotor   = new BaseMotor(0, 9102.2);
        }

        public static void Connect(IPAddress address)
        {
            //halt all motion during configuration process
            EmergencyStop();

            MotorSocketProvider.SetIPAddress(address);

            InitializeVerticalMotor();
            InitializeHorizontalMotor();

            //Global Controller Commands
            MotorSocketProvider.Write("scale11");   //set all axis to scale mode

            MotorSocketProvider.Write("!comexc1:"); //set continuous execution mode

            //Default not zeroing!
            ExitZeroingMode();
        }

        private static void InitializeHorizontalMotor()
        {
            //encoder resolution not necessary?
            _horizontalMotor.SendCommand("eres",    "8000");    //encoder resolution * 4 = 8000 counts per rev
            //_horizontalMotor.SendCommand("lh",      "0");     //Hardware End-of-Travel Limit — Enable Checking: Disable negative-direction limit; Disable positive-direction limit: i = 0

            //scale factors: 100:1 gear reducer = 800,000 counts per rev / 360deg = 2222.222 counts per degree
            _horizontalMotor.SendCommand("scla",    "2222");    //Acceleration Scale Factor [rev/sec/sec]
            _horizontalMotor.SendCommand("sclv",    "2222");    //Velocity Scale Factor     [rev/sec]
            _horizontalMotor.SendCommand("scld",    "2222");    //Distance Scale Factor     [rev]

            //feedback values
            _horizontalMotor.SendCommand("smper",   "15");      //Maximum Allowable Position Error
            _horizontalMotor.SendCommand("sgp",     "1");       //Proportional Feeback Gain [microvolts/step]
            _horizontalMotor.SendCommand("sgv",     "15");      //Velocity Feedback Gain    [microvolts/step/sec]
        }

        private static void InitializeVerticalMotor()
        {
            _verticalMotor.SendCommand("eres", "8192");         //encoder resolution * 4 = 8192 counts per rev
            //_verticalMotor.SendCommand("lh",    "0");         //Hardware End-of-Travel Limit — Enable Checking: Disable negative-direction limit; Disable positive-direction limit: i = 0

            //scale factors: 400:1 gear reducer = 3,276,800 counts per rev / 360deg = 9102.222 counts per degree
            _verticalMotor.SendCommand("scla",  "9102");        //Acceleration Scale Factor [rev/sec/sec]
            _verticalMotor.SendCommand("sclv",  "9102");        //Velocity Scale Factor     [rev/sec]
            _verticalMotor.SendCommand("scld",  "9102.2");      //Distance Scale Factor     [rev]

            //feedback values
            _verticalMotor.SendCommand("smper", "4");           //Maximum Allowable Position Error
            _verticalMotor.SendCommand("sgp",   "20");          //Proportional Feedback Gain [microvolts/step]
            _verticalMotor.SendCommand("sgv",   "3");           //Velocity Feedback Gain     [microvolts/step/sec]
            //cause occillation errors
            //_verticalMotor.SendCommand("sgi", "0.1");        //Integral Feedback Gain    [microvolts/sec*sec]
            //_verticalMotor.SendCommand("sgilim", "2");       //Integral Windup Limit
        }
        #endregion

        #region get angles
        public static double GetHorizontalAngle()
        {
            return _horizontalMotor.GetAngle();
        }

        public static double GetVerticalAngle()
        {
            return _verticalMotor.GetAngle() * -1;
        }
        #endregion

        #region set angles
        public static void SetHorizontalAngle(double angle)
        {
            _horizontalMotor.Move(angle, 10, 10, true);
        }

        public static void SetVerticalAngle(double angle)
        {
            angle *= -1;
            _verticalMotor.Move(angle, 5, 3, true);
        }

        public static void SetHorizontalAngleAndWait(double angle)
        {
            _horizontalMotor.MoveAndWait(angle, 10, 10, true);
        }

        public static void SetVerticalAngleAndWait(double angle)
        {
            angle *= -1;
            _verticalMotor.MoveAndWait(angle, 5, 3, true);
        }
        #endregion

        #region zero motors
        private static bool _zeroing;        
        public static void EnterZeroingMode()
        {
            MotorSocketProvider.Write("ma00:");     //set all axis to incremental mode (not absolute)
            _zeroing = true;
        }

        public static void ZeroHorizontalMotor()
        {
            if (!_zeroing)
                throw new InvalidOperationException("Call EnterZeroingMode before calling Zero Methods");

            _horizontalMotor.ZeroMotor();
        }

        public static void ZeroVerticalMotor()
        {
            if (!_zeroing)
                throw new InvalidOperationException("Call EnterZeroingMode before calling Zero Methods");

            _verticalMotor.ZeroMotor();
        }

        public static void ExitZeroingMode()
        {
            MotorSocketProvider.Write("ma11:");     //set all axis to absolute mode (not incremental)
            _zeroing = false;
        }
        #endregion

        public static void EmergencyStop()
        {
            try
            {
                MotorSocketProvider.Write("!k:");
            }
            catch(Exception)
            {
                //omnomnom
            }
        }
    }
}
