// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "AttributeTypeCode", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public enum AttributeTypeCode
  {
    [EnumMember(Value = "Boolean")] Boolean,
    [EnumMember(Value = "Customer")] Customer,
    [EnumMember(Value = "DateTime")] DateTime,
    [EnumMember(Value = "Decimal")] Decimal,
    [EnumMember(Value = "Double")] Double,
    [EnumMember(Value = "Integer")] Integer,
    [EnumMember(Value = "Lookup")] Lookup,
    [EnumMember(Value = "Memo")] Memo,
    [EnumMember(Value = "Money")] Money,
    [EnumMember(Value = "Owner")] Owner,
    [EnumMember(Value = "PartyList")] PartyList,
    [EnumMember(Value = "Picklist")] Picklist,
    [EnumMember(Value = "State")] State,
    [EnumMember(Value = "Status")] Status,
    [EnumMember(Value = "String")] String,
    [EnumMember(Value = "Uniqueidentifier")] Uniqueidentifier,
    [EnumMember(Value = "CalendarRules")] CalendarRules,
    [EnumMember(Value = "Virtual")] Virtual,
    [EnumMember(Value = "BigInt")] BigInt,
    [EnumMember(Value = "ManagedProperty")] ManagedProperty,
    [EnumMember(Value = "EntityName")] EntityName,
  }
}
