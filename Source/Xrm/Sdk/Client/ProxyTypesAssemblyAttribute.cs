// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ProxyTypesAssemblyAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk.Client
{
  [AttributeUsage(AttributeTargets.Assembly)]
  public sealed class ProxyTypesAssemblyAttribute : Attribute
  {
    private bool _containsSharedContracts;

    public ProxyTypesAssemblyAttribute()
    {
    }

    internal ProxyTypesAssemblyAttribute(bool containsSharedContracts) => _containsSharedContracts = containsSharedContracts;

    /// <summary>
    /// indicates whether the assembly contains data contracts known to the SDK host
    /// </summary>
    internal bool ContainsSharedContracts => _containsSharedContracts;
  }
}
