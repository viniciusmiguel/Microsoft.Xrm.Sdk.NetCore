// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.RealmInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Xml.Serialization;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>Must be public for de-serialization</summary>
  public sealed class RealmInfo
  {
    public string State { get; set; }

    public string UserState { get; set; }

    public string LogOn { get; set; }

    public string FederationGlobalVersion { get; set; }

    public string DomainName { get; set; }

    [XmlElement("AuthURL")]
    public string AuthorizationUrl { get; set; }

    [XmlElement("IsFederatedNS")]
    public bool IsFederatedNamespace { get; set; }

    [XmlElement("STSAuthURL")]
    public string TokenServiceAuthenticationUrl { get; set; }

    public int FederationTier { get; set; }

    public string FederationBrandName { get; set; }

    [XmlElement("AllowFedUsersWLIDSignIn")]
    public bool AllowFedUsersLiveIdSignIn { get; set; }

    public string Certificate { get; set; }

    [XmlElement("MEXURL")]
    public string MetadataUrl { get; set; }

    [XmlElement("SAML_AuthURL")]
    public string SamlAuthUrl { get; set; }

    public int PreferredProtocol { get; set; }

    [XmlIgnore]
    [XmlElement("EDUDomainFlags")]
    public int EduDomains { get; set; }

    [XmlElement("NameSpaceType")]
    public string NamespaceType { get; set; }
  }
}
