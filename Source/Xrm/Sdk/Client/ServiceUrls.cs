// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceUrls
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// Contains the available urls for a service endpoint, and whether they were generated from querying the alternate endpoint.ye
  /// </summary>
  public sealed class ServiceUrls
  {
    public Uri PrimaryEndpoint { get; set; }

    public Uri AlternateEndpoint { get; set; }

    public bool GeneratedFromAlternate { get; internal set; }
  }
}
