// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MetadataBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "MetadataBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (AttributeMetadata))]
  [KnownType(typeof (EntityMetadata))]
  [KnownType(typeof (OptionSetMetadata))]
  [KnownType(typeof (RelationshipMetadataBase))]
  public abstract class MetadataBase : IExtensibleDataObject
  {
    private Guid? _id;
    private bool? _hasChanged;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public Guid? MetadataId
    {
      get => _id;
      set => _id = value;
    }

    [DataMember(Order = 60)]
    public bool? HasChanged
    {
      get => _hasChanged;
      set => _hasChanged = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
