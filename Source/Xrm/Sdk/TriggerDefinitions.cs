// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.TriggerDefinitions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Data contract for the Reconciled Entity File pointers response
  /// </summary>
  [DataContract(Name = "TriggerDefinitions", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class TriggerDefinitions : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    public TriggerDefinitions() => Definitions = new List<TriggerDefinition>();

    /// <summary>List of Definitions</summary>
    [DataMember(IsRequired = false, Order = 0)]
    public List<TriggerDefinition> Definitions { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
