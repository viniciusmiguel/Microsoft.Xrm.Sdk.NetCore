// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SolutionComponentDetails
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "SolutionComponentDetails", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class SolutionComponentDetails
  {
    [DataMember]
    public string ComponentName { get; set; }

    [DataMember]
    public Dictionary<string, string> Attributes { get; set; }

    [DataMember]
    public string ComponentTypeName { get; set; }

    [DataMember]
    public PresentInOrg IsPresentInOrg { get; set; }
  }
}
