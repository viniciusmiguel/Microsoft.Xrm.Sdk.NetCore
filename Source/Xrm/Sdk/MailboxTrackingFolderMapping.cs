// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.MailboxTrackingFolderMapping
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "MailboxTrackingFolderMapping", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  [Serializable]
  public sealed class MailboxTrackingFolderMapping : IExtensibleDataObject
  {
    private string _exchangeFolderId;
    private string _exchangeFolderName;
    private Guid _regardingObjectId;
    private string _regardingObjectName;
    private int _regardingObjectTypeCode;
    private bool _isFolderOnboarded;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public MailboxTrackingFolderMapping()
    {
    }

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "")]
    public MailboxTrackingFolderMapping(
      string exchangeFolderId,
      string exchangeFolderName,
      Guid regardingObjectId,
      string regardingObjectName,
      int regardingObjectTypeCode,
      bool isFolderOnboarded)
    {
      _exchangeFolderId = exchangeFolderId;
      _exchangeFolderName = exchangeFolderName;
      _regardingObjectId = regardingObjectId;
      _regardingObjectName = regardingObjectName;
      _regardingObjectTypeCode = regardingObjectTypeCode;
      _isFolderOnboarded = isFolderOnboarded;
    }

    [DataMember]
    public string ExchangeFolderId
    {
      get => _exchangeFolderId;
      internal set => _exchangeFolderId = value;
    }

    [DataMember]
    public string ExchangeFolderName
    {
      get => _exchangeFolderName;
      internal set => _exchangeFolderName = value;
    }

    [DataMember]
    public Guid RegardingObjectId
    {
      get => _regardingObjectId;
      internal set => _regardingObjectId = value;
    }

    [DataMember]
    public string RegardingObjectName
    {
      get => _regardingObjectName;
      internal set => _regardingObjectName = value;
    }

    [DataMember]
    public int RegardingObjectTypeCode
    {
      get => _regardingObjectTypeCode;
      internal set => _regardingObjectTypeCode = value;
    }

    [DataMember]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "")]
    public bool IsFolderOnboarded
    {
      get => _isFolderOnboarded;
      internal set => _isFolderOnboarded = value;
    }

    ExtensionDataObject IExtensibleDataObject.ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
