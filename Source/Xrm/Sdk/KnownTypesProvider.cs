// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.KnownTypesProvider
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Class to centralize known types for the SDK contracts</summary>
  [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Class contains lists of types.")]
  internal static class KnownTypesProvider
  {
    private static object _lockObj = new();
    private static volatile List<Assembly> _knownAssemblies = null;
    private static volatile Dictionary<string, Type> _knownCustomValueTypes = null;
    private static volatile bool _regenerateknownCustomValueTypes = false;
    private static volatile ConcurrentDictionary<string, Type> _knownOrganizationRequestResponseTypesByQualifiedName = null;
    private static volatile ConcurrentDictionary<string, Type> _knownOrganizationRequestResponseTypesByTypeName = null;
    private static volatile bool _regenerateknownOrganizationRequestResponseTypes = true;

    [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
    [SecuritySafeCritical]
    static KnownTypesProvider() => AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(CurrentDomain_AssemblyLoad);

    private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args) => RegisterAssembly(args.LoadedAssembly);

    private static List<Assembly> KnownAssemblies
    {
      get
      {
        if (_knownAssemblies == null)
        {
          lock (_lockObj)
          {
            if (_knownAssemblies == null)
            {
              var assemblyList = new List<Assembly>();
              foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
              {
                if (GetProxyTypesAttribute(assembly) != null && !assemblyList.Contains(assembly))
                {
                  assemblyList.Add(assembly);
                  _regenerateknownCustomValueTypes = true;
                  _regenerateknownOrganizationRequestResponseTypes = true;
                }
              }
              _knownAssemblies = assemblyList;
            }
          }
        }
        return _knownAssemblies;
      }
    }

    /// <summary>
    /// Registers the assembly if it contain the ProxyTypesAssemblyAttribute
    /// </summary>
    /// <param name="assembly"></param>
    private static void RegisterAssembly(Assembly assembly)
    {
      if (GetProxyTypesAttribute(assembly) == null || KnownAssemblies.Contains(assembly))
        return;
      lock (_lockObj)
      {
        if (_knownAssemblies.Contains(assembly))
          return;
        _knownAssemblies.Add(assembly);
        _regenerateknownCustomValueTypes = true;
        _regenerateknownOrganizationRequestResponseTypes = true;
      }
    }

    /// <summary>
    /// Extract the ProxyTypesAssemblyAttribute on the assembly
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns>attribute if it is defined. null otherwise</returns>
    private static ProxyTypesAssemblyAttribute GetProxyTypesAttribute(Assembly assembly)
    {
      var customAttributes = assembly.GetCustomAttributes(typeof (ProxyTypesAssemblyAttribute), false);
      return customAttributes == null || customAttributes.Length == 0 ? null : customAttributes[0] as ProxyTypesAssemblyAttribute;
    }

    internal static Dictionary<string, Type> KnownCustomValueTypes
    {
      get
      {
        if (_knownCustomValueTypes == null || _regenerateknownCustomValueTypes)
        {
          lock (_lockObj)
          {
            if (_knownCustomValueTypes != null)
            {
              if (!_regenerateknownCustomValueTypes)
                goto label_23;
            }
            var knownAssemblies = KnownAssemblies;
            var dictionary = new Dictionary<string, Type>();
            foreach (var assembly in knownAssemblies)
            {
              if (!(assembly == Assembly.GetExecutingAssembly()))
              {
                var proxyTypesAttribute = GetProxyTypesAttribute(assembly);
                if (proxyTypesAttribute != null && proxyTypesAttribute.ContainsSharedContracts)
                {
                  foreach (var exportedType in assembly.GetExportedTypes())
                  {
                    var flag = false;
                    var customAttributes1 = exportedType.GetCustomAttributes(typeof (DataContractAttribute), false);
                    if (customAttributes1 != null && customAttributes1.Length != 0)
                    {
                      flag = true;
                    }
                    else
                    {
                      var customAttributes2 = exportedType.GetCustomAttributes(typeof (CollectionDataContractAttribute), false);
                      if (customAttributes2 != null && customAttributes2.Length != 0)
                        flag = true;
                    }
                    if (flag && !exportedType.IsSubclassOf(typeof (OrganizationRequest)) && !exportedType.IsSubclassOf(typeof (OrganizationResponse)) && !dictionary.ContainsKey(exportedType.Name))
                    {
                      dictionary.Add(exportedType.Name, exportedType);
                      dictionary.Add(string.Format(CultureInfo.InvariantCulture, "ArrayOf{0}", exportedType.Name), exportedType.MakeArrayType());
                      dictionary.Add(string.Format(CultureInfo.InvariantCulture, "ArrayOfArrayOf{0}", exportedType.Name), exportedType.MakeArrayType().MakeArrayType());
                    }
                  }
                }
              }
            }
            _knownCustomValueTypes = dictionary;
            _regenerateknownCustomValueTypes = false;
          }
        }
label_23:
        return _knownCustomValueTypes;
      }
    }

    /// <summary>
    /// Dictionary of known organization Request/Response types by qualified name
    /// </summary>
    internal static ConcurrentDictionary<string, Type> KnownOrganizationRequestResponseTypes
    {
      get
      {
        LoadKnownOrganizationRequestResponseTypes();
        return _knownOrganizationRequestResponseTypesByQualifiedName;
      }
    }

    /// <summary>
    /// Dictionary of known organization Request/Response types by type name
    /// </summary>
    internal static ConcurrentDictionary<string, Type> KnownOrganizationRequestResponseTypesByTypeName
    {
      get
      {
        LoadKnownOrganizationRequestResponseTypes();
        return _knownOrganizationRequestResponseTypesByTypeName;
      }
    }

    /// <summary>
    /// Reflect and loads the knownassemblies if the knowncustomvaluetypes have not been initialized (or) if the knownassemblies list has been updated.
    /// </summary>
    private static void LoadKnownOrganizationRequestResponseTypes()
    {
      if (!_regenerateknownOrganizationRequestResponseTypes)
        return;
      lock (_lockObj)
      {
        if (!_regenerateknownOrganizationRequestResponseTypes)
          return;
        _knownOrganizationRequestResponseTypesByQualifiedName = new ConcurrentDictionary<string, Type>();
        _knownOrganizationRequestResponseTypesByTypeName = new ConcurrentDictionary<string, Type>();
        foreach (var knownAssembly in KnownAssemblies)
        {
          foreach (var exportedType in knownAssembly.GetExportedTypes())
          {
            var type = exportedType;
            var customAttributes = type.GetCustomAttributes(typeof (DataContractAttribute), false);
            if (customAttributes != null && customAttributes.Length != 0 && (type.IsSubclassOf(typeof (OrganizationRequest)) || type.IsSubclassOf(typeof (OrganizationResponse))))
            {
              foreach (DataContractAttribute contractAttribute in customAttributes)
              {
                var key1 = QualifiedName(contractAttribute.Name ?? type.Name, contractAttribute.Namespace);
                if (!_knownOrganizationRequestResponseTypesByQualifiedName.ContainsKey(key1))
                  _knownOrganizationRequestResponseTypesByQualifiedName.AddOrUpdate(key1, type, (key, oldValue) => type);
                if (!_knownOrganizationRequestResponseTypesByTypeName.ContainsKey(type.Name))
                  _knownOrganizationRequestResponseTypesByTypeName.AddOrUpdate(type.Name, type, (key, oldValue) => type);
              }
            }
          }
        }
        _regenerateknownOrganizationRequestResponseTypes = false;
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "The extra coupling is temporary.")]
    public static IEnumerable<Type> RetrieveKnownValueTypes()
    {
      var knownTypes = new List<Type>();
      AddKnownAttributeTypes(knownTypes);
      knownTypes.Add(typeof (AliasedValue));
      knownTypes.Add(typeof (Dictionary<string, string>));
      knownTypes.Add(typeof (Entity));
      knownTypes.Add(typeof (Entity[]));
      knownTypes.Add(typeof (ColumnSet));
      knownTypes.Add(typeof (EntityReferenceCollection));
      knownTypes.Add(typeof (QueryBase));
      knownTypes.Add(typeof (QueryExpression));
      knownTypes.Add(typeof (QueryExpression[]));
      knownTypes.Add(typeof (LocalizedLabel[]));
      knownTypes.Add(typeof (PagingInfo));
      knownTypes.Add(typeof (Relationship));
      knownTypes.Add(typeof (AttributePrivilegeCollection));
      knownTypes.Add(typeof (RelationshipQueryCollection));
      knownTypes.Add(typeof (EntityMetadataCollection));
      knownTypes.Add(typeof (OneToManyRelationshipMetadata[]));
      knownTypes.Add(typeof (MetadataFilterExpression));
      knownTypes.Add(typeof (MetadataConditionExpression));
      knownTypes.Add(typeof (MetadataQueryBase));
      knownTypes.Add(typeof (DeletedMetadataFilters));
      knownTypes.Add(typeof (DeletedMetadataCollection));
      knownTypes.Add(typeof (ExecuteMultipleSettings));
      knownTypes.Add(typeof (OrganizationRequestCollection));
      knownTypes.Add(typeof (OrganizationResponseCollection));
      knownTypes.Add(typeof (ExecuteMultipleResponseItemCollection));
      knownTypes.Add(typeof (QuickFindResultCollection));
      knownTypes.Add(typeof (QuickFindConfigurationCollection));
      knownTypes.Add(typeof (AttributeMappingCollection));
      knownTypes.Add(typeof (MailboxTrackingFolderMappingCollection));
      knownTypes.Add(typeof (OrganizationDetail));
      knownTypes.Add(typeof (KeyAttributeCollection));
      knownTypes.Add(typeof (BusinessEntityChanges));
      knownTypes.Add(typeof (BusinessEntityChangesCollection));
      knownTypes.Add(typeof (ConcurrencyBehavior));
      knownTypes.Add(typeof (ChangeType));
      knownTypes.Add(typeof (NewOrUpdatedItem));
      knownTypes.Add(typeof (RemovedOrDeletedItem));
      knownTypes.Add(typeof (EntityAttributeCollection));
      knownTypes.Add(typeof (EmailEngagementAggregate));
      knownTypes.Add(typeof (OptionSetValueCollection));
      knownTypes.Add(typeof (OrganizationInfo));
      knownTypes.Add(typeof (UserLicenseInfo));
      knownTypes.Add(typeof (UserSearchFacet));
      knownTypes.Add(typeof (UserSearchFacetCollection));
      knownTypes.Add(typeof (UserSearchFacetResponseCollection));
      knownTypes.Add(typeof (DependencyDepth));
      knownTypes.Add(typeof (MetadataQuery));
      knownTypes.Add(typeof (ImportFileUploadResponse));
      knownTypes.Add(typeof (EntityRecordCountCollection));
      knownTypes.Add(typeof (DependencySummary));
      knownTypes.Add(typeof (DependencySummary[]));
      knownTypes.Add(typeof (LookupEntityInfo));
      knownTypes.Add(typeof (EntityAndAttribute));
      knownTypes.Add(typeof (LookupDataRequest));
      knownTypes.Add(typeof (EntityFilePointersRequest));
      knownTypes.Add(typeof (EntityFilePointersResponse));
      knownTypes.Add(typeof (UpdatePointersRequest));
      knownTypes.Add(typeof (ViewColumn));
      knownTypes.Add(typeof (ViewColumn[]));
      knownTypes.Add(typeof (LookupView));
      knownTypes.Add(typeof (LookupEntityMetadata));
      knownTypes.Add(typeof (LookupMetadata));
      knownTypes.Add(typeof (LookupEntityResponse));
      knownTypes.Add(typeof (LookupEntityResponse[]));
      knownTypes.Add(typeof (LookupDataResponse));
      knownTypes.Add(typeof (CascadeSPGenerationRequest));
      knownTypes.Add(typeof (PrivilegeInfo));
      knownTypes.Add(typeof (PrivilegeRoleMapping));
      knownTypes.Add(typeof (PrivilegeRoleAssignmentRequest));
      knownTypes.Add(typeof (EntityUIProcessRequest));
      knownTypes.Add(typeof (CreateReserveEntityRequest));
      knownTypes.Add(typeof (AnalyticsStoreDetails));
      knownTypes.Add(typeof (LayerDesiredOrder));
      knownTypes.Add(typeof (LayerDesiredOrderType));
      knownTypes.Add(typeof (SolutionParameters));
      knownTypes.Add(typeof (ImportDecision));
      knownTypes.Add(typeof (SolutionComponentOption));
      knownTypes.Add(typeof (SolutionInfo));
      knownTypes.Add(typeof (SolutionOperationResult));
      knownTypes.Add(typeof (SolutionOperationType));
      knownTypes.Add(typeof (SolutionOperationStatus));
      knownTypes.Add(typeof (SolutionOperationMessageType));
      knownTypes.Add(typeof (StageSolutionResults));
      knownTypes.Add(typeof (StageSolutionStatus));
      knownTypes.Add(typeof (ProvisionLanguageForUserResult));
      knownTypes.Add(typeof (ProvisionLanguageForUserStatusType));
      knownTypes.Add(typeof (SolutionDetails));
      knownTypes.Add(typeof (MissingDependency));
      knownTypes.Add(typeof (ExportComponentDetails));
      knownTypes.Add(typeof (ExportComponentsParams));
      knownTypes.Add(typeof (SolutionComponentDetails));
      knownTypes.Add(typeof (SolutionValidationResult));
      knownTypes.Add(typeof (SolutionValidationResultType));
      knownTypes.Add(typeof (SqlNameMappingOptions));
      knownTypes.Add(typeof (PSqlConnectionContext));
      knownTypes.Add(typeof (FileSasUrlResponse));
      knownTypes.Add(typeof (TriggerDefinition));
      knownTypes.Add(typeof (TriggerDefinitions));
      knownTypes.Add(typeof (UpgradeCurrencyTypeStatus));
      knownTypes.Add(typeof (UpgradeCurrencyTypeTable));
      knownTypes.Add(typeof (ValidateSolutionStatus));
      knownTypes.Add(typeof (ValidateSolutionPrerequisitesResult));
      foreach (var type in KnownCustomValueTypes.Values)
        knownTypes.Add(type);
      return knownTypes;
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
    public static IEnumerable<Type> RetrieveKnownConditionValueTypes()
    {
      var knownTypes = new List<Type>();
      AddKnownAttributeTypes(knownTypes);
      return knownTypes;
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by other methods of this class")]
    internal static void AddKnownAttributeTypes(List<Type> knownTypes)
    {
      knownTypes.Add(typeof (bool));
      knownTypes.Add(typeof (bool[]));
      knownTypes.Add(typeof (int));
      knownTypes.Add(typeof (int[]));
      knownTypes.Add(typeof (string));
      knownTypes.Add(typeof (string[]));
      knownTypes.Add(typeof (string[][]));
      knownTypes.Add(typeof (double));
      knownTypes.Add(typeof (double[]));
      knownTypes.Add(typeof (Decimal));
      knownTypes.Add(typeof (Decimal[]));
      knownTypes.Add(typeof (Guid));
      knownTypes.Add(typeof (Guid[]));
      knownTypes.Add(typeof (DateTime));
      knownTypes.Add(typeof (DateTime[]));
      knownTypes.Add(typeof (Money));
      knownTypes.Add(typeof (Money[]));
      knownTypes.Add(typeof (DataSet));
      knownTypes.Add(typeof (EntityReference));
      knownTypes.Add(typeof (EntityReference[]));
      knownTypes.Add(typeof (OptionSetValue));
      knownTypes.Add(typeof (OptionSetValue[]));
      knownTypes.Add(typeof (EntityCollection));
      knownTypes.Add(typeof (EntityCollection[]));
      knownTypes.Add(typeof (EntityImageCollection[]));
      knownTypes.Add(typeof (Money));
      knownTypes.Add(typeof (Label));
      knownTypes.Add(typeof (LocalizedLabel));
      knownTypes.Add(typeof (LocalizedLabelCollection));
      knownTypes.Add(typeof (EntityMetadata[]));
      knownTypes.Add(typeof (EntityMetadata));
      knownTypes.Add(typeof (AttributeMetadata[]));
      knownTypes.Add(typeof (AttributeMetadata));
      knownTypes.Add(typeof (RelationshipMetadataBase[]));
      knownTypes.Add(typeof (RelationshipMetadataBase));
      knownTypes.Add(typeof (EntityFilters));
      knownTypes.Add(typeof (OptionSetMetadataBase));
      knownTypes.Add(typeof (OptionSetMetadataBase[]));
      knownTypes.Add(typeof (OptionSetMetadata));
      knownTypes.Add(typeof (BooleanOptionSetMetadata));
      knownTypes.Add(typeof (OptionSetType));
      knownTypes.Add(typeof (ManagedPropertyMetadata));
      knownTypes.Add(typeof (ManagedPropertyMetadata[]));
      knownTypes.Add(typeof (EntityKeyMetadata[]));
      knownTypes.Add(typeof (EntityKeyMetadata));
      knownTypes.Add(typeof (EntitySetting[]));
      knownTypes.Add(typeof (EntitySetting));
      knownTypes.Add(typeof (BooleanManagedProperty));
      knownTypes.Add(typeof (AttributeRequiredLevelManagedProperty));
      knownTypes.Add(typeof (EndpointAccessType));
      knownTypes.Add(typeof (GlobalSearchConfigurations));
      knownTypes.Add(typeof (GlobalSearchConfigurationCollection));
      knownTypes.Add(typeof (GlobalSearchConfigurationResponseCollection));
      knownTypes.Add(typeof (SelectColumn));
      knownTypes.Add(typeof (SelectColumnCollection));
      knownTypes.Add(typeof (SelectColumnCollection[]));
    }

    public static List<Type> GetKnownMetadataEnumTypes() => new()
    {
      typeof (object[]),
      typeof (StringFormat),
      typeof (StringFormat[]),
      typeof (AttributeRequiredLevel),
      typeof (AttributeRequiredLevel[]),
      typeof (AttributeTypeCode),
      typeof (AttributeTypeCode[]),
      typeof (CascadeType),
      typeof (CascadeType[]),
      typeof (Metadata.DateTimeFormat),
      typeof (Metadata.DateTimeFormat[]),
      typeof (IntegerFormat),
      typeof (IntegerFormat[]),
      typeof (LookupFormat),
      typeof (LookupFormat[]),
      typeof (ManagedPropertyEvaluationPriority),
      typeof (ManagedPropertyEvaluationPriority[]),
      typeof (ManagedPropertyOperation),
      typeof (ManagedPropertyOperation[]),
      typeof (ManagedPropertyType),
      typeof (ManagedPropertyType[]),
      typeof (SecurityTypes),
      typeof (SecurityTypes[]),
      typeof (OwnershipTypes),
      typeof (OwnershipTypes[]),
      typeof (ImeMode),
      typeof (ImeMode[]),
      typeof (RelationshipType),
      typeof (RelationshipType[]),
      typeof (AttributeTypeDisplayName),
      typeof (AttributeTypeDisplayName[])
    };

    internal static string QualifiedName(string typeName, string typeNamespace) => string.Format(CultureInfo.InvariantCulture, "{0}/{1}", typeNamespace, typeName);
  }
}
