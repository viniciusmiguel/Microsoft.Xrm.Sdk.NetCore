// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SqlNameMappingOptions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Indicates whether the table names and column names in the sql command text are expressed in logical name or display name.
  /// </summary>
  [DataContract(Name = "SqlNameMappingOptions", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public enum SqlNameMappingOptions
  {
    [EnumMember] LogicalName,
    [EnumMember] DisplayName,
  }
}
