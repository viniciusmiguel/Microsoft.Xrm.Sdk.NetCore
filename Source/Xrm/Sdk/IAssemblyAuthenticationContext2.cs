// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IAssemblyAuthenticationContext2
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Extension to the IAssemblyAuthenticationContext to add Resolve Authority and resource for a given challenge URI
  /// </summary>
  public interface IAssemblyAuthenticationContext2 : IAssemblyAuthenticationContext
  {
    /// <summary>
    /// Retrieves Authority and Resource from AAD challenge URI.
    /// The challenge URI is used to post a challenge to an authenticated endpoint, expecting a 401 response which includes the "www-authenticate" header containing the authority and resource to use when calling acquire token.
    /// </summary>
    /// <param name="aadChallengeUri">URI of the target service that will respond to an AAD challenge response</param>
    /// <param name="authority">If found, the authority to use when calling AcquireToken, else returns empty string</param>
    /// <param name="resource">If found, the resource to use when calling AcquireToken, else returns empty string</param>
    /// <returns>True if successfully populated, false if unable to retrieve</returns>
    bool ResolveAuthorityAndResourceFromChallengeUri(
      Uri aadChallengeUri,
      out string authority,
      out string resource);
  }
}
