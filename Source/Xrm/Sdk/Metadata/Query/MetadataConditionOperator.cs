// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.MetadataConditionOperator
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  [DataContract(Name = "MetadataConditionOperator", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public enum MetadataConditionOperator
  {
    [EnumMember(Value = "Equals")] Equals,
    [EnumMember(Value = "NotEquals")] NotEquals,
    [EnumMember(Value = "In")] In,
    [EnumMember(Value = "NotIn")] NotIn,
    [EnumMember(Value = "GreaterThan")] GreaterThan,
    [EnumMember(Value = "LessThan")] LessThan,
  }
}
