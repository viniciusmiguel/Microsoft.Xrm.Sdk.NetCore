// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IManagedIdentityService
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Interface for plug-ins to obtain access token from managed identity.
  /// </summary>
  public interface IManagedIdentityService
  {
    /// <summary>Acquire the access token for specified scopes.</summary>
    /// <param name="scopes">Scopes of the token</param>
    /// <returns>Access token for the scopes</returns>
    string AcquireToken(IEnumerable<string> scopes);
  }
}
