// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DependencySummary
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Dependency Summary
  /// Contains selected field from dependency entity with additional joined data
  /// </summary>
  [DataContract(Name = "DependencySummary", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class DependencySummary : IExtensibleDataObject
  {
    [DataMember(IsRequired = false, Order = 1)]
    public int DependencyType { get; set; }

    [DataMember(IsRequired = false, Order = 2)]
    public Guid DependencyId { get; set; }

    [DataMember(IsRequired = false, Order = 3)]
    public int DependentComponentType { get; set; }

    [DataMember(IsRequired = false, Order = 4)]
    public Guid DependentComponentParentId { get; set; }

    [DataMember(IsRequired = false, Order = 5)]
    public Guid DependentComponentObjectId { get; set; }

    [DataMember(IsRequired = false, Order = 6)]
    public Guid DependentComponentBaseSolutionId { get; set; }

    [DataMember(IsRequired = false, Order = 7)]
    public Guid DependentComponentNodeId { get; set; }

    [DataMember(IsRequired = false, Order = 8)]
    public string DependentComponentName { get; set; }

    [DataMember(IsRequired = false, Order = 9)]
    public string DependentComponentDisplayName { get; set; }

    [DataMember(IsRequired = false, Order = 10)]
    public int RequiredComponentType { get; set; }

    [DataMember(IsRequired = false, Order = 11)]
    public Guid RequiredComponentParentId { get; set; }

    [DataMember(IsRequired = false, Order = 12)]
    public Guid RequiredComponentObjectId { get; set; }

    [DataMember(IsRequired = false, Order = 13)]
    public Guid RequiredComponentBaseSolutionId { get; set; }

    [DataMember(IsRequired = false, Order = 14)]
    public Guid RequiredComponentNodeId { get; set; }

    [DataMember(IsRequired = false, Order = 15)]
    public string RequiredComponentName { get; set; }

    [DataMember(IsRequired = false, Order = 16)]
    public string RequiredComponentDisplayName { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
