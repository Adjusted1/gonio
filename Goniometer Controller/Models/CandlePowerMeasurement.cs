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
        /// <param sensorname="readings"></param>
        /// <param sensorname="strayReadings"></param>
        /// <returns>a new collection with only the calculated illuminance values</returns>
        public static MeasurementCollection RemoveStrayLight(MeasurementCollection readings, MeasurementCollection strayReadings)
        {
            var key = MeasurementKeys.Illuminance;
            MeasurementCollection results = new MeasurementCollection();
            
            foreach(var m in readings.FindAll(key))
            {
                var stray = strayReadings.GetEstimateReading(key, m.Theta, m.Phi);

                results.Add(MeasurementBase.Create(m.Theta, m.Phi, key, m.Value - stray.Value));
            }

            return results;
        }

        /// <summary>
        /// for each reading, multiply by the factor
        /// </summary>
        /// <param sensorname="readings"></param>
        /// <param sensorname="factor"></param>
        /// <returns>a new collection with only the offset illuminance values</returns>
        public static MeasurementCollection ApplyOffsetFactor(MeasurementCollection readings, double factor)
        {
            var key = MeasurementKeys.Illuminance;
            MeasurementCollection results = new MeasurementCollection();
            
            foreach(var m in readings.FindAll(key))
            {
                results.Add(MeasurementBase.Create(m.Theta, m.Phi, key, m.Value * factor));
            }

            return results;
        }

        public static MeasurementCollection CalculateIntensity(MeasurementCollection readings, double distance)
        {
            var key = MeasurementKeys.Illuminance;
            MeasurementCollection results = new MeasurementCollection();

            foreach (var m in readings.FindAll(key))
            {
                double value = m.Value * Math.Pow(distance, 2);
                results.Add(MeasurementBase.Create(m.Theta, m.Phi, MeasurementKeys.LuminousIntensity, value, m.SensorName, m.PortName));
            }

            return results;
        }
    }
}
