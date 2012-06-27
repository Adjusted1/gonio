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
    public class MotorController : INotifyPropertyChanged, IDisposable
    {
        private MotorSocket _socket;
        private BaseMotor _horizontalMotor;
        private BaseMotor _verticalMotor;

        #region constructor and initializer
        internal MotorController(IPAddress address)
        {
            Connect(address);
        }

        private void Connect(IPAddress address)
        {
            if (_socket != null)
                _socket.Dispose();

            _socket = new MotorSocket(address);

            InitializeVerticalMotor();
            InitializeHorizontalMotor();
        }

        private void InitializeHorizontalMotor()
        {
            _horizontalMotor = new BaseMotor(_socket, 1);
            _horizontalMotor.PropertyChanged += HandleHorizontalAngleChanges;

            _horizontalMotor.SendCommand("eres",    "8192");    //encoder resolution * 4 = 8192 counts per rev
            _horizontalMotor.SendCommand("lh",      "0");       //Hardware End-of-Travel Limit — Enable Checking: Disable negative-direction limit; Disable positive-direction limit: i = 0

            //scale factors: 
            _horizontalMotor.SendCommand("scla",    "100");     //Acceleration Scale Factor [rev/sec/sec]
            _horizontalMotor.SendCommand("sclv",    "100");     //Velocity Scale Factor     [rev/sec]
            _horizontalMotor.SendCommand("scld",    "2222");    //Distance Scale Factor     [rev]

            //feedback values
            _horizontalMotor.SendCommand("smper",   "15");      //Maximum Allowable Position Error
            _horizontalMotor.SendCommand("sgp",     "1");       //Proportional Feeback Gain [microvolts/step]
            _horizontalMotor.SendCommand("sgv",     "15");      //Velocity Feedback Gain    [microvolts/step/sec]

            _horizontalMotor.SendAccelerationCommand(200);
            _horizontalMotor.SendVelocityCommand(210);
            _horizontalMotor.ExecuteCommands();
        }

        private void InitializeVerticalMotor()
        {
            _verticalMotor = new BaseMotor(_socket, 0);
            _verticalMotor.PropertyChanged += HandleVerticalAngleChanges;

            _verticalMotor.SendCommand("eres", "8192");         //encoder resolution * 4 = 8192 counts per rev
            _verticalMotor.SendCommand("lh",    "0");           //Hardware End-of-Travel Limit — Enable Checking: Disable negative-direction limit; Disable positive-direction limit: i = 0

            //scale factors: 400:1 gear reducer = 3276800 counts per rev / 360deg = 9102.222 counts per degree
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

            _verticalMotor.SendAccelerationCommand(5);
            _verticalMotor.SendVelocityCommand(3);
            _verticalMotor.ExecuteCommands();
        }
        #endregion

        public void Dispose()
        {
            EmergencyStop();
        }

        #region get angles
        public double horizontalAngle
        {
            get
            {
                return _horizontalMotor.angle;
            }
        }

        public double verticalAngle
        {
            get
            {
                return _verticalMotor.angle;
            }
        }
        #endregion

        #region set angles
        public void SetHorizontalAngle(double angle)
        {
            SetAngle(_horizontalMotor, angle);
        }

        public void SetVerticalAngle(double angle)
        {
            SetAngle(_verticalMotor, angle);
        }

        private void SetAngle(BaseMotor motor, double angle)
        {
            motor.SendAngleCommand(angle);
            motor.ExecuteCommands();
        }
        
        public void SetHorizontalAngleAndWait(double angle)
        {
            SetAngleAndAwait(_horizontalMotor, angle);
        }

        public void SetVerticalAngleAndWait(double angle)
        {
            SetAngleAndAwait(_verticalMotor, angle);
        }

        private void SetAngleAndAwait(BaseMotor motor, double angle)
        {
            //TODO calculate timeout required for a full 360 loop
            TimeSpan timeout = new TimeSpan(0, 0, 1);

            motor.SendAngleCommand(angle);
            motor.ExecuteCommands();

            DateTime startTime = DateTime.Now;
            while (motor.angle - angle < motor.accuracy)
            {
                if (DateTime.Now - startTime > timeout)
                    //we've exceeded our alloted time
                    throw new TimeoutException();
                else
                    //sleep then check again
                    Thread.Sleep(100);
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            var notify = PropertyChanged;
            if (notify != null)
            {
                notify(this, new PropertyChangedEventArgs(info));
            }
        }

        private void HandleHorizontalAngleChanges(object sender, PropertyChangedEventArgs args)
        {
            //propogate update
            if (args.PropertyName == "angle")
            {
                NotifyPropertyChanged("horizontalAngle");
            }
        }

        private void HandleVerticalAngleChanges(object sender, PropertyChangedEventArgs args)
        {
            //propogate update
            if (args.PropertyName == "angle")
            {
                NotifyPropertyChanged("verticalAngle");
            }
        }
        #endregion

        #region zero motors
        public void ZeroVerticalMotor()
        {
            _verticalMotor.ZeroMotor();
        }

        public void ZeroHorizontalMotor()
        {
            _horizontalMotor.ZeroMotor();
        }
        #endregion

        public void EmergencyStop()
        {
            if (_verticalMotor != null)
                _verticalMotor.EmergencyStop();

            if (_horizontalMotor != null)
                _horizontalMotor.EmergencyStop();

            if (_socket != null)
                _socket.Write("!k:");
        }
    }
}
