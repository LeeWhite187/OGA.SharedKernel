using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace OGA.SharedKernel.Version
{
    /// <summary>
    /// Intended to be a version class suitable for semantic version data.
    /// Adapted from System.Version class.
    /// </summary>
    [Serializable]
#if NET452
    public sealed class cVersion3 : ICloneable, IComparable, IComparable<cVersion3>, IEquatable<cVersion3>
#elif NET47
    public sealed class cVersion3 : ICloneable, IComparable, IComparable<cVersion3>, IEquatable<cVersion3>
#else
    public sealed class cVersion3 : ICloneable, IComparable, IComparable<cVersion3?>, IEquatable<cVersion3?>
#endif
    {
        #region Private Fields

        // AssemblyName depends on the order staying the same
        private readonly int _Major; // Do not rename (binary serialization)
        private readonly int _Minor; // Do not rename (binary serialization)
        private readonly int _Patch; // Do not rename (binary serialization)

        #endregion


        #region Public Fields

        /// <summary>
        /// Major value of the Version3 instance.
        /// This is the X in: X.Y.Z
        /// </summary>
        public int Major => _Major;

        /// <summary>
        /// Minor value of the Version3 instance.
        /// This is the Y in: X.Y.Z
        /// </summary>
        public int Minor => _Minor;

        /// <summary>
        /// Patch value of the Version3 instance.
        /// This is the Z in: X.Y.Z
        /// </summary>
        public int Patch => _Patch;

        #endregion


        #region ctor / dtor

        /// <summary>
        /// Constructor accepting all three props of a Version3.
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="patch"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public cVersion3(int major, int minor, int patch)
        {
            if (major < 0)
                throw new ArgumentOutOfRangeException("Invalid Major.");

            if (minor < 0)
                throw new ArgumentOutOfRangeException("Invalid Minor.");

            if (patch < 0)
                throw new ArgumentOutOfRangeException("Invalid Patch.");

            _Major = major;
            _Minor = minor;
            _Patch = patch;
        }

        /// <summary>
        /// Constructor accepting the most significant two properties of a Version3.
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public cVersion3(int major, int minor)
        {
            if (major < 0)
                throw new ArgumentOutOfRangeException("Invalid Major.");

            if (minor < 0)
                throw new ArgumentOutOfRangeException("Invalid Minor.");

            _Major = major;
            _Minor = minor;
            _Patch = -1;
        }

        /// <summary>
        /// Constructor accepting a Version3 in string format.
        /// NOTE: This constructor ONLY accepts a Version3 string (Major.Minor.Patch)
        /// </summary>
        /// <param name="version"></param>
        public cVersion3(string version)
        {
            cVersion3 v = cVersion3.Parse(version);
            _Major = v.Major;
            _Minor = v.Minor;
            _Patch = v.Patch;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public cVersion3()
        {
            //_Major = 0;
            //_Minor = 0;
            //_Patch = 0;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="version"></param>
        private cVersion3(cVersion3 version)
        {
            Debug.Assert(version != null);

            _Major = version._Major;
            _Minor = version._Minor;
            _Patch = version._Patch;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Standard Clone method for creating a deep copy.
        /// This method is part of the ICloneable interface, so the class can match the NET native Version class function.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new cVersion3(this);
        }

#if NET452
        /// <summary>
        /// Implementation of the IComparable interface.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(object version)
#elif NET47
        /// <summary>
        /// Implementation of the IComparable interface.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(object version)
#else
        /// <summary>
        /// Implementation of the IComparable interface.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(object? version)
#endif
        {
            if (version == null)
            {
                return 1;
            }

            if (version is cVersion3 v)
            {
                return CompareTo(v);
            }

            throw new ArgumentException("Invalid Version Instance.");
        }

#if NET452
        /// <summary>
        /// Implementation of the IComparable interface.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int CompareTo(cVersion3 value)
#elif NET47
        /// <summary>
        /// Implementation of the IComparable interface.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int CompareTo(cVersion3 value)
#else
        /// <summary>
        /// Implementation of the IComparable interface.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int CompareTo(cVersion3? value)
#endif
        {
            if (value == null)
            {
                return 1;
            }

            return
                object.ReferenceEquals(value, this) ? 0 :
                value is null ? 1 :
                _Major != value._Major ? (_Major > value._Major ? 1 : -1) :
                _Minor != value._Minor ? (_Minor > value._Minor ? 1 : -1) :
                _Patch != value._Patch ? (_Patch > value._Patch ? 1 : -1) :
                0;
        }

#if NET452
        /// <summary>
        /// Implementation of the IEquatable interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
#elif NET47
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
            return Equals(obj as cVersion3);
        }

#if NET452
        /// <summary>
        /// Implementation of the IEquatable interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(cVersion3 obj)
#elif NET47
        /// <summary>
        /// Implementation of the IEquatable interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(cVersion3 obj)
#else
        /// <summary>
        /// Implementation of the IEquatable interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals([NotNullWhen(true)] cVersion3? obj)
#endif
        {
            return object.ReferenceEquals(obj, this) ||
                (!(obj is null) &&
                _Major == obj._Major &&
                _Minor == obj._Minor &&
                _Patch == obj._Patch);
        }

        /// <summary>
        /// Implementation of the base object class.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // Let's assume that most version numbers will be pretty small and just
            // OR some lower order bits together.

            int accumulator = 0;

            accumulator |= (_Major & 0x0000000F) << 28;
            accumulator |= (_Minor & 0x000000FF) << 20;
            accumulator |= (_Patch & 0x00000FFF);

            return accumulator;
        }

        /// <summary>
        /// Formats the output as: Mj.Mi.Pa
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            string val = $"{this.Major.ToString()}.{this.Minor.ToString()}.{this.Patch.ToString()}";
            return val;
        }

        /// <summary>
        /// Public method that returns a Version3 instance from a given version3 string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static cVersion3 Parse(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

#if NET452
            return ParseVersion(input, throwOnFailure: true);
#elif NET47
            return ParseVersion(input, throwOnFailure: true);
#else
            return ParseVersion(input, throwOnFailure: true)!;
#endif
        }

