// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IdentityProviderLookup
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace Microsoft.Xrm.Sdk.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  internal sealed class IdentityProviderLookup
  {
    private static IdentityProviderLookup _instance;
    private readonly IdentityProviderDictionary _identityProviderDictionary = new();
    private const string OrgIdIdentityService = "{0}/GetUserRealm.srf";
    private const string OrgIdIdentityQuery = "login={0}&xml=1";

    public static IdentityProviderLookup Instance => _instance ?? (_instance = new IdentityProviderLookup());

    internal IdentityProviderDictionary IdentityProviderDictionary => _identityProviderDictionary;

    public static void Clear() => _instance = null;

    /// <summary>
    /// This lookup returns the service root url for the identity provider associated to the user principal name.
    /// </summary>
    /// <param name="host">The OrgID host to query</param>
    /// <param name="orgIdServiceRoot">The OrgID service root for non ADFS requests</param>
    /// <param name="userPrincipalName">The domainSuffix to look for.  May be empty.</param>
    /// <returns>The service root of the corresponding online provider, or the local ADFS WS-Trust metadata endpoint.</returns>
    [SuppressMessage("Microsoft.Security", "CA9885:AvoidHttpUtilityMethods", Justification = "This code is client code for external use with no platform dependencies.  We can't add those.")]
    [SuppressMessage("Microsoft.NetFramework.Analyzers", "CA3075:Insecure DTD processing in XML", Justification = "FxCop Bankruptcy")]
    public IdentityProvider GetIdentityProvider(
      Uri host,
      Uri orgIdServiceRoot,
      string userPrincipalName)
    {
      ClientExceptionHelper.ThrowIfNull(host, nameof (host));
      ClientExceptionHelper.ThrowIfNull(orgIdServiceRoot, nameof (orgIdServiceRoot));
      ClientExceptionHelper.ThrowIfNullOrEmpty(userPrincipalName, nameof (userPrincipalName));
      IdentityProvider identityProvider1;
      if (IdentityProviderDictionary.TryGetValue(userPrincipalName, out identityProvider1))
        return identityProvider1;
      var s = string.Format(CultureInfo.InvariantCulture, "login={0}&xml=1", HttpUtility.UrlEncode(userPrincipalName));
      var uriString = string.Format(CultureInfo.InvariantCulture, "{0}/GetUserRealm.srf", host.AbsoluteUri.TrimEnd('/'));
      try
      {
        var httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri(uriString));
        httpWebRequest.Method = "POST";
        httpWebRequest.ContentLength = s.Length;
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        RealmInfo realmInfo = null;
        using (var requestStream = httpWebRequest.GetRequestStream())
        {
          var bytes = Encoding.UTF8.GetBytes(s);
          requestStream.Write(bytes, 0, s.Length);
        }
        using (var response = (HttpWebResponse) httpWebRequest.GetResponse())
        {
          using (var responseStream = response.GetResponseStream())
          {
            using (var streamReader = new StreamReader(responseStream))
              realmInfo = new XmlSerializer(typeof (RealmInfo)).Deserialize(streamReader) as RealmInfo;
          }
        }
        if (realmInfo != null)
        {
          var identityProvider2 = ExtractIdentityProvider(orgIdServiceRoot, realmInfo);
          IdentityProviderDictionary[userPrincipalName] = identityProvider2;
          return identityProvider2;
        }
      }
      catch (WebException)
      {
      }
      return null;
    }

    private static IdentityProvider ExtractIdentityProvider(
      Uri orgIdServiceRoot,
      RealmInfo realmInfo)
    {
      IdentityProvider identityProvider1 = null;
      var namespaceType = realmInfo.NamespaceType;
      if (!string.IsNullOrEmpty(namespaceType))
      {
        if (string.Compare(namespaceType, "Managed", StringComparison.OrdinalIgnoreCase) == 0)
        {
          var identityProvider2 = new OnlineIdentityProvider();
          identityProvider2.IdentityProviderType = IdentityProviderType.OrgId;
          identityProvider2.ServiceUrl = orgIdServiceRoot;
          identityProvider1 = identityProvider2;
        }
        else if (string.Compare(namespaceType, "Federated", StringComparison.OrdinalIgnoreCase) == 0)
        {
          if (string.IsNullOrEmpty(realmInfo.MetadataUrl))
          {
            var identityProvider3 = new OnlineIdentityProvider();
            identityProvider3.IdentityProviderType = IdentityProviderType.LiveId;
            identityProvider3.ServiceUrl = new Uri(realmInfo.TokenServiceAuthenticationUrl);
            identityProvider1 = identityProvider3;
          }
          else
          {
            var identityProvider4 = new LocalIdentityProvider();
            identityProvider4.IdentityProviderType = IdentityProviderType.ADFS;
            identityProvider4.ServiceUrl = new Uri(realmInfo.MetadataUrl);
            identityProvider1 = identityProvider4;
          }
        }
      }
      return identityProvider1;
    }
  }
}
