using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Goniometer
{
    public static class Controlxtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            control.Invoke((Delegate)action);
        }
    }
}
