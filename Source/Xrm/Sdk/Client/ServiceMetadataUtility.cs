// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceMetadataUtility
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Crm.Protocols.WSTrust.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// 	Handles retrieving/making use of service metadata information.
  /// </summary>
  internal static class ServiceMetadataUtility
  {
    public static IssuerEndpointDictionary RetrieveIssuerEndpoints(
      EndpointAddress issuerMetadataAddress)
    {
      var endpointDictionary = new IssuerEndpointDictionary();
      var metadata = CreateMetadataClient(issuerMetadataAddress.Uri.Scheme).GetMetadata(issuerMetadataAddress.Uri, MetadataExchangeClientMode.HttpGet);
      if (metadata != null)
      {
        foreach (var importAllEndpoint in new WsdlImporter(metadata).ImportAllEndpoints())
        {
          if (!(importAllEndpoint.Binding is NetTcpBinding))
          {
            var serviceCredentialType = TokenServiceCredentialType.None;
            var trustVersion = TrustVersion.Default;
            if (importAllEndpoint.Binding is WS2007HttpBinding binding)
            {
              var securityBindingElement = binding.CreateBindingElements().Find<SecurityBindingElement>();
              if (securityBindingElement != null)
              {
                trustVersion = securityBindingElement.MessageSecurityVersion.TrustVersion;
                if (trustVersion == TrustVersion.WSTrust13)
                {
                  if (binding.Security.Message.ClientCredentialType == MessageCredentialType.UserName)
                    serviceCredentialType = TokenServiceCredentialType.Username;
                  else if (binding.Security.Message.ClientCredentialType == MessageCredentialType.Certificate)
                    serviceCredentialType = TokenServiceCredentialType.Certificate;
                  else if (binding.Security.Message.ClientCredentialType == MessageCredentialType.Windows)
                    serviceCredentialType = TokenServiceCredentialType.Windows;
                }
              }
            }
            else
            {
              var securityElement = importAllEndpoint.Binding.CreateBindingElements().Find<SecurityBindingElement>();
              if (securityElement != null)
              {
                trustVersion = securityElement.MessageSecurityVersion.TrustVersion;
                if (trustVersion == TrustVersion.WSTrust13)
                {
                  var issuedTokenParameters = GetIssuedTokenParameters(securityElement);
                  if (issuedTokenParameters != null)
                  {
                    if (issuedTokenParameters.KeyType == SecurityKeyType.SymmetricKey)
                      serviceCredentialType = TokenServiceCredentialType.SymmetricToken;
                    else if (issuedTokenParameters.KeyType == SecurityKeyType.AsymmetricKey)
                      serviceCredentialType = TokenServiceCredentialType.AsymmetricToken;
                    else if (issuedTokenParameters.KeyType == SecurityKeyType.BearerKey)
                      serviceCredentialType = TokenServiceCredentialType.Bearer;
                  }
                  else if (GetKerberosTokenParameters(securityElement) != null)
                    serviceCredentialType = TokenServiceCredentialType.Kerberos;
                }
              }
            }
            if (serviceCredentialType != TokenServiceCredentialType.None)
            {
              var key = serviceCredentialType.ToString();
              if (!endpointDictionary.ContainsKey(key))
                endpointDictionary.Add(key, new IssuerEndpoint()
                {
                  IssuerAddress = importAllEndpoint.Address,
                  IssuerBinding = importAllEndpoint.Binding,
                  IssuerMetadataAddress = issuerMetadataAddress,
                  CredentialType = serviceCredentialType,
                  TrustVersion = trustVersion
                });
            }
          }
        }
      }
      return endpointDictionary;
    }

    [SuppressMessage("Microsoft.Security", "CA2141:TransparentMethodsMustNotSatisfyLinkDemandsFxCopRule")]
    public static IssuerEndpointDictionary RetrieveLiveIdIssuerEndpoints(
      IdentityProviderTrustConfiguration identityProviderTrustConfiguration)
    {
      var endpointDictionary = new IssuerEndpointDictionary();
      endpointDictionary.Add(TokenServiceCredentialType.Username.ToString(), new IssuerEndpoint()
      {
        CredentialType = TokenServiceCredentialType.Username,
        IssuerAddress = new EndpointAddress(identityProviderTrustConfiguration.Endpoint.AbsoluteUri),
        IssuerBinding = identityProviderTrustConfiguration.Binding
      });
      var tokenWsTrustBinding1 = new IssuedTokenWSTrustBinding();
      tokenWsTrustBinding1.TrustVersion = identityProviderTrustConfiguration.TrustVersion;
      tokenWsTrustBinding1.SecurityMode = identityProviderTrustConfiguration.SecurityMode;
      var tokenWsTrustBinding2 = tokenWsTrustBinding1;
      tokenWsTrustBinding2.KeyType = SecurityKeyType.BearerKey;
      endpointDictionary.Add(TokenServiceCredentialType.SymmetricToken.ToString(), new IssuerEndpoint()
      {
        CredentialType = TokenServiceCredentialType.SymmetricToken,
        IssuerAddress = new EndpointAddress(identityProviderTrustConfiguration.Endpoint.AbsoluteUri),
        IssuerBinding = tokenWsTrustBinding2
      });
      return endpointDictionary;
    }

    public static IssuerEndpointDictionary RetrieveDefaultIssuerEndpoint(
      AuthenticationProviderType authenticationProviderType,
      IssuerEndpoint issuer)
    {
      var endpointDictionary = new IssuerEndpointDictionary();
      if (issuer != null && issuer.IssuerAddress != null)
      {
        TokenServiceCredentialType serviceCredentialType;
        switch (authenticationProviderType)
        {
          case AuthenticationProviderType.Federation:
            serviceCredentialType = TokenServiceCredentialType.Kerberos;
            break;
          case AuthenticationProviderType.OnlineFederation:
            serviceCredentialType = TokenServiceCredentialType.Username;
            break;
          default:
            serviceCredentialType = TokenServiceCredentialType.Kerberos;
            break;
        }
        endpointDictionary.Add(serviceCredentialType.ToString(), new IssuerEndpoint()
        {
          CredentialType = serviceCredentialType,
          IssuerAddress = issuer.IssuerAddress,
          IssuerBinding = issuer.IssuerBinding
        });
      }
      return endpointDictionary;
    }

    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "We don't care about the actual exception, just want to ignore it for now.")]
    public static IssuerEndpointDictionary RetrieveIssuerEndpoints(
      AuthenticationProviderType authenticationProviderType,
      ServiceEndpointDictionary endpoints,
      bool queryMetadata)
    {
      foreach (var serviceEndpoint in endpoints.Values)
      {
        try
        {
          var issuer = GetIssuer(serviceEndpoint.Binding);
          if (issuer != null)
            return queryMetadata && issuer.IssuerMetadataAddress != null ? RetrieveIssuerEndpoints(issuer.IssuerMetadataAddress) : RetrieveDefaultIssuerEndpoint(authenticationProviderType, issuer);
        }
        catch (Exception)
        {
        }
      }
      return new IssuerEndpointDictionary();
    }

    public static IssuerEndpoint GetIssuer(Binding binding)
    {
      if (binding == null)
        return null;
      var issuedTokenParameters = GetIssuedTokenParameters(binding.CreateBindingElements().Find<SecurityBindingElement>());
      if (issuedTokenParameters == null)
        return null;
      return new IssuerEndpoint()
      {
        IssuerAddress = issuedTokenParameters.IssuerAddress,
        IssuerBinding = issuedTokenParameters.IssuerBinding,
        IssuerMetadataAddress = issuedTokenParameters.IssuerMetadataAddress
      };
    }

    private static KerberosSecurityTokenParameters GetKerberosTokenParameters(
      SecurityBindingElement securityElement)
    {
      return securityElement != null && securityElement.EndpointSupportingTokenParameters != null && securityElement.EndpointSupportingTokenParameters.Endorsing != null && securityElement.EndpointSupportingTokenParameters.Endorsing.Count > 0 ? securityElement.EndpointSupportingTokenParameters.Endorsing[0] as KerberosSecurityTokenParameters : null;
    }

    private static IssuedSecurityTokenParameters GetIssuedTokenParameters(
      SecurityBindingElement securityElement)
    {
      if (securityElement != null && securityElement.EndpointSupportingTokenParameters != null)
      {
        if (securityElement.EndpointSupportingTokenParameters.Endorsing != null && securityElement.EndpointSupportingTokenParameters.Endorsing.Count > 0)
        {
          if (securityElement.EndpointSupportingTokenParameters.Endorsing[0] is IssuedSecurityTokenParameters issuedTokenParameters)
            return issuedTokenParameters;
          if (securityElement.EndpointSupportingTokenParameters.Endorsing[0] is SecureConversationSecurityTokenParameters securityTokenParameters)
          {
            if (securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Endorsing.Count > 0)
              return securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Endorsing[0] as IssuedSecurityTokenParameters;
            if (securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Signed.Count > 0)
              return securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Signed[0] as IssuedSecurityTokenParameters;
          }
        }
        else if (securityElement.EndpointSupportingTokenParameters.Signed != null && securityElement.EndpointSupportingTokenParameters.Signed.Count > 0)
          return securityElement.EndpointSupportingTokenParameters.Signed[0] as IssuedSecurityTokenParameters;
      }
      return null;
    }

    public static CustomBinding SetIssuer(Binding binding, IssuerEndpoint issuerEndpoint)
    {
      var bindingElements = binding.CreateBindingElements();
      var issuedTokenParameters = GetIssuedTokenParameters(bindingElements.Find<SecurityBindingElement>());
      if (issuedTokenParameters != null)
      {
        issuedTokenParameters.IssuerAddress = issuerEndpoint.IssuerAddress;
        issuedTokenParameters.IssuerBinding = issuerEndpoint.IssuerBinding;
        if (issuerEndpoint.IssuerMetadataAddress != null)
          issuedTokenParameters.IssuerMetadataAddress = issuerEndpoint.IssuerMetadataAddress;
      }
      return new CustomBinding(bindingElements);
    }

    private static void ParseEndpoints(
      ServiceEndpointDictionary serviceEndpoints,
      ServiceEndpointCollection serviceEndpointCollection)
    {
      serviceEndpoints.Clear();
      if (serviceEndpointCollection == null)
        return;
      foreach (var serviceEndpoint in serviceEndpointCollection)
      {
        if (IsEndpointSupported(serviceEndpoint))
          serviceEndpoints.Add(serviceEndpoint.Name, serviceEndpoint);
      }
    }

    private static bool IsEndpointSupported(ServiceEndpoint endpoint) => endpoint != null && !endpoint.Address.Uri.AbsolutePath.EndsWith("web", StringComparison.OrdinalIgnoreCase);

    internal static ServiceEndpointMetadata RetrieveServiceEndpointMetadata(
      Type contractType,
      Uri serviceUri,
      bool checkForSecondary)
    {
      var serviceEndpointMetadata = new ServiceEndpointMetadata();
      serviceEndpointMetadata.ServiceUrls = ServiceConfiguration<IOrganizationService>.CalculateEndpoints(serviceUri);
      if (!checkForSecondary)
        serviceEndpointMetadata.ServiceUrls.AlternateEndpoint = null;
      var numberFromAssembly = GetSDKVersionNumberFromAssembly();
      var address = new Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}&sdkversion={2}", serviceUri.AbsoluteUri, "?wsdl", numberFromAssembly.ToString(2)));
      var metadataClient = CreateMetadataClient(address.Scheme);
      if (metadataClient != null)
      {
        try
        {
          serviceEndpointMetadata.ServiceMetadata = metadataClient.GetMetadata(address, MetadataExchangeClientMode.HttpGet);
        }
        catch (InvalidOperationException ex)
        {
          var flag = true;
          if (checkForSecondary && ex.InnerException is WebException innerException && (innerException.Status == WebExceptionStatus.NameResolutionFailure || innerException.Status == WebExceptionStatus.Timeout) && serviceEndpointMetadata.ServiceUrls != null)
          {
            if (serviceEndpointMetadata.ServiceUrls.PrimaryEndpoint == serviceUri)
              flag = TryRetrieveMetadata(metadataClient, new Uri(serviceEndpointMetadata.ServiceUrls.AlternateEndpoint.AbsoluteUri + "?wsdl"), serviceEndpointMetadata);
            else if (serviceEndpointMetadata.ServiceUrls.AlternateEndpoint == serviceUri)
              flag = TryRetrieveMetadata(metadataClient, new Uri(serviceEndpointMetadata.ServiceUrls.PrimaryEndpoint.AbsoluteUri + "?wsdl"), serviceEndpointMetadata);
          }
          if (flag)
            throw;
        }
      }
      ClientExceptionHelper.ThrowIfNull(serviceEndpointMetadata.ServiceMetadata, "STS Metadata");
      var contractCollection = CreateContractCollection(contractType);
      if (contractCollection != null)
      {
        var importer = new WsdlImporter(serviceEndpointMetadata.ServiceMetadata);
        var importExtensions = importer.WsdlImportExtensions;
        var policyImporter = AddSecurityBindingToPolicyImporter(importer);
        var wsdlImporter = new WsdlImporter(serviceEndpointMetadata.ServiceMetadata, policyImporter, importExtensions);
        foreach (var contract in contractCollection)
          wsdlImporter.KnownContracts.Add(GetPortTypeQName(contract), contract);
        var serviceEndpointCollection = wsdlImporter.ImportAllEndpoints();
        if (wsdlImporter.Errors.Count > 0)
        {
          foreach (var error in wsdlImporter.Errors)
            serviceEndpointMetadata.MetadataConversionErrors.Add(error);
        }
        ParseEndpoints(serviceEndpointMetadata.ServiceEndpoints, serviceEndpointCollection);
      }
      return serviceEndpointMetadata;
    }

    private static Version GetSDKVersionNumberFromAssembly()
    {
      Version result;
      if (!Version.TryParse(OrganizationServiceProxy.GetXrmSdkAssemblyFileVersion(), out result))
        result = new Version("0.0");
      return result;
    }

    /// <summary>
    /// Returns a list of policy import extensions in the importer parameter and adds a SecurityBindingElementImporter if not already present in the list.
    /// </summary>
    /// <param name="importer">The WsdlImporter object</param>
    /// <returns>The list of PolicyImportExtension objects</returns>
    private static List<IPolicyImportExtension> AddSecurityBindingToPolicyImporter(
      WsdlImporter importer)
    {
      var policyImporter = new List<IPolicyImportExtension>();
      var importExtensions = importer.PolicyImportExtensions;
      var importer1 = importExtensions.Find<SecurityBindingElementImporter>();
      if (importer1 != null)
        importExtensions.Remove<SecurityBindingElementImporter>();
      else
        importer1 = new SecurityBindingElementImporter();
      policyImporter.Add(new AuthenticationPolicyImporter(importer1));
      policyImporter.AddRange(importExtensions);
      return policyImporter;
    }

    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Need to catch any exception here and fail.")]
    private static bool TryRetrieveMetadata(
      MetadataExchangeClient mcli,
      Uri serviceEndpoint,
      ServiceEndpointMetadata serviceEndpointMetadata)
    {
      var flag = true;
      try
      {
        serviceEndpointMetadata.ServiceMetadata = mcli.GetMetadata(serviceEndpoint, MetadataExchangeClientMode.HttpGet);
        serviceEndpointMetadata.ServiceUrls.GeneratedFromAlternate = true;
        flag = false;
      }
      catch
      {
      }
      return flag;
    }

    private static XmlQualifiedName GetPortTypeQName(ContractDescription contract) => new(contract.Name, contract.Namespace);

    private static Collection<ContractDescription> CreateContractCollection(Type contract) => new()
    {
      ContractDescription.GetContract(contract)
    };

    private static MetadataExchangeClient CreateMetadataClient(string scheme)
    {
      var mexBinding = string.Compare(scheme, "https", StringComparison.OrdinalIgnoreCase) != 0 ? MetadataExchangeBindings.CreateMexHttpBinding() as WSHttpBinding : MetadataExchangeBindings.CreateMexHttpsBinding() as WSHttpBinding;
      mexBinding.MaxReceivedMessageSize = int.MaxValue;
      mexBinding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
      return new MetadataExchangeClient(mexBinding)
      {
        ResolveMetadataReferences = true,
        MaximumResolvedReferences = 100
      };
    }

    public static void ReplaceEndpointAddress(ServiceEndpoint endpoint, Uri adddress) => endpoint.Address = new EndpointAddressBuilder(endpoint.Address)
    {
      Uri = adddress
    }.ToEndpointAddress();

    internal static void AdjustUserNameForWindows(ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull(clientCredentials, nameof (clientCredentials));
      if (string.IsNullOrWhiteSpace(clientCredentials.UserName.UserName))
        return;
      NetworkCredential networkCredential;
      if (clientCredentials.UserName.UserName.IndexOf('@') > -1)
      {
        var strArray = clientCredentials.UserName.UserName.Split('@');
        networkCredential = strArray.Length <= 1 ? new NetworkCredential(strArray[0], clientCredentials.UserName.Password) : new NetworkCredential(strArray[0], clientCredentials.UserName.Password, strArray[1]);
      }
      else if (clientCredentials.UserName.UserName.IndexOf('\\') > -1)
      {
        var strArray = clientCredentials.UserName.UserName.Split('\\');
        networkCredential = strArray.Length <= 1 ? new NetworkCredential(strArray[0], clientCredentials.UserName.Password) : new NetworkCredential(strArray[1], clientCredentials.UserName.Password, strArray[0]);
      }
      else
        networkCredential = new NetworkCredential(clientCredentials.UserName.UserName, clientCredentials.UserName.Password);
      clientCredentials.Windows.ClientCredential = networkCredential;
      clientCredentials.UserName.UserName = string.Empty;
      clientCredentials.UserName.Password = string.Empty;
    }
  }
}
