// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.RemovedOrDeletedItem
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Holds the Change Type and EntityReference of the records that are REMOVED or DELETED at the server since the last sync
  /// </summary>
  [DataContract(Name = "RemovedOrDeletedItem", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  public sealed class RemovedOrDeletedItem : IChangedItem, IExtensibleDataObject
  {
    private ChangeType _type;
    private EntityReference _removedItem;
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
    /// Gets or sets entity of the REMOVED/DELETED business entity record.
    /// </summary>
    [DataMember]
    public EntityReference RemovedItem
    {
      get => _removedItem;
      set => _removedItem = value;
    }

    public RemovedOrDeletedItem(ChangeType type, EntityReference entityReference)
    {
      _type = type;
      _removedItem = entityReference;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
