// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.SeverityLevel
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  /// <summary>
  /// The impact of a given message where low is not that important and high / critical is blocking
  /// </summary>
  [DataContract(Name = "SeverityLevel", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public enum SeverityLevel
  {
    /// <summary>Low / Informational</summary>
    [EnumMember] Low,
    /// <summary>Somewhat impactful issue (Warning)</summary>
    [EnumMember] Medium,
    /// <summary>Highly impacting issue (blocking)</summary>
    [EnumMember] High,
    /// <summary>critically impacting issue (blocking)</summary>
    [EnumMember] Critical,
  }
}
