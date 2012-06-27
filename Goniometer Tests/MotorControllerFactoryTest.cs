using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Net;

using Goniometer_Controller.Motors;


namespace Goniometer_Tests
{
    
    
    /// <summary>
    ///This is a test class for MotorControllerFactoryTest and is intended
    ///to contain all MotorControllerFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MotorControllerFactoryTest
    {
        /// <summary>
        ///A test for getMotorController
        ///</summary>
        [TestMethod()]
        public void getMotorControllerTest()
        {
            //configure factory
            string ipaddress = ConfigurationManager.AppSettings["motor_ipaddress"];
            MotorControllerFactory.ConfigureMotorController(IPAddress.Parse(ipaddress));

            MotorController actual;
            actual = MotorControllerFactory.getMotorController();

            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for ConfigureMotorController
        ///</summary>
        [TestMethod()]
        public void ConfigureMotorControllerTest()
        {
            //configure factory
            string ipaddress = ConfigurationManager.AppSettings["motor_ipaddress"];
            MotorControllerFactory.ConfigureMotorController(IPAddress.Parse(ipaddress));
        }
    }
}
