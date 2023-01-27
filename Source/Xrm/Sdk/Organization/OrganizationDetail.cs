// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Organization.OrganizationDetail
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
  /// <summary>
  /// OrganizationDetail
  /// These types should match the types in src/SDK/Core/DiscoveryServiceProxy.cs.
  /// The converters should be updated if the classes are changed in either file.
  /// </summary>
  [DataContract(Name = "OrganizationDetail", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
  [DebuggerDisplay("{FriendlyName}")]
  public class OrganizationDetail : IExtensibleDataObject
  {
    private EndpointCollection _endpoints = new();
    private Guid _organizationId;
    private string _friendlyName;
    private string _organizationVersion;
    private ExtensionDataObject _extensionDataObject;

    public static OrganizationDetail FromDiscovery(Microsoft.Xrm.Sdk.Discovery.OrganizationDetail detail) => new()
    {
      OrganizationId = detail.OrganizationId,
      FriendlyName = detail.FriendlyName,
      OrganizationVersion = detail.OrganizationVersion,
      UrlName = detail.UrlName,
      UniqueName = detail.UniqueName,
      Endpoints = EndpointCollection.FromDiscovery(detail.Endpoints),
      State = (OrganizationState) detail.State,
      EnvironmentId = detail.EnvironmentId,
      Geo = detail.Geo,
      TenantId = detail.TenantId,
      DatacenterId = detail.DatacenterId
    };

    [DataMember]
    public Guid OrganizationId
    {
      get => _organizationId;
      set => _organizationId = value;
    }

    [DataMember]
    public string FriendlyName
    {
      get => _friendlyName;
      set => _friendlyName = value;
    }

    [DataMember]
    public string OrganizationVersion
    {
      get => _organizationVersion;
      set => _organizationVersion = value;
    }

    [DataMember]
    public string EnvironmentId { get; set; }

    [DataMember]
    public Guid DatacenterId { get; set; }

    [DataMember]
    public string Geo { get; set; }

    [DataMember]
    public string TenantId { get; set; }

    [DataMember]
    public string UrlName { get; set; }

    [DataMember]
    public string UniqueName { get; set; }

    [DataMember]
    public EndpointCollection Endpoints
    {
      get => _endpoints;
      set => _endpoints = value;
    }

    [DataMember]
    public OrganizationState State { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
