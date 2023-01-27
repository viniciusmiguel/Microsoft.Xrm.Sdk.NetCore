// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ValidateSolutionPrerequisitesResult
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>results of the solution prerequities validation api</summary>
  [DataContract(Name = "ValidateSolutionPrerequisitesResult", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class ValidateSolutionPrerequisitesResult : IExtensibleDataObject
  {
    [DataMember]
    public List<SolutionComponentDetails> SolutionComponentsDetails { get; set; }

    [DataMember]
    public SolutionDetails SolutionDetails { get; set; }

    [DataMember]
    public List<MissingDependency> MissingDependencies { get; set; }

    [DataMember]
    public ValidateSolutionStatus ValidationStatus { get; set; }

    [DataMember]
    public List<SolutionValidationResult> SolutionValidationResults { get; set; }

    [DataMember(IsRequired = false)]
    public List<SolutionComponentDetails> OrgSolutionComponentsDetails { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
