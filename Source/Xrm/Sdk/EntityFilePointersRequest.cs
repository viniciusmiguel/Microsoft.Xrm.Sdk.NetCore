// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntityFilePointersRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Data contract for the Entity File pointers to Reconcile
  /// </summary>
  [DataContract(Name = "EntityFilePointersRequest", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class EntityFilePointersRequest : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public int ObjectTypeCode { get; set; }

    /// <summary>List of file pointers to reconcile</summary>
    [DataMember]
    public string[] FilePointers { get; set; }

    /// <summary>Gets or sets the organization id.</summary>
    [DataMember]
    public Guid OrganizationId { get; set; }

    /// <summary>Gets or sets the scale group id.</summary>
    [DataMember]
    public Guid ScaleGroupId { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
