// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.LiveIdAuthenticationConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk.Client
{
  internal static class LiveIdAuthenticationConfiguration
  {
    internal static string DeviceTokenId = "urn:liveid:device";
    internal static string UserNameTokenId = "user";
    internal static string DeviceUserNameTokenId = "devicesoftware";
    internal static string PolicyReference = "http://schemas.xmlsoap.org/ws/2004/09/policy";
    internal static string SecurityTokenSchema = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
    internal static string DefaultPolicy = "MBI_FED_SSL";
  }
}
