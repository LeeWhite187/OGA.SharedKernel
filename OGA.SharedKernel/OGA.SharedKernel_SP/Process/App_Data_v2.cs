using OGA.SharedKernel_SP.Version;
using System;

namespace OGA.SharedKernel.Process
{
    /// <summary>
    /// Static public class used to expose process-wide parameters of the application.
    /// This includes providing global access to Ids, version, runtime encryption key, important folder paths, etc...
    /// NOTE: Most of the properties of this class are set during process startup, allowing this class to remain thin.
    /// This version (v2) utilizes cVersion3 class for better semantic versioning.
    /// </summary>
    static public class App_Data_v2
    {
        #region Public Properties

        /// <summary>
        /// Set to the version3 of the application binary.
        /// NOTE: This class type follows semantic versioning conventions, versus MS versioning.
        /// </summary>
        static public cVersion3 Version3 { get; set; }

        /// <summary>
        /// Holds the build number for the application binary.
        /// </summary>
        static int BuildNumber { get; set; }

        /// <summary>
        /// Set to the Company name of the application, during process startup.
        /// </summary>
        static public string Company_Name { get; set; }
        /// <summary>
        /// Set to the application name, during process startup.
        /// </summary>
        static public string Application_Name { get; set; }
        /// <summary>
        /// Set to the process name, during process startup.
        /// </summary>
        static public string Process_Name { get; set; }
        /// <summary>
        /// Set to the service name, during process startup.
        /// </summary>
        static public string Service_Name { get; set; }

        /// <summary>
        /// Uniquely identifies the application.
        /// Remains a constant everytime the application is installed or runs.
        /// </summary>
        static public System.Guid AppID { get; set; }
        /// <summary>
        /// Uniquely identifies the installed instance of the application.
        /// Is set to a unique value at install, and remains constant.
        /// </summary>
        static public System.Guid InstallID { get; set; }
        /// <summary>
        /// Uniquely identifies the runtime instance of the application.
        /// Is generated each time the process starts.
        /// Changes on restart.
        /// </summary>
        static public System.Guid RuntimeID { get; set; }

        /// <summary>
        /// Hold command line arguments in case they are needed during process execution.
        /// </summary>
        static public string[] Arguments { get; set; }

        /// <summary>
        /// Set to the filesystem path of the process executable.
        /// </summary>
        static public string Executable_Folder { get; set; }
        /// <summary>
        /// Represents the path where application config and data are stored in the filesystem.
        /// </summary>
        static public string Config_Folder { get; set; }

        /// <summary>
        /// The process has been configured with a specific service or station purpose.
        /// FALSE = Process is not characterized for a specific service or station.
        /// TRUE = Process has been assigned a specific service or station role.
        /// </summary>
        static public bool Is_ServiceSpecificProcess { get; set; }

        /// <summary>
        /// Runtime Encryption key.
        /// Loaded during application startup.
        /// Is used for decrypting secrets from local configuration.
        /// </summary>
        static public string Runtime_Enc_Key { get; set; }

        #endregion


        #region ctor / dtor

        static App_Data_v2()
        {
            Version3 = new cVersion3();

            BuildNumber = 0;

            Company_Name = cGlobal_Constants.CompanyName;
            Application_Name = cGlobal_Constants.Unnamed;
            Process_Name = cGlobal_Constants.Unnamed;
            Service_Name = cGlobal_Constants.Unnamed;

            AppID = new Guid();
            RuntimeID = new Guid();
            InstallID = new Guid();

            Arguments = new string[] { };

            Executable_Folder = "";
            Config_Folder = "";

            Is_ServiceSpecificProcess = false;

            Runtime_Enc_Key = "";
        }

        #endregion


        #region Public Methods

        static public string Arguments_to_LogString()
        {
            System.Text.StringBuilder b = new System.Text.StringBuilder();

            if (Arguments == null)
            {
                return "No arguments.";
            }
            else if (Arguments.Length == 0)
            {
                return "No arguments.";
            }
            // There is at least one argument.

            b.Append("Argument count=" + Arguments.Length.ToString() + "\r\n");

            // Iterate the arguments and build a list for the log.
            for (int index = 0; index < Arguments.Length; index++)
            {
                b.Append("Argument_" + index.ToString() + "=" + (Arguments[index] ?? "") + "\r\n");
            }

            return b.ToString();
        }

        #endregion
    }
}
