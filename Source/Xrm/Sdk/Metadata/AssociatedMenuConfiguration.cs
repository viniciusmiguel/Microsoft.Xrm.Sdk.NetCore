// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.AssociatedMenuConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "AssociatedMenuConfiguration", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public sealed class AssociatedMenuConfiguration : IExtensibleDataObject
  {
    private AssociatedMenuBehavior? _associatedMenuBehavior;
    private AssociatedMenuGroup? _associatedMenuGroup;
    private Label _associatedMenuLabel;
    private int? _associatedMenuOrder;
    private bool _associatedMenuIsCustomizable;
    private string _associatedMenuIcon;
    private Guid _associatedMenuViewId;
    private bool _associatedMenuAvailableOffline;
    private string _associatedMenuMenuId;
    private string _associatedMenuQueryApi;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public AssociatedMenuBehavior? Behavior
    {
      get => _associatedMenuBehavior;
      set => _associatedMenuBehavior = value;
    }

    [DataMember]
    public AssociatedMenuGroup? Group
    {
      get => _associatedMenuGroup;
      set => _associatedMenuGroup = value;
    }

    [DataMember]
    public Label Label
    {
      get => _associatedMenuLabel;
      set => _associatedMenuLabel = value;
    }

    [DataMember]
    public int? Order
    {
      get => _associatedMenuOrder;
      set => _associatedMenuOrder = value;
    }

    [DataMember(Order = 90)]
    public bool IsCustomizable
    {
      get => _associatedMenuIsCustomizable;
      internal set => _associatedMenuIsCustomizable = value;
    }

    [DataMember(Order = 90)]
    public string Icon
    {
      get => _associatedMenuIcon;
      internal set => _associatedMenuIcon = value;
    }

    [DataMember(Order = 90)]
    public Guid ViewId
    {
      get => _associatedMenuViewId;
      internal set => _associatedMenuViewId = value;
    }

    [DataMember(Order = 90)]
    public bool AvailableOffline
    {
      get => _associatedMenuAvailableOffline;
      internal set => _associatedMenuAvailableOffline = value;
    }

    [DataMember(Order = 90)]
    public string MenuId
    {
      get => _associatedMenuMenuId;
      internal set => _associatedMenuMenuId = value;
    }

    [DataMember(Order = 90)]
    public string QueryApi
    {
      get => _associatedMenuQueryApi;
      internal set => _associatedMenuQueryApi = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
