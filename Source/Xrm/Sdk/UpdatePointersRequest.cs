// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.UpdatePointersRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Data contract for the update pointers request.</summary>
  [DataContract(Name = "UpdatePointersRequest", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class UpdatePointersRequest
  {
    /// <summary>Gets or sets the prefix.</summary>
    [DataMember]
    public string Prefix { get; set; }

    /// <summary>Gets or sets the storage pointer.</summary>
    [DataMember]
    public int StoragePointer { get; set; }

    /// <summary>Gets or sets the file pointer.</summary>
    [DataMember]
    public Guid FilePointer { get; set; }

    /// <summary>Gets or sets the file size.</summary>
    [DataMember]
    public long FileSize { get; set; }

    /// <summary>Gets or sets the object type code.</summary>
    [DataMember]
    public int Otc { get; set; }

    /// <summary>
    /// Gets or sets the id of the target attachment or annotation.
    /// </summary>
    [DataMember]
    public Guid TargetObjectId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether whether to set the body or documentbody column to null in the target annotation or attachment.
    /// </summary>
    [DataMember]
    public bool SetBodyToNull { get; set; }

    /// <summary>Gets or sets the organization id.</summary>
    [DataMember]
    public Guid OrganizationId { get; set; }

    /// <summary>Gets or sets the scale group id.</summary>
    [DataMember]
    public Guid ScaleGroupId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the CMK is enabled.
    /// </summary>
    [DataMember]
    public bool IsCmkEnabled { get; set; }

    /// <summary>Gets or sets the extension data.</summary>
    public ExtensionDataObject ExtensionData { get; set; }
  }
}
