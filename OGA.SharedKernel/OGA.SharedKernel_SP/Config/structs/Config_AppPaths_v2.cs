using System;
using System.Collections.Generic;
using System.Text;

namespace OGA.SharedKernel.Config.structs
{
    /// <summary>
    /// This class is used to retrieve config and log paths from exe config files.
    /// </summary>
    public class Config_AppPaths_v2
    {
        #region Public Properties

        static public string CONSTANT_ConfigFile = "appsettings.json";
        static public string CONSTANT_SectionName = "Paths";

        /// <summary>
        /// Set, during process startup, to the path of common config storage.
        /// </summary>
        public string CommonConfigPath { get; set; }

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

        public Config_AppPaths_v2()
        {
            CommonConfigPath = "";
            AppConfigPath = "";
            LogPath = "";
        }

        #endregion


        #region Public Methods

        public string ToLogString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("CommonConfigPath=" + (CommonConfigPath ?? "") + ";\r\n");
            b.Append("AppConfigPath=" + (AppConfigPath ?? "") + ";\r\n");
            b.Append("LogPath=" + (LogPath ?? "") + ";\r\n");

            return b.ToString();
        }

        #endregion
    }
}
