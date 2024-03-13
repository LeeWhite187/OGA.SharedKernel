using System;
using System.Collections.Generic;
using System.Text;

namespace OGA.SharedKernel.Serialization
{
    /// <summary>
    /// Provides a standardized means of generating class type names, in human-readable format.
    /// This was created because any reflection query of a generic type yields an implicit type format, that does not directly match the type string in source.
    /// This class unwinds generic types to create a type string that matches the type string of the type in source.
    /// This class works for all known primitive, generic, and concrete types.
    /// </summary>
    public class Serialization_Helper
    {
        /// <summary>
        /// Call this method to get a string name type of the given object.
        /// Set usefullnames to include the assembly with each classname.
        /// Return type is of the form:
        /// "string"
        /// NOTE: The following two examples include escaped greater-than and less-than symbols, since this comment block is formatted XML.
        /// "List&lt;string&gt;"
        /// "DistributionWrapper&lt;SendCommand&gt;"
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="usefullnames"></param>
        /// <returns></returns>
        static public string GetType_forSerialization(object obj, bool usefullnames = false)
        {
            return GetType_forSerialization(obj.GetType(), usefullnames);
        }

        /// <summary>
        /// Call this method to get a string name type of the given type.
        /// Set usefullnames to include the assembly with each classname.
        /// Return type is of the form:
        /// "string"
        /// NOTE: The following two examples include escaped greater-than and less-than symbols, since this comment block is formatted XML.
        /// "List&lt;string&gt;"
        /// "DistributionWrapper&lt;SendCommand&gt;"
        /// </summary>
        /// <param name="type"></param>
        /// <param name="usefullnames"></param>
        /// <returns></returns>
        static public string GetType_forSerialization(Type type, bool usefullnames = false)
        {
            StringBuilder retType = new StringBuilder();

            if (type.IsGenericType)
            {
                string[] parentType = new string[]{ };
                if (usefullnames)
                    parentType = type.FullName != null ? type.FullName.Split('`') : type.Name.Split('`');
                else
                    parentType = type.Name.Split('`');

                // We will build the type here.
                Type[] arguments = type.GetGenericArguments();

                StringBuilder argList = new StringBuilder();
                
                foreach (Type t in arguments)
                {
                    // Let's make sure we get the argument list.
                    string arg = GetType_forSerialization(t, usefullnames);
                    if (argList.Length > 0)
                    {
                        argList.AppendFormat(", {0}", arg);
                    }
                    else
                    {
                        argList.Append(arg);
                    }
                }

                if (argList.Length > 0)
                {
                    retType.AppendFormat("{0}<{1}>", parentType[0], argList.ToString());
                }
            }
            else
            {
                return (usefullnames ? type.ToString() : type.Name);
            }

            return retType.ToString();
        }
    }
}
