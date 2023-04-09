using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OGA.SharedKernel.SpecialTypes
{
    /// <summary>
    /// This struct is a simple implementation of the builtin "void".
    /// It can be used in a generic, to make a concrete class of type T as void.
    /// This overcomes the language limitation that c# will not allow a generic to be concreted to type void.
    /// This struct may have additional purposes, beyond its original intention.
    /// But, it was originally created to allow a generalized web client method (one that can send and receive any type)
    ///     to accept nothing as a reply, which allows the generalized method call to accept a simple Ok (200) and no response body.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 0)]
    public struct Void { }
}
