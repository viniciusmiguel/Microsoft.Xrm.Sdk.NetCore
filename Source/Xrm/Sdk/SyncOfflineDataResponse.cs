// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SyncOfflineDataResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SyncOfflineDataResponse" /> class.
  /// </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class SyncOfflineDataResponse
  {
    /// <summary>Denotes updated entities</summary>
    [DataMember]
    public SubscriptionUpdatedEntitiesData Updates { get; set; }

    /// <summary>Denotes deleted entities</summary>
    [DataMember]
    public SubscriptionDeletedEntitiesData Deletes { get; set; }

    /// <summary>Denotes sync completed entities</summary>
    [DataMember]
    public IList<string> CompletedEntities { get; set; }

    /// <summary>Denotes the sync token</summary>
    [DataMember]
    public string SyncToken { get; set; }

    /// <summary>Denotes if it is the final page</summary>
    [DataMember]
    public bool IsFinalPage { get; set; }
  }
}
