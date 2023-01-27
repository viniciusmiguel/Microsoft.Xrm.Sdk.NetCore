// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OrganizationServiceContextInitializer
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>Manages context for sdk calls</summary>
  internal sealed class OrganizationServiceContextInitializer : 
    ServiceContextInitializer<IOrganizationService>
  {
    public OrganizationServiceContextInitializer(OrganizationServiceProxy proxy)
      : base(proxy)
    {
      Initialize();
    }

    private OrganizationServiceProxy OrganizationServiceProxy => ServiceProxy as OrganizationServiceProxy;

    private void Initialize()
    {
      if (OrganizationServiceProxy == null)
        return;
      if (OrganizationServiceProxy.OfflinePlayback)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("IsOfflinePlayback", "http://schemas.microsoft.com/xrm/2011/Contracts", true));
      if (OrganizationServiceProxy.CallerId != Guid.Empty)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationServiceProxy.CallerId));
      if (OrganizationServiceProxy.CallerRegardingObjectId != Guid.Empty)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerRegardingObjectId", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationServiceProxy.CallerRegardingObjectId));
      if (OrganizationServiceProxy.LanguageCodeOverride != 0)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("LanguageCodeOverride", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationServiceProxy.LanguageCodeOverride));
      if (OrganizationServiceProxy.SyncOperationType != null)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("OutlookSyncOperationType", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationServiceProxy.SyncOperationType));
      if (!string.IsNullOrEmpty(OrganizationServiceProxy.ClientAppName))
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppName", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationServiceProxy.ClientAppName));
      if (!string.IsNullOrEmpty(OrganizationServiceProxy.ClientAppVersion))
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationServiceProxy.ClientAppVersion));
      if (!string.IsNullOrEmpty(OrganizationServiceProxy.SdkClientVersion))
      {
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationServiceProxy.SdkClientVersion));
      }
      else
      {
        var assemblyFileVersion = OrganizationServiceProxy.GetXrmSdkAssemblyFileVersion();
        if (!string.IsNullOrEmpty(assemblyFileVersion))
          OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", assemblyFileVersion));
      }
      OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("UserType", "http://schemas.microsoft.com/xrm/2011/Contracts", OrganizationServiceProxy.UserType));
    }
  }
}
