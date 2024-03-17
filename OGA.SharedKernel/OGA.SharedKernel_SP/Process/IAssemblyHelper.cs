using System;
using System.Collections.Generic;
using System.Reflection;

namespace OGA.SharedKernel.Process
{
    /// <summary>
    /// Assembly Helper class interface that exposes method calls used for searching process dependencies for controllers, map configs, exception types, config derivatives, etc.
    /// </summary>
    public interface IAssemblyHelper
    {
        /// <summary>
        /// Returns a list of assembly names that are referenced by the process binary.
        /// </summary>
        /// <returns></returns>
        List<string> Get_AssembliesList();

        /// <summary>
        /// Creates a loggable list of assemblies referenced by the process binary.
        /// </summary>
        /// <returns></returns>
        string Push_AssembliesList_to_LogString();

        /// <summary>
        /// Iterates a given list of types, for a particular class name.
        /// </summary>
        /// <param name="searchname"></param>
        /// <param name="derivedclasses"></param>
        /// <returns></returns>
        int Get_Classes_with_Attribute(string searchname, out List<Type> derivedclasses);

        /// <summary>
        /// Get a list of assembly name instances for the main assembly and all references.
        /// This method added to prevent issues of the entryassembly being null when running in Unit Testing.
        /// </summary>
        /// <returns></returns>
        List<AssemblyName> Get_All_AssemblyNames();

        /// <summary>
        /// Get a list of all assemblies of the main assembly and references.
        /// </summary>
        /// <returns></returns>
        List<Assembly> Get_All_Assemblies();

        /// <summary>
        /// Returns the subset of class types that derive from the given base.
        /// </summary>
        /// <param name="basetype"></param>
        /// <param name="derivedclasses"></param>
        /// <returns></returns>
        int Get_DerivedClasses_from_Base(Type basetype, out List<Type> derivedclasses);

        /// <summary>
        /// Attempts to determine which of the given types is not a base of the others.
        /// </summary>
        /// <param name="classlisting"></param>
        /// <returns></returns>
        List<Type> Get_TopLevelTypes(List<Type> classlisting);

        /// <summary>
        /// Determine if the given search type is a base of any type in the given class list.
        /// </summary>
        /// <param name="searchtype"></param>
        /// <param name="classlist"></param>
        /// <returns></returns>
        bool Is_BaseClass_of_Others(Type searchtype, List<Type> classlist);

        /// <summary>
        /// Determines if the given search type is a derived class of any type in the given class list.
        /// </summary>
        /// <param name="searchtype"></param>
        /// <param name="classlist"></param>
        /// <returns></returns>
        bool Is_Class_Derived_from_Others(Type searchtype, List<Type> classlist);
    }
}