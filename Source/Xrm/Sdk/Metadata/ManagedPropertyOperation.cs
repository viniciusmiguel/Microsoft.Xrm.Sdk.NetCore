// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ManagedPropertyOperation
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ManagedPropertyOperation", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public enum ManagedPropertyOperation
  {
    [EnumMember(Value = "None")] None = 0,
    [EnumMember(Value = "Create")] Create = 1,
    [EnumMember(Value = "Update")] Update = 2,
    [EnumMember(Value = "CreateUpdate")] CreateUpdate = 3,
    [EnumMember(Value = "Delete")] Delete = 4,
    [EnumMember(Value = "UpdateDelete")] UpdateDelete = 6,
    [EnumMember(Value = "All")] All = 7,
  }
}
