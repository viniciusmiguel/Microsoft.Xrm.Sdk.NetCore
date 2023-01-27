// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.TdsPowerBISqlRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// TdsPowerBIRequest Class.
  /// Used by the TDS endpoint to send REST request over to the web role.
  /// </summary>
  [DataContract]
  public sealed class TdsPowerBISqlRequest
  {
    /// <summary>Query Text</summary>
    [DataMember]
    public string QueryText { get; set; }

    /// <summary>Gets or sets parameters for the request.</summary>
    [DataMember]
    public Dictionary<string, object> QueryParameters { get; set; }
  }
}
