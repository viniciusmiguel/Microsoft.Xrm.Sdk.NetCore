// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.CascadeSPGenerationRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract]
  public sealed class CascadeSPGenerationRequest
  {
    /// <summary>Gets or sets if org is backed by Xdb.</summary>
    [DataMember]
    public bool IsBackedByXdb { get; set; }

    /// <summary>Gets or sets the cascading changing list.</summary>
    [DataMember]
    public ArrayList CascadingChangeList { get; set; }

    /// <summary>Gets or sets list of cascade rollup entities.</summary>
    [DataMember]
    public HashSet<Guid> CascadeRollupEntities { get; set; }

    /// <summary>
    /// Gets or sets the list which contains object type code of the entities for which cascade SP has to be generated.
    /// </summary>
    [DataMember]
    public HashSet<int> EntitiesBeingChanged { get; set; }

    /// <summary>Gets or sets the request correlation id.</summary>
    [DataMember]
    public Guid RequestCorrelationId { get; set; }
  }
}
