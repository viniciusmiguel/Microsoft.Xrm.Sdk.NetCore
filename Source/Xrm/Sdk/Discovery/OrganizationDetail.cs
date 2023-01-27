// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.OrganizationDetail
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
  [DataContract(Name = "OrganizationDetail", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
  public class OrganizationDetail : IExtensibleDataObject
  {
    private EndpointCollection _endpoints = new();
    private Guid _organizationId;
    private string _friendlyName;
    private string _organizationVersion;
    private string _environmentId;
    private string _geo;
    private string _tenantId;
    private Guid _datacenterId;
    private ExtensionDataObject _extensionDataObject;

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
    public string EnvironmentId
    {
      get => _environmentId;
      set => _environmentId = value;
    }

    [DataMember]
    public Guid DatacenterId
    {
      get => _datacenterId;
      set => _datacenterId = value;
    }

    [DataMember]
    public string Geo
    {
      get => _geo;
      set => _geo = value;
    }

    [DataMember]
    public string TenantId
    {
      get => _tenantId;
      set => _tenantId = value;
    }

    [DataMember]
    public string UrlName { get; set; }

    [DataMember]
    public string UniqueName { get; set; }

    [DataMember]
    public EndpointCollection Endpoints
    {
      get => _endpoints;
      internal set => _endpoints = value;
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
