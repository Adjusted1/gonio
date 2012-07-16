using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Models
{
    public class CandlePowerMeasurement : MeasurementBase
    {
        public CandlePowerMeasurement(double theta, double phi, double value)
            : base(theta, phi, MeasurementKeys.CandlePower, value)
        {
        }

        public static CandlePowerMeasurement Create(double theta, double phi, double value)
        {
            return new CandlePowerMeasurement(theta, phi, value);
        }

        public static MeasurementCollection RemoveStrayLight(MeasurementCollection readings, MeasurementCollection strayReadings)
        {
            MeasurementCollection results = new MeasurementCollection();
            
            foreach(var m in readings.FindAll(MeasurementKeys.CandlePower))
            {
                var stray = strayReadings.GetEstimateReading(MeasurementKeys.CandlePower, m.theta, m.phi);

                results.Add(MeasurementBase.Create(m.theta, m.phi, MeasurementKeys.CandlePower, m.value - stray.value));
            }

            return results;
        }

        public static MeasurementCollection ApplyOffsetFactor(MeasurementCollection readings, double factor)
        {
            MeasurementCollection results = new MeasurementCollection();
            
            foreach(var m in readings.FindAll(MeasurementKeys.CandlePower))
            {
                results.Add(MeasurementBase.Create(m.theta, m.phi, MeasurementKeys.CandlePower, m.value * factor));
            }

            return results;
        }
    }
}
