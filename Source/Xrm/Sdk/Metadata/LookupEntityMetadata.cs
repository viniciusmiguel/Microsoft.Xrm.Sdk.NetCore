// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupEntityMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Lookup Entity Metadata</summary>
  [DataContract(Name = "LookupEntityMetadata", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupEntityMetadata : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>
    /// Gets or sets a value indicating whether the Is Read Only In Mobile Client
    /// </summary>
    [DataMember]
    public bool IsReadOnlyInMobileClient { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the Is Enabled In Unified Interface
    /// </summary>
    [DataMember]
    public bool IsEnabledInUnifiedInterface { get; set; }

    /// <summary>Gets or sets the Display Name</summary>
    [DataMember]
    public string DisplayName { get; set; }

    /// <summary>Gets or sets the Primary Name Attribute</summary>
    [DataMember]
    public string PrimaryNameAttribute { get; set; }

    /// <summary>Gets or sets the Primary id/Key Attribute</summary>
    [DataMember]
    public string PrimaryIdAttribute { get; set; }

    /// <summary>Gets or sets the Logical Name</summary>
    [DataMember]
    public string LogicalName { get; set; }

    /// <summary>Gets or sets the Display Collection Name</summary>
    [DataMember]
    public string DisplayCollectionName { get; set; }

    /// <summary>Gets or sets the Icon Vector Name</summary>
    [DataMember]
    public string IconVectorName { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
