using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer_Controller
{
    static internal class StringExtensions
    {
        public static string Multiply(this string source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier * source.Length);
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(source);
            }

            return sb.ToString();
        }


        public static string Multiply(this char source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier);
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(source);
            }

            return sb.ToString();
        }
    }
}
