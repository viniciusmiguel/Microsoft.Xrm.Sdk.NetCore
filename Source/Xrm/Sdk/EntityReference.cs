// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntityReference
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Pointer to an entity instance</summary>
  [DataContract(Name = "EntityReference", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public sealed class EntityReference : IExtensibleDataObject
  {
    private string _logicalName;
    private string _name;
    private Guid _id;
    private KeyAttributeCollection _keyCollection;
    private string _rowVersion;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public EntityReference()
    {
    }

    public EntityReference(string logicalName) => _logicalName = logicalName;

    public EntityReference(string logicalName, Guid id)
    {
      _logicalName = logicalName;
      _id = id;
    }

    public EntityReference(string logicalName, string keyName, object keyValue)
    {
      _logicalName = logicalName;
      KeyAttributes.Add(new KeyValuePair<string, object>(keyName, keyValue));
    }

    public EntityReference(string logicalName, KeyAttributeCollection keyAttributeCollection)
    {
      _logicalName = logicalName;
      _keyCollection = keyAttributeCollection;
    }

    [DataMember]
    public Guid Id
    {
      get => _id;
      set => _id = value;
    }

    [DataMember]
    public string LogicalName
    {
      get => _logicalName;
      set => _logicalName = value;
    }

    [DataMember]
    public string Name
    {
      get => _name;
      set => _name = value;
    }

    [DataMember]
    public KeyAttributeCollection KeyAttributes
    {
      get
      {
        if (_keyCollection == null)
          _keyCollection = new KeyAttributeCollection();
        return _keyCollection;
      }
      set => _keyCollection = value;
    }

    [DataMember]
    public string RowVersion
    {
      get => _rowVersion;
      set => _rowVersion = value;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is EntityReference entityReference))
        return false;
      if (this == entityReference)
        return true;
      return _id.Equals(entityReference._id) && string.Compare(_logicalName, entityReference._logicalName, StringComparison.Ordinal) == 0 && KeyAttributes.Count == entityReference.KeyAttributes.Count && KeyAttributes.Intersect<KeyValuePair<string, object>>(entityReference.KeyAttributes).Count<KeyValuePair<string, object>>() == KeyAttributes.Count;
    }

    public override int GetHashCode()
    {
      var hashCode = string.IsNullOrEmpty(_logicalName) ? 0 : _logicalName.GetHashCode() ^ _id.GetHashCode();
      foreach (var keyAttribute in KeyAttributes)
        hashCode ^= string.IsNullOrEmpty(keyAttribute.Key) ? 0 : keyAttribute.Key.GetHashCode() ^ keyAttribute.Value.GetHashCode();
      return hashCode;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
