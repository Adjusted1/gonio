using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Models
{
    public class CandlePowerMeasurementFunctions
    {
        /// <summary>
        /// for each reading, subtract the estimate reading from the stray readings collection
        /// </summary>
        /// <param name="readings"></param>
        /// <param name="strayReadings"></param>
        /// <returns>a new collection with only the calculated illuminance values</returns>
        public static MeasurementCollection RemoveStrayLight(MeasurementCollection readings, MeasurementCollection strayReadings)
        {
            var key = MeasurementKeys.IlluminanceEv;
            MeasurementCollection results = new MeasurementCollection();
            
            foreach(var m in readings.FindAll(key))
            {
                var stray = strayReadings.GetEstimateReading(key, m.theta, m.phi);

                results.Add(MeasurementBase.Create(m.theta, m.phi, key, m.value - stray.value));
            }

            return results;
        }

        /// <summary>
        /// for each reading, multiply by the factor
        /// </summary>
        /// <param name="readings"></param>
        /// <param name="factor"></param>
        /// <returns>a new collection with only the offset illuminance values</returns>
        public static MeasurementCollection ApplyOffsetFactor(MeasurementCollection readings, double factor)
        {
            var key = MeasurementKeys.IlluminanceEv;
            MeasurementCollection results = new MeasurementCollection();
            
            foreach(var m in readings.FindAll(key))
            {
                results.Add(MeasurementBase.Create(m.theta, m.phi, key, m.value * factor));
            }

            return results;
        }
    }
}
