// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.AttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "AttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (MultiSelectPicklistAttributeMetadata))]
  [KnownType(typeof (BooleanAttributeMetadata))]
  [KnownType(typeof (DateTimeAttributeMetadata))]
  [KnownType(typeof (DecimalAttributeMetadata))]
  [KnownType(typeof (DoubleAttributeMetadata))]
  [KnownType(typeof (EntityNameAttributeMetadata))]
  [KnownType(typeof (ImageAttributeMetadata))]
  [KnownType(typeof (IntegerAttributeMetadata))]
  [KnownType(typeof (BigIntAttributeMetadata))]
  [KnownType(typeof (LookupAttributeMetadata))]
  [KnownType(typeof (MemoAttributeMetadata))]
  [KnownType(typeof (MoneyAttributeMetadata))]
  [KnownType(typeof (PicklistAttributeMetadata))]
  [KnownType(typeof (StateAttributeMetadata))]
  [KnownType(typeof (StatusAttributeMetadata))]
  [KnownType(typeof (StringAttributeMetadata))]
  [KnownType(typeof (ManagedPropertyAttributeMetadata))]
  [KnownType(typeof (UniqueIdentifierAttributeMetadata))]
  [KnownType(typeof (FileAttributeMetadata))]
  [MetadataName(LogicalName = "AttributeMetadata", LogicalCollectionName = "AttributeDefinitions")]
  public class AttributeMetadata : MetadataBase
  {
    private string _attributeOf;
    private AttributeTypeCode? _attributeType;
    private AttributeTypeDisplayName _attributeTypeDisplayName;
    private int? _columnNumber;
    private Label _description;
    private Label _displayName;
    private string _entityLogicalName;
    private BooleanManagedProperty _isAuditEnabled;
    private bool? _isCustomAttribute;
    private bool? _isPrimaryId;
    private bool? _isPrimaryAttribute;
    private Guid? _linkedAttributeId;
    private string _logicalName;
    private string _schemaName;
    private string _externalName;
    private bool? _validForCreate;
    private bool? _validForRead;
    private bool? _validForUpdate;
    private bool? _isSecured;
    private bool? _canBeSecuredForRead;
    private bool? _canBeSecuredForCreate;
    private bool? _canBeSecuredForUpdate;
    private bool? _isManaged;
    private string _deprecatedVersion;
    private string _introducedVersion;
    private BooleanManagedProperty _isGlobalFilterEnabled;
    private BooleanManagedProperty _isSortableEnabled;
    private bool? _isSearchable;
    private bool? _isFilterable;
    private bool? _isRetrievable;
    private string _inheritsFrom;
    private bool? _isDataSourceSecret;
    private bool? _isValidForForm;
    private bool? _isRequiredForForm;
    private bool? _isValidForGrid;
    private BooleanManagedProperty _isCustomizable;
    private BooleanManagedProperty _isRenameable;
    private BooleanManagedProperty _isValidForAdvancedFind;
    private AttributeRequiredLevelManagedProperty _requiredLevel;
    private BooleanManagedProperty _canModifyAdditionalSettings;
    private string _aggregateOf;
    private bool? _isLogical;
    private int _displayMask;

    public AttributeMetadata()
    {
    }

    protected AttributeMetadata(AttributeTypeCode attributeType)
      : this()
    {
      AttributeType = new AttributeTypeCode?(attributeType);
      AttributeTypeName = GetAttributeTypeDisplayName(attributeType);
    }

    protected AttributeMetadata(AttributeTypeCode attributeType, string schemaName)
      : this(attributeType)
    {
      SchemaName = schemaName;
    }

    /// <summary>
    /// Please make sure add any new AttributeTypes in here so a given AttributeType is translated to AttributeTypeDisplayName
    /// and also make sure add the new AttributeType to src\managedplatform\sdk\metadata\metadatacache\MetadataCacheEnums.cs
    /// </summary>
    /// <param name="attributeType"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private AttributeTypeDisplayName GetAttributeTypeDisplayName(AttributeTypeCode attributeType)
    {
      switch (attributeType)
      {
        case AttributeTypeCode.Boolean:
          return AttributeTypeDisplayName.BooleanType;
        case AttributeTypeCode.Customer:
          return AttributeTypeDisplayName.CustomerType;
        case AttributeTypeCode.DateTime:
          return AttributeTypeDisplayName.DateTimeType;
        case AttributeTypeCode.Decimal:
          return AttributeTypeDisplayName.DecimalType;
        case AttributeTypeCode.Double:
          return AttributeTypeDisplayName.DoubleType;
        case AttributeTypeCode.Integer:
          return AttributeTypeDisplayName.IntegerType;
        case AttributeTypeCode.Lookup:
          return AttributeTypeDisplayName.LookupType;
        case AttributeTypeCode.Memo:
          return AttributeTypeDisplayName.MemoType;
        case AttributeTypeCode.Money:
          return AttributeTypeDisplayName.MoneyType;
        case AttributeTypeCode.Owner:
          return AttributeTypeDisplayName.OwnerType;
        case AttributeTypeCode.PartyList:
          return AttributeTypeDisplayName.PartyListType;
        case AttributeTypeCode.Picklist:
          return AttributeTypeDisplayName.PicklistType;
        case AttributeTypeCode.State:
          return AttributeTypeDisplayName.StateType;
        case AttributeTypeCode.Status:
          return AttributeTypeDisplayName.StatusType;
        case AttributeTypeCode.String:
          return AttributeTypeDisplayName.StringType;
        case AttributeTypeCode.Uniqueidentifier:
          return AttributeTypeDisplayName.UniqueidentifierType;
        case AttributeTypeCode.CalendarRules:
          return AttributeTypeDisplayName.CalendarRulesType;
        case AttributeTypeCode.Virtual:
          return AttributeTypeDisplayName.VirtualType;
        case AttributeTypeCode.BigInt:
          return AttributeTypeDisplayName.BigIntType;
        case AttributeTypeCode.ManagedProperty:
          return AttributeTypeDisplayName.ManagedPropertyType;
        case AttributeTypeCode.EntityName:
          return AttributeTypeDisplayName.EntityNameType;
        default:
          return null;
      }
    }

    [DataMember]
    public string AttributeOf
    {
      get => _attributeOf;
      internal set => _attributeOf = value;
    }

    [DataMember]
    public AttributeTypeCode? AttributeType
    {
      get => _attributeType;
      internal set => _attributeType = value;
    }

    /// <summary>
    /// AttributeTypeName will eventually replace AttributeTypeCode enum as enum is not WCF backcompat friendly for adding new
    /// attribute types. All new AttributeTypes added should use the AttributeTypeName instead.
    /// </summary>
    [DataMember(Order = 60)]
    public AttributeTypeDisplayName AttributeTypeName
    {
      get => _attributeTypeDisplayName;
      internal set => _attributeTypeDisplayName = value;
    }

    [DataMember]
    public int? ColumnNumber
    {
      get => _columnNumber;
      internal set => _columnNumber = value;
    }

    /// <summary>
    /// Gets or sets the description for the attribute.  This is valid for both the Create and Update of an attribute.
    /// </summary>
    [DataMember]
    public Label Description
    {
      get => _description;
      set => _description = value;
    }

    [DataMember]
    public Label DisplayName
    {
      get => _displayName;
      set => _displayName = value;
    }

    /// <summary>
    /// Gets the version an attribute was deprecated in.
    /// This is the assembly version of the product's release
    /// </summary>
    [DataMember]
    public string DeprecatedVersion
    {
      get => _deprecatedVersion;
      internal set => _deprecatedVersion = value;
    }

    /// <summary>
    /// Gets the version an attribute was introduced in.
    /// This is the assembly version of the product's release
    /// </summary>
    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => _introducedVersion;
      internal set => _introducedVersion = value;
    }

    [DataMember]
    public string EntityLogicalName
    {
      get => _entityLogicalName;
      internal set => _entityLogicalName = value;
    }

    [DataMember]
    public BooleanManagedProperty IsAuditEnabled
    {
      get => _isAuditEnabled;
      set => _isAuditEnabled = value;
    }

    [DataMember]
    public bool? IsCustomAttribute
    {
      get => _isCustomAttribute;
      internal set => _isCustomAttribute = value;
    }

    [DataMember]
    public bool? IsPrimaryId
    {
      get => _isPrimaryId;
      internal set => _isPrimaryId = value;
    }

    [DataMember]
    public bool IsValidODataAttribute { get; internal set; }

    [DataMember]
    public bool? IsPrimaryName
    {
      get => _isPrimaryAttribute;
      internal set => _isPrimaryAttribute = value;
    }

    [DataMember]
    public bool? IsValidForCreate
    {
      get => _validForCreate;
      set => _validForCreate = value;
    }

    [DataMember]
    public bool? IsValidForRead
    {
      get => _validForRead;
      internal set => _validForRead = value;
    }

    [DataMember]
    public bool? IsValidForUpdate
    {
      get => _validForUpdate;
      set => _validForUpdate = value;
    }

    [DataMember]
    public bool? CanBeSecuredForRead
    {
      get => _canBeSecuredForRead;
      internal set => _canBeSecuredForRead = value;
    }

    [DataMember]
    public bool? CanBeSecuredForCreate
    {
      get => _canBeSecuredForCreate;
      internal set => _canBeSecuredForCreate = value;
    }

    [DataMember]
    public bool? CanBeSecuredForUpdate
    {
      get => _canBeSecuredForUpdate;
      internal set => _canBeSecuredForUpdate = value;
    }

    [DataMember]
    public bool? IsSecured
    {
      get => _isSecured;
      set => _isSecured = value;
    }

    [DataMember]
    public bool? IsRetrievable
    {
      get => _isRetrievable;
      internal set => _isRetrievable = value;
    }

    [DataMember]
    public bool? IsFilterable
    {
      get => _isFilterable;
      internal set => _isFilterable = value;
    }

    [DataMember]
    public bool? IsSearchable
    {
      get => _isSearchable;
      internal set => _isSearchable = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => _isManaged;
      internal set => _isManaged = value;
    }

    [DataMember]
    public BooleanManagedProperty IsGlobalFilterEnabled
    {
      get => _isGlobalFilterEnabled;
      set => _isGlobalFilterEnabled = value;
    }

    [DataMember]
    public BooleanManagedProperty IsSortableEnabled
    {
      get => _isSortableEnabled;
      set => _isSortableEnabled = value;
    }

    [DataMember]
    public Guid? LinkedAttributeId
    {
      get => _linkedAttributeId;
      set => _linkedAttributeId = value;
    }

    [DataMember]
    [Alternatekey]
    public string LogicalName
    {
      get => _logicalName;
      set => _logicalName = value;
    }

    [DataMember]
    public BooleanManagedProperty IsCustomizable
    {
      get => _isCustomizable;
      set => _isCustomizable = value;
    }

    [DataMember]
    public BooleanManagedProperty IsRenameable
    {
      get => _isRenameable;
      set => _isRenameable = value;
    }

    [DataMember]
    public BooleanManagedProperty IsValidForAdvancedFind
    {
      get => _isValidForAdvancedFind;
      set => _isValidForAdvancedFind = value;
    }

    [DataMember]
    public bool? IsValidForForm
    {
      get => _isValidForForm;
      set => _isValidForForm = value;
    }

    [DataMember]
    public bool? IsRequiredForForm
    {
      get => _isRequiredForForm;
      set => _isRequiredForForm = value;
    }

    [DataMember]
    public bool? IsValidForGrid
    {
      get => _isValidForGrid;
      set => _isValidForGrid = value;
    }

    [DataMember]
    public AttributeRequiredLevelManagedProperty RequiredLevel
    {
      get => _requiredLevel;
      set => _requiredLevel = value;
    }

    [DataMember]
    public BooleanManagedProperty CanModifyAdditionalSettings
    {
      get => _canModifyAdditionalSettings;
      set => _canModifyAdditionalSettings = value;
    }

    [DataMember]
    public string SchemaName
    {
      get => _schemaName;
      set => _schemaName = value;
    }

    [DataMember]
    public string ExternalName
    {
      get => _externalName;
      set => _externalName = value;
    }

    internal int DisplayMask
    {
      get => _displayMask;
      set => _displayMask = value;
    }

    internal string AggregateOf
    {
      get => _aggregateOf;
      set => _aggregateOf = value;
    }

    [DataMember(Order = 70)]
    public bool? IsLogical
    {
      get => _isLogical;
      internal set => _isLogical = value;
    }

    [DataMember]
    public bool? IsDataSourceSecret
    {
      get => _isDataSourceSecret;
      set => _isDataSourceSecret = value;
    }

    [DataMember]
    public string InheritsFrom
    {
      get => _inheritsFrom;
      internal set => _inheritsFrom = value;
    }

    [DataMember]
    public DateTime? CreatedOn { get; internal set; }

    [DataMember]
    public DateTime? ModifiedOn { get; internal set; }

    /// <summary>
    /// Indicates how the field's data is stored (0:Persist; 1:Calculated; ...)
    /// </summary>
    [DataMember(Order = 70)]
    public int? SourceType { get; set; }

    [DataMember(Order = 90)]
    public string AutoNumberFormat { get; set; }

    [DataMember]
    public EntitySetting[] Settings { get; set; }
  }
}
