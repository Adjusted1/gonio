using Goniometer.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Goniometer_Controller.Models;

namespace Goniometer_Tests
{
    
    
    /// <summary>
    ///This is a test class for iesnaTest and is intended
    ///to contain all iesnaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class iesnaTest
    {
        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            MeasurementCollection data = LightMathTest.GetLuminousData();
            iesna target = new iesna(data);
            target.test = "Test - Manually Validate Lumen Summation";
            target.manufacture = "Philips";

            string actual = target.ToString();
            Assert.IsFalse(String.IsNullOrEmpty(actual));
        }
    }
}
