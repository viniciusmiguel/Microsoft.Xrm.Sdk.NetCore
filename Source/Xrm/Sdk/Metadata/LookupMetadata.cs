// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>Lookup Metadata</summary>
  [DataContract(Name = "LookupMetadata", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupMetadata : IExtensibleDataObject
  {
    private LookupEntityMetadata _entity;
    private LookupView _view;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>The Lookup Entity Metadata</summary>
    [DataMember]
    public LookupEntityMetadata Entity
    {
      get
      {
        if (_entity == null)
          _entity = new LookupEntityMetadata();
        return _entity;
      }
      set => _entity = value;
    }

    /// <summary>The Lookup View</summary>
    [DataMember]
    public LookupView View
    {
      get
      {
        if (_view == null)
          _view = new LookupView();
        return _view;
      }
      set => _view = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
