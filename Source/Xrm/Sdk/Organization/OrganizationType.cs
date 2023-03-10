// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Organization.OrganizationType
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
  /// <summary>An Enumeration represents Organization Type</summary>
  /// <remarks>
  /// Copied from src\Platform\Core\DataServices\Configuration\LocatorService\LocatorServiceInterface.cs
  /// </remarks>
  [DataContract(Name = "OrganizationType", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public enum OrganizationType
  {
    [EnumMember] Customer,
    [EnumMember] Monitoring,
    [EnumMember] Support,
    [EnumMember] BackEnd,
    [EnumMember] Secondary,
    [EnumMember] CustomerTest,
    [EnumMember] CustomerFreeTest,
    [EnumMember] CustomerPreview,
    [EnumMember] Placeholder,
    [EnumMember] TestDrive,
    [EnumMember] MsftInvestigation,
    [EnumMember] EmailTrial,
    [EnumMember] Default,
    [EnumMember] Developer,
    [EnumMember] Trial,
    [EnumMember] Teams,
  }
}
