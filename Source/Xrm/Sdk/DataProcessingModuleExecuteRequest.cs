// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DataProcessingModuleExecuteRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "DataProcessingModuleExecuteRequest", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class DataProcessingModuleExecuteRequest : IExtensibleDataObject
  {
    /// <summary>Specify the module to execute</summary>
    [DataMember(IsRequired = true, Order = 0)]
    public Guid DataProcessingConfigurationId { get; set; }

    /// <summary>Specify the end points to execute</summary>
    [DataMember(IsRequired = false, Order = 1)]
    public string[] EndPoints { get; set; }

    /// <summary>Spark job name</summary>
    [DataMember(IsRequired = false, Order = 2)]
    public string JobName { get; set; }

    /// <summary>Python script for spark job</summary>
    [DataMember(IsRequired = false, Order = 3)]
    public string Script { get; set; }

    /// <summary>Python job arguments</summary>
    [DataMember(IsRequired = false, Order = 4)]
    public string[] JobArguments { get; set; }

    /// <summary>Gets or sets parameters for the request.</summary>
    [DataMember(Name = "ScalarInputs", IsRequired = false, Order = 5)]
    public ScalarInputParameter[] ScalarInputs { get; set; }

    /// <summary>
    /// The callback URL to call at the end of the module execution.
    /// </summary>
    [DataMember(Name = "CallbackUri", IsRequired = false, Order = 6)]
    public string CallbackUri { get; set; }

    /// <summary>The versions of inputs to the module</summary>
    [DataMember(Name = "UpstreamResults", IsRequired = false, Order = 7)]
    public UpstreamResultInput[] UpstreamResults { get; set; }

    [DataMember(Name = "OverrideApplicationId", IsRequired = false, Order = 8)]
    public Guid? OverrideApplicationId { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
