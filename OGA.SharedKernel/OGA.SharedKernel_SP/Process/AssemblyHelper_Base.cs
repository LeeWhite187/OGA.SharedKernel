using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace OGA.SharedKernel_SP.Process
{
    /// <summary>
    /// This class provides a central point for accessing process binary library metadata.
    /// The ability to access assembly metadata is needed during early process startup, before any DI container/registry is accessible.
    /// Since it is accessible outside of DI, we have a static property reference to the live implementation, for any libraries to consume as needed.
    /// NOTE: This base class includes an interface implementation, but the implementation (in this base) exists only to satisfy a compiler warning and to prevent property null.
    /// NOTE: Be sure to set the static property reference to the class implementation, during early process startup.
    /// </summary>
    public class AssemblyHelper_Base : IAssemblyHelper
    {
        #region Public Properties

        /// <summary>
        /// Global Assembly Helper Reference.
        /// Is set during process startup, to provide a global reference that exists outside of the DI registry.
        /// </summary>
        static public IAssemblyHelper AssemblyHelperRef { get; protected set; } = new AssemblyHelper_Base();

        #endregion


        #region Public Methods

        /// <summary>
        /// Call this method during early process startup to set the Assembly Helper instance, so it can be used outside of DI.
        /// </summary>
        /// <param name="instance"></param>
        /// <exception cref="ArgumentNullException"></exception>
        static public void SetRef(IAssemblyHelper instance)
        {
            if (instance == null)
                throw new ArgumentNullException("Assembly Helper Instance Is Null.");

            AssemblyHelperRef = instance;
        }

        #endregion


        #region Default Method Calls

        /// <summary>
        /// Returns a list of assembly names that are referenced by the process binary.
        /// NOTE: All methods in this base class return exceptions, to ensure the developer gets an early indication that static property reference is not populated with an implementation.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        virtual public List<string> Get_AssembliesList()
        {
            OGA.SharedKernel.Logging_Base.Logger_Ref?.Error("AssemblyHelper_Base.Get_AssembliesList Missing Implementation. Needs delegate handler applied at startup.");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a loggable list of assemblies referenced by the process binary.
        /// NOTE: All methods in this base class return exceptions, to ensure the developer gets an early indication that static property reference is not populated with an implementation.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        virtual public string Push_AssembliesList_to_LogString()
        {
            OGA.SharedKernel.Logging_Base.Logger_Ref?.Error("AssemblyHelper_Base.Push_AssembliesList_to_LogString Missing Implementation. Needs delegate handler applied at startup.");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Iterates a given list of types, for a particular class name.
        /// NOTE: All methods in this base class return exceptions, to ensure the developer gets an early indication that static property reference is not populated with an implementation.
        /// </summary>
        /// <param name="searchname"></param>
        /// <param name="derivedclasses"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        virtual public int Get_Classes_with_Attribute(string searchname, out List<Type> derivedclasses)
        {
            OGA.SharedKernel.Logging_Base.Logger_Ref?.Error("AssemblyHelper_Base.Get_Classes_with_Attribute Missing Implementation. Needs delegate handler applied at startup.");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a list of assembly name instances for the main assembly and all references.
        /// This method added to prevent issues of the entryassembly being null when running in Unit Testing.
        /// NOTE: All methods in this base class return exceptions, to ensure the developer gets an early indication that static property reference is not populated with an implementation.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        virtual public List<AssemblyName> Get_All_AssemblyNames()
        {
            OGA.SharedKernel.Logging_Base.Logger_Ref?.Error("AssemblyHelper_Base.Get_All_AssemblyNames Missing Implementation. Needs delegate handler applied at startup.");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a list of all assemblies of the main assembly and references.
        /// NOTE: All methods in this base class return exceptions, to ensure the developer gets an early indication that static property reference is not populated with an implementation.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        virtual public List<Assembly> Get_All_Assemblies()
        {
            OGA.SharedKernel.Logging_Base.Logger_Ref?.Error("AssemblyHelper_Base.Get_All_Assemblies Missing Implementation. Needs delegate handler applied at startup.");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the subset of class types that derive from the given base.
        /// NOTE: All methods in this base class return exceptions, to ensure the developer gets an early indication that static property reference is not populated with an implementation.
        /// </summary>
        /// <param name="basetype"></param>
        /// <param name="derivedclasses"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        virtual public int Get_DerivedClasses_from_Base(Type basetype, out List<Type> derivedclasses)
        {
            OGA.SharedKernel.Logging_Base.Logger_Ref?.Error("AssemblyHelper_Base.Get_DerivedClasses_from_Base Missing Implementation. Needs delegate handler applied at startup.");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Attempts to determine which of the given types is not a base of the others.
        /// NOTE: All methods in this base class return exceptions, to ensure the developer gets an early indication that static property reference is not populated with an implementation.
        /// </summary>
        /// <param name="classlisting"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        virtual public List<Type> Get_TopLevelTypes(List<Type> classlisting)
        {
            OGA.SharedKernel.Logging_Base.Logger_Ref?.Error("AssemblyHelper_Base.Get_TopLevelTypes Missing Implementation. Needs delegate handler applied at startup.");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determine if the given search type is a base of any type in the given class list.
        /// NOTE: All methods in this base class return exceptions, to ensure the developer gets an early indication that static property reference is not populated with an implementation.
        /// </summary>
        /// <param name="searchtype"></param>
        /// <param name="classlist"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        virtual public bool Is_BaseClass_of_Others(Type searchtype, List<Type> classlist)
        {
            OGA.SharedKernel.Logging_Base.Logger_Ref?.Error("AssemblyHelper_Base.Is_BaseClass_of_Others Missing Implementation. Needs delegate handler applied at startup.");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines if the given search type is a derived class of any type in the given class list.
        /// NOTE: All methods in this base class return exceptions, to ensure the developer gets an early indication that static property reference is not populated with an implementation.
        /// </summary>
        /// <param name="searchtype"></param>
        /// <param name="classlist"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        virtual public bool Is_Class_Derived_from_Others(Type searchtype, List<Type> classlist)
        {
            OGA.SharedKernel.Logging_Base.Logger_Ref?.Error("ProcessData.Is_Class_Derived_from_Others Missing Implementation. Needs delegate handler applied at startup.");
            throw new NotImplementedException();
        }

        #endregion
    }
}
