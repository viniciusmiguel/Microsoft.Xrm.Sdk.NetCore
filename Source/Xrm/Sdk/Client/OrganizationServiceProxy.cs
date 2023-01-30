/*
using Microsoft.Xrm.Sdk.Query;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>
  /// helper class that manages a ChannelFactory and serves up channels for sdk client use
  /// <remarks>For internal use only</remarks>
  /// </summary>
  public class OrganizationServiceProxy : ServiceProxy<IOrganizationService>, IOrganizationService
  {
    private static string _xrmSdkAssemblyFileVersion;

    internal bool OfflinePlayback { get; set; }

    public Guid CallerId { get; set; }

    public UserType UserType { get; set; }

    public Guid CallerRegardingObjectId { get; set; }

    internal int LanguageCodeOverride { get; set; }

    public string SyncOperationType { get; set; }

    internal string ClientAppName { get; set; }

    internal string ClientAppVersion { get; set; }

    public string SdkClientVersion { get; set; }

    internal OrganizationServiceProxy()
    {
    }

    public OrganizationServiceProxy(
      Uri uri,
      Uri homeRealmUri,
      ClientCredentials clientCredentials,
      ClientCredentials deviceCredentials)
      : base(uri, homeRealmUri, clientCredentials, deviceCredentials)
    {
    }

    public OrganizationServiceProxy(
      IServiceConfiguration<IOrganizationService> serviceConfiguration,
      SecurityTokenResponse securityTokenResponse)
      : base(serviceConfiguration, securityTokenResponse)
    {
    }

    public OrganizationServiceProxy(
      IServiceConfiguration<IOrganizationService> serviceConfiguration,
      ClientCredentials clientCredentials)
      : base(serviceConfiguration, clientCredentials)
    {
    }

    public OrganizationServiceProxy(
      IServiceManagement<IOrganizationService> serviceManagement,
      SecurityTokenResponse securityTokenResponse)
      : this(serviceManagement as IServiceConfiguration<IOrganizationService>, securityTokenResponse)
    {
    }

    public OrganizationServiceProxy(
      IServiceManagement<IOrganizationService> serviceManagement,
      ClientCredentials clientCredentials)
      : this(serviceManagement as IServiceConfiguration<IOrganizationService>, clientCredentials)
    {
    }

    /// <summary>
    /// This method will enable support for the default strong proxy types.
    /// 
    /// If you are using a shared Service Configuration instance, you must be careful if using
    /// </summary>
    public void EnableProxyTypes()
    {
      ClientExceptionHelper.ThrowIfNull(ServiceConfiguration, "ServiceConfiguration");
      var serviceConfiguration = ServiceConfiguration as OrganizationServiceConfiguration;
      ClientExceptionHelper.ThrowIfNull(serviceConfiguration, "orgConfig");
      serviceConfiguration.EnableProxyTypes();
    }

    /// <summary>
    /// This method will enable support for the strong proxy types exposed in the passed assembly.
    /// <param name="assembly">The assembly that will provide support for the desired strong types in the proxy.</param>
    /// </summary>
    public void EnableProxyTypes(Assembly assembly)
    {
      ClientExceptionHelper.ThrowIfNull(assembly, nameof (assembly));
      ClientExceptionHelper.ThrowIfNull(ServiceConfiguration, "ServiceConfiguration");
      var serviceConfiguration = ServiceConfiguration as OrganizationServiceConfiguration;
      ClientExceptionHelper.ThrowIfNull(serviceConfiguration, "orgConfig");
      serviceConfiguration.EnableProxyTypes(assembly);
    }

    /// <summary>
    /// Get's the file version of the Xrm Sdk assembly that is loaded in the current client domain.
    /// For Sdk clients called via the OrganizationServiceProxy this is the version of the local Microsoft.Xrm.Sdk dll used by the Client App.
    /// </summary>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Security", "CA2143:TransparentMethodsShouldNotDemandFxCopRule")]
    [SuppressMessage("Microsoft.Security", "CA2141:TransparentMethodsMustNotSatisfyLinkDemandsFxCopRule")]
    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    internal static string GetXrmSdkAssemblyFileVersion()
    {
      if (string.IsNullOrEmpty(_xrmSdkAssemblyFileVersion))
      {
        var strArray = new string[1]
        {
          "Microsoft.Xrm.Sdk.dll"
        };
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var str in strArray)
        {
          foreach (var assembly in assemblies)
          {
            if (assembly.ManifestModule.Name.Equals(str, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(assembly.Location) && File.Exists(assembly.Location))
            {
              _xrmSdkAssemblyFileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
              break;
            }
          }
        }
      }
      if (string.IsNullOrEmpty(_xrmSdkAssemblyFileVersion))
        _xrmSdkAssemblyFileVersion = "9.1.2.3";
      return _xrmSdkAssemblyFileVersion;
    }

    protected internal virtual Guid CreateCore(Entity entity)
    {
      var retry = new bool?();
      do
      {
        var forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
            return ServiceChannel.Channel.Create(entity);
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<OrganizationServiceFault> ex)
        {
          forceClose = true;
          retry = HandleFailover(ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
      return Guid.Empty;
    }

    protected internal virtual Entity RetrieveCore(string entityName, Guid id, ColumnSet columnSet)
    {
      var retry = new bool?();
      do
      {
        var forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
            return ServiceChannel.Channel.Retrieve(entityName, id, columnSet);
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<OrganizationServiceFault> ex)
        {
          forceClose = true;
          retry = HandleFailover(ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
      return null;
    }

    protected internal virtual void UpdateCore(Entity entity)
    {
      var retry = new bool?();
      do
      {
        var forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
          {
            ServiceChannel.Channel.Update(entity);
            break;
          }
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<OrganizationServiceFault> ex)
        {
          forceClose = true;
          retry = HandleFailover(ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
    }

    protected internal virtual void DeleteCore(string entityName, Guid id)
    {
      var retry = new bool?();
      do
      {
        var forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
          {
            ServiceChannel.Channel.Delete(entityName, id);
            break;
          }
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<OrganizationServiceFault> ex)
        {
          forceClose = true;
          retry = HandleFailover(ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
    }

    protected internal virtual OrganizationResponse ExecuteCore(OrganizationRequest request)
    {
      var retry = new bool?();
      do
      {
        var forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
            return ServiceChannel.Channel.Execute(request);
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<OrganizationServiceFault> ex)
        {
          forceClose = true;
          retry = HandleFailover(ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
      return null;
    }

    protected internal virtual void AssociateCore(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      var retry = new bool?();
      do
      {
        var forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
          {
            ServiceChannel.Channel.Associate(entityName, entityId, relationship, relatedEntities);
            break;
          }
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<OrganizationServiceFault> ex)
        {
          forceClose = true;
          retry = HandleFailover(ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
    }

    protected internal virtual void DisassociateCore(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      var retry = new bool?();
      do
      {
        var forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
          {
            ServiceChannel.Channel.Disassociate(entityName, entityId, relationship, relatedEntities);
            break;
          }
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<OrganizationServiceFault> ex)
        {
          forceClose = true;
          retry = HandleFailover(ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
    }

    protected internal virtual EntityCollection RetrieveMultipleCore(QueryBase query)
    {
      var retry = new bool?();
      do
      {
        var forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
            return ServiceChannel.Channel.RetrieveMultiple(query);
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException)
        {
          forceClose = true;
          retry = new bool?(HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<OrganizationServiceFault> ex)
        {
          forceClose = true;
          retry = HandleFailover(ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
      return null;
    }

    public Guid Create(Entity entity) => CreateCore(entity);

    public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) => RetrieveCore(entityName, id, columnSet);

    public void Update(Entity entity) => UpdateCore(entity);

    public void Delete(string entityName, Guid id) => DeleteCore(entityName, id);

    public OrganizationResponse Execute(OrganizationRequest request) => ExecuteCore(request);

    public void Associate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      AssociateCore(entityName, entityId, relationship, relatedEntities);
    }

    public void Disassociate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      DisassociateCore(entityName, entityId, relationship, relatedEntities);
    }

    public EntityCollection RetrieveMultiple(QueryBase query) => RetrieveMultipleCore(query);
  }
}
*/
