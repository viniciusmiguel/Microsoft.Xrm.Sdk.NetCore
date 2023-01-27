// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.NewOrUpdatedItem
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Holds the Change Type and Entities that are INSERTED or UPDATED at the server since the last sync
  /// </summary>
  [DataContract(Name = "NewOrUpdatedItem", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  public sealed class NewOrUpdatedItem : IChangedItem, IExtensibleDataObject
  {
    private ChangeType _type;
    private Entity _newOrUpdatedEntity;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    /// <summary>
    /// Gets or sets changeType that indicates the type of the change
    /// </summary>
    [DataMember]
    public ChangeType Type
    {
      get => _type;
      set => _type = value;
    }

    /// <summary>
    /// Gets or sets entity of the INSERTED/UPDATED business entity record.
    /// </summary>
    [DataMember]
    public Entity NewOrUpdatedEntity
    {
      get => _newOrUpdatedEntity;
      set => _newOrUpdatedEntity = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }

    public NewOrUpdatedItem(ChangeType type, Entity entity)
    {
      _type = type;
      _newOrUpdatedEntity = entity;
    }
  }
}
