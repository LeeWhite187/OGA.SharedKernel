using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel
{
    /// <summary>
    /// Contains global strings for different uses.
    /// </summary>
    static public class cGlobal_Constants
    {
        /// <summary>
        /// Default sentinel value for unpopulated fields.
        /// </summary>
        static public string Sentinel_Value = "sdfsdfsdfsdfsdsdfsdf";
        /// <summary>
        /// Standard data ToString format to generate sortable dates.
        /// </summary>
        static public string Sortable_DateFormat = "yyyyMMdd-HHmmss";

        /// <summary>
        /// Holds the Company name that authors the running process.
        /// Make sure your Program.Main populates this field during early startup.
        /// </summary>
        static public string CompanyName = "Blank-Company";
        /// <summary>
        /// Used by some library classes for marking string properties as unset.
        /// </summary>
        static public string Unnamed = "Not Named";

        /// <summary>
        /// Standardized date ToString format for datetimes that are passed to SQL Server via DAL.
        /// This string format provides enough precision for a MSSQL Server datetime column, as it is precise to 1/30th of a second.
        /// </summary>
        static public string DateTime_Format_for_SQL = "yyyy-MM-dd HH:mm:ss.fff";

        /// <summary>
        /// Used by Runtime diagnostic calls that format date fields.
        /// </summary>
        static public string RunInfo_DateFormat = "yyyy MM dd";
    }
}
