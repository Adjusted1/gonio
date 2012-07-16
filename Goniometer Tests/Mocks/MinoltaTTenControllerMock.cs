using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Goniometer_Controller.Sensors;

namespace Goniometer_Tests.Mocks
{
    public class MinoltaTTenControllerMock : IMinoltaT10Controller
    {
        public double reading
        {
            get { return 20; }
        }

        public string status
        {
            get { return ""; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
