using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller.Sensors
{
    public static class MinoltaCL200Provider
    {
        private static string _portname;
        public static void SetPortName(string portname)
        {
            _portname = portname;
        }

        public static MinoltaCL200Controller GetController()
        {
            return new MinoltaCL200Controller(_portname);
        }
    }
}
