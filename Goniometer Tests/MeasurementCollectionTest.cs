using Goniometer_Controller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace Goniometer_Tests
{
    
    
    /// <summary>
    ///This is a test class for MeasurementCollectionTest and is intended
    ///to contain all MeasurementCollectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MeasurementCollectionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FromCSV
        ///</summary>
        [TestMethod()]
        public void FromCSVTest()
        {
            string testfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] testfiles = { "raw.csv" };

            MeasurementCollection actual;
            foreach (string testfile in testfiles)
            {
                using (var sr = new StreamReader(testfolder + "\\" + testfile))
                {
                    actual = MeasurementCollection.FromCSV(sr.ReadToEnd());
                    Assert.IsNotNull(actual);
                }
            }
        }
    }
}
