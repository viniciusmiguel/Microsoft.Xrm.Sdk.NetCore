// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.DependencyDepth
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  /// <summary>
  /// The Enum defines the depth of dependencies that need to be syncd
  /// </summary>
  [DataContract(Name = "DependencyDepth", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public enum DependencyDepth
  {
    /// <summary>No type is specified</summary>
    [EnumMember] Unknown,
    /// <summary>
    /// On demand mode where root dependencies and context need to be synced
    /// </summary>
    [EnumMember] OnDemandWithContext,
    /// <summary>On demand mode where context sync is not needed</summary>
    [EnumMember] OnDemandWithoutContext,
    /// <summary>On demand mode where only context sync is needed</summary>
    [EnumMember] OnDemandContextOnly,
    /// <summary>Offline mode where everything need to be synced</summary>
    [EnumMember] Offline,
    /// <summary>Mobile mode</summary>
    [EnumMember] Mobile,
    /// <summary>User context mode, that</summary>
    [EnumMember] UserContext,
  }
}
