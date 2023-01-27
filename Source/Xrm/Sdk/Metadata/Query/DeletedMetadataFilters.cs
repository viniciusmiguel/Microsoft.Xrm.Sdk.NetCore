// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.DeletedMetadataFilters
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  /// <summary>Enumeration that lists the types of deleted metadata</summary>
  [Flags]
  [DataContract(Name = "DeletedMetadataFilters", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public enum DeletedMetadataFilters
  {
    [EnumMember(Value = "Entity")] Entity = 1,
    [EnumMember(Value = "Attribute")] Attribute = 2,
    [EnumMember(Value = "Relationship")] Relationship = 4,
    [EnumMember(Value = "Label")] Label = 8,
    [EnumMember(Value = "OptionSet")] OptionSet = 16, // 0x00000010
    Default = Entity, // 0x00000001
    All = Default | OptionSet | Label | Relationship | Attribute, // 0x0000001F
  }
}
