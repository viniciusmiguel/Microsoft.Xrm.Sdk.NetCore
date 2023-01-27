// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.RetrieveUserIdByExternalIdRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
  [DataContract(Name = "RetrieveUserIdByExternalIdRequest", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
  public sealed class RetrieveUserIdByExternalIdRequest : DiscoveryRequest
  {
    private string _organizationName;
    private Guid _organizationId;
    private string _externalId;
    private string _release;

    /// <summary>The external id that is associated to a crmuserid</summary>
    [DataMember]
    public string ExternalId
    {
      get => _externalId;
      set => _externalId = value;
    }

    /// <summary>The organization name to retrieve the CrmUserId for</summary>
    [DataMember]
    public string OrganizationName
    {
      get => _organizationName;
      set => _organizationName = value;
    }

    [DataMember]
    public Guid OrganizationId
    {
      get => _organizationId;
      set => _organizationId = value;
    }

    [DataMember]
    public string Release
    {
      get => _release;
      set => _release = value;
    }
  }
}
