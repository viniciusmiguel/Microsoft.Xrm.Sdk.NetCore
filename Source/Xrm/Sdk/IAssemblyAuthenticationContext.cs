// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IAssemblyAuthenticationContext
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk
{
  public interface IAssemblyAuthenticationContext
  {
    /// <summary>Acquires security token from the authority.</summary>
    /// <param name="authority">Authority to use on AuthenticationContext</param>
    /// <param name="resource">Identifier of the target resource that is the recipient of the requested token.</param>
    /// <param name="authenticationType">Authentication type to use</param>
    /// <returns>AccessToken</returns>
    string AcquireToken(string authority, string resource, AuthenticationType authenticationType);
  }
}
