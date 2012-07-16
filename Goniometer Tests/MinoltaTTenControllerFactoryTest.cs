using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

using Goniometer_Controller.Sensors;

namespace Goniometer_Tests
{
    /// <summary>
    ///This is a test class for MinoltaTTenControllerFactoryTest and is intended
    ///to contain all MinoltaTTenControllerFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MinoltaTTenControllerFactoryTest
    {
        /// <summary>
        ///A test for GetSensorController
        ///</summary>
        [TestMethod()]
        public void GetSensorControllerTest()
        {
            string portname = ConfigurationManager.AppSettings["sensor_port"];
            MinoltaT10Provider.SetPortName(portname);

            MinoltaT10Controller actual;
            actual = MinoltaT10Provider.GetController();

            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for ConfigureMotorController
        ///</summary>
        [TestMethod()]
        public void ConfigureMotorControllerTest()
        {
            string portname = ConfigurationManager.AppSettings["sensor_port"];
            MinoltaT10Provider.SetPortName(portname);
        }
    }
}
