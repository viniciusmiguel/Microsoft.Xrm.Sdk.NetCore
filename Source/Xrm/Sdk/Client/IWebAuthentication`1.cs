// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IWebAuthentication`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.IdentityModel.Tokens;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  internal interface IWebAuthentication<TService>
  {
    SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      Uri uri,
      string keyType);

    SecurityTokenResponse Authenticate(SecurityToken securityToken, Uri uri, string keyType);
  }
}
