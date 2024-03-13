using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel.Config.structs
{
    /// <summary>
    /// This class is used to retrieve config and log paths from exe config files.
    /// </summary>
    [Obsolete("This class has been superceded by, Config_AppPaths_v2, which adds additional properties. This version remains in place, for legacy support.", false)]
    public class Config_AppPaths
    {
        #region Public Properties

        /// <summary>
        /// Name of the configuration file (in the process folder) that holds path config for the process.
        /// </summary>
        static public string CONSTANT_ConfigFile = "appsettings.json";
        /// <summary>
        /// Name of the json property, in the configuration file, that holds the path fields.
        /// </summary>
        static public string CONSTANT_SectionName = "Paths";

        /// <summary>
        /// Set, during process startup, to the path of the application config storage.
        /// </summary>
        public string AppConfigPath { get; set; }

        /// <summary>
        /// Set, during process startup, to the path of the log folder.
        /// </summary>
        public string LogPath { get; set; }

        #endregion


        #region ctor / dtor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Config_AppPaths()
        {
            AppConfigPath = "";
            LogPath = "";
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Call this method to retrieve a formatted list of application path data that can be dumped to the log.
        /// </summary>
        /// <returns></returns>
        public string ToLogString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("AppConfigPath=" + (AppConfigPath ?? "") + ";\r\n");
            b.Append("LogPath=" + (LogPath ?? "") + ";\r\n");

            return b.ToString();
        }

        #endregion
    }
}
