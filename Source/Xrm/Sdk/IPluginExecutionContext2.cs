// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IPluginExecutionContext2
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Extension of IPluginExecutionContext adding support for azure AAD properties
  /// </summary>
  public interface IPluginExecutionContext2 : IPluginExecutionContext, IExecutionContext
  {
    /// <summary>Gets azure active directory object Id of user.</summary>
    Guid UserAzureActiveDirectoryObjectId { get; }

    /// <summary>
    /// Gets azure active directory object Id of user that initiates web service.
    /// </summary>
    Guid InitiatingUserAzureActiveDirectoryObjectId { get; }

    /// <summary>
    /// Gets application Id of user that initiates the plugin (for NON-app user .. it is Guid.Empty)
    /// </summary>
    Guid InitiatingUserApplicationId { get; }

    /// <summary>
    /// Gets contactId that got passed for the calls that come from portals client to web service (for NON-portal/Anonymous call, it is guid.Empty)
    /// </summary>
    Guid PortalsContactId { get; }

    /// <summary>
    /// Gets a value indicating whether 'True' if the call is originated from Portals client
    /// </summary>
    bool IsPortalsClientCall { get; }
  }
}
