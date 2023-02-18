using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel.Config.structs
{
    /// <summary>
    /// This class is used to retrieve build data from exe config files.
    /// </summary>
    public class Config_BuildData
    {
        #region Public Properties

        static public string CONSTANT_ConfigFile= "appsettings.json";
        static public string CONSTANT_SectionName = "BuildData";

        public string RepoType { get; set; }
        public string Source_URL { get; set; }
        public string Source_SolutionSubFolder { get; set; }
        public string Source_Revision { get; set; }

        #endregion


        #region ctor / dtor

        public Config_BuildData()
        {
            RepoType = "";
            Source_URL = "";
            Source_SolutionSubFolder = "";
            Source_Revision = "";
        }

        #endregion


        #region Public Methods

        public string ToLogString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("RepoType=" + (RepoType ?? "") + ";\r\n");
            b.Append("Source_URL=" + (Source_URL ?? "") + ";\r\n");
            b.Append("Source_SolutionSubFolder=" + (Source_SolutionSubFolder ?? "") + ";\r\n");
            b.Append("Source_Revision=" + (Source_Revision?.ToString() ?? "") + ".");

            return b.ToString();
        }

        #endregion
    }
}
