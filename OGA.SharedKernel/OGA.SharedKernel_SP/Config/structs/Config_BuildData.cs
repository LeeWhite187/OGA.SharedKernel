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

        /// <summary>
        /// Name of the configuration file (in the process folder) that holds build info for the process.
        /// </summary>
        static public string CONSTANT_ConfigFile= "appsettings.json";
        /// <summary>
        /// Name of the json property, in the configuration file, that holds the build info properties.
        /// </summary>
        static public string CONSTANT_SectionName = "BuildData";

        /// <summary>
        /// This is set to the type of repository for the source: svn, git, bitbucket, github, etc...
        /// </summary>
        public string RepoType { get; set; }
        /// <summary>
        /// Set to the repository URL of the root source code solution.
        /// </summary>
        public string Source_URL { get; set; }
        /// <summary>
        /// Set to the relative folder path, where the specific project is located.
        /// </summary>
        public string Source_SolutionSubFolder { get; set; }
        /// <summary>
        /// Set to the repository revision the binary was compiled from. For svn, this will be numeric. For git, this will be a hash.
        /// </summary>
        public string Source_Revision { get; set; }

        #endregion


        #region ctor / dtor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Config_BuildData()
        {
            RepoType = "";
            Source_URL = "";
            Source_SolutionSubFolder = "";
            Source_Revision = "";
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Call this method to retrieve a formatted list of application build info that can be dumped to the log.
        /// </summary>
        /// <returns></returns>
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
