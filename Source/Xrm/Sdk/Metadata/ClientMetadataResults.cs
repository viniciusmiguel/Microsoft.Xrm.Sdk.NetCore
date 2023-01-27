// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ClientMetadataResults
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Client Metadata results</summary>
  [DataContract(Name = "ClientMetadataResults", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class ClientMetadataResults : IExtensibleDataObject
  {
    private List<ClientEntityMetadata> _entities;
    private List<ClientEntityMetadata> _relationshipNavigationEntities;
    private string _otherMetadata;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public List<ClientEntityMetadata> Entities
    {
      get => _entities;
      set => _entities = value;
    }

    [DataMember]
    public List<ClientEntityMetadata> RelationshipNavigationEntities
    {
      get => _relationshipNavigationEntities;
      set => _relationshipNavigationEntities = value;
    }

    [DataMember]
    public string OtherMetadata
    {
      get => _otherMetadata;
      set => _otherMetadata = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
