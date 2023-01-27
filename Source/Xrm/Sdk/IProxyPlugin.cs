// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IProxyPlugin
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Plugins that proxy calls to other types internally such as Sandbox plugins and InternalOperationPlugin
  /// need to implement this interface. This will make them have better telemetry out of the box.
  /// </summary>
  internal interface IProxyPlugin : IPlugin
  {
    string ProxyPluginType { get; }
  }
}
