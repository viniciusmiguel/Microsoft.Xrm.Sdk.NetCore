// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.TriggerDefinition
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Data contract for the Reconciled Entity File pointers response
  /// </summary>
  [DataContract(Name = "TriggerDefinition", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class TriggerDefinition : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Display name of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 0)]
    public string DisplayName { get; set; }

    /// <summary>primary entity logical name of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 1)]
    public string PrimaryEntityLogicalName { get; set; }

    /// <summary>primary entity displayname of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 2)]
    public string PrimaryEntityDisplayName { get; set; }

    /// <summary>Sdk message id of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 3)]
    public Guid SdkMessageId { get; set; }

    /// <summary>sdk message name of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 4)]
    public string SdkMessageName { get; set; }

    /// <summary>catalog unique name of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 5)]
    public string CatalogUniqueName { get; set; }

    /// <summary>catalog display name of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 6)]
    public string CatalogDisplayName { get; set; }

    /// <summary>sub-catalog unique name of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 7)]
    public string SubCatalogUniqueName { get; set; }

    /// <summary>sub-catalog unique name of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 8)]
    public string SubCatalogDisplayName { get; set; }

    /// <summary>event type of the trigger definition</summary>
    [DataMember(IsRequired = false, Order = 9)]
    public string EventType { get; set; }

    /// <summary>Primary entity id</summary>
    [DataMember(IsRequired = false, Order = 10)]
    public Guid PrimaryEntityId { get; set; }

    /// <summary>Catalog Id</summary>
    [DataMember(IsRequired = false, Order = 11)]
    public Guid CatalogId { get; set; }

    /// <summary>Sub catalog Id</summary>
    [DataMember(IsRequired = false, Order = 12)]
    public Guid SubCatalogId { get; set; }

    /// <summary>OpenApi operation id name</summary>
    [DataMember(IsRequired = false, Order = 13)]
    public string OpenApiOperationIdName { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