#if NET452
        /// <summary>
        /// Public method that attempts to create a Version3 instance from a given version3 string.
        /// Returns true if successful.
        /// False if failed.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse(string input, out cVersion3 result)
#elif NET47
        /// <summary>
        /// Public method that attempts to create a Version3 instance from a given version3 string.
        /// Returns true if successful.
        /// False if failed.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse(string input, out cVersion3 result)
#else
        /// <summary>
        /// Public method that attempts to create a Version3 instance from a given version3 string.
        /// Returns true if successful.
        /// False if failed.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse([NotNullWhen(true)] string? input, [NotNullWhen(true)] out cVersion3? result)
#endif
        {
            if (input == null)
            {
                result = null;
                return false;
            }

            // Trim whitespace and strip off any leading 'v' or 'V'...
            string tempval = input.Replace("v", "").Replace("V", "").Trim();

            return (result = ParseVersion(tempval, throwOnFailure: false)) != null;
        }

#endregion


        #region Operator Overloads

        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        // Force inline as the true/false ternary takes it above ALWAYS_INLINE size even though the asm ends up smaller
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET452
        public static bool operator ==(cVersion3 v1, cVersion3 v2)
#elif NET47
        public static bool operator ==(cVersion3 v1, cVersion3 v2)
#else
        public static bool operator ==(cVersion3? v1, cVersion3? v2)
#endif
        {
            // Test "right" first to allow branch elimination when inlined for null checks (== null)
            // so it can become a simple test
            if (v2 is null)
            {
                // return true/false not the test result https://github.com/dotnet/runtime/issues/4207
                return (v1 is null) ? true : false;
            }

            // Quick reference equality test prior to calling the virtual Equality
            return ReferenceEquals(v2, v1) ? true : v2.Equals(v1);
        }

