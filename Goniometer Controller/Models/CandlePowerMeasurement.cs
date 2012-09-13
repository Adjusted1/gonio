using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Models
{
    public class CandlePowerMeasurementFunctions
    {
        public static MeasurementCollection CalculateIntensity(MeasurementCollection readings, double distance)
        {
            string oldUnit = MeasurementKeys.Illuminance;
            string newUnit = MeasurementKeys.LuminousIntensity;

            MeasurementCollection results = new MeasurementCollection();

            foreach (var m in readings.FindAll(oldUnit))
            {
                double value = m.Value * Math.Pow(distance, 2);
                results.Add(MeasurementBase.Create(m.Theta, m.Phi, newUnit, value, m.SensorName, m.PortName));
            }

            return results;
        }
    }
}
