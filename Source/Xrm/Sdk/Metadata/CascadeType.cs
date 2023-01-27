// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.CascadeType
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "CascadeType", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public enum CascadeType
  {
    [EnumMember(Value = "NoCascade")] NoCascade,
    [EnumMember(Value = "Cascade")] Cascade,
    [EnumMember(Value = "Active")] Active,
    [EnumMember(Value = "UserOwned")] UserOwned,
    [EnumMember(Value = "RemoveLink")] RemoveLink,
    [EnumMember(Value = "Restrict")] Restrict,
  }
}