#if NET452
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(cVersion3 v1, cVersion3 v2) => !(v1 == v2);
#elif NET47
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(cVersion3 v1, cVersion3 v2) => !(v1 == v2);
#else
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(cVersion3? v1, cVersion3? v2) => !(v1 == v2);
#endif


#if NET452
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator <(cVersion3 v1, cVersion3 v2)
#elif NET47
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator <(cVersion3 v1, cVersion3 v2)
#else
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator <(cVersion3? v1, cVersion3? v2)
#endif
        {
            if (v1 is null)
            {
                return !(v2 is null);
            }

            return v1.CompareTo(v2) < 0;
        }

#if NET452
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator <=(cVersion3 v1, cVersion3 v2)
#elif NET47
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator <=(cVersion3 v1, cVersion3 v2)
#else
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator <=(cVersion3? v1, cVersion3? v2)
#endif
        {
            if (v1 is null)
            {
                return true;
            }

            return v1.CompareTo(v2) <= 0;
        }

#if NET452
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator >(cVersion3 v1, cVersion3 v2) => v2 < v1;
#elif NET47
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator >(cVersion3 v1, cVersion3 v2) => v2 < v1;
#else
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator >(cVersion3? v1, cVersion3? v2) => v2 < v1;
#endif

#if NET452
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator >=(cVersion3 v1, cVersion3 v2) => v2 <= v1;
#elif NET47
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator >=(cVersion3 v1, cVersion3 v2) => v2 <= v1;
#else
        /// <summary>
        /// Implements the IEquatable interface, same as the native Version class.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator >=(cVersion3? v1, cVersion3? v2) => v2 <= v1;
#endif

        #endregion


        #region Private Methods

        /// <summary>
        /// Since this is a version3 class, it only works with Semantic versions of the form: Ma.Mi.Pa
        /// </summary>
        /// <param name="input"></param>
        /// <param name="throwOnFailure"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
#if NET452
        private static cVersion3 ParseVersion(string input, bool throwOnFailure)
#elif NET47
        private static cVersion3 ParseVersion(string input, bool throwOnFailure)
#else
        private static cVersion3? ParseVersion(string input, bool throwOnFailure)
#endif
        {
            // Check that the given string is not empty...
            if(string.IsNullOrEmpty(input))
            {
                if (throwOnFailure)
                    throw new ArgumentOutOfRangeException($"Empty string.");

                return null;
            }

            // Split the version string into parts...
#if NET452
            string[] pieces = input.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
#elif NET47
            string[] pieces = input.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
#else
            string[] pieces = input.Split('.', StringSplitOptions.RemoveEmptyEntries);
#endif

            // Check that we have major, minor, and patch...
            if(pieces.Length != 3)
            {
                if (throwOnFailure)
                    throw new ArgumentOutOfRangeException($"Invalid Version3.");

                return null;
            }

            // Attempt to retrieve the major version value...
            // This will throw if told.
            if (!TryParseComponent(pieces[0].Trim(), nameof(Major), throwOnFailure, out int ma))
            {
                return null;
            }

            // Attempt to retrieve the minor version value...
            // This will throw if told.
            if (!TryParseComponent(pieces[1].Trim(), nameof(Minor), throwOnFailure, out int mi))
            {
                return null;
            }

            // Attempt to retrieve the patch version value...
            // This will throw if told.
            if (!TryParseComponent(pieces[2].Trim(), nameof(Patch), throwOnFailure, out int pa))
            {
                return null;
            }

            // If here, we have major, minor, and patch values from the given version.

            // Compose a new instance...
            cVersion3 v3 = new cVersion3(ma, mi, pa);

            return v3;
        }

        private static bool TryParseComponent(string component, string componentName, bool throwOnFailure, out int parsedComponent)
        {
            if (throwOnFailure)
            {
                if ((parsedComponent = int.Parse(component, NumberStyles.Integer, CultureInfo.InvariantCulture)) < 0)
                {
                    throw new ArgumentOutOfRangeException($"Invalid {componentName}.");
                }
                return true;
            }

            return int.TryParse(component, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsedComponent) && parsedComponent >= 0;
        }

        #endregion
    }
}
