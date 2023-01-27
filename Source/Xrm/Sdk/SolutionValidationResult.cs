// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SolutionValidationResult
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// A container which is used to record any issues that were found during validating process.
  /// </summary>
  [DataContract(Name = "SolutionValidationResult", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class SolutionValidationResult
  {
    /// <summary>The SolutionValidationResult Type</summary>
    [DataMember]
    public SolutionValidationResultType SolutionValidationResultType { get; set; }

    /// <summary>A plain text message that describes the issue.</summary>
    [DataMember]
    public string Message { get; set; }

    /// <summary>Errorcode</summary>
    [DataMember]
    public int ErrorCode { get; set; }

    /// <summary>AdditionalInfo</summary>
    [DataMember]
    public string AdditionalInfo { get; set; }
  }
}
