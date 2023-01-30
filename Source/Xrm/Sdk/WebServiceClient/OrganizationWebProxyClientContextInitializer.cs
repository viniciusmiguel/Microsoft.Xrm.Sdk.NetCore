/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.OrganizationWebProxyClientContextInitializer
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  /// <summary>Manages context for sdk calls</summary>
  internal sealed class OrganizationWebProxyClientContextInitializer : 
    WebProxyClientContextInitializer<IOrganizationService>
  {
    public OrganizationWebProxyClientContextInitializer(OrganizationWebProxyClient proxy)
      : base(proxy)
    {
      Initialize();
    }

    private OrganizationWebProxyClient OrganizationWebProxyClient => ServiceProxy as OrganizationWebProxyClient;

    private void Initialize()
    {
      if (ServiceProxy == null)
        return;
      AddTokenToHeaders();
      if (ServiceProxy == null)
        return;
      if (OrganizationWebProxyClient.OfflinePlayback)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("IsOfflinePlayback", "http://schemas.microsoft.com/xrm/2011/Contracts", true));
      if (OrganizationWebProxyClient.CallerId != Guid.Empty)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationWebProxyClient.CallerId));
      if (OrganizationWebProxyClient.CallerRegardingObjectId != Guid.Empty)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerRegardingObjectId", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationWebProxyClient.CallerRegardingObjectId));
      if (OrganizationWebProxyClient.LanguageCodeOverride != 0)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("LanguageCodeOverride", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationWebProxyClient.LanguageCodeOverride));
      if (OrganizationWebProxyClient.SyncOperationType != null)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("OutlookSyncOperationType", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationWebProxyClient.SyncOperationType));
      OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("UserType", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationWebProxyClient.userType));
      AddCommonHeaders();
    }
  }
}
*/
