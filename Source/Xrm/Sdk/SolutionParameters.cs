﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SolutionParameters
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Holds the solution parameters for import</summary>
  [DataContract(Name = "SolutionParameters", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class SolutionParameters : IExtensibleDataObject
  {
    [DataMember]
    public Guid StageSolutionUploadId { get; set; }

    [DataMember]
    public List<SolutionComponentOption> SolutionComponentOptions { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
