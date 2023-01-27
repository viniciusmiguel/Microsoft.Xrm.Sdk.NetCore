// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Entity
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Represents an instance of an entity.</summary>
  [DataContract(Name = "Entity", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public class Entity : IExtensibleDataObject
  {
    private string _logicalName;
    private Guid _id;
    private AttributeCollection _attributes;
    private EntityState? _entityState;
    private FormattedValueCollection _formattedValues;
    private RelatedEntityCollection _relatedEntities;
    internal bool _isReadOnly;
    private string _rowVersion;
    private KeyAttributeCollection _keyAttributes;
    private ExtensionDataObject _extensionDataObject;

    public Entity()
      : this(null)
    {
      HasLazyFileAttribute = false;
    }

    public Entity(string entityName)
    {
      _logicalName = entityName;
      HasLazyFileAttribute = false;
    }

    public Entity(string entityName, Guid id)
    {
      _logicalName = entityName;
      _id = id;
      HasLazyFileAttribute = false;
    }

    public Entity(string entityName, string keyName, object keyValue)
    {
      _logicalName = entityName;
      KeyAttributes.Add(keyName, keyValue);
      HasLazyFileAttribute = false;
    }

    public Entity(string entityName, KeyAttributeCollection keyAttributes)
    {
      _logicalName = entityName;
      _keyAttributes = keyAttributes;
      HasLazyFileAttribute = false;
    }

    /// <summary>Specifies the name of the entity.</summary>
    [DataMember]
    public string LogicalName
    {
      get => _logicalName;
      set
      {
        CheckIsReadOnly(nameof (LogicalName));
        _logicalName = value;
      }
    }

    /// <summary>Specifies the unique id of the entity;</summary>
    [DataMember]
    public virtual Guid Id
    {
      get => _id;
      set
      {
        if (_id != Guid.Empty)
          CheckIsReadOnly(nameof (Id));
        _id = value;
      }
    }

    /// <summary>
    /// Specifies a collection of attribute name/value pairs for the entity.
    /// </summary>
    [DataMember]
    public AttributeCollection Attributes
    {
      get
      {
        if (_attributes == null)
          _attributes = new AttributeCollection();
        return _attributes;
      }
      set => _attributes = value;
    }

    [DataMember]
    public EntityState? EntityState
    {
      get => _entityState;
      set
      {
        CheckIsReadOnly(nameof (EntityState));
        _entityState = value;
      }
    }

    [DataMember]
    public FormattedValueCollection FormattedValues
    {
      get
      {
        if (_formattedValues == null)
          _formattedValues = new FormattedValueCollection();
        return _formattedValues;
      }
      internal set => _formattedValues = value;
    }

    [DataMember]
    public RelatedEntityCollection RelatedEntities
    {
      get
      {
        if (_relatedEntities == null)
        {
          _relatedEntities = new RelatedEntityCollection();
          _relatedEntities.IsReadOnly = IsReadOnly;
        }
        return _relatedEntities;
      }
      internal set
      {
        CheckIsReadOnly(nameof (RelatedEntities));
        _relatedEntities = value;
      }
    }

    [DataMember]
    public string RowVersion
    {
      get => _rowVersion;
      set => _rowVersion = value;
    }

    /// <summary>
    /// Specifies a collection of KeyAttribute name/value pairs for the alternate key.
    /// </summary>
    [DataMember]
    public KeyAttributeCollection KeyAttributes
    {
      get
      {
        if (_keyAttributes == null)
          _keyAttributes = new KeyAttributeCollection();
        return _keyAttributes;
      }
      set => _keyAttributes = value;
    }

    /// <summary>
    /// Gets and sets a flag for a lazy file attribute value. This flag is used
    /// when large files are not routed to plugins.
    /// </summary>
    /// <returns>True if the entity has a lazy file attribute, otherwise false.</returns>
    public bool HasLazyFileAttribute { get; set; }

    /// <summary>Gets and sets the lazy file attribute name;</summary>
    /// <returns>The lazy file attribute key.</returns>
    public string LazyFileAttributeKey { get; set; }

    /// <summary>Gets and sets the lazy file attribute value;</summary>
    /// <returns>A lazy file attribute value.</returns>
    public Lazy<object> LazyFileAttributeValue { get; set; }

    /// <summary>Gets and sets the lazy file size attribute name;</summary>
    /// <returns>The lazy file size attribute key.</returns>
    public string LazyFileSizeAttributeKey { get; set; }

    /// <summary>Gets and sets the lazy file size attribute value;</summary>
    /// <returns>The lazy file size attribute value.</returns>
    public int LazyFileSizeAttributeValue { get; set; }

    /// <summary>Gets or sets the value of an attribute in an entity</summary>
    /// <param name="attributeName">logical name of attribute</param>
    /// <returns>value of the attribute</returns>
    public object this[string attributeName]
    {
      get => Attributes[attributeName];
      set => Attributes[attributeName] = value;
    }

    /// <summary>Checks if value for an attribute is specified</summary>
    /// <param name="attributeName">logical name of attribute</param>
    /// <returns>true if the attribute has value, otherwise false</returns>
    public bool Contains(string attributeName) => Attributes.Contains(attributeName);

    /// <summary>
    /// Creates an early bound instance of current entity, and copies members to it
    /// If T = Entity, the instance will be copied to a late bound instance
    /// </summary>
    /// <typeparam name="T">Early bound type</typeparam>
    /// <returns>Early bound instance of entity</returns>
    public T ToEntity<T>() where T : Entity
    {
      if (typeof (T) == typeof (Entity))
      {
        var target = new Entity();
        ShallowCopyTo(target);
        return target as T;
      }
      if (string.IsNullOrWhiteSpace(_logicalName))
        throw new NotSupportedException("LogicalName must be set before calling ToEntity()");
      string str = null;
      var customAttributes = typeof (T).GetCustomAttributes(typeof (EntityLogicalNameAttribute), true);
      if (customAttributes != null)
      {
        var objArray = customAttributes;
        var index = 0;
        if (index < objArray.Length)
          str = ((EntityLogicalNameAttribute) objArray[index]).LogicalName;
      }
      if (string.IsNullOrWhiteSpace(str))
        throw new NotSupportedException("Cannot convert to type that is does not have EntityLogicalNameAttribute");
      if (_logicalName != str)
        throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "Cannot convert entity {0} to {1}", _logicalName, str));
      var instance = (T) Activator.CreateInstance(typeof (T));
      ShallowCopyTo(instance);
      return instance;
    }

    /// <summary>Creates a reference for the current entity instance.</summary>
    public EntityReference ToEntityReference() => new(LogicalName, Id)
    {
      RowVersion = RowVersion
    };

    /// <summary>Performs a shallow copy of members</summary>
    /// <param name="target"></param>
    internal void ShallowCopyTo(Entity target)
    {
      if (target == null || target == this)
        return;
      target.Id = Id;
      target.SetLogicalNameInternal(LogicalName);
      target.SetEntityStateInternal(EntityState);
      target.SetRelatedEntitiesInternal(RelatedEntities);
      target.Attributes = Attributes;
      target.FormattedValues = FormattedValues;
      target.ExtensionData = ExtensionData;
      target.RowVersion = RowVersion;
      target.KeyAttributes = KeyAttributes;
    }

    public virtual T GetAttributeValue<T>(string attributeLogicalName)
    {
      var attributeValue = GetAttributeValue(attributeLogicalName);
      return attributeValue == null ? default (T) : (T) attributeValue;
    }

    private object GetAttributeValue(string attributeLogicalName)
    {
      if (string.IsNullOrWhiteSpace(attributeLogicalName))
        throw new ArgumentNullException(nameof (attributeLogicalName));
      return !Contains(attributeLogicalName) ? null : this[attributeLogicalName];
    }

    public bool TryGetAttributeValue<T>(string attributeKey, out T result)
    {
      try
      {
        var attributeValue = GetAttributeValue(attributeKey);
        if (attributeValue == null)
        {
          result = default (T);
          return false;
        }
        if (attributeValue is T obj)
        {
          result = obj;
          return true;
        }
        var converter = TypeDescriptor.GetConverter(typeof (T));
        result = (T) converter.ConvertFrom(attributeValue);
        return true;
      }
      catch
      {
      }
      result = default (T);
      return false;
    }

    protected virtual void SetAttributeValue(string attributeLogicalName, object value)
    {
      if (string.IsNullOrWhiteSpace(attributeLogicalName))
        throw new ArgumentNullException(nameof (attributeLogicalName));
      this[attributeLogicalName] = value;
    }

    protected virtual string GetFormattedAttributeValue(string attributeLogicalName)
    {
      if (string.IsNullOrWhiteSpace(attributeLogicalName))
        throw new ArgumentNullException(nameof (attributeLogicalName));
      return !FormattedValues.Contains(attributeLogicalName) ? null : FormattedValues[attributeLogicalName];
    }

    protected virtual TEntity GetRelatedEntity<TEntity>(
      string relationshipSchemaName,
      EntityRole? primaryEntityRole)
      where TEntity : Entity
    {
      var key = !string.IsNullOrWhiteSpace(relationshipSchemaName) ? new Relationship(relationshipSchemaName)
      {
        PrimaryEntityRole = primaryEntityRole
      } : throw new ArgumentNullException(nameof (relationshipSchemaName));
      return !RelatedEntities.Contains(key) ? default (TEntity) : (TEntity) RelatedEntities[key].Entities.FirstOrDefault<Entity>();
    }

    protected virtual void SetRelatedEntity<TEntity>(
      string relationshipSchemaName,
      EntityRole? primaryEntityRole,
      TEntity entity)
      where TEntity : Entity
    {
      if (string.IsNullOrWhiteSpace(relationshipSchemaName))
        throw new ArgumentNullException(nameof (relationshipSchemaName));
      if (entity != null && string.IsNullOrWhiteSpace(entity.LogicalName))
        throw new ArgumentException("The entity is missing a value for the 'LogicalName' property.", nameof (entity));
      var key = new Relationship(relationshipSchemaName)
      {
        PrimaryEntityRole = primaryEntityRole
      };
      EntityCollection entityCollection1;
      if (entity == null)
      {
        entityCollection1 = null;
      }
      else
      {
        entityCollection1 = new EntityCollection(new TEntity[1]
        {
          entity
        });
        entityCollection1.EntityName = entity.LogicalName;
      }
      var entityCollection2 = entityCollection1;
      if (entityCollection2 != null)
        RelatedEntities[key] = entityCollection2;
      else
        RelatedEntities.Remove(key);
    }

    protected virtual IEnumerable<TEntity> GetRelatedEntities<TEntity>(
      string relationshipSchemaName,
      EntityRole? primaryEntityRole)
      where TEntity : Entity
    {
      var key = !string.IsNullOrWhiteSpace(relationshipSchemaName) ? new Relationship(relationshipSchemaName)
      {
        PrimaryEntityRole = primaryEntityRole
      } : throw new ArgumentNullException(nameof (relationshipSchemaName));
      return !RelatedEntities.Contains(key) ? null : RelatedEntities[key].Entities.Cast<TEntity>();
    }

    protected virtual void SetRelatedEntities<TEntity>(
      string relationshipSchemaName,
      EntityRole? primaryEntityRole,
      IEnumerable<TEntity> entities)
      where TEntity : Entity
    {
      if (string.IsNullOrWhiteSpace(relationshipSchemaName))
        throw new ArgumentNullException(nameof (relationshipSchemaName));
      if (entities != null && entities.Any<TEntity>(entity => string.IsNullOrWhiteSpace(entity.LogicalName)))
        throw new ArgumentException("An entity is missing a value for the 'LogicalName' property.", nameof (entities));
      var key = new Relationship(relationshipSchemaName)
      {
        PrimaryEntityRole = primaryEntityRole
      };
      EntityCollection entityCollection1;
      if (entities == null)
      {
        entityCollection1 = null;
      }
      else
      {
        entityCollection1 = new EntityCollection(new List<Entity>(entities));
        entityCollection1.EntityName = entities.First<TEntity>().LogicalName;
      }
      var entityCollection2 = entityCollection1;
      if (entityCollection2 != null)
        RelatedEntities[key] = entityCollection2;
      else
        RelatedEntities.Remove(key);
    }

    /// <summary>
    /// Indicates that the entity is attached to an <see cref="!:OrganizationServiceContext" />.
    /// </summary>
    internal bool IsReadOnly
    {
      get => _isReadOnly;
      set
      {
        _isReadOnly = value;
        RelatedEntities.IsReadOnly = value;
      }
    }

    internal void SetLogicalNameInternal(string logicalName) => _logicalName = logicalName;

    internal void SetEntityStateInternal(EntityState? entityState) => _entityState = entityState;

    internal void SetRelatedEntitiesInternal(RelatedEntityCollection relatedEntities) => _relatedEntities = relatedEntities;

    private void CheckIsReadOnly(string propertyName)
    {
      if (IsReadOnly)
        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The entity is read-only and the '{0}' property cannot be modified. Use the context to update the entity instead.", propertyName));
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
