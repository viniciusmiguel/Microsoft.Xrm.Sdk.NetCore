// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.CreateTDSViewAsyncRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract]
  public sealed class CreateTDSViewAsyncRequest
  {
    /// <summary>Gets or sets the Entity logical name.</summary>
    [DataMember]
    public string EntityLogicalName { get; set; }

    /// <summary>Gets or sets the Caller id.</summary>
    [DataMember]
    public Guid CallerId { get; set; }

    /// <summary>Gets or sets the request correlation id.</summary>
    [DataMember]
    public Guid RequestCorrelationId { get; set; }
  }
}
