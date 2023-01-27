// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.SdkHeaders
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk.Client
{
  internal static class SdkHeaders
  {
    /// <summary>
    /// Header set by offline client when playing back requests while going online
    /// </summary>
    public const string IsOfflinePlayback = "IsOfflinePlayback";
    /// <summary>Supports alternate user context in SDK. Type:Guid</summary>
    public const string CallerId = "CallerId";
    /// <summary>
    /// Alternate user regarding object context in SDK. Type:Guid
    /// </summary>
    public const string CallerRegardingObjectId = "CallerRegardingObjectId";
    /// <summary>Defines user type in SDK.</summary>
    public const string UserType = "UserType";
    /// <summary>Defines a language code override for an SDK call</summary>
    public const string LanguageCodeOverride = "LanguageCodeOverride";
    /// <summary>Necessary for throttling Outlook sync operations.</summary>
    public const string OutlookSyncOperationType = "OutlookSyncOperationType";
    /// <summary>
    /// Used to inform the server about the calling client app
    /// </summary>
    public const string ClientAppName = "ClientAppName";
    /// <summary>
    /// Used to inform the server about the calling client app version
    /// </summary>
    public const string ClientAppVersion = "ClientAppVersion";
    /// <summary>
    /// Used to inform the server about the calling client sdk client version.
    /// </summary>
    public const string SdkClientVersion = "SdkClientVersion";
  }
}
