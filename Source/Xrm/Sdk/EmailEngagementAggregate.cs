// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EmailEngagementAggregate
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// EmailEngagementAggregate holds the counts for email opens, links clicks, attachment opens, replies
  /// </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class EmailEngagementAggregate : IExtensibleDataObject
  {
    private int totalEmails;
    private int totalFollowedEmails;
    private int totalEmailOpens;
    private int totalEmailReplies;
    private int totalAttachmentOpens;
    private int totalLinkClicks;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Total Email for the entity</summary>
    [DataMember]
    public int TotalEmails
    {
      get => totalEmails;
      set => totalEmails = value;
    }

    /// <summary>Total followed Emails for the entity</summary>
    [DataMember]
    public int TotalFollowedEmails
    {
      get => totalFollowedEmails;
      set => totalFollowedEmails = value;
    }

    /// <summary>Total Email Opens for the entity</summary>
    [DataMember]
    public int TotalEmailOpens
    {
      get => totalEmailOpens;
      set => totalEmailOpens = value;
    }

    /// <summary>Total Email Replies for the Entity</summary>
    [DataMember]
    public int TotalEmailReplies
    {
      get => totalEmailReplies;
      set => totalEmailReplies = value;
    }

    /// <summary>Total Attachment OPens for the entity</summary>
    [DataMember]
    public int TotalAttachmentOpens
    {
      get => totalAttachmentOpens;
      set => totalAttachmentOpens = value;
    }

    /// <summary>Total Links clicked for the entity</summary>
    [DataMember]
    public int TotalLinkClicks
    {
      get => totalLinkClicks;
      set => totalLinkClicks = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
