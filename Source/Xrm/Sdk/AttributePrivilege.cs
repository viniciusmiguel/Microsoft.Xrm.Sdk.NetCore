// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AttributePrivilege
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "AttributePrivilege", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public sealed class AttributePrivilege : IExtensibleDataObject
  {
    private Guid _attributeId;
    private int _canCreate;
    private int _canRead;
    private int _canUpdate;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public AttributePrivilege()
    {
    }

    public AttributePrivilege(Guid attributeId, int canCreate, int canRead, int canUpdate)
    {
      _attributeId = attributeId;
      _canCreate = canCreate;
      _canRead = canRead;
      _canUpdate = canUpdate;
    }

    [DataMember]
    public Guid AttributeId
    {
      get => _attributeId;
      internal set => _attributeId = value;
    }

    [DataMember]
    public int CanCreate
    {
      get => _canCreate;
      internal set => _canCreate = value;
    }

    [DataMember]
    public int CanRead
    {
      get => _canRead;
      internal set => _canRead = value;
    }

    [DataMember]
    public int CanUpdate
    {
      get => _canUpdate;
      internal set => _canUpdate = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
