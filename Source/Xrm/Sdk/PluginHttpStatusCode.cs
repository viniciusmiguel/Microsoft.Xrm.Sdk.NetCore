// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.PluginHttpStatusCode
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// HTTP status codes supported to be returned due to an InvalidPluginExecutionException.
  /// The default HTTP status code for plugin exceptions is 400 Bad Request.
  /// </summary>
  public enum PluginHttpStatusCode
  {
    NotSet = 0,
    BadRequest = 400, // 0x00000190
    Unauthorized = 401, // 0x00000191
    Forbidden = 403, // 0x00000193
    NotFound = 404, // 0x00000194
    MethodNotAllowed = 405, // 0x00000195
    RequestTimeout = 408, // 0x00000198
    Conflict = 409, // 0x00000199
    Gone = 410, // 0x0000019A
    PreconditionFailed = 412, // 0x0000019C
    RequestEntityTooLarge = 413, // 0x0000019D
    FailedDependency = 424, // 0x000001A8
    TooManyRequests = 429, // 0x000001AD
    InternalServerError = 500, // 0x000001F4
    BadGateway = 502, // 0x000001F6
    ServiceUnavailable = 503, // 0x000001F7
    GatewayTimeout = 504, // 0x000001F8
  }
}
