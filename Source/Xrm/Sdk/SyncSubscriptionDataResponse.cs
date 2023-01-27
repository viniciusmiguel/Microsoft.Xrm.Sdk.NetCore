// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SyncSubscriptionDataResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SyncSubscriptionDataResponse" /> class.
  /// </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/9.0/Metadata")]
  public sealed class SyncSubscriptionDataResponse
  {
    [DataMember]
    public SubscriptionData Data { get; set; }

    /// <summary>Sync token to mark the data which is getting sync'd</summary>
    [DataMember]
    public string SyncToken { get; set; }

    /// <summary>
    /// Flag to indicate if there is more data available to be sync'd
    /// </summary>
    [DataMember]
    public bool IsFinalPage { get; set; }
  }
}
