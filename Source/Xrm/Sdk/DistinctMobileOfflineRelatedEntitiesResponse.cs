// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DistinctMobileOfflineRelatedEntitiesResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.DistinctMobileOfflineRelatedEntitiesResponse" /> class
  /// </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class DistinctMobileOfflineRelatedEntitiesResponse
  {
    /// <summary>Entities that are related</summary>
    [DataMember]
    public IList<string> DistinctRelatedEntities { get; set; }

    /// <summary>Entities that are not in profile</summary>
    [DataMember]
    public IList<string> EntitiesNotInProfile { get; set; }
  }
}
