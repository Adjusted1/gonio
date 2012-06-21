using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

using Goniometer.Functions;
using System.IO;
using System.Reflection;

namespace Goniometer_Tests
{
    [TestClass()]
    public class LightMathTest
    {
        /// <summary>
        ///A test for CalculateLumensByHorizontalAverage
        ///</summary>
        [TestMethod()]
        public void CalculateLumensByHorizontalAverageTest()
        {
            List<Tuple<double, double, double>> data = GenerateData();
            double expected = 2700;
            double actual;
            actual = LightMath.CalculateLumensByHorizontalAverage(data);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CalculateLumensByVertical
        ///</summary>
        [TestMethod()]
        public void CalculateLumensByVerticalTest()
        {
            List<Tuple<double, double, double>> data = GenerateData();
            double expected = 2700;
            double actual;
            actual = LightMath.CalculateLumensByVertical(data);
            Assert.AreEqual(expected, actual);
        }

        private List<Tuple<double, double, double>> GenerateData()
        {
            string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//exampledata.txt";
            var results = new List<Tuple<double, double, double>>();

            string hValues, vValues, readings;
            using (var sr = new StreamReader(filename))
            {
                vValues = sr.ReadLine();
                hValues = sr.ReadLine();

                readings = sr.ReadToEnd();
            }

            double[] hRange = hValues.Split(',').Select(h => Double.Parse(h)).ToArray();
            double[] vRange = vValues.Split(',').Select(v => Double.Parse(v)).ToArray();

            string[] lines = readings.Split('\n');
            for (int h = 0; h < lines.Length; h++ )
            {
                string[] values = lines[h].Split(',');
                for (int v = 0; v < values.Length; v++)
                {
                    double result = Double.Parse(values[v]);
                    results.Add(Tuple.Create(hRange[h], vRange[v], result));
                }
            }

            return results;
        }
    }
}
