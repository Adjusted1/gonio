using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Goniometer.Functions;
using Goniometer_Controller;
using Goniometer_Controller.Models;
using Goniometer_Controller.Functions;

namespace Goniometer.Reports
{
    /// <summary>
    /// ANSI LM-63-2002
    /// </summary>
    public class iesna
    {
        #region required keywords
        public string test;
        public string testlab;
        public DateTime issueDate;
        public string manufacture;
        #endregion

        #region optional keywords
        public string lumcat;       //luminaire catalog number
        public string luminaire;    //luminaire description
        public string lampcat;      //lamp catalog number
        public string lamp;         //lamp description (i.e., type, wattage, size, etc.)

        public string ballastcat;
        public string ballast;

        public string maintcat;
        public string other;
        public string more;
        
        public string lampPosition;
        public string search;

        public Dictionary<string, string> comments;
        #endregion

        private MeasurementCollection _data;

        public iesna(MeasurementCollection data)
        {
            _data = data;
        }

        /// <summary>
        /// write report to file according to ansi standards
        /// </summary>
        /// <param sensorname="report"></param>
        /// <param sensorname="filefolder"></param>
        /// <returns>fullpath to created file</returns>
        public static string WriteToFile(iesna report, string fileFolder)
        {
            string fileName = fileFolder + String.Format("//iesna_{0:yyyyMMddHHmmss}.ies", DateTime.Now);

            using (var fs = new FileStream(fileName, FileMode.CreateNew))   //never overwrite a previous file
            using (var sw = new StreamWriter(fs, Encoding.ASCII))           //standard requires ansii
            {
                //TODO implement max column lengths of 256 char including /n

                sw.Write(report.ToString());
                sw.Flush();
            }

            return fileName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("IESNA:LM-63-2002");
            sb.AppendLine("[TEST]"          + test                                );
            sb.AppendLine("[TESTLAB]"       + testlab                             );
            sb.AppendLine("[ISSUEDATE]"     + issueDate.ToString("dd-MMM-YYYY")   );
            sb.AppendLine("[MANUFAC]"       + manufacture                         );
            sb.AppendLine("[LUMCAT]"        + lumcat                              );
            sb.AppendLine("[LUMINAIRE]"     + luminaire                           );
            sb.AppendLine("[LAMPCAT]"       + lampcat                             );
            sb.AppendLine("[LAMP]"          + lamp                                );
            sb.AppendLine("[BALLASTCAT]"    + ballastcat                          );
            sb.AppendLine("[BALLAST]"       + ballast                             );
            sb.AppendLine("[MAINTCAT]"      + maintcat                            );
            sb.AppendLine("[OTHER]"         + other                               );
            sb.AppendLine("[MORE]"          + more                                );
            sb.AppendLine("[LAMPPOSITION]"  + lampPosition                        );
            sb.AppendLine("[SEARCH]"        + search                              );

            if (comments != null && comments.Count > 0)
                foreach (var key in comments.Keys)
                    sb.AppendLine(String.Format("[_{0}] {1}", key.ToUpper(), comments[key]));

            sb.AppendLine("TILT=NONE");
            sb.AppendLine("1");

            //fetch all candle readings
            string mKey = MeasurementKeys.LuminousIntensity;
            var candles = _data.FindAll(mKey)
                               .Select(m => Tuple.Create(m.Theta, m.Phi, m.Value))
                               .ToList();

            //lumen reading
            double lumen =  LightMath.CalculateLumens(candles);
            sb.AppendLine(String.Format("{0:0.##}",lumen));

            //horizontal values
            double[] hRange = _data.GetPhiRange();
            sb.AppendLine(String.Join(" ", hRange));

            //vertical values
            double[] vRange = _data.GetThetaRange();
            sb.AppendLine(String.Join(" ", vRange));

            //raw values
            for (int v = 0; v < vRange.Length; v++)
            {
                string[] values = _data.FindAll(mKey, vRange[v]).Select(m => m.Value.ToString("0.##")).ToArray();
                sb.AppendLine(String.Join(" ", values));
            }

            return sb.ToString();
        }
    }
}
