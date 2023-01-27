// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.FieldPermissionType
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Globalization;

namespace Microsoft.Xrm.Sdk
{
  public static class FieldPermissionType
  {
    public const int NotAllowed = 0;
    public const int Allowed = 4;

    /// <summary>
    /// Validate whether the provided value is one of the constants in the class
    /// </summary>
    /// <exception cref="T:System.ArgumentOutOfRangeException">Throws ArgumentOutOfRangeException if the provided value is not
    /// one of the constants specified in the class</exception>
    /// <param name="value">an integer to be validated as a FieldPermissionType</param>
    public static void Validate(int value)
    {
      if (value != 4 && value != 0)
        throw new ArgumentOutOfRangeException(nameof (value), string.Format(CultureInfo.InvariantCulture, "Value {0} is not a valid FieldPermissionType", value));
    }
  }
}
