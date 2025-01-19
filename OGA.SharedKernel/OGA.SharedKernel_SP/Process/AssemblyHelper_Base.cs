using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace OGA.SharedKernel.Process
{
    /// <summary>
    /// This class provides a central point for accessing process binary library metadata.
    /// The ability to access assembly metadata is needed during early process startup, before any DI container/registry is accessible.
    /// Since it is accessible outside of DI, we have a static property reference to the live implementation, for any libraries to consume as needed.
    /// NOTE: This base class includes an interface implementation, but the implementation (in this base) exists only to satisfy a compiler warning and to prevent property null.
    /// NOTE: Be sure to set the static property reference to the class implementation, during early process startup.
    /// See the Wiki for details: https://wiki.galaxydump.com/link/57
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

    #region Helper Clasess

    /// <summary>
    /// Used when reconciling process assemblies for duplicates with dissenting data (version, key, culture).
    /// Represents an assembly that is referenced twice within the process assembly graph.
    /// </summary>
    public class AssemblyDuplicationError
    {
        /// <summary>
        /// Holds the simple assembly name, without the version, culture, or PublicKeyToken.
        /// </summary>
        public string AssyName { get; set; }

        /// <summary>
        /// List of parent assemblies that reference it.
        /// </summary>
        public List<string> ReferencedBy { get; private set; }

        /// <summary>
        /// List of duplicate instances, with their distinct metadata.
        /// </summary>
        public List<AssemblyData> Instances { get; private set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        public AssemblyDuplicationError()
        {
            ReferencedBy = new List<string>();
            Instances = new List<AssemblyData>();
        }

        /// <summary>
        /// Used when we need to output a duplicate assembly error to the log.
        /// </summary>
        /// <returns></returns>
        public string ToLogString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AssemblyName = " + this.AssyName ?? "");

            // Output the referencing assembly list...
            int rc = this.ReferencedBy?.Count ?? 0;
            if (rc == 0)
            {
                sb.AppendLine($"No Referenced Assemblies to list.");
            }
            else
            {
                sb.AppendLine($"Referenced by ({rc}) Assemblies:");
                foreach(var r in this.ReferencedBy)
                    sb.AppendLine("\t" + r ?? "");
            }

            // Output instances...
            int ic = this.Instances?.Count ?? 0;
            if(ic == 0)
            {
                sb.AppendLine($"No Instances to list.");
            }
            else
            {
                sb.AppendLine($"({rc}) Instances to list:");
                foreach(var i in this.Instances)
                    sb.AppendLine("\t" + i?.FullName ?? "");
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// Not to be confused with AssemblyInfo.
    /// Holds name, version, culture, and key of an assembly.
    /// Used to identify duplicate assemblies under a running process.
    /// </summary>
    public class AssemblyData
    {
        #region Public Properties

        /// <summary>
        /// Name of the parent assembly that references this one.
        /// This must be set after construction, by the calling logic.
        /// </summary>
        public string ParentAssemblyName { get; set; }

        /// <summary>
        /// Filepath where the assembly is located.
        /// This can only be set from an Assembly, as it's not directly available from an AssemblyName instance.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// The fully qualifying name of the assembly.
        /// Of the form: name, version, culture, publickeytoken
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// The simple name of the assembly.
        /// Ex: OGA.Plugins.Lib
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// String version of the assembly.
        /// Usually a 4-term version, taken from the assembly.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Culture identifier of the assembly.
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// If set, will be the public Key Token of the assembly.
        /// Blank if not set.
        /// </summary>
        public string PublicKeyToken { get; set; }

        #endregion


        #region ctor / dtor

        /// <summary>
        /// Copy constructor, for creating deep copies.
        /// </summary>
        /// <param name="ad"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AssemblyData(AssemblyData ad)
        {
            if (ad == null)
                throw new ArgumentNullException();

            this.ParentAssemblyName = "";
            this.FilePath = ad.FilePath;
            this.FullName = ad.FullName;
            this.Name = ad.Name;
            this.Version = ad.Version;
            this.Culture = ad.Culture;
            this.PublicKeyToken = ad.PublicKeyToken;
        }
        /// <summary>
        /// Constructor from an assembly.
        /// </summary>
        /// <param name="assy"></param>
        public AssemblyData(Assembly assy)
        {
            RecoverAssemblyInfo(assy);
        }
        /// <summary>
        /// Constructor from an assemblyName.
        /// </summary>
        /// <param name="an"></param>
        public AssemblyData(AssemblyName an)
        {
            RecoverAssemblyInfo(an);
        }

        #endregion


        #region Static Methods

        static public AssemblyData FromAssembly(Assembly assy)
        {
            return new AssemblyData(assy);
        }
        static public AssemblyData FromAssemblyName(AssemblyName an)
        {
            return new AssemblyData(an);

        }

        static public int CompareAssemblies(Assembly a1, Assembly a2)
        {
            try
            {
                var a = FromAssembly(a1);
                var b = FromAssembly(a2);

                if(a == b) return 1;
                else return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        static public int CompareAssemblies(Assembly a1, AssemblyName a2)
        {
            try
            {
                var a = FromAssembly(a1);
                var b = FromAssemblyName(a2);

                if(a == b) return 1;
                else return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        static public int CompareAssemblies(AssemblyName a1, Assembly a2)
        {
            try
            {
                var a = FromAssemblyName(a1);
                var b = FromAssembly(a2);

                if(a == b) return 1;
                else return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        static public int CompareAssemblies(AssemblyName a1, AssemblyName a2)
        {
            try
            {
                var a = FromAssemblyName(a1);
                var b = FromAssemblyName(a2);

                if(a == b) return 1;
                else return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        #endregion


        #region Equality Overloads

        /// <summary>
        /// Implements the IEquatable interface.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        // Force inline as the true/false ternary takes it above ALWAYS_INLINE size even though the asm ends up smaller
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if (NET452 || NET47 || NET48)
        public static bool operator ==(AssemblyData obj1, AssemblyData obj2)
#else
        public static bool operator ==(AssemblyData? obj1, AssemblyData? obj2)
#endif
        {
            // Test "right" first to allow branch elimination when inlined for null checks (== null)
            // so it can become a simple test
            if (obj2 is null)
            {
                // return true/false not the test result https://github.com/dotnet/runtime/issues/4207
                return (obj1 is null) ? true : false;
            }

            // Quick reference equality test prior to calling the virtual Equality
            return ReferenceEquals(obj2, obj1) ? true : obj2.Equals(obj1);
        }

#if (NET452 || NET47 || NET48)
        /// <summary>
        /// Implements the IEquatable interface.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator !=(AssemblyData obj1, AssemblyData obj2) => !(obj1 == obj2);
#else
        /// <summary>
        /// Implements the IEquatable interface.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator !=(AssemblyData? obj1, AssemblyData? obj2) => !(obj1 == obj2);
#endif

#if (NET452 || NET47 || NET48)
        /// <summary>
        /// Implementation of the IEquatable interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
#else
        /// <summary>
        /// Implementation of the IEquatable interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
#endif
        {
            return Equals(obj as AssemblyData);
        }


#if (NET452 || NET47 || NET48)
        /// <summary>
        /// Implementation of the IEquatable interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(AssemblyData obj)
#else
        /// <summary>
        /// Implementation of the IEquatable interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals([NotNullWhen(true)] AssemblyData? obj)
#endif
        {
            return object.ReferenceEquals(obj, this) ||
                (!(obj is null) &&
                Name == obj.Name &&
                Version == obj.Version &&
                Culture == obj.Culture &&
                PublicKeyToken == obj.PublicKeyToken);
        }

        /// <summary>
        /// Public override of GetHashCode to satisfy compiler warning for overriding Equality.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
#if (NET452 || NET47 || NET48)
            int hash = 11;
            hash = hash * 18 + this.ParentAssemblyName.GetHashCode();
            hash = hash * 18 + this.FilePath.GetHashCode();
            hash = hash * 18 + this.FullName.GetHashCode();
            hash = hash * 18 + this.Name.GetHashCode();
            hash = hash * 18 + this.Version.GetHashCode();
            hash = hash * 18 + this.Culture.GetHashCode();
            hash = hash * 18 + this.PublicKeyToken.GetHashCode();
            return hash;
#else
            return HashCode.Combine(this.ParentAssemblyName, this.FilePath, this.FullName, this.Name, this.Version, this.Culture, this.PublicKeyToken);
#endif
        }
        
        #endregion


        #region Public Overrides

        /// <summary>
        /// Override the public ToString, to display info of the entry.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var an = FullName ?? "";
            return an;
        }

        #endregion


        #region Private Methods

        private void RecoverAssemblyInfo (Assembly assy)
        {
            if (assy == null)
                throw new ArgumentNullException();

            // Since given an assembly, we will fetch it's filepath...
            try
            {
                this.FilePath = assy.Location ?? "";
            }
            catch(Exception)
            {
                this.FilePath = "";
            }

            var an = assy.GetName();
            if (an == null)
                throw new ArgumentNullException();

            RecoverAssemblyInfo(an);
        }
        private void RecoverAssemblyInfo (AssemblyName an)
        {
            if (an == null)
                throw new ArgumentNullException();

            this.ParentAssemblyName = "";

            this.Name = an.Name ?? "";
            this.FullName = an.FullName ?? "";
            this.Culture = an.CultureName ?? "";
            try
            {
                this.Version = an.Version?.ToString(4)?.ToLower() ?? "";
            }
            catch(Exception)
            {
                this.Version = "";
            }
            var pkt = an.GetPublicKeyToken();
            try
            {
                if (pkt == null)
                    this.PublicKeyToken = "";
                else
                    this.PublicKeyToken = System.Text.Encoding.UTF8.GetString(pkt) ?? "";

            }
            catch(Exception)
            {
                this.PublicKeyToken = "";
            }
        }

        #endregion
    }

    /// <summary>
    /// Used when traversing assemblies, looking for duplicates and references.
    /// </summary>
    internal class AssemblyTrackingEntry
    {
        public bool Traversed { get; set; }
        public Assembly Assy { get; set; }
        public AssemblyData MetaData { get; set; }

        public AssemblyTrackingEntry(Assembly assy)
        {
            if(assy == null) throw new ArgumentNullException();
            this.Assy = assy;
            this.Traversed = false;

            this.MetaData = AssemblyData.FromAssembly(assy);
        }

        /// <summary>
        /// Override the public ToString, to display info of the entry.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var an = Assy?.FullName ?? "";
            return an;
        }
    }

    #endregion
}
