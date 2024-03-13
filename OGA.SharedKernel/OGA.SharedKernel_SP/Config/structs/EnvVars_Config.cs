using System;
using System.Collections.Generic;
using System.Text;

namespace OGA.SharedKernel.Config.structs
{
    /// <summary>
    /// Simple POCO used for loading service configuration.
    /// </summary>
    public class EnvVars_Config
    {
        /// <summary>
        /// Once loaded, this defines the actual environment: dev, prod, val, test, etc...
        /// </summary>
        public string environment { get; set; }
        /// <summary>
        /// Once loaded, this contains the process's runtime key.
        /// </summary>
        public string runtimekey { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public EnvVars_Config()
        {
            environment = "";
            runtimekey = "";
        }
    }
}
