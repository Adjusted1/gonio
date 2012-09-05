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
        ///A test for ConfigureMotorController
        ///</summary>
        [TestMethod()]
        public void ConfigureMotorControllerTest()
        {
            //configure factory
            string ipaddress = ConfigurationManager.AppSettings["motor_ipaddress"];
            MotorController.Connect(IPAddress.Parse(ipaddress));
        }
    }
}
