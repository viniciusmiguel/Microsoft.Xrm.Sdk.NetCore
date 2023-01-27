// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AttributeMapping
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "AttributeMapping", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
  [Serializable]
  public sealed class AttributeMapping : IExtensibleDataObject
  {
    private Guid _attributeMappingId;
    private string _mappingName;
    private string _attributeCrmName;
    private string _attributeExchangeName;
    private int _entityTypeCode;
    private int _syncDirection;
    private int _defaultSyncDirection;
    private int _allowedSyncDirection;
    private bool _isComputed;
    private Collection<string> _computedProperties;
    private string _attributeCrmDisplayName;
    private string _attributeExchangeDisplayName;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public AttributeMapping()
    {
    }

    public AttributeMapping(
      Guid attributeMappingId,
      string mappingName,
      string attributeCrmName,
      string attributeExchangeName,
      int entityTypeCode,
      int syncDirection,
      int defaultSyncDirection,
      int allowedSyncDirection,
      bool isComputed,
      Collection<string> computedProperties,
      string attributeCrmDisplayName,
      string attributeExchangeDisplayName)
    {
      _attributeMappingId = attributeMappingId;
      _mappingName = mappingName;
      _attributeCrmName = attributeCrmName;
      _attributeExchangeName = attributeExchangeName;
      _entityTypeCode = entityTypeCode;
      _syncDirection = syncDirection;
      _defaultSyncDirection = defaultSyncDirection;
      _allowedSyncDirection = allowedSyncDirection;
      _isComputed = isComputed;
      _computedProperties = computedProperties;
      _attributeCrmDisplayName = attributeCrmDisplayName;
      _attributeExchangeDisplayName = attributeExchangeDisplayName;
    }

    [DataMember]
    public Guid AttributeMappingId
    {
      get => _attributeMappingId;
      internal set => _attributeMappingId = value;
    }

    [DataMember]
    public string MappingName
    {
      get => _mappingName;
      internal set => _mappingName = value;
    }

    [DataMember]
    public string AttributeCrmName
    {
      get => _attributeCrmName;
      internal set => _attributeCrmName = value;
    }

    [DataMember]
    public string AttributeExchangeName
    {
      get => _attributeExchangeName;
      internal set => _attributeExchangeName = value;
    }

    [DataMember]
    public int SyncDirection
    {
      get => _syncDirection;
      internal set => _syncDirection = value;
    }

    [DataMember]
    public int DefaultSyncDirection
    {
      get => _defaultSyncDirection;
      internal set => _defaultSyncDirection = value;
    }

    [DataMember]
    public int AllowedSyncDirection
    {
      get => _allowedSyncDirection;
      internal set => _allowedSyncDirection = value;
    }

    [DataMember]
    public bool IsComputed
    {
      get => _isComputed;
      internal set => _isComputed = value;
    }

    [DataMember]
    public int EntityTypeCode
    {
      get => _entityTypeCode;
      internal set => _entityTypeCode = value;
    }

    [DataMember]
    public Collection<string> ComputedProperties
    {
      get => _computedProperties;
      internal set => _computedProperties = value;
    }

    [DataMember]
    public string AttributeCrmDisplayName
    {
      get => _attributeCrmDisplayName;
      internal set => _attributeCrmDisplayName = value;
    }

    [DataMember]
    public string AttributeExchangeDisplayName
    {
      get => _attributeExchangeDisplayName;
      internal set => _attributeExchangeDisplayName = value;
    }

    ExtensionDataObject IExtensibleDataObject.ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
