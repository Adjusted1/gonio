using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

using Goniometer_Controller.Functions;

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
            string testfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] testfiles = { "exampledata.txt", "exampledata2.txt" };

            foreach (string testfile in testfiles)
            {
                double expected;
                double actual;
                var data = GenerateData(testfolder + "//" + testfile, out expected);

                actual = LightMath.CalculateLumens(data);
                Assert.AreEqual(expected, actual, 0.1);
            }
        }

        /// <summary>
        ///A test for CalculateLumensByVertical
        ///</summary>
        [TestMethod()]
        public void CalculateLumensByVerticalTest()
        {
            string testfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] testfiles = { "exampledata.txt", "exampledata2.txt" };

            foreach (string testfile in testfiles)
            {
                double expected;
                double actual;
                var data = GenerateData(testfolder + "//" + testfile, out expected);

                actual = LightMath.CalculateLumensByVertical(data);
                Assert.AreEqual(expected, actual, 0.1);
            }
        }

        private List<Tuple<double, double, double>> GenerateData(string filename, out double lumens)
        {
            var results = new List<Tuple<double, double, double>>();

            string hValues, vValues, readings;
            using (var sr = new StreamReader(filename))
            {
                lumens = Double.Parse(sr.ReadLine());

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
