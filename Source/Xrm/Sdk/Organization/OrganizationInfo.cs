// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Organization.OrganizationInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
  /// <summary>A class that represents organization information</summary>
  [DataContract(Name = "OrganizationInfo", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  [DebuggerDisplay("{InstanceType}")]
  public sealed class OrganizationInfo : IExtensibleDataObject
  {
    /// <summary>Gets or sets the instance types.</summary>
    [DataMember(IsRequired = true, Order = 1)]
    public OrganizationType InstanceType { get; set; }

    /// <summary>Gets or sets the solutions.</summary>
    [DataMember(IsRequired = false, Order = 2)]
    public List<Solution> Solutions { get; set; }

    /// <summary>Gets or sets the structure that contains extra data.</summary>
    public ExtensionDataObject ExtensionData { get; set; }
  }
}
