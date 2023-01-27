// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.ValidatorIssue
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  /// <summary>
  /// A container which is used to record any issues that were found during validating process.
  /// </summary>
  [DataContract(Name = "ValidatorIssue", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class ValidatorIssue
  {
    /// <summary>
    /// Unique errorcode which uniquely identifies a given issue type.
    /// This is losely typed to <see cref="T:Microsoft.Xrm.Sdk.Query.InfoCode" />. Not declared as an enum to prevent tight coupling between server and caller
    /// </summary>
    [DataMember]
    public int TypeCode { get; set; }

    /// <summary>
    /// How important is this issue in terms of needing to fix
    /// This is losely typed to <see cref="T:Microsoft.Xrm.Sdk.Query.SeverityLevel" />. Not declared as an enum to prevent tight coupling between server and caller
    /// </summary>
    [DataMember]
    public int Severity { get; set; }

    /// <summary>A plain text message that describes the issue.</summary>
    [DataMember]
    public string LocalizedMessageText { get; set; }

    /// <summary>
    /// A prop bag which is used to pass along any contextual information for the issue (Entity info, condition, etc)
    /// </summary>
    [DataMember]
    public Dictionary<string, string> OptionalPropertyBag { get; set; }
  }
}
