using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;

namespace Goniometer_Controller
{
    public class MotorController : IDisposable
    {
        private MotorSocket socket;
        private BaseMotor verticalMotor;
        private BaseMotor horizontalMotor;

        #region constructor and initializer
        public MotorController(IPAddress address)
        {
            Connect(address);
        }

        private void Connect(IPAddress address)
        {
            if (socket != null)
                socket.Dispose();

            socket = new MotorSocket(address);

            InitializeVerticalMotor();
            InitializeHorizontalMotor();
        }

        private void InitializeVerticalMotor()
        {
            verticalMotor = new BaseMotor(socket, 0);
            verticalMotor.SendAccelerationCommand(5);
            verticalMotor.SendVelocityCommand(3);
            verticalMotor.ExecuteCommands();
        }

        private void InitializeHorizontalMotor()
        {
            horizontalMotor = new BaseMotor(socket, 1);
            horizontalMotor.SendAccelerationCommand(200);
            horizontalMotor.SendVelocityCommand(210);
            horizontalMotor.ExecuteCommands();
        }
        #endregion

        public void Dispose()
        {
            EmergencyStop();
        }

        #region set angles
        public void SetVerticalAngleAndWait(double angle)
        {
            SetAngleAndAwait(verticalMotor, angle);
        }

        public void SetHorizontalAngleAndWait(double angle)
        {
            SetAngleAndAwait(horizontalMotor, angle);
        }

        private void SetAngleAndAwait(BaseMotor motor, double angle)
        {
            //TODO calculate timeout required for a full 360 loop
            TimeSpan timeout = new TimeSpan(0, 0, 1);

            motor.SendAngleCommand(angle);
            motor.ExecuteCommands();

            DateTime startTime = DateTime.Now;
            while (motor.GetAngle() - angle < motor.accuracy)
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

        #region zero motors
        public void ZeroVerticalMotor()
        {
            verticalMotor.ZeroMotor();
        }

        public void ZeroHorizontalMotor()
        {
            horizontalMotor.ZeroMotor();
        }
        #endregion

        public void EmergencyStop()
        {
            if (verticalMotor != null)
                verticalMotor.EmergencyStop();

            if (horizontalMotor != null)
                horizontalMotor.EmergencyStop();

            if (socket != null)
                socket.Write("!k:");
        }
    }
}
