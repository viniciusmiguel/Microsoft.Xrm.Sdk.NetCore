// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.StringFormat
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "StringFormat", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public enum StringFormat
  {
    [EnumMember(Value = "Email")] Email,
    [EnumMember(Value = "Text")] Text,
    [EnumMember(Value = "TextArea")] TextArea,
    [EnumMember(Value = "Url")] Url,
    [EnumMember(Value = "TickerSymbol")] TickerSymbol,
    [EnumMember(Value = "PhoneticGuide")] PhoneticGuide,
    [EnumMember(Value = "VersionNumber")] VersionNumber,
    [EnumMember(Value = "Phone")] Phone,
    [EnumMember(Value = "Json")] Json,
    [EnumMember(Value = "RichText")] RichText,
  }
}
