using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Goniometer
{
    internal static class Controlxtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            control.Invoke((Delegate)action);
        }
    }

    internal static class TimeSpanExtensions
    {
        public static TimeSpan? Sum(this IEnumerable<TimeSpan> spans)
        {
            TimeSpan? total = null;
            foreach (var span in spans)
            {
                if (total == null)
                    total = new TimeSpan();

                total += span;
            }

            return total;
        }
    }
}
