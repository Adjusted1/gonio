using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goniometer.Reports
{
    //ANSI LM-63-2002

    class iesna
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
        #endregion

        public Dictionary<string, string> comments;

        #region testdata

        #endregion

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

            return report;
        }
    }
}
