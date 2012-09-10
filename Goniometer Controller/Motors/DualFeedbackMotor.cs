using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Goniometer_Controller.Motors
{
    /* Dual Feedback Motor requires two encoders, one on the servo motor and another on the load.
     * 
     * The dual feedback can compensate for a load that may 
     * A) become offset during motion (backlash in a gearhead)
     * B) or may drift because of flex in the structure
     * 
     * True compensation would require that we somehow map both the
     * A) offset (can change depending on motion direction) 
     * B) and flex (can change depending on position or load)
     *
     * BUT this is overkill, instead we will use 
     * simple approximation method and get close enough
     * 
     * Assumre linear relationship:
     * 
     * 1) Instruct Motor to MOVE to destination
     * 2) WAIT for Motor Encoder to reach destination
     * 3) Measure difference between load location and intended location
     * 4) Instruct Motor to MOVE to destination + difference on load
     * 5) Repeat if necessary
     * 
     * This method works because the flex and offset shouldn't
     * change significantly during the incremental move
     * 
     * If we set a Max of 2 repeats, we can minimize the wait time in exchange for accuracy
     * 
     **/

    internal class DualFeedbackMotor : BaseMotor
    {
        private short _encoderAxisNumber;
        private double _encoderScale;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="motorAxisNumber">zero indexed</param>
        /// <param name="motorScale"></param>
        /// <param name="encoderAxisNumber">zero indexed</param>
        /// <param name="encoderScale"></param>
        public DualFeedbackMotor(short motorAxisNumber, double motorScale, short encoderAxisNumber, double encoderScale)
            : base(motorAxisNumber, motorScale)
        {
            this._encoderAxisNumber = encoderAxisNumber;
            this._encoderScale = encoderScale;
        }

        public override double GetEncoderPosition()
        {
            short axis = (short)(_encoderAxisNumber + 1);
            int pos = MotorSocketProvider.GetEncoderPosition(axis);
            return pos / _encoderScale;
        }

        public override void ZeroMotor()
        {
            //zero motor
            base.ZeroMotor();

            //zero encoder
            string cmd = "pset";
            cmd += ','.Multiply(_encoderAxisNumber);
            cmd += "0:";

            MotorSocketProvider.Write(cmd); 
        }

        public override void MoveAndWait(double distance, double velocity, double acceleration)
        {
            int attempt = 0;
            int maxAttempts = 2;
            double adjustedDistance = distance;

            do
            {
                //first or adjusted move
                base.MoveAndWait(adjustedDistance, velocity, acceleration);

                //record attempts
                attempt++;
                if (attempt > maxAttempts)
                {
                    //max attempts, exit
                    return;
                }
                else
                {
                    //recalculate difference
                    double encoderPosition = this.GetEncoderPosition();
                    double motorPosition   = this.GetMotorPosition();

                    adjustedDistance = distance - encoderPosition + motorPosition;
                }
            //check if we are close enough
            } while (Math.Abs(this.GetEncoderPosition() - distance) > _accuracy);
        }
    }
}
