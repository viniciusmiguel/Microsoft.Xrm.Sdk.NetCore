// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.ValidateFetchXmlExpressionResult
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  /// <summary>
  /// Response container which given back to the caller of the ValidateFetchExpression api
  /// </summary>
  [DataContract(Name = "ValidateFetchXmlExpressionResult", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class ValidateFetchXmlExpressionResult : IExtensibleDataObject
  {
    [DataMember]
    public string Helplink { get; set; } = "https://go.microsoft.com/fwlink/?linkid=2161205";

    /// <summary>
    /// Messages found during the validation of a given fetchxml
    /// </summary>
    [DataMember]
    public List<ValidatorIssue> Messages { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
