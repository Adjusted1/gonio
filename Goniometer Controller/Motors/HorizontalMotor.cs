using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Motors
{
    internal class HorizontalMotor : DualFeedbackMotor
    {
        private static double _min = 0;
        private static double _max = 360;

        //private static double _velocity = 3;
        private static double _velocity = 5;
        //private static double _accerlation = 1;
        private static double _accerlation = 3;

        private static short _motorAxis = 1;
        private static short _encoderAxis = 2;

        private static double _motorScale = 2222.2;
        private static double _encoderScale = -13.888;

        //motor encoder resolution * 4 = 8000 counts per rev
        //load  encoder resolution * 4 = 5000 counts per rev

        //scale factors:
        //motor scale factor: 100:1 gear reducer = 800,000 counts per rev / 360deg = 2222.222 counts per degree
        //load  scale factor:         no reducer =    5000 counts per rev / 360deg = 13.8...

        //load encoder runs negative numbers

        public HorizontalMotor()
            : base(_motorAxis, _motorScale, _encoderAxis, _encoderScale)
        {

        }

        public void Move(double angle)
        {
            this.Move(angle, _velocity, _accerlation);
        }

        public void MoveAndWait(double angle)
        {
            this.MoveAndWait(angle, _velocity, _accerlation);
        }
    }
}
