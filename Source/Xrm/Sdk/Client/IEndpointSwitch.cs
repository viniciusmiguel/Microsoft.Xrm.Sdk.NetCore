// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IEndpointSwitch
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// This interface provides support for failover event handling.  This is only enabled in on-line scenarios.
  /// </summary>
  public interface IEndpointSwitch
  {
    bool EndpointAutoSwitchEnabled { get; set; }

    Uri AlternateEndpoint { get; }

    Uri PrimaryEndpoint { get; }

    bool IsPrimaryEndpoint { get; }

    bool CanSwitch(Uri currentUri);

    void SwitchEndpoint();

    bool HandleEndpointSwitch();

    event EventHandler<EndpointSwitchEventArgs> EndpointSwitched;

    event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired;
  }
}
