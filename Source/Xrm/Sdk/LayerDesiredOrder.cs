// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.LayerDesiredOrder
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Holds the hints for solution install</summary>
  [DataContract(Name = "LayerDesiredOrder", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class LayerDesiredOrder : IExtensibleDataObject
  {
    private LayerDesiredOrderType _type;
    private List<SolutionInfo> _solutions;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public LayerDesiredOrderType Type
    {
      get => _type;
      set => _type = value;
    }

    [DataMember]
    public List<SolutionInfo> Solutions
    {
      get => _solutions;
      set => _solutions = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
