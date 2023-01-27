// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.TypeExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Type class related extension methods and utilities.</summary>
  /// <exclude />
  internal static class TypeExtensions
  {
    public static string GetLogicalName(this Type type) => KnownProxyTypesProvider.GetInstance(true).GetNameForType(type);

    /// <summary>
    /// Retrieves the underlying type if the type is nullable, otherwise returns the current type.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Type GetUnderlyingType(this Type type)
    {
      var underlyingType = Nullable.GetUnderlyingType(type);
      return (object) underlyingType != null ? underlyingType : type;
    }

    /// <summary>
    /// Determines if a generic type is assignable from this type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsA<T>(this Type type) => type.IsA(typeof (T));

    /// <summary>
    /// Determines if the input reference type is assignable from this type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="referenceType"></param>
    /// <returns></returns>
    public static bool IsA(this Type type, Type referenceType) => referenceType != null && referenceType.IsAssignableFrom(type);
  }
}
