// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Organization.Solution
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
  /// <summary>A class that represents solution information</summary>
  [DataContract(Name = "Solution", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  [DebuggerDisplay("{FriendlyName}")]
  public sealed class Solution : IExtensibleDataObject
  {
    /// <summary>Gets or sets the solution identifier.</summary>
    [DataMember(IsRequired = true, Order = 1)]
    public Guid Id { get; set; }

    /// <summary>Gets or sets the version number of the solution.</summary>
    [DataMember(IsRequired = true, Order = 2)]
    public string VersionNumber { get; set; }

    /// <summary>Gets or sets the unique name of the solution.</summary>
    [DataMember(IsRequired = true, Order = 3)]
    public string SolutionUniqueName { get; set; }

    /// <summary>Gets or sets the friendly name of the solution.</summary>
    [DataMember(IsRequired = true, Order = 4)]
    public string FriendlyName { get; set; }

    /// <summary>Gets or sets the publisherId of the solution.</summary>
    [DataMember(IsRequired = true, Order = 5)]
    public Guid PublisherId { get; set; }

    /// <summary>Gets or sets the publisherId name of the solution.</summary>
    [DataMember(IsRequired = true, Order = 6)]
    public string PublisherIdName { get; set; }

    /// <summary>
    /// Gets or sets the publisher unique name of the solution.
    /// </summary>
    [DataMember(IsRequired = true, Order = 7)]
    public string PublisherUniqueName { get; set; }

    /// <summary>Gets or sets the structure that contains extra data.</summary>
    public ExtensionDataObject ExtensionData { get; set; }
  }
}
