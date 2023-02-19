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
        public string environment { get; set; }
        public string runtimekey { get; set; }

        public EnvVars_Config()
        {
            environment = "";
            runtimekey = "";
        }
    }
}
