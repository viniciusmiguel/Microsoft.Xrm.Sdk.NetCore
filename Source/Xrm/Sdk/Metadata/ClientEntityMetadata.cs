// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ClientEntityMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Client Entity Metadata</summary>
  [DataContract(Name = "ClientEntityMetadata", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class ClientEntityMetadata : IExtensibleDataObject
  {
    private EntityMetadata _entityMetadata;
    private string[] _attributeNames;
    private ExtensionDataObject _extensionDataObject;

    [DataMember(EmitDefaultValue = false)]
    public EntityMetadata EntityMetadata
    {
      get => _entityMetadata;
      set => _entityMetadata = value;
    }

    [DataMember(EmitDefaultValue = false)]
    public string[] AttributeNames
    {
      get => _attributeNames;
      set => _attributeNames = value;
    }

    [DataMember(EmitDefaultValue = false)]
    public EntityClientSetting EntityClientSetting { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
