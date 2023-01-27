// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Linq;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>The runtime context of the data service.</summary>
  [SuppressMessage("Microsoft.Security", "CA9881:ClassesShouldBeSealed", Justification = "This class is used as base by crmsvcutil")]
  [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
  public class OrganizationServiceContext : IDisposable
  {
    private readonly IOrganizationService _service;
    private readonly Dictionary<Entity, EntityDescriptor> _descriptors;
    private readonly Dictionary<EntityReference, EntityDescriptor> _identityToDescriptor;
    private readonly Dictionary<LinkDescriptor, LinkDescriptor> _bindings;
    private readonly HashSet<Entity> _roots;
    private readonly bool _trackEntityChanges;
    private ConcurrencyBehavior _concurrencyBehavior;
    internal static SequentialGuidOverrideDelegate SequentialGuidOverride;

    protected virtual IQueryProvider QueryProvider { get; private set; }

    public MergeOption MergeOption { get; set; }

    public SaveChangesOptions SaveChangesDefaultOptions { get; set; }

    public ConcurrencyBehavior ConcurrencyBehavior
    {
      get => _concurrencyBehavior;
      set => _concurrencyBehavior = value;
    }

    public OrganizationServiceContext(IOrganizationService service)
      : this(service, true)
    {
    }

    internal OrganizationServiceContext(IOrganizationService service, bool trackEntityChanges)
    {
      _service = service != null ? service : throw new ArgumentNullException(nameof (service));
      _descriptors = new Dictionary<Entity, EntityDescriptor>(EqualityComparer<Entity>.Default);
      _identityToDescriptor = new Dictionary<EntityReference, EntityDescriptor>(EqualityComparer<EntityReference>.Default);
      _bindings = new Dictionary<LinkDescriptor, LinkDescriptor>(LinkDescriptor.EquivalenceComparer);
      _roots = new HashSet<Entity>(EqualityComparer<Entity>.Default);
      _trackEntityChanges = trackEntityChanges;
      QueryProvider = new QueryProvider(this);
      MergeOption = MergeOption.AppendOnly;
      _concurrencyBehavior = ConcurrencyBehavior.Default;
    }

    ~OrganizationServiceContext() => Dispose(false);

    /// <summary>Binds to the set of entities of a specified type.</summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public IQueryable<TEntity> CreateQuery<TEntity>() where TEntity : Entity
    {
      CheckEntitySubclass(typeof (TEntity));
      return CreateQuery<TEntity>(QueryProvider, KnownProxyTypesProvider.GetInstance(true).GetNameForType(typeof (TEntity)));
    }

    /// <summary>Binds to the set of dynamic entities.</summary>
    /// <param name="entityLogicalName"></param>
    /// <returns></returns>
    public IQueryable<Entity> CreateQuery(string entityLogicalName) => !string.IsNullOrWhiteSpace(entityLogicalName) ? CreateQuery<Entity>(QueryProvider, entityLogicalName) : throw new ArgumentNullException(nameof (entityLogicalName));

    protected virtual IQueryable<TEntity> CreateQuery<TEntity>(
      IQueryProvider provider,
      string entityLogicalName)
    {
      return new Query<TEntity>(provider, entityLogicalName);
    }

    /// <summary>
    /// Loads the related entity collection for the specified relationship.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="propertyName"></param>
    public void LoadProperty(Entity entity, string propertyName)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      if (string.IsNullOrWhiteSpace(propertyName))
        throw new ArgumentNullException(nameof (propertyName));
      var type = entity.GetType();
      CheckEntitySubclass(type);
      var property = type.GetProperty(propertyName);
      var schemaNameAttribute = !(property == null) ? property.GetFirstOrDefaultCustomAttribute<RelationshipSchemaNameAttribute>() : throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The property '{0}' does not exist on the entity '{1}'.", propertyName, entity));
      if (schemaNameAttribute != null)
      {
        var relationship = schemaNameAttribute.Relationship;
        LoadProperty(entity, relationship);
      }
      else
        LoadProperty(entity, property.GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>() ?? throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The closed type '{0}' does not have a corresponding '{1}' settable property.", type, propertyName)));
    }

    /// <summary>
    /// Loads the related entity collection for the specified relationship.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="relationship"></param>
    public void LoadProperty(Entity entity, Relationship relationship)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      EntityDescriptor entityDescriptor;
      var isAttached = _descriptors.TryGetValue(entity, out entityDescriptor);
      if (isAttached)
      {
        if (MergeOption == MergeOption.NoTracking)
          throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The context can not load the related collection or reference for tracked entities while the 'MergeOption' is set to 'NoTracking'. Change the 'MergeOption' value or detach the '{0}' entity.", entity.LogicalName));
        if (entityDescriptor.State == EntityStates.Added)
          throw new InvalidOperationException("The context can not load the related collection or reference for entities in the added state.");
      }
      else if (MergeOption != MergeOption.NoTracking)
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The context can not load the related collection or reference for untracked entities while the 'MergeOption' is not set to 'NoTracking'. Change the 'MergeOption' to 'NoTracking' or attach the '{0}' entity.", entity.LogicalName));
      var relatedEntities = GetRelatedEntities(entity, relationship);
      if (relatedEntities == null)
        return;
      foreach (var entity1 in relatedEntities.Entities)
      {
        var target = MergeEntity(entity1);
        MergeRelationship(entity, relationship, target, isAttached);
      }
    }

    private void LoadProperty(Entity entity, AttributeLogicalNameAttribute attribute)
    {
      if (MergeOption != MergeOption.NoTracking && EnsureTracked(entity, nameof (entity)).State == EntityStates.Added)
        throw new InvalidOperationException("The context can not load the related collection or reference for entities in the added state.");
      var logicalName = attribute.LogicalName;
      var retrieveResponse = (RetrieveResponse) Execute(new RetrieveRequest()
      {
        Target = new EntityReference(entity.LogicalName, entity.Id),
        ColumnSet = new ColumnSet(new string[1]
        {
          logicalName
        })
      });
      if (retrieveResponse == null || retrieveResponse.Entity == null || !retrieveResponse.Entity.Attributes.Contains(logicalName))
        return;
      entity.Attributes[logicalName] = retrieveResponse.Entity.Attributes[logicalName];
    }

    public void Attach(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      ValidateAttach(entity, EntityStates.Unchanged);
      AttachEntityGraph(entity, EntityStates.Unchanged);
    }

    public bool Detach(Entity entity) => entity != null ? Detach(entity, true) : throw new ArgumentNullException(nameof (entity));

    public bool Detach(Entity entity, bool recursive)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      EntityDescriptor existingEntity;
      if (!_descriptors.TryGetValue(entity, out existingEntity))
        return false;
      if (!recursive)
      {
        DetachEntityTracking(existingEntity);
        foreach (var traverseRelatedEntity in TraverseRelatedEntities(entity))
        {
          LinkDescriptor existingLink;
          if (_bindings.TryGetValue(new LinkDescriptor(traverseRelatedEntity.Item1, traverseRelatedEntity.Item2, traverseRelatedEntity.Item3), out existingLink))
            DetachLinkTracking(existingLink);
        }
        foreach (var existingLink in GetTargetingLinks(entity).ToList<LinkDescriptor>())
          DetachLinkTrackingAndRemoveEntity(existingLink);
      }
      else
      {
        foreach (var target in DetachEntityGraph(entity))
        {
          foreach (var existingLink in GetTargetingLinks(target).ToList<LinkDescriptor>())
            DetachLinkTrackingAndRemoveEntity(existingLink);
        }
      }
      return true;
    }

    public void AttachLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      EnsureRelatable(source, relationship, target, EntityStates.Unchanged);
      var linkDescriptor = new LinkDescriptor(source, relationship, target);
      if (IsAttached(linkDescriptor))
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The context is already tracking the '{0}' relationship.", relationship.SchemaName));
      AttachLinkTracking(linkDescriptor);
      AddRelationshipIfNotContains(source, relationship, target);
    }

    public bool DetachLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      LinkDescriptor existingLink;
      if (!_bindings.TryGetValue(new LinkDescriptor(source, relationship, target), out existingLink))
        return false;
      DetachLinkTrackingAndRemoveEntity(existingLink);
      return true;
    }

    public IEnumerable<Entity> GetAttachedEntities() => _descriptors.Values.Select<EntityDescriptor, Entity>(d => d.Entity);

    public bool IsAttached(Entity entity) => entity != null ? _descriptors.ContainsKey(entity) : throw new ArgumentNullException(nameof (entity));

    public bool IsDeleted(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      EntityDescriptor entityDescriptor;
      return _descriptors.TryGetValue(entity, out entityDescriptor) && entityDescriptor.State == EntityStates.Deleted;
    }

    public bool IsAttached(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      return IsAttached(new LinkDescriptor(source, relationship, target));
    }

    private bool IsAttached(LinkDescriptor link) => _bindings.ContainsKey(link);

    public bool IsDeleted(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      LinkDescriptor linkDescriptor;
      return _bindings.TryGetValue(new LinkDescriptor(source, relationship, target), out linkDescriptor) && linkDescriptor.State == EntityStates.Deleted;
    }

    [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "FxCopy Bankruptcy", MessageId = "")]
    private void ValidateAttach(Entity graph, EntityStates state) => TraverseEntityGraph(graph, entity =>
    {
      if (entity == graph)
      {
        if (IsAttached(entity))
          throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The context is already tracking the '{0}' entity.", entity.LogicalName));
      }
      else if (IsAttached(entity))
        return;
      EntityState? entityState1;
      if (state == EntityStates.Unchanged)
      {
        entityState1 = entity.EntityState;
        if (entityState1.HasValue)
        {
          entityState1 = entity.EntityState;
          var entityState2 = EntityState.Unchanged;
          if (!(entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue))
            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The '{0}' entity must be in the default (null) or unchanged state.", entity.LogicalName));
        }
      }
      if (state == EntityStates.Added)
      {
        entityState1 = entity.EntityState;
        if (entityState1.HasValue)
        {
          entityState1 = entity.EntityState;
          var entityState3 = EntityState.Created;
          if (!(entityState1.GetValueOrDefault() == entityState3 & entityState1.HasValue))
            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The '{0}' entity must be in the default (null) or created state.", entity.LogicalName));
        }
      }
      if (state != EntityStates.Added && entity.Id == Guid.Empty)
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The '{0}' entity has an empty ID.", entity.LogicalName));
      if (entity.Id != Guid.Empty && _identityToDescriptor.TryGetValue(entity.ToEntityReference(), out var _))
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The context is already tracking a different '{0}' entity with the same identity.", entity.LogicalName));
      if (entity.IsReadOnly)
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The '{0}' entity is already attached to a context.", entity.LogicalName));
    }, (source, relationship, target) => { }).ToList<Entity>();

    [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "FxCopy Bankruptcy", MessageId = "")]
    private void AttachEntityGraph(Entity graph, EntityStates state) => TraverseEntityGraph(graph, entity => AttachEntityTracking(new EntityDescriptor(state, entity.ToEntityReference(), entity)), (source, relationship, target) => AttachLinkTracking(state, source, relationship, target)).ToList<Entity>();

    private void AttachEntityTracking(EntityDescriptor newEntity)
    {
      if (IsAttached(newEntity.Entity))
        return;
      if (newEntity.Identity.Id != Guid.Empty)
        _identityToDescriptor.Add(newEntity.Identity, newEntity);
      _descriptors.Add(newEntity.Entity, newEntity);
      if (_trackEntityChanges)
        newEntity.Entity.IsReadOnly = true;
      newEntity.Entity.SetEntityStateInternal(MapEntityState(newEntity.State) ?? newEntity.Entity.EntityState);
      OnBeginEntityTracking(newEntity.Entity);
    }

    private static EntityState? MapEntityState(EntityStates state)
    {
      switch (state)
      {
        case EntityStates.Unchanged:
          return new EntityState?(EntityState.Unchanged);
        case EntityStates.Added:
          return new EntityState?(EntityState.Created);
        case EntityStates.Modified:
          return new EntityState?(EntityState.Changed);
        default:
          return new EntityState?();
      }
    }

    private void AttachLinkTracking(
      EntityStates state,
      Entity source,
      Relationship relationship,
      Entity target)
    {
      var entityState1 = source.EntityState;
      var entityState2 = EntityState.Created;
      int num;
      if (!(entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue))
      {
        var entityState3 = target.EntityState;
        var entityState4 = EntityState.Created;
        if (!(entityState3.GetValueOrDefault() == entityState4 & entityState3.HasValue))
        {
          num = (int) state;
          goto label_4;
        }
      }
      num = 4;
label_4:
      var state1 = (EntityStates) num;
      if (state1 == EntityStates.Added)
        _roots.Add(source);
      AttachLinkTracking(new LinkDescriptor(state1, source, relationship, target));
    }

    private void AttachLinkTracking(LinkDescriptor newLink)
    {
      if (IsAttached(newLink.Source, newLink.Relationship, newLink.Target))
        return;
      _bindings.Add(newLink, newLink);
      OnBeginLinkTracking(newLink.Source, newLink.Relationship, newLink.Target);
    }

    private IEnumerable<Entity> DetachEntityGraph(Entity graph) => TraverseEntityGraph(graph, new Action<EntityDescriptor>(DetachEntityTracking), new Action<LinkDescriptor>(DetachLinkTracking)).ToList<Entity>();

    private void DetachEntityTracking(EntityDescriptor existingEntity)
    {
      if (_trackEntityChanges)
        existingEntity.Entity.IsReadOnly = false;
      existingEntity.State = EntityStates.Detached;
      var num = _descriptors.Remove(existingEntity.Entity) ? 1 : 0;
      _identityToDescriptor.Remove(existingEntity.Entity.ToEntityReference());
      _roots.Remove(existingEntity.Entity);
      if (num == 0)
        return;
      OnEndEntityTracking(existingEntity.Entity);
    }

    private void DetachLinkTracking(LinkDescriptor existingLink)
    {
      existingLink.State = EntityStates.Detached;
      if (!_bindings.Remove(existingLink))
        return;
      OnEndLinkTracking(existingLink.Source, existingLink.Relationship, existingLink.Target);
    }

    private void DetachLinkTrackingAndRemoveEntity(LinkDescriptor existingLink)
    {
      DetachLinkTracking(existingLink);
      RemoveRelationshipIfContains(existingLink);
    }

    public void AddLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      EnsureRelatable(source, relationship, target, EntityStates.Added);
      var linkDescriptor = new LinkDescriptor(EntityStates.Added, source, relationship, target);
      if (IsAttached(linkDescriptor))
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The context is already tracking the '{0}' relationship.", relationship.SchemaName));
      AttachLinkTracking(linkDescriptor);
      AddRelationshipIfNotContains(source, relationship, target);
      _roots.Add(source);
    }

    public void DeleteLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      var flag = EnsureRelatable(source, relationship, target, EntityStates.Deleted);
      var linkDescriptor = new LinkDescriptor(source, relationship, target);
      LinkDescriptor existingLink;
      if (_bindings.TryGetValue(linkDescriptor, out existingLink) && existingLink.State == EntityStates.Added)
      {
        DeleteLinkTrackingAndRemoveEntity(existingLink);
      }
      else
      {
        if (flag)
          throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "One or both of the ends of the '{0}' relationship is in the added state.", relationship.SchemaName));
        if (existingLink == null)
        {
          AttachLinkTracking(linkDescriptor);
          existingLink = linkDescriptor;
        }
        if (existingLink.State == EntityStates.Deleted)
          return;
        existingLink.State = EntityStates.Deleted;
        RemoveRelationshipIfContains(existingLink);
      }
    }

    public void AddObject(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      ValidateAttach(entity, EntityStates.Added);
      AttachEntityGraph(entity, EntityStates.Added);
      _roots.Add(entity);
    }

    public void AddRelatedObject(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      if (EnsureTracked(source, nameof (source)).State == EntityStates.Deleted)
        throw new InvalidOperationException("AddRelatedObject method only works if the source entity is in a non-deleted state.");
      AddObject(target);
      AddLink(source, relationship, target);
    }

    public void DeleteObject(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      DeleteObject(entity, false);
    }

    public void DeleteObject(Entity entity, bool recursive)
    {
      var existingEntity = entity != null ? EnsureTracked(entity, nameof (entity)) : throw new ArgumentNullException(nameof (entity));
      if (!recursive)
      {
        DeleteEntityTracking(existingEntity);
        foreach (var traverseRelatedEntity in TraverseRelatedEntities(entity))
        {
          LinkDescriptor linkDescriptor;
          if (_bindings.TryGetValue(new LinkDescriptor(traverseRelatedEntity.Item1, traverseRelatedEntity.Item2, traverseRelatedEntity.Item3), out linkDescriptor))
            linkDescriptor.State = EntityStates.Deleted;
        }
        foreach (var existingLink in GetTargetingLinks(entity).ToList<LinkDescriptor>())
          DeleteLinkTrackingAndRemoveEntity(existingLink);
      }
      else
      {
        foreach (var target in DeleteEntityGraph(entity))
        {
          foreach (var existingLink in GetTargetingLinks(target).ToList<LinkDescriptor>())
            DeleteLinkTrackingAndRemoveEntity(existingLink);
        }
      }
    }

    private IEnumerable<Entity> DeleteEntityGraph(Entity entity) => TraverseEntityGraph(entity, new Action<EntityDescriptor>(DeleteEntityTracking), new Action<LinkDescriptor>(DeleteLinkTracking)).ToList<Entity>();

    private void DeleteEntityTracking(EntityDescriptor existingEntity)
    {
      switch (existingEntity.State)
      {
        case EntityStates.Added:
          DetachEntityTracking(existingEntity);
          goto case EntityStates.Deleted;
        case EntityStates.Deleted:
          _roots.Remove(existingEntity.Entity);
          break;
        default:
          existingEntity.State = EntityStates.Deleted;
          goto case EntityStates.Deleted;
      }
    }

    private void DeleteLinkTracking(LinkDescriptor existingLink)
    {
      switch (existingLink.State)
      {
        case EntityStates.Added:
          DetachLinkTracking(existingLink);
          break;
        case EntityStates.Deleted:
          break;
        default:
          existingLink.State = EntityStates.Deleted;
          break;
      }
    }

    private void DeleteLinkTrackingAndRemoveEntity(LinkDescriptor existingLink)
    {
      DeleteLinkTracking(existingLink);
      RemoveRelationshipIfContains(existingLink);
    }

    public void UpdateObject(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      UpdateObject(entity, false);
    }

    public void UpdateObject(Entity entity, bool recursive)
    {
      var existingEntity = entity != null ? EnsureTracked(entity, nameof (entity)) : throw new ArgumentNullException(nameof (entity));
      if (!recursive)
      {
        InternalUpdate(existingEntity);
      }
      else
      {
        ValidateUpdate(entity);
        UpdateEntityGraph(entity);
      }
    }

    [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "FxCopy Bankruptcy", MessageId = "")]
    private void ValidateUpdate(Entity graph) => TraverseEntityGraph(graph, entity =>
    {
      if (!IsAttached(entity))
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The context is not currently tracking the '{0}' entity.", entity.LogicalName));
    }, (source, relationship, target) => { }).ToList<Entity>();

    [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "FxCopy Bankruptcy", MessageId = "")]
    private void UpdateEntityGraph(Entity entity) => TraverseEntityGraph(entity, new Action<EntityDescriptor>(InternalUpdate), link => { }).ToList<Entity>();

    private void InternalUpdate(EntityDescriptor existingEntity)
    {
      if (existingEntity.State != EntityStates.Unchanged)
        return;
      existingEntity.State = EntityStates.Modified;
      existingEntity.Entity.SetEntityStateInternal(new EntityState?(EntityState.Changed));
      _roots.Add(existingEntity.Entity);
    }

    public OrganizationResponse Execute(OrganizationRequest request)
    {
      if (request == null)
        throw new ArgumentNullException(nameof (request));
      OnExecuting(request);
      OrganizationResponse response;
      try
      {
        response = _service.Execute(request);
      }
      catch (Exception ex)
      {
        OnExecute(request, ex);
        throw;
      }
      OnExecute(request, response);
      return response;
    }

    public void ClearChanges()
    {
      foreach (var existingLink in _bindings.Values.ToList<LinkDescriptor>())
        DetachLinkTracking(existingLink);
      foreach (var existingEntity in _descriptors.Values.ToList<EntityDescriptor>())
        DetachEntityTracking(existingEntity);
      _bindings.Clear();
      _descriptors.Clear();
      _identityToDescriptor.Clear();
      _roots.Clear();
    }

    public SaveChangesResultCollection SaveChanges() => SaveChanges(SaveChangesDefaultOptions);

    public SaveChangesResultCollection SaveChanges(SaveChangesOptions options)
    {
      OnSavingChanges(options);
      var results = new SaveChangesResultCollection(options);
      foreach (var tuple in GetDisassociateRequests().ToList<Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>>>())
      {
        var result = SaveChange(tuple.Item1, results);
        if (!CanContinue(options, result))
        {
          OnSaveChanges(results);
          throw new SaveChangesException(result.Error, results);
        }
        foreach (var existingLink in tuple.Item2)
          DetachLinkTracking(existingLink);
      }
      foreach (var existingEntity in GetDeletedEntities().ToList<EntityDescriptor>())
      {
        var entityReference = existingEntity.Entity.ToEntityReference();
        var result = SaveChange(new DeleteRequest()
        {
          Target = entityReference,
          ConcurrencyBehavior = _concurrencyBehavior
        }, results);
        if (!CanContinue(options, result))
        {
          OnSaveChanges(results);
          throw new SaveChangesException(result.Error, results);
        }
        DetachEntityTracking(existingEntity);
        foreach (var existingLink in GetTargetingLinks(existingEntity.Entity).ToList<LinkDescriptor>())
          DetachLinkTracking(existingLink);
      }
      foreach (var entity in FilterRoots(new HashSet<Entity>(_roots)).ToList<Entity>())
      {
        foreach (var changeRequest in GetChangeRequests(results, entity))
        {
          if (!CanContinue(options, changeRequest))
          {
            OnSaveChanges(results);
            throw new SaveChangesException(changeRequest.Error, results);
          }
        }
      }
      DetachAllOnSave();
      OnSaveChanges(results);
      return results;
    }

    private static IEnumerable<Entity> FilterRoots(ICollection<Entity> roots)
    {
      var filtered = new HashSet<Entity>();
      while (roots.Any<Entity>())
        FilterRoots(filtered, roots);
      return filtered;
    }

    [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "FxCopy Bankruptcy", MessageId = "")]
    private static void FilterRoots(ICollection<Entity> filtered, ICollection<Entity> unfiltered)
    {
      var root = unfiltered.First<Entity>();
      TraverseEntityGraph(root, entity =>
      {
        if (entity == root)
          return;
        filtered.Remove(entity);
        unfiltered.Remove(entity);
      }, (s, r, t) => { }).ToList<Entity>();
      unfiltered.Remove(root);
      filtered.Add(root);
    }

    private bool CanDeleteRelationship(LinkDescriptor link)
    {
      EntityDescriptor entityDescriptor1;
      EntityDescriptor entityDescriptor2;
      return link.State == EntityStates.Deleted && _descriptors.TryGetValue(link.Source, out entityDescriptor1) && entityDescriptor1.State != EntityStates.Deleted && _descriptors.TryGetValue(link.Target, out entityDescriptor2) && entityDescriptor2.State != EntityStates.Deleted;
    }

    private static bool CanContinue(SaveChangesOptions options, SaveChangesResult result) => (options & SaveChangesOptions.ContinueOnError) == SaveChangesOptions.ContinueOnError || result.Error == null;

    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Need to show proper error message instead of throwing exception.")]
    private SaveChangesResult SaveChange(
      OrganizationRequest request,
      IList<SaveChangesResult> results)
    {
      SaveChangesResult saveChangesResult;
      try
      {
        var response = Execute(request);
        saveChangesResult = new SaveChangesResult(request, response);
      }
      catch (Exception ex)
      {
        saveChangesResult = new SaveChangesResult(request, ex);
      }
      results.Add(saveChangesResult);
      return saveChangesResult;
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>>> GetDisassociateRequests()
    {
      var organizationServiceContext = this;
      foreach (var source in organizationServiceContext._bindings.Values.Where<LinkDescriptor>(new Func<LinkDescriptor, bool>(organizationServiceContext.CanDeleteRelationship)).GroupBy(b => new
      {
        Source = b.Source,
        Relationship = b.Relationship
      }))
      {
        var entityReference = source.Key.Source.ToEntityReference();
        var relationship = source.Key.Relationship;
        var list = source.ToList<LinkDescriptor>();
        var referenceCollection = new EntityReferenceCollection();
        referenceCollection.AddRange(list.Select<LinkDescriptor, EntityReference>(grouping => grouping.Target.ToEntityReference()));
        yield return new Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>>(new DisassociateRequest()
        {
          Target = entityReference,
          Relationship = relationship,
          RelatedEntities = referenceCollection
        }, list);
      }
    }

    private IEnumerable<EntityDescriptor> GetDeletedEntities() => _descriptors.Values.Where<EntityDescriptor>(d => d.State == EntityStates.Deleted);

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<SaveChangesResult> GetChangeRequests(
      SaveChangesResultCollection results,
      Entity entity)
    {
      var path = new List<Entity>() { entity };
      var localCircularLinks = new List<LinkDescriptor>();
      var entityState1 = entity.EntityState;
      var entityState2 = EntityState.Unchanged;
      foreach (var saveChangesResult in entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue ? GetChangeRequestsFromUnchangedTree(results, entity, path, localCircularLinks) : GetChangeRequestsFromChangedTree(results, entity, path, localCircularLinks))
        yield return saveChangesResult;
      if (localCircularLinks.Any<LinkDescriptor>())
      {
        foreach (var associateResult in ToAssociateResults(localCircularLinks, results))
          yield return associateResult;
      }
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<SaveChangesResult> GetChangeRequestsFromChangedTree(
      SaveChangesResultCollection results,
      Entity entity,
      IEnumerable<Entity> path,
      IList<LinkDescriptor> circularLinks)
    {
      var localPath = new List<Entity>() { entity };
      var localCircularLinks = new List<LinkDescriptor>();
      foreach (var saveChangesResult in GetChangeRequestsFromSubtree(results, entity, localPath, localCircularLinks, path, circularLinks))
        yield return saveChangesResult;
      yield return GetSaveChangesResult(results, entity);
      DetachOnSave(entity);
      if (localCircularLinks.Any<LinkDescriptor>())
      {
        foreach (var associateResult in ToAssociateResults(localCircularLinks, results))
          yield return associateResult;
      }
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<SaveChangesResult> GetChangeRequestsFromUnchangedTree(
      SaveChangesResultCollection results,
      Entity entity,
      IEnumerable<Entity> path,
      IList<LinkDescriptor> circularLinks)
    {
      var relatedLinks = new List<LinkDescriptor>();
      foreach (var data in entity.RelatedEntities.SelectMany(relationship => relationship.Value.Entities, (relationship, target) => new
      {
        relationship = relationship,
        target = target
      }).GroupBy(_param1 => _param1.target, _param1 => new
      {
        Relationship = _param1.relationship,
        Target = _param1.target
      }).Select(grp => new
      {
        Target = grp.Key,
        Relationships = grp.Select(g => g.Relationship).ToList<KeyValuePair<Relationship, EntityCollection>>()
      }).ToList())
      {
        var target = data.Target;
        var addedLinks = new List<LinkDescriptor>();
        foreach (var relationship in data.Relationships)
        {
          LinkDescriptor linkDescriptor;
          if (_bindings.TryGetValue(new LinkDescriptor(entity, relationship.Key, target), out linkDescriptor) && linkDescriptor.State == EntityStates.Added)
            addedLinks.Add(linkDescriptor);
        }
        if (!path.Contains<Entity>(target))
        {
          var path1 = path.Concat<Entity>(new Entity[1]
          {
            target
          });
          var entityState1 = target.EntityState;
          var entityState2 = EntityState.Unchanged;
          foreach (var saveChangesResult in entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue ? GetChangeRequestsFromUnchangedTree(results, target, path1, circularLinks) : GetChangeRequestsFromChangedTree(results, target, path1, circularLinks))
            yield return saveChangesResult;
          if (addedLinks.Any<LinkDescriptor>())
            relatedLinks.AddRange(addedLinks);
        }
        else if (addedLinks.Any<LinkDescriptor>())
        {
          foreach (var linkDescriptor in addedLinks)
          {
            circularLinks.Add(linkDescriptor);
            SetNewId(linkDescriptor.Source);
            SetNewId(linkDescriptor.Target);
          }
        }
        addedLinks = null;
      }
      if (relatedLinks.Any<LinkDescriptor>())
      {
        foreach (var associateResult in ToAssociateResults(relatedLinks, results))
          yield return associateResult;
        foreach (var linkDescriptor in relatedLinks)
        {
          var link = linkDescriptor;
          DetachLinkTrackingAndRemoveEntity(link);
          EntityDescriptor existingEntity;
          if (!_bindings.Values.Any<LinkDescriptor>(b => b.Target == link.Target) && _descriptors.TryGetValue(link.Target, out existingEntity))
            DetachEntityTracking(existingEntity);
        }
      }
      _roots.Remove(entity);
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<SaveChangesResult> GetChangeRequestsFromSubtree(
      SaveChangesResultCollection results,
      Entity entity,
      IEnumerable<Entity> localPath,
      IList<LinkDescriptor> localCircularLinks,
      IEnumerable<Entity> path,
      IList<LinkDescriptor> circularLinks)
    {
      foreach (var data in entity.RelatedEntities.SelectMany(relationship => relationship.Value.Entities, (relationship, target) => new
      {
        relationship = relationship,
        target = target
      }).GroupBy(_param1 => _param1.target, _param1 => new
      {
        Relationship = _param1.relationship,
        Target = _param1.target
      }).Select(grp => new
      {
        Target = grp.Key,
        Relationships = grp.Select(g => g.Relationship).ToList<KeyValuePair<Relationship, EntityCollection>>()
      }).ToList())
      {
        var target = data.Target;
        var source = new List<LinkDescriptor>();
        foreach (var relationship in data.Relationships)
        {
          LinkDescriptor existingLink;
          if (_bindings.TryGetValue(new LinkDescriptor(entity, relationship.Key, target), out existingLink))
          {
            if (existingLink.State == EntityStates.Added)
              source.Add(existingLink);
            else
              DetachLinkTrackingAndRemoveEntity(existingLink);
          }
        }
        var flag1 = localPath.Contains<Entity>(target);
        var flag2 = path.Contains<Entity>(target);
        if (!flag1 && !flag2)
        {
          var localPath1 = localPath.Concat<Entity>(new Entity[1]
          {
            target
          });
          var path1 = path.Concat<Entity>(new Entity[1]
          {
            target
          });
          IEnumerable<SaveChangesResult> saveChangesResults;
          if (!source.Any<LinkDescriptor>())
          {
            var entityState1 = target.EntityState;
            var entityState2 = EntityState.Unchanged;
            saveChangesResults = entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue ? GetChangeRequestsFromUnchangedTree(results, target, path1, circularLinks) : GetChangeRequestsFromChangedTree(results, target, path1, circularLinks);
          }
          else
            saveChangesResults = GetChangeRequestsFromSubtree(results, target, localPath1, localCircularLinks, path1, circularLinks);
          foreach (var saveChangesResult in saveChangesResults)
            yield return saveChangesResult;
        }
        else if (source.Any<LinkDescriptor>())
        {
          foreach (var existingLink in source)
          {
            if (flag1)
              localCircularLinks.Add(existingLink);
            else
              circularLinks.Add(existingLink);
            DetachLinkTrackingAndRemoveEntity(existingLink);
            SetNewId(existingLink.Source);
            SetNewId(existingLink.Target);
          }
        }
      }
    }

    private static OrganizationRequest GetRequest(
      Entity entity,
      ConcurrencyBehavior concurrencyBehavior)
    {
      var entityState1 = entity.EntityState;
      var entityState2 = EntityState.Created;
      if (entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue)
        return new CreateRequest()
        {
          Target = entity
        };
      var entityState3 = entity.EntityState;
      var entityState4 = EntityState.Changed;
      if (!(entityState3.GetValueOrDefault() == entityState4 & entityState3.HasValue))
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The '{0}' entity must be in the created or changed state.", entity.LogicalName));
      return new UpdateRequest()
      {
        Target = entity,
        ConcurrencyBehavior = concurrencyBehavior
      };
    }

    [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", Justification = "FxCopy Bankruptcy", MessageId = "")]
    private SaveChangesResult GetSaveChangesResult(
      SaveChangesResultCollection results,
      Entity entity)
    {
      var request = GetRequest(entity, _concurrencyBehavior);
      if (request is CreateRequest createRequest)
        TraverseEntityGraph(createRequest.Target, new Action<Entity>(SetNewId), (source, relationship, target) => { }, new Entity[1]
        {
          createRequest.Target
        }).ToList<Entity>();
      var saveChangesResult = SaveChange(request, results);
      if (!(saveChangesResult.Response is CreateResponse response) || !(entity.Id == Guid.Empty))
        return saveChangesResult;
      entity.Id = response.id;
      return saveChangesResult;
    }

    private void DetachOnSave(Entity entity)
    {
      foreach (var target in DetachEntityGraph(entity))
      {
        var flag = true;
        foreach (var existingLink in GetTargetingLinks(target).ToList<LinkDescriptor>())
        {
          if (existingLink.State == EntityStates.Added)
          {
            existingLink.Target.RelatedEntities.ClearInternal();
            if (!IsAttached(existingLink.Target))
            {
              AttachEntityGraph(existingLink.Target, EntityStates.Unchanged);
              existingLink.Target.SetEntityStateInternal(new EntityState?(EntityState.Unchanged));
              flag = false;
            }
          }
          else
            DetachLinkTrackingAndRemoveEntity(existingLink);
        }
        if (flag)
          target.SetEntityStateInternal(new EntityState?());
      }
    }

    private void DetachAllOnSave()
    {
      foreach (var existingEntity in _descriptors.Values.ToList<EntityDescriptor>())
        DetachEntityTracking(existingEntity);
      foreach (var existingLink in _bindings.Values.ToList<LinkDescriptor>())
        DetachLinkTracking(existingLink);
      _roots.Clear();
    }

    private static EntityReferenceCollection ToEntityReferenceCollection(
      IEnumerable<LinkDescriptor> links)
    {
      var referenceCollection = new EntityReferenceCollection();
      referenceCollection.AddRange(links.Select<LinkDescriptor, EntityReference>(b => b.Target.ToEntityReference()));
      return referenceCollection;
    }

    private static IEnumerable<AssociateRequest> ToAssociateRequests(
      IEnumerable<LinkDescriptor> links)
    {
      return links.GroupBy(link => new
      {
        Source = link.Source,
        Relationship = link.Relationship
      }).Select(grp => new AssociateRequest()
      {
        Target = grp.Key.Source.ToEntityReference(),
        Relationship = grp.Key.Relationship,
        RelatedEntities = ToEntityReferenceCollection(grp)
      });
    }

    private IEnumerable<SaveChangesResult> ToAssociateResults(
      IEnumerable<LinkDescriptor> links,
      IList<SaveChangesResult> results)
    {
      return ToAssociateRequests(links)
                .Select<AssociateRequest, SaveChangesResult>(associate => SaveChange(associate, results));
    }

    private static void SetNewId(Entity entity)
    {
      var entityState1 = entity.EntityState;
      var entityState2 = EntityState.Created;
      if (!(entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue) || !(entity.Id == Guid.Empty))
        return;
      var sequentialGuid = CreateSequentialGuid();
      entity.Id = sequentialGuid;
    }

    [SecuritySafeCritical]
    private static Guid CreateSequentialGuid()
    {
      if (false)
        return Guid.NewGuid();
      try
      {
        new PermissionSet(PermissionState.Unrestricted).Assert();
        if (SequentialGuidOverride != null)
          return SequentialGuidOverride();
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
      var empty = Guid.Empty;
      long sequential;
      try
      {
        new PermissionSet(PermissionState.Unrestricted).Assert();
        sequential = NativeMethods.UuidCreateSequential(ref empty);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
      if (sequential != 0L)
        return Guid.NewGuid();
      var byteArray = empty.ToByteArray();
      var num1 = byteArray[2];
      byteArray[2] = byteArray[1];
      byteArray[1] = num1;
      var num2 = byteArray[3];
      byteArray[3] = byteArray[0];
      byteArray[0] = num2;
      var num3 = byteArray[4];
      byteArray[4] = byteArray[5];
      byteArray[5] = num3;
      var num4 = byteArray[6];
      byteArray[6] = byteArray[7];
      byteArray[7] = num4;
      return new Guid(byteArray);
    }

    internal Entity MergeEntity(Entity entity)
    {
      if (MergeOption == MergeOption.NoTracking || entity == null || entity.Id == Guid.Empty)
        return entity;
      var entityDescriptor = new EntityDescriptor(EntityStates.Unchanged, entity.ToEntityReference(), entity);
      EntityDescriptor existingEntity;
      _identityToDescriptor.TryGetValue(entityDescriptor.Identity, out existingEntity);
      if (existingEntity != null)
      {
        if (MergeOption == MergeOption.AppendOnly || MergeOption == MergeOption.PreserveChanges && existingEntity.State != EntityStates.Unchanged)
          return existingEntity.Entity;
        DetachEntityTracking(existingEntity);
      }
      _descriptors[entityDescriptor.Entity] = entityDescriptor;
      _identityToDescriptor[entityDescriptor.Identity] = entityDescriptor;
      entityDescriptor.Entity.SetEntityStateInternal(new EntityState?(EntityState.Unchanged));
      if (_trackEntityChanges)
        entityDescriptor.Entity.IsReadOnly = true;
      OnBeginEntityTracking(entityDescriptor.Entity);
      return entityDescriptor.Entity;
    }

    private void MergeRelationship(
      Entity source,
      Relationship relationship,
      Entity target,
      bool isAttached)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      if (isAttached)
      {
        var key = new LinkDescriptor(source, relationship, target);
        if (MergeOption == MergeOption.NoTracking)
          return;
        LinkDescriptor linkDescriptor;
        _bindings.TryGetValue(key, out linkDescriptor);
        if (linkDescriptor != null && (MergeOption == MergeOption.AppendOnly || MergeOption == MergeOption.PreserveChanges && linkDescriptor.State != EntityStates.Unchanged))
        {
          AddRelationshipIfNotContains(source, relationship, linkDescriptor.Target);
          return;
        }
        _bindings[key] = key;
        OnBeginLinkTracking(key.Source, key.Relationship, key.Target);
      }
      if (!source.RelatedEntities.Contains(relationship))
      {
        source.RelatedEntities.SetItemInternal(relationship, new EntityCollection(new Entity[1]
        {
          target
        })
        {
          EntityName = target.LogicalName
        });
      }
      else
      {
        var targetReference = target.ToEntityReference();
        var entities = source.RelatedEntities[relationship].Entities;
        var entity = entities.SingleOrDefault<Entity>(e => Equals(e.ToEntityReference(), targetReference));
        if (entity != null)
          entities.Remove(entity);
        entities.Add(target);
      }
    }

    private static void AddRelationshipIfNotContains(
      Entity source,
      Relationship relationship,
      Entity target)
    {
      if (!source.RelatedEntities.Contains(relationship))
      {
        source.RelatedEntities.SetItemInternal(relationship, new EntityCollection(new Entity[1]
        {
          target
        })
        {
          EntityName = target.LogicalName
        });
      }
      else
      {
        if (source.RelatedEntities[relationship].Entities.Contains(target))
          return;
        source.RelatedEntities[relationship].Entities.Add(target);
      }
    }

    private static bool RemoveRelationshipIfContains(LinkDescriptor existingLink) => RemoveRelationshipIfContains(existingLink.Source, existingLink.Relationship, existingLink.Target);

    private static bool RemoveRelationshipIfContains(
      Entity source,
      Relationship relationship,
      Entity target)
    {
      if (!source.RelatedEntities.Contains(relationship))
        return false;
      var relatedEntity = source.RelatedEntities[relationship];
      var flag = relatedEntity.Entities.Remove(target);
      if (relatedEntity.Entities.Count == 0)
        source.RelatedEntities.RemoveInternal(relationship);
      return flag;
    }

    private static void CheckEntitySubclass(Type entityType)
    {
      if (!entityType.IsSubclassOf(typeof (Entity)))
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The specified type '{0}' must be a subclass of '{1}'.", entityType, typeof (Entity)));
      if (string.IsNullOrWhiteSpace(KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType)))
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The specified type '{0}' is not a known entity type.", entityType));
    }

    private EntityCollection GetRelatedEntities(Entity entity, Relationship relationship)
    {
      var relatedEntityName = GetRelatedEntityName(entity, relationship);
      var relationshipQueryCollection1 = new RelationshipQueryCollection();
      relationshipQueryCollection1.Add(relationship, new QueryExpression(relatedEntityName)
      {
        ColumnSet = new ColumnSet(true)
      });
      var relationshipQueryCollection2 = relationshipQueryCollection1;
      var entityReference = new EntityReference(entity.LogicalName, entity.Id);
      var relatedEntities = (Execute(new RetrieveRequest()
      {
        Target = entityReference,
        ColumnSet = new ColumnSet(),
        RelatedEntitiesQuery = relationshipQueryCollection2
      }) as RetrieveResponse).Entity.RelatedEntities;
      return !relatedEntities.Contains(relationship) ? null : relatedEntities[relationship];
    }

    private string GetRelatedEntityName(Entity entity, Relationship relationship)
    {
      if (relationship.PrimaryEntityRole.HasValue)
        return entity.LogicalName;
      var relationshipResponse = Execute(new RetrieveRelationshipRequest()
      {
        Name = relationship.SchemaName
      }) as RetrieveRelationshipResponse;
      if (relationshipResponse.RelationshipMetadata is OneToManyRelationshipMetadata relationshipMetadata1)
        return !(relationshipMetadata1.ReferencingEntity == entity.LogicalName) ? relationshipMetadata1.ReferencingEntity : relationshipMetadata1.ReferencedEntity;
      if (!(relationshipResponse.RelationshipMetadata is ManyToManyRelationshipMetadata relationshipMetadata2))
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unable to load the '{0}' relationship.", relationship.SchemaName));
      return !(relationshipMetadata2.Entity1LogicalName == entity.LogicalName) ? relationshipMetadata2.Entity1LogicalName : relationshipMetadata2.Entity2LogicalName;
    }

    private static IEnumerable<Entity> TraverseEntityGraph(
      Entity entity,
      Action<Entity> onEntity,
      Action<Entity, Relationship, Entity> onLink)
    {
      return TraverseEntityGraph(entity, onEntity, onLink, Array.Empty<Entity>());
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Target = "local$0", Justification = "Value is returned from method and cannot be disposed.")]
    private static IEnumerable<Entity> TraverseEntityGraph(
      Entity entity,
      Action<Entity> onEntity,
      Action<Entity, Relationship, Entity> onLink,
      IEnumerable<Entity> path)
    {
      onEntity(entity);
      yield return entity;
      foreach (var traverseRelatedEntity in TraverseRelatedEntities(entity))
      {
        var entity1 = traverseRelatedEntity.Item1;
        var relationship = traverseRelatedEntity.Item2;
        var entity2 = traverseRelatedEntity.Item3;
        onLink(entity1, relationship, entity2);
        if (!path.Contains<Entity>(entity2))
        {
          var path1 = path.Concat<Entity>(new Entity[1]
          {
            entity2
          });
          foreach (var entity3 in TraverseEntityGraph(entity2, onEntity, onLink, path1))
            yield return entity3;
        }
      }
    }

    private static IEnumerable<Tuple<Entity, Relationship, Entity>> TraverseRelatedEntities(
      Entity entity)
    {
      return entity.RelatedEntities.ToList().Select(relatedEntity => new
      {
        relatedEntity = relatedEntity,
        relationship = relatedEntity.Key
      }).Select(_param1 => new
      {
         Eh__TransparentIdentifier0 = _param1, //TODO: this is weird
        entities = _param1.relatedEntity.Value.Entities.ToList<Entity>()
      }).SelectMany(_param1 => _param1.entities, (_param1, target) => new Tuple<Entity, Relationship, Entity>(entity, _param1.Eh__TransparentIdentifier0.relationship, target));
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<Entity> TraverseEntityGraph(
      Entity graph,
      Action<EntityDescriptor> onEntity,
      Action<LinkDescriptor> onLink)
    {
      return TraverseEntityGraph(graph, entity =>
      {
        EntityDescriptor entityDescriptor;
        if (!_descriptors.TryGetValue(entity, out entityDescriptor))
          return;
        onEntity(entityDescriptor);
      }, (source, relationship, target) =>
      {
        LinkDescriptor linkDescriptor;
        if (!_bindings.TryGetValue(new LinkDescriptor(source, relationship, target), out linkDescriptor))
          return;
        onLink(linkDescriptor);
      });
    }

    private IEnumerable<LinkDescriptor> GetTargetingLinks(Entity target) => _bindings.Values.Where<LinkDescriptor>(b => b.Target == target);

    private EntityDescriptor EnsureTracked(Entity entity, string parameterName)
    {
      if (entity == null)
        throw new ArgumentNullException(parameterName);
      EntityDescriptor entityDescriptor;
      if (!_descriptors.TryGetValue(entity, out entityDescriptor))
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The context is not currently tracking the '{0}' entity.", entity.LogicalName));
      return entityDescriptor;
    }

    private bool EnsureRelatable(
      Entity source,
      Relationship relationship,
      Entity target,
      EntityStates state)
    {
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      var entityDescriptor1 = EnsureTracked(source, nameof (source));
      if (source == target)
        throw new InvalidOperationException("The entity cannot link to itself.");
      if (source.Id != Guid.Empty && target.Id != Guid.Empty && source.Id == target.Id && string.Equals(source.LogicalName, target.LogicalName, StringComparison.Ordinal))
        throw new InvalidOperationException("The entity cannot link to itself.");
      EntityDescriptor entityDescriptor2 = null;
      if (target != null || state != EntityStates.Modified && state != EntityStates.Unchanged)
        entityDescriptor2 = EnsureTracked(target, nameof (target));
      if ((state == EntityStates.Added || state == EntityStates.Unchanged) && (entityDescriptor1.State == EntityStates.Deleted || entityDescriptor2 != null && entityDescriptor2.State == EntityStates.Deleted))
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "One or both of the ends of the '{0}' relationship is in the deleted state.", relationship.SchemaName));
      if (state != EntityStates.Deleted && state != EntityStates.Unchanged || entityDescriptor1.State != EntityStates.Added && (entityDescriptor2 == null || entityDescriptor2.State != EntityStates.Added))
        return false;
      if (state != EntityStates.Deleted)
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "One or both of the ends of the '{0}' relationship is in the added state.", relationship.SchemaName));
      return true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      ClearChanges();
    }

    protected virtual void OnExecuting(OrganizationRequest request)
    {
    }

    protected virtual void OnExecute(OrganizationRequest request, OrganizationResponse response)
    {
    }

    protected virtual void OnExecute(OrganizationRequest request, Exception exception)
    {
    }

    protected virtual void OnSavingChanges(SaveChangesOptions options)
    {
    }

    protected virtual void OnSaveChanges(SaveChangesResultCollection results)
    {
    }

    protected virtual void OnBeginEntityTracking(Entity entity)
    {
    }

    protected virtual void OnEndEntityTracking(Entity entity)
    {
    }

    protected virtual void OnBeginLinkTracking(
      Entity source,
      Relationship relationship,
      Entity target)
    {
    }

    protected virtual void OnEndLinkTracking(
      Entity entity,
      Relationship relationship,
      Entity target)
    {
    }

    private static class Strings
    {
      public const string PropertyDoesNotExist = "The property '{0}' does not exist on the entity '{1}'.";
      public const string NoSettableProperty = "The closed type '{0}' does not have a corresponding '{1}' settable property.";
      public const string RequiresCreatedOrChangedState = "The '{0}' entity must be in the created or changed state.";
      public const string RequiresUnchangedState = "The '{0}' entity must be in the default (null) or unchanged state.";
      public const string RequiresCreatedState = "The '{0}' entity must be in the default (null) or created state.";
      public const string AlreadyTrackingEntity = "The context is already tracking the '{0}' entity.";
      public const string AlreadyTrackingRelationship = "The context is already tracking the '{0}' relationship.";
      public const string EmptyId = "The '{0}' entity has an empty ID.";
      public const string AlreadyTrackingIdentity = "The context is already tracking a different '{0}' entity with the same identity.";
      public const string EntityAlreadyAttached = "The '{0}' entity is already attached to a context.";
      public const string NotSubclass = "The specified type '{0}' must be a subclass of '{1}'.";
      public const string NotKnownEntityType = "The specified type '{0}' is not a known entity type.";
      public const string NotTrackingEntity = "The context is not currently tracking the '{0}' entity.";
      public const string RelationshipEndIsDeleted = "One or both of the ends of the '{0}' relationship is in the deleted state.";
      public const string RelationshipEndIsAdded = "One or both of the ends of the '{0}' relationship is in the added state.";
      public const string CannotLoadAddedEntity = "The context can not load the related collection or reference for entities in the added state.";
      public const string CannotLoadAttachedEntity = "The context can not load the related collection or reference for tracked entities while the 'MergeOption' is set to 'NoTracking'. Change the 'MergeOption' value or detach the '{0}' entity.";
      public const string CannotLoadDetachedEntity = "The context can not load the related collection or reference for untracked entities while the 'MergeOption' is not set to 'NoTracking'. Change the 'MergeOption' to 'NoTracking' or attach the '{0}' entity.";
      public const string SourceEqualsTarget = "The entity cannot link to itself.";
    }

    internal delegate Guid SequentialGuidOverrideDelegate();
  }
}
