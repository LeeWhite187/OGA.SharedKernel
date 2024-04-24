using System;
using System.Diagnostics;

namespace OGA.SharedKernel.Process
}
{
    /* Stack Trace Class
     * This class provides a stack trace that maximizes traceability to a source file.
     * For runtimes that don't have PDB files with them, stack frames are decorated with a module token and IL offset.
     * For runtimes that do have PDB files with them, stack frames are decorated with filename and line numbers.
     * 
     * It supports any mix of assemblies with or without PDB files.
     * For assemblies that include a PDB, this will decoreate stack frames with line numbers that annotate the source.
     * For assemblies that don't have PDB files beside them, this will decorate stack frames with assembly, version, module, module token, and IL offset.
     * 
     * In the latter case, the generated stack frame can be crossed back to a source file name and line number using
     *  the recorded assembly, version, module, and IL offset.
     *  
     *  Here's an example stack trace:
     *  at FLMarker:{Stacktrace_Scratchtesting.dll,9341bcc1-7fe6-4b64-a297-42a5f782553b,C:\Users\glwhite\source\repos\Stacktrace_Scratchtesting\Stacktrace_Scratchtesting\Program.cs,Program,Main,15}
     *  at FLMarker:{Stacktrace_Scratchtesting.dll,9341bcc1-7fe6-4b64-a297-42a5f782553b,C:\Users\glwhite\source\repos\Stacktrace_Scratchtesting\Stacktrace_Scratchtesting\Program.cs,Program,ThrowError,36}
     *  at ILMarker:{System.Private.CoreLib.dll,28be434f-13d6-4768-8f5f-f1b9d2bc9827,DateTime,.ctor,MethodToken:0x60008b5,ILOffset:0x0}
     *  at ILMarker:{System.Private.CoreLib.dll,28be434f-13d6-4768-8f5f-f1b9d2bc9827,DateTime,.ctor,MethodToken:0x60008b5,ILOffset:0x0}
     *  at ILMarker:{System.Private.CoreLib.dll,28be434f-13d6-4768-8f5f-f1b9d2bc9827,DateTime,.ctor,MethodToken:0x60008b5,ILOffset:0x0}
     *  at ILMarker:{System.Private.CoreLib.dll,28be434f-13d6-4768-8f5f-f1b9d2bc9827,ThrowHelper,ThrowArgumentOutOfRange_BadYearMonthDay,MethodToken:0x600181f,ILOffset:0xb}

     *  
     *  NOTE: There are two types of entries:
     *      FLMarker
     *          These are for frames whose assembly includes a usable PDB file.
     *          These are formatted like the following:
     *              at FLMarker:{<Assembly>,<AssemblyVersion>,<File>,<Class>,<Method>,<LineNumber>}
     *      ILMarker
     *          These are for frames whose assembly does not have a usable PDB with it.
     *          These are formatted like the following:
     *              at ILMarker:{<Assembly>,<AssemblyVersion>,<Module>,<Method>,<MethodToken>,<ILOffset>}
     *  
     *  The prepended marker distinction allows for an automated technique to identify frame types (with or without IL Offsets),
     *      so a PDB database search can be automated.
     */


    /// <summary>
    /// Builds a stack trace with IL Offsets or file and linenumbers if pdb is present.
    /// This allows for stack traces to be logged with traceability back to a source file and line,
    ///     when a PDB file is not with the executing runtime.
    /// </summary>
    public class cStackTrace
    {
        #region Private Fields

#if (NET452 || NET47 || NET48)
        private Exception _exc;
#else
        private Exception? _exc;
#endif

        private int _offset;

        #endregion


        #region ctor / dtor

        /// <summary>
        /// Call this constructor with a stack frame offset, from this call site.
        /// </summary>
        /// <param name="offset"></param>
        public cStackTrace(int offset)
        {
            this._exc = null;
            if(offset < 0)
                this._offset = 0;
            else
                this._offset = offset + 1;
        }

        /// <summary>
        /// Call this constructor to use an exception as the stack trace source.
        /// </summary>
        /// <param name="exc"></param>
        public cStackTrace(Exception exc)
        {
            this._exc = exc;
        }

        #endregion


        #region Public Static Methods

        /// <summary>
        /// Retrieves the ILMarker for the method that calls this method.
        /// </summary>
        /// <returns></returns>
        static public string Get_ILMarker_For_Current_Method()
        {
            // Use an offset of one, to skip over this method in the call stack...
            return Get_ILMarker_For_Current_Method(1);
        }
        /// <summary>
        /// Retrieves the ILMarker for a calling method.
        /// Specifically, this method accepts an offset that is used to retrieve a specific caller based on its offset.
        /// If you want to retrieve the parent method of the method that calls this method, set offset = 1.
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        static public string Get_ILMarker_For_Current_Method(int offset)
        {
#if (NET452 || NET47 || NET48)
            StackTrace st = null;
#else
            StackTrace? st = null;
#endif

            // Ensure the offset is not negative...
            if (offset < 0)
                // Invalid offset.
                throw new Exception("Stack Frame offset, " + offset.ToString() + ", cannot be negative.");

            // Increment the offset by one, to skip over this method in the call stack...
            offset++;

            // Get the stacktrace...
            st = new System.Diagnostics.StackTrace(offset, true);

            // See if the offset is too high...
            if(st.FrameCount < 1)
                // Invalid offset.
                throw new Exception("Stack Frame offset, " + offset.ToString() + ", is too large");

            // Get the desired frame...
            var sf = st.GetFrame(0);

            string frameentry = Get_ILMarker_Entry_from_Frame(sf);

            return frameentry;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Returns the call stack as a multiline string list of entries.
        /// Includes file and line if a PDB is present, or IL Offset if not.
        /// </summary>
        /// <returns></returns>
        public string To_LogString()
        {
#if (NET452 || NET47 || NET48)
            StackTrace st = null;
#else
            StackTrace? st = null;
#endif
            string strstacktrace = "";

            // We need to get a stack trace.
            // We will get it from the exception, or create it now.

            // Get the stack trace...
            if(this._exc != null)
                st = new System.Diagnostics.StackTrace(this._exc, true);
            else
                st = new System.Diagnostics.StackTrace(this._offset, true);

            // Build the stack frame list...
            foreach (StackFrame frame in st.GetFrames())
            {
                /* Frame Entry format:
                 * 
                 * With PDB (Filename and line number):
                 // <Assembly>,<AssemblyVersion>,<File>,<Class>,<Method>,<LineNumber>
                
                 * Without PDB (Module and IL Offset):
                 // <Assembly>,<AssemblyVersion>,<Module>,<Method>,<MethodToken>,<ILOffset>
                 */
                strstacktrace = Get_Frame_Entry(frame) + "\r\n" + strstacktrace;
            }

            return strstacktrace;
        }

        #endregion


        #region Private Methods

        /// <summary>
        ///  Build a single stack frame entry.
        ///  This method will determine if the frame is in an assembly that has usable pdb data or not.
        ///  If no usable pdb data, the module token and IL offset will be saved in the frame entry.
        ///  If usable pdb data is found, the filename and line number are saved in the frame entry.
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        static private string Get_Frame_Entry(StackFrame frame)
        {
            string framestring = "";

            if(frame == null)
            {
                return "NULL STACKFRAME";
            }

            // Attempt to get the filename of the frame...
            // This will determine if PDB data is available for the frame's assembly, or not.
            string filename = frame.GetFileName() ?? "";

            // Cache out the method because we will use it several times...
            var method = frame.GetMethod();

            /*  Frame Entry format:
                With PDB (Filename and line number):
                    <Assembly>,<AssemblyVersion>,<File>,<Class>,<Method>,<LineNumber>
                
                Without PDB (Module and IL Offset):
                    <Assembly>,<AssemblyVersion>,<Module>,<Method>,<MethodToken>,<ILOffset>
            */

            // Create an entry with filename and line number if we have it...
            if (!string.IsNullOrEmpty(filename))
            {
                // We have a filename.
                // This means, we should also have a line number as well.

                framestring = Format_FLMarker_Frame(method, filename, frame.GetFileLineNumber());
            }
            else
            {
                // No filename was available.
                // This means, we don't have pdb access.
                // So, we need to create an ILMarker entry.

                framestring = Format_ILMarker_Frame(method, frame.GetILOffset());
            }

            return framestring;
        }

        /// <summary>
        ///  Build a single ILMarker based frame entry.
        ///  This method is used in situations where the caller needs an ILMarker frame entry, regardless of PDB presence.
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
#if (NET452 || NET47 || NET48)
        static private string Get_ILMarker_Entry_from_Frame(StackFrame frame)
#else
        static private string Get_ILMarker_Entry_from_Frame(StackFrame? frame)
#endif
        {
            string framestring = "";

            if(frame == null)
            {
                return "NULL STACKFRAME";
            }

            // Cache out the method because we will use it several times...
            var method = frame.GetMethod();

            /*  Frame Entry format:
                    <Assembly>,<AssemblyVersion>,<Module>,<Method>,<MethodToken>,<ILOffset>
            */
            framestring = Format_ILMarker_Frame(method, frame.GetILOffset());

            return framestring;
        }

#if (NET452 || NET47 || NET48)
        static private string Format_FLMarker_Frame(System.Reflection.MethodBase method, string filename, int linenumber)
#else
        static private string Format_FLMarker_Frame(System.Reflection.MethodBase? method, string filename, int linenumber)
#endif
        {
            // Format the frame entry like this...
            // <Assembly>,<AssemblyVersion>,<File>,<Class>,<Method>,<LineNumber>
            string framestring = "at FLMarker:{" +
            // Assembly...
            method?.Module?.Name ?? "" + "," +
            // Assembly Version...
            method?.Module?.ModuleVersionId.ToString() ?? "" + "," +
            // Filename...
            filename ?? "" + "," +
            // Class...
            method?.ReflectedType?.Name ?? "" + "," +
            // Method...
            method?.Name ?? "" + "," +
            // Line Number...
            linenumber.ToString() + "}";

            return framestring;
        }

#if (NET452 || NET47 || NET48)
        static private string Format_ILMarker_Frame(System.Reflection.MethodBase method, int iloffset)
#else
        static private string Format_ILMarker_Frame(System.Reflection.MethodBase? method, int iloffset)
#endif
        {
            // Format the frame entry like this...
            // <Assembly>,<AssemblyVersion>,<Module>,<Method>,<MethodToken>,<ILOffset>
            string framestring = "at ILMarker:{" +
            // Assembly...
            method?.Module?.Name ?? "" + "," +
            // Assembly Version...
            method?.Module?.ModuleVersionId.ToString() ?? "" + "," +
            // Class...
            method?.ReflectedType?.Name ?? "" + "," +
            // Method...
            method?.Name ?? "" + "," +
            // Method Token...
            "MethodToken:0x" + method?.MetadataToken.ToString("x") ?? "" + "," +
            // IL Offset...
            "ILOffset:0x" + iloffset.ToString("x") + "}";

            return framestring;
        }

        #endregion

    }