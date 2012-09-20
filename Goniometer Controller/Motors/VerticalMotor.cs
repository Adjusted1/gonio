using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Motors
{
    internal class VerticalMotor : DualFeedbackMotor
    {
        private static double _min = 0;
        private static double _max = 180;
                
        private static double _velocity = 5;
        private static double _accerlation = 3;
                
        private static short _motorAxis = 0;
        private static short _encoderAxis = 3;

        private static double _motorScale = -9102.2;
        private static double _encoderScale = -27.777;

        //motor encoder resolution * 4 = 8192 counts per rev
        //load  encoder resolution * 4 = 10000 counts per rev

        //scale factors:
        //motor scale factor: 400:1 gear reducer = 3,276,800 counts per rev / 360deg = 9102.2... counts per degree
        //load  scale factor:         no reducer =    10,000 counts per rev / 360deg = 27.7...

        public VerticalMotor() 
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
