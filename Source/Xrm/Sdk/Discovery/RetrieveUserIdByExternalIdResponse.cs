// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.RetrieveUserIdByExternalIdResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
  /// <summary>
  /// Response to the RetrieveCrmUserIdByExternalIdRequest which returns the CrmUserId of external id provided.
  /// </summary>
  [DataContract(Name = "RetrieveUserIdByExternalIdResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
  public sealed class RetrieveUserIdByExternalIdResponse : DiscoveryResponse
  {
    private Guid _userId;

    /// <summary>The User Id for the provided external id.</summary>
    [DataMember]
    public Guid UserId
    {
      get => _userId;
      set => _userId = value;
    }
  }
}
