// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SyncSubscriptionMetadataResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SyncSubscriptionMetadataResponse" /> class.
  /// </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/9.0/Metadata")]
  public sealed class SyncSubscriptionMetadataResponse
  {
    /// <summary>Enities metadata definition</summary>
    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 0)]
    public SubscriptionEntitiesMetadata Metadata { get; set; }

    /// <summary>Sync token to mark the data which is getting sync'd</summary>
    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 1)]
    public string SyncToken { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether or not this is the final page of data
    /// </summary>
    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 2)]
    public bool IsFinalPage { get; set; }

    /// <summary>Gets or sets a value indicating the metadata version</summary>
    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 3)]
    public string MetadataVersion { get; set; }

    /// <summary>Gets or sets a value indicating the profile version</summary>
    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 4)]
    public string ProfileVersion { get; set; }
  }
}
