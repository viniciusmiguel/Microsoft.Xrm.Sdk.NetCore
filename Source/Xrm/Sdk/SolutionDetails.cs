// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SolutionDetails
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "SolutionDetails", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class SolutionDetails
  {
    [DataMember]
    public string SolutionUniqueName { get; set; }

    [DataMember]
    public string SolutionFriendlyName { get; set; }

    [DataMember]
    public string SolutionDescription { get; set; }

    [DataMember]
    public string PublisherUniqueName { get; set; }

    [DataMember]
    public string PublisherFriendlyName { get; set; }

    [DataMember]
    public string PreviousSolutionUniqueName { get; set; }

    [DataMember]
    public string PreviousSolutionFriendlyName { get; set; }

    [DataMember]
    public string PreviousPublisherUniqueName { get; set; }

    [DataMember]
    public string PreviousPublisherFriendlyName { get; set; }

    [DataMember]
    public bool IsPatchSolution { get; set; }

    [DataMember]
    public bool IsManaged { get; set; }

    [DataMember]
    public bool PreviousIsManaged { get; set; }

    [DataMember]
    public string SolutionVersion { get; set; }

    [DataMember]
    public string PreviousSolutionVersion { get; set; }

    [DataMember]
    public List<string> PreviousPatchSolutionsNames { get; set; }

    [DataMember]
    public bool IsPrerequisitesExport { get; set; }

    [DataMember]
    public bool HasPendingUpgrade { get; set; }
  }
}
