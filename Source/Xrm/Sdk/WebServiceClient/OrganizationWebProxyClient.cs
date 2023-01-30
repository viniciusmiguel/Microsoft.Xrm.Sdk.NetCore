/*
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Reflection;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  public class OrganizationWebProxyClient : 
    WebProxyClient<IOrganizationService>,
    IOrganizationService
  {
    public OrganizationWebProxyClient(Uri serviceUrl, bool useStrongTypes)
      : base(serviceUrl, useStrongTypes)
    {
    }

    public OrganizationWebProxyClient(Uri serviceUrl, Assembly strongTypeAssembly)
      : base(serviceUrl, strongTypeAssembly)
    {
    }

    public OrganizationWebProxyClient(Uri serviceUrl, TimeSpan timeout, bool useStrongTypes)
      : base(serviceUrl, timeout, useStrongTypes)
    {
    }

    public OrganizationWebProxyClient(Uri uri, TimeSpan timeout, Assembly strongTypeAssembly)
      : base(uri, timeout, strongTypeAssembly)
    {
    }

    internal bool OfflinePlayback { get; set; }

    public string SyncOperationType { get; set; }

    public Guid CallerId { get; set; }

    public UserType userType { get; set; }

    public Guid CallerRegardingObjectId { get; set; }

    internal int LanguageCodeOverride { get; set; }

    public void Associate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      AssociateCore(entityName, entityId, relationship, relatedEntities);
    }

    public Guid Create(Entity entity) => CreateCore(entity);

    public void Delete(string entityName, Guid id) => DeleteCore(entityName, id);

    public void Disassociate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      DisassociateCore(entityName, entityId, relationship, relatedEntities);
    }

    public OrganizationResponse Execute(OrganizationRequest request) => ExecuteCore(request);

    public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) => RetrieveCore(entityName, id, columnSet);

    public EntityCollection RetrieveMultiple(QueryBase query) => RetrieveMultipleCore(query);

    public void Update(Entity entity) => UpdateCore(entity);

    protected internal virtual Guid CreateCore(Entity entity) => ExecuteAction<Guid>(() => Channel.Create(entity));

    protected internal virtual Entity RetrieveCore(string entityName, Guid id, ColumnSet columnSet) => ExecuteAction<Entity>(() => Channel.Retrieve(entityName, id, columnSet));

    protected internal virtual void UpdateCore(Entity entity) => ExecuteAction(() => Channel.Update(entity));

    protected internal virtual void DeleteCore(string entityName, Guid id) => ExecuteAction(() => Channel.Delete(entityName, id));

    protected internal virtual OrganizationResponse ExecuteCore(OrganizationRequest request) => ExecuteAction<OrganizationResponse>(() => Channel.Execute(request));

    protected internal virtual void AssociateCore(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      ExecuteAction(() => Channel.Associate(entityName, entityId, relationship, relatedEntities));
    }

    protected internal virtual void DisassociateCore(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      ExecuteAction(() => Channel.Disassociate(entityName, entityId, relationship, relatedEntities));
    }

    protected internal virtual EntityCollection RetrieveMultipleCore(QueryBase query) => ExecuteAction<EntityCollection>(() => Channel.RetrieveMultiple(query));

    protected override WebProxyClientContextInitializer<IOrganizationService> CreateNewInitializer() => new OrganizationWebProxyClientContextInitializer(this);
  }
}
*/
