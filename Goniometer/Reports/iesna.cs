using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Goniometer.Functions;
using System.IO;

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

        //horizontal, vertical, reading
        public List<Tuple<double, double, double>> data;
        public double lumens;

        /// <summary>
        /// write report to file according to ansi standards
        /// </summary>
        /// <param name="report"></param>
        /// <param name="filefolder"></param>
        /// <returns>fullpath to created file</returns>
        public static string WriteToFile(iesna report, string fileFolder)
        {
            string fileName = fileFolder + String.Format("//iesna_{0}.ies", DateTime.Now);

            using (var fs = new FileStream(fileName, FileMode.CreateNew))   //never overwrite a previous file
            using (var sw = new StreamWriter(fs, Encoding.ASCII))           //standard requires ansii
            {
                //TODO implement max column lengths of 256 char including /n

                sw.Write(report.ToString());
            }

            return fileName
        }

        public override string ToString()
        {
            string report = "";

            report += "IESNA:LM-63-2002\n";
            report += "[TEST]"          + test                                 + "\n";
            report += "[TESTLAB]"       + testlab                              + "\n";
            report += "[ISSUEDATE]"     + issueDate.ToString("dd-MMM-YYYY")    + "\n";
            report += "[MANUFAC]"       + manufacture                          + "\n";
            report += "[LUMCAT]"        + lumcat                               + "\n";
            report += "[LUMINAIRE]"     + luminaire                            + "\n";
            report += "[LAMPCAT]"       + lampcat                              + "\n";
            report += "[LAMP]"          + lamp                                 + "\n";
            report += "[BALLASTCAT]"    + ballastcat                           + "\n";
            report += "[BALLAST]"       + ballast                              + "\n";
            report += "[MAINTCAT]"      + maintcat                             + "\n";
            report += "[OTHER]"         + other                                + "\n";
            report += "[MORE]"          + more                                 + "\n";
            report += "[LAMPPOSITION]"  + lampPosition                         + "\n";
            report += "[SEARCH]"        + search                               + "\n";

            foreach (var key in comments.Keys)
            {
                report += String.Format("[_{0}] {1}", key.ToUpper(), comments[key]);
            }

            report += "TILT=NONE\n";
            report += "1";

            return report;
        }
    }
}
