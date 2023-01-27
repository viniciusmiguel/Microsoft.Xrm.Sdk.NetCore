// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.StageSolutionResults
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Stage solution results</summary>
  [DataContract(Name = "StageSolutionResults", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class StageSolutionResults : IExtensibleDataObject
  {
    [DataMember]
    public Guid StageSolutionUploadId { get; set; }

    [DataMember]
    public List<SolutionComponentDetails> SolutionComponentsDetails { get; set; }

    [DataMember]
    public SolutionDetails SolutionDetails { get; set; }

    [DataMember]
    public List<MissingDependency> MissingDependencies { get; set; }

    [DataMember]
    public StageSolutionStatus StageSolutionStatus { get; set; }

    [DataMember]
    public List<SolutionValidationResult> SolutionValidationResults { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
