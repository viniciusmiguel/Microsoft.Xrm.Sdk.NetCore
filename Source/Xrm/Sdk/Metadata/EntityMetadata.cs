// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.EntityMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "EntityMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "EntityMetadata", LogicalCollectionName = "EntityDefinitions")]
  public sealed class EntityMetadata : MetadataBase
  {
    private int? _activityTypeMask;
    private AttributeMetadata[] _attributes;
    private bool? _canTriggerWorkflow;
    private Label _description;
    private Label _displayCollectionName;
    private Label _displayName;
    private bool? _isDocumentMangementEnabled;
    private bool? _isOneNoteIntegrationEnabled;
    private bool? _isInteractionCentricEnabled;
    private bool? _isKnowledgeManagementEnabled;
    private bool? _isSLAEnabled;
    private bool? _isBpfEntity;
    private bool? _isDocumentRecommendationsEnabled;
    private bool? _isMSTeamsIntegrationEnabled;
    private string _settingOf;
    private Guid? _dataProviderId;
    private Guid? _dataSourceId;
    private bool? _isSolutionAware;
    private bool? _hasEmailAddresses;
    private Guid? _ownerId;
    private int? _ownerIdType;
    private Guid? _owningBusinessUnit;
    private bool? _isActivity;
    private bool? _isActivityParty;
    private BooleanManagedProperty _isAuditEnabled;
    private bool? _isRetrieveAuditEnabled;
    private bool? _isRetrieveMultipleAuditEnabled;
    private bool? _isArchivalEnabled;
    private bool? _isAvailableOffline;
    private bool? _isChildEntity;
    private bool? _isAIRUpdated;
    private bool? _autoCreateAccessTeams;
    private BooleanManagedProperty _isValidForQueue;
    private BooleanManagedProperty _isConnectionsEnabled;
    private string _iconLargeName;
    private string _iconMediumName;
    private string _iconSmallName;
    private string _iconVectorName;
    private bool? _isCustomEntity;
    private bool? _isBusinessProcessEnabled;
    private BooleanManagedProperty _isCustomizable;
    private BooleanManagedProperty _isRenameable;
    private BooleanManagedProperty _isMappable;
    private BooleanManagedProperty _isDuplicateDetectionEnabled;
    private bool? _isImportable;
    private bool? _isIntersect;
    private BooleanManagedProperty _isMailMergeEnabled;
    private bool? autoRouteToOwnerQueue;
    private bool? _isEnabledForCharts;
    private bool? _isEnabledForTrace;
    private bool? _isValidForAdvancedFind;
    private string _entityHelpUrl;
    private bool? _entityHelpUrlEnabled;
    private BooleanManagedProperty _isVisibleInMobile;
    private BooleanManagedProperty _isVisibleInMobileClient;
    private BooleanManagedProperty _isReadOnlyInMobileClient;
    private string _logicalName;
    private ManyToManyRelationshipMetadata[] _manyToManyRelationships;
    private OneToManyRelationshipMetadata[] _manyToOneRelationships;
    private int? _objectTypeCode;
    private OneToManyRelationshipMetadata[] _oneToManyRelationships;
    private OwnershipTypes? _ownershipType;
    private string _primaryNameAttribute;
    private string _primaryImageAttribute;
    private string _primaryIdAttribute;
    private SecurityPrivilegeMetadata[] _privileges;
    private string _recurrenceBaseEntityLogicalName;
    private string _reportViewName;
    private string _schemaName;
    private string _physicalName;
    private string _externalName;
    private int? _workflowSupport;
    private bool? _isManaged;
    private bool? _isReadingPaneEnabled;
    private bool? _isQuickCreateEnabled;
    private string _introducedVersion;
    private bool? _isStateModelAware;
    private bool? _enforceStateTransitions;
    private BooleanManagedProperty _canCreateAttributes;
    private BooleanManagedProperty _canCreateForms;
    private BooleanManagedProperty _canCreateCharts;
    private BooleanManagedProperty _canCreateViews;
    private BooleanManagedProperty _canBeRelatedEntityInRelationship;
    private BooleanManagedProperty _canBePrimaryEntityInRelationship;
    private BooleanManagedProperty _canBeInManyToMany;
    private BooleanManagedProperty _canBeInCustomEntityAssociation;
    private BooleanManagedProperty _canModifyAdditionalSettings;
    private BooleanManagedProperty _canChangeHierarchicalRelationship;
    private BooleanManagedProperty _canChangeTrackingBeEnabled;
    private BooleanManagedProperty _canEnableSyncToExternalSearchIndex;
    private bool? _syncToExternalSearchIndex;
    private bool? _changeTrackingEnabled;
    private bool? _isOptimisticConcurrencyEnabled;
    private string _entityColor;
    private EntityKeyMetadata[] _keys;
    private string _logicalCollectionName;
    private string _externalCollectionName;
    private string _collectionSchemaName;
    private BooleanManagedProperty _isOfflineInMobileClient;
    private int? _daysSinceRecordLastModified;
    private string _mobileOfflineFilters;
    private string _entitySetName;
    private bool? _isEnabledForExternalChannels;
    private bool? _isPrivate;
    private bool? _usesBusinessDataLabelTable;
    private bool? _isLogicalEntity;
    private int? _availableForRetrieve;
    private int? _availableForRetrieveMultiple;
    private int? _availableForCreate;
    private int? _availableForUpdate;
    private int? _availableForDelete;
    private bool? _hasNotes;
    private bool? _hasActivities;
    private bool? _hasFeedback;

    [DataMember]
    public int? ActivityTypeMask
    {
      get => _activityTypeMask;
      set => _activityTypeMask = value;
    }

    [DataMember]
    public AttributeMetadata[] Attributes
    {
      get => _attributes;
      internal set => _attributes = value;
    }

    [DataMember]
    public bool? AutoRouteToOwnerQueue
    {
      get => autoRouteToOwnerQueue;
      set => autoRouteToOwnerQueue = value;
    }

    [DataMember]
    public bool? CanTriggerWorkflow
    {
      get => _canTriggerWorkflow;
      internal set => _canTriggerWorkflow = value;
    }

    [DataMember]
    public Label Description
    {
      get => _description;
      set => _description = value;
    }

    [DataMember]
    public Label DisplayCollectionName
    {
      get => _displayCollectionName;
      set => _displayCollectionName = value;
    }

    [DataMember]
    public Label DisplayName
    {
      get => _displayName;
      set => _displayName = value;
    }

    [DataMember(Order = 70)]
    public bool? EntityHelpUrlEnabled
    {
      get => _entityHelpUrlEnabled;
      set => _entityHelpUrlEnabled = value;
    }

    [DataMember(Order = 70)]
    public string EntityHelpUrl
    {
      get => _entityHelpUrl;
      set => _entityHelpUrl = value;
    }

    [DataMember]
    public bool? IsDocumentManagementEnabled
    {
      get => _isDocumentMangementEnabled;
      set => _isDocumentMangementEnabled = value;
    }

    [DataMember]
    public bool? IsOneNoteIntegrationEnabled
    {
      get => _isOneNoteIntegrationEnabled;
      set => _isOneNoteIntegrationEnabled = value;
    }

    [DataMember]
    public bool? IsInteractionCentricEnabled
    {
      get => _isInteractionCentricEnabled;
      set => _isInteractionCentricEnabled = value;
    }

    [DataMember]
    public bool? IsKnowledgeManagementEnabled
    {
      get => _isKnowledgeManagementEnabled;
      set => _isKnowledgeManagementEnabled = value;
    }

    [DataMember(Order = 81)]
    public bool? IsSLAEnabled
    {
      get => _isSLAEnabled;
      set => _isSLAEnabled = value;
    }

    [DataMember(Order = 82)]
    public bool? IsBPFEntity
    {
      get => _isBpfEntity;
      set => _isBpfEntity = value;
    }

    [DataMember]
    public bool? IsDocumentRecommendationsEnabled
    {
      get => _isDocumentRecommendationsEnabled;
      set => _isDocumentRecommendationsEnabled = value;
    }

    [DataMember]
    public bool? IsMSTeamsIntegrationEnabled
    {
      get => _isMSTeamsIntegrationEnabled;
      set => _isMSTeamsIntegrationEnabled = value;
    }

    [DataMember]
    public string SettingOf
    {
      get => _settingOf;
      set => _settingOf = value;
    }

    [DataMember]
    public Guid? DataProviderId
    {
      get => _dataProviderId;
      set => _dataProviderId = value;
    }

    [DataMember]
    public Guid? DataSourceId
    {
      get => _dataSourceId;
      set => _dataSourceId = value;
    }

    [DataMember]
    public bool? AutoCreateAccessTeams
    {
      get => _autoCreateAccessTeams;
      set => _autoCreateAccessTeams = value;
    }

    [DataMember]
    public bool? IsActivity
    {
      get => _isActivity;
      set => _isActivity = value;
    }

    [DataMember]
    public bool? IsActivityParty
    {
      get => _isActivityParty;
      set => _isActivityParty = value;
    }

    [DataMember]
    public BooleanManagedProperty IsAuditEnabled
    {
      get => _isAuditEnabled;
      set => _isAuditEnabled = value;
    }

    [DataMember]
    public bool? IsRetrieveAuditEnabled
    {
      get => _isRetrieveAuditEnabled;
      set => _isRetrieveAuditEnabled = value;
    }

    [DataMember]
    public bool? IsRetrieveMultipleAuditEnabled
    {
      get => _isRetrieveMultipleAuditEnabled;
      set => _isRetrieveMultipleAuditEnabled = value;
    }

    [DataMember]
    public bool? IsArchivalEnabled
    {
      get => _isArchivalEnabled;
      set => _isArchivalEnabled = value;
    }

    [DataMember]
    public bool? IsAvailableOffline
    {
      get => _isAvailableOffline;
      set => _isAvailableOffline = value;
    }

    [DataMember]
    public bool? IsChildEntity
    {
      get => _isChildEntity;
      internal set => _isChildEntity = value;
    }

    [DataMember]
    public bool? IsAIRUpdated
    {
      get => _isAIRUpdated;
      internal set => _isAIRUpdated = value;
    }

    [DataMember]
    public BooleanManagedProperty IsValidForQueue
    {
      get => _isValidForQueue;
      set => _isValidForQueue = value;
    }

    [DataMember]
    public BooleanManagedProperty IsConnectionsEnabled
    {
      get => _isConnectionsEnabled;
      set => _isConnectionsEnabled = value;
    }

    [DataMember]
    public string IconLargeName
    {
      get => _iconLargeName;
      set => _iconLargeName = value;
    }

    [DataMember]
    public string IconMediumName
    {
      get => _iconMediumName;
      set => _iconMediumName = value;
    }

    [DataMember]
    public string IconSmallName
    {
      get => _iconSmallName;
      set => _iconSmallName = value;
    }

    [DataMember]
    public string IconVectorName
    {
      get => _iconVectorName;
      set => _iconVectorName = value;
    }

    [DataMember]
    public bool? IsCustomEntity
    {
      get => _isCustomEntity;
      internal set => _isCustomEntity = value;
    }

    [DataMember]
    public bool? IsBusinessProcessEnabled
    {
      get => _isBusinessProcessEnabled;
      set => _isBusinessProcessEnabled = value;
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
    public BooleanManagedProperty IsMappable
    {
      get => _isMappable;
      set => _isMappable = value;
    }

    [DataMember]
    public BooleanManagedProperty IsDuplicateDetectionEnabled
    {
      get => _isDuplicateDetectionEnabled;
      set => _isDuplicateDetectionEnabled = value;
    }

    [DataMember]
    public BooleanManagedProperty CanCreateAttributes
    {
      get => _canCreateAttributes;
      set => _canCreateAttributes = value;
    }

    [DataMember]
    public BooleanManagedProperty CanCreateForms
    {
      get => _canCreateForms;
      set => _canCreateForms = value;
    }

    [DataMember]
    public BooleanManagedProperty CanCreateViews
    {
      get => _canCreateViews;
      set => _canCreateViews = value;
    }

    [DataMember]
    public BooleanManagedProperty CanCreateCharts
    {
      get => _canCreateCharts;
      set => _canCreateCharts = value;
    }

    [DataMember]
    public BooleanManagedProperty CanBeRelatedEntityInRelationship
    {
      get => _canBeRelatedEntityInRelationship;
      internal set => _canBeRelatedEntityInRelationship = value;
    }

    [DataMember]
    public BooleanManagedProperty CanBePrimaryEntityInRelationship
    {
      get => _canBePrimaryEntityInRelationship;
      internal set => _canBePrimaryEntityInRelationship = value;
    }

    [DataMember]
    public BooleanManagedProperty CanBeInManyToMany
    {
      get => _canBeInManyToMany;
      internal set => _canBeInManyToMany = value;
    }

    [DataMember]
    public BooleanManagedProperty CanBeInCustomEntityAssociation
    {
      get => _canBeInCustomEntityAssociation;
      internal set => _canBeInCustomEntityAssociation = value;
    }

    [DataMember]
    public BooleanManagedProperty CanEnableSyncToExternalSearchIndex
    {
      get => _canEnableSyncToExternalSearchIndex;
      set => _canEnableSyncToExternalSearchIndex = value;
    }

    [DataMember]
    public bool? SyncToExternalSearchIndex
    {
      get => _syncToExternalSearchIndex;
      set => _syncToExternalSearchIndex = value;
    }

    [DataMember]
    public BooleanManagedProperty CanModifyAdditionalSettings
    {
      get => _canModifyAdditionalSettings;
      set => _canModifyAdditionalSettings = value;
    }

    [DataMember(Order = 70)]
    public BooleanManagedProperty CanChangeHierarchicalRelationship
    {
      get => _canChangeHierarchicalRelationship;
      set => _canChangeHierarchicalRelationship = value;
    }

    [DataMember(Order = 71)]
    public bool? IsOptimisticConcurrencyEnabled
    {
      get => _isOptimisticConcurrencyEnabled;
      internal set => _isOptimisticConcurrencyEnabled = value;
    }

    [DataMember]
    public bool? ChangeTrackingEnabled
    {
      get => _changeTrackingEnabled;
      set => _changeTrackingEnabled = value;
    }

    [DataMember]
    public BooleanManagedProperty CanChangeTrackingBeEnabled
    {
      get => _canChangeTrackingBeEnabled;
      set => _canChangeTrackingBeEnabled = value;
    }

    [DataMember]
    public bool? IsImportable
    {
      get => _isImportable;
      internal set => _isImportable = value;
    }

    [DataMember]
    public bool? IsIntersect
    {
      get => _isIntersect;
      internal set => _isIntersect = value;
    }

    [DataMember]
    public BooleanManagedProperty IsMailMergeEnabled
    {
      get => _isMailMergeEnabled;
      set => _isMailMergeEnabled = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => _isManaged;
      internal set => _isManaged = value;
    }

    [DataMember]
    public bool? IsEnabledForCharts
    {
      get => _isEnabledForCharts;
      internal set => _isEnabledForCharts = value;
    }

    [DataMember]
    public bool? IsEnabledForTrace
    {
      get => _isEnabledForTrace;
      internal set => _isEnabledForTrace = value;
    }

    [DataMember]
    public bool? IsValidForAdvancedFind
    {
      get => _isValidForAdvancedFind;
      internal set => _isValidForAdvancedFind = value;
    }

    [DataMember]
    public BooleanManagedProperty IsVisibleInMobile
    {
      get => _isVisibleInMobile;
      set => _isVisibleInMobile = value;
    }

    [DataMember]
    public BooleanManagedProperty IsVisibleInMobileClient
    {
      get => _isVisibleInMobileClient;
      set => _isVisibleInMobileClient = value;
    }

    [DataMember]
    public BooleanManagedProperty IsReadOnlyInMobileClient
    {
      get => _isReadOnlyInMobileClient;
      set => _isReadOnlyInMobileClient = value;
    }

    [DataMember(Order = 72)]
    public BooleanManagedProperty IsOfflineInMobileClient
    {
      get => _isOfflineInMobileClient;
      set => _isOfflineInMobileClient = value;
    }

    [DataMember(Order = 72)]
    public int? DaysSinceRecordLastModified
    {
      get => _daysSinceRecordLastModified;
      set => _daysSinceRecordLastModified = value;
    }

    [DataMember(Order = 81)]
    public string MobileOfflineFilters
    {
      get => _mobileOfflineFilters;
      set => _mobileOfflineFilters = value;
    }

    [DataMember]
    public bool? IsReadingPaneEnabled
    {
      get => _isReadingPaneEnabled;
      set => _isReadingPaneEnabled = value;
    }

    [DataMember]
    public bool? IsQuickCreateEnabled
    {
      get => _isQuickCreateEnabled;
      set => _isQuickCreateEnabled = value;
    }

    [DataMember]
    [Alternatekey]
    public string LogicalName
    {
      get => _logicalName;
      set => _logicalName = value;
    }

    [DataMember]
    public ManyToManyRelationshipMetadata[] ManyToManyRelationships
    {
      get => _manyToManyRelationships;
      internal set => _manyToManyRelationships = value;
    }

    [DataMember]
    public OneToManyRelationshipMetadata[] ManyToOneRelationships
    {
      get => _manyToOneRelationships;
      internal set => _manyToOneRelationships = value;
    }

    [DataMember]
    public OneToManyRelationshipMetadata[] OneToManyRelationships
    {
      get => _oneToManyRelationships;
      internal set => _oneToManyRelationships = value;
    }

    [DataMember]
    public int? ObjectTypeCode
    {
      get => _objectTypeCode;
      internal set => _objectTypeCode = value;
    }

    [DataMember]
    public OwnershipTypes? OwnershipType
    {
      get => _ownershipType;
      set => _ownershipType = value;
    }

    [DataMember]
    public string PrimaryNameAttribute
    {
      get => _primaryNameAttribute;
      internal set => _primaryNameAttribute = value;
    }

    [DataMember(Order = 60)]
    public string PrimaryImageAttribute
    {
      get => _primaryImageAttribute;
      internal set => _primaryImageAttribute = value;
    }

    [DataMember]
    public string PrimaryIdAttribute
    {
      get => _primaryIdAttribute;
      internal set => _primaryIdAttribute = value;
    }

    [DataMember]
    public SecurityPrivilegeMetadata[] Privileges
    {
      get => _privileges;
      internal set => _privileges = value;
    }

    [DataMember]
    public string RecurrenceBaseEntityLogicalName
    {
      get => _recurrenceBaseEntityLogicalName;
      internal set => _recurrenceBaseEntityLogicalName = value;
    }

    [DataMember]
    public string ReportViewName
    {
      get => _reportViewName;
      internal set => _reportViewName = value;
    }

    [DataMember]
    public string SchemaName
    {
      get => _schemaName;
      set => _schemaName = value;
    }

    /// <summary>
    /// Gets the version an entity was introduced in.
    /// This is the assembly version of the product's release
    /// </summary>
    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => _introducedVersion;
      internal set => _introducedVersion = value;
    }

    [DataMember]
    public bool? IsStateModelAware
    {
      get => _isStateModelAware;
      internal set => _isStateModelAware = value;
    }

    [DataMember]
    public bool? EnforceStateTransitions
    {
      get => _enforceStateTransitions;
      internal set => _enforceStateTransitions = value;
    }

    internal int? WorkflowSupport
    {
      get => _workflowSupport;
      set => _workflowSupport = value;
    }

    internal string PhysicalName
    {
      get => _physicalName;
      set => _physicalName = value;
    }

    [DataMember]
    public string ExternalName
    {
      get => _externalName;
      set => _externalName = value;
    }

    [DataMember(Order = 71)]
    public string EntityColor
    {
      get => _entityColor;
      set => _entityColor = value;
    }

    [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
    [DataMember(Order = 71)]
    public EntityKeyMetadata[] Keys
    {
      get => _keys;
      internal set => _keys = value;
    }

    [DataMember(Order = 71)]
    public string LogicalCollectionName
    {
      get => _logicalCollectionName;
      set => _logicalCollectionName = value;
    }

    [DataMember(Order = 71)]
    public string ExternalCollectionName
    {
      get => _externalCollectionName;
      set => _externalCollectionName = value;
    }

    [DataMember(Order = 71)]
    public string CollectionSchemaName
    {
      get => _collectionSchemaName;
      internal set => _collectionSchemaName = value;
    }

    [DataMember(Order = 72)]
    public string EntitySetName
    {
      get => _entitySetName;
      set => _entitySetName = value;
    }

    [DataMember(Order = 72)]
    public bool? IsEnabledForExternalChannels
    {
      get => _isEnabledForExternalChannels;
      set => _isEnabledForExternalChannels = value;
    }

    [DataMember(Order = 72)]
    public bool? IsPrivate
    {
      get => _isPrivate;
      internal set => _isPrivate = value;
    }

    [DataMember]
    public bool? UsesBusinessDataLabelTable
    {
      get => _usesBusinessDataLabelTable;
      set => _usesBusinessDataLabelTable = value;
    }

    [DataMember(Order = 82)]
    public bool? IsLogicalEntity
    {
      get => _isLogicalEntity;
      internal set => _isLogicalEntity = value;
    }

    [DataMember]
    public bool? HasNotes
    {
      get => _hasNotes;
      set => _hasNotes = value;
    }

    [DataMember]
    public bool? HasActivities
    {
      get => _hasActivities;
      set => _hasActivities = value;
    }

    [DataMember]
    public bool? HasFeedback
    {
      get => _hasFeedback;
      set => _hasFeedback = value;
    }

    [DataMember]
    public bool? IsSolutionAware
    {
      get => _isSolutionAware;
      set => _isSolutionAware = value;
    }

    [DataMember]
    public EntitySetting[] Settings { get; set; }

    [DataMember]
    public DateTime? CreatedOn { get; internal set; }

    [DataMember]
    public DateTime? ModifiedOn { get; internal set; }

    [DataMember]
    public bool? HasEmailAddresses
    {
      get => _hasEmailAddresses;
      set => _hasEmailAddresses = value;
    }

    [DataMember]
    public Guid? OwnerId
    {
      get => _ownerId;
      set => _ownerId = value;
    }

    [DataMember]
    public int? OwnerIdType
    {
      get => _ownerIdType;
      set => _ownerIdType = value;
    }

    [DataMember]
    public Guid? OwningBusinessUnit
    {
      get => _owningBusinessUnit;
      set => _owningBusinessUnit = value;
    }

    internal int? AvailableForRetrieve
    {
      get => _availableForRetrieve;
      set => _availableForRetrieve = value;
    }

    internal int? AvailableForRetrieveMultiple
    {
      get => _availableForRetrieveMultiple;
      set => _availableForRetrieveMultiple = value;
    }

    internal int? AvailableForCreate
    {
      get => _availableForCreate;
      set => _availableForCreate = value;
    }

    internal int? AvailableForUpdate
    {
      get => _availableForUpdate;
      set => _availableForUpdate = value;
    }

    internal int? AvailableForDelete
    {
      get => _availableForDelete;
      set => _availableForDelete = value;
    }
  }
}
