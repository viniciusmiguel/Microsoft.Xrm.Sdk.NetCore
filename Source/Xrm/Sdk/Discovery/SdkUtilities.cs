// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.SdkUtilities
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.Xrm.Sdk.Discovery
{
  internal static class SdkUtilities
  {
    /// <summary>Converts a secure string to string.</summary>
    /// <param name="value">Secure string</param>
    /// <returns>String</returns>
    [SecuritySafeCritical]
    internal static string SecureStringToString(SecureString value)
    {
      if (value == null)
        return null;
      var num = IntPtr.Zero;
      try
      {
        num = Marshal.SecureStringToBSTR(value);
        return Marshal.PtrToStringUni(num);
      }
      finally
      {
        if (num != IntPtr.Zero)
          Marshal.ZeroFreeBSTR(num);
      }
    }

    /// <summary>Converts a string to secure string.</summary>
    /// <param name="value">String</param>
    /// <returns>Read-only Secure string</returns>
    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    internal static SecureString StringToSecureString(string value)
    {
      if (value == null)
        return null;
      var secureString = new SecureString();
      foreach (var c in value)
        secureString.AppendChar(c);
      secureString.MakeReadOnly();
      return secureString;
    }
  }
}
