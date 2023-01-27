// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntityFilePointersResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Data contract for the Reconciled Entity File pointers response
  /// </summary>
  [DataContract(Name = "EntityFilePointersResponse", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class EntityFilePointersResponse : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>List of file pointers which are not in the Org DB</summary>
    [DataMember]
    public string[] UnReferencedFiles { get; set; }

    /// <summary>Whether the CMK is enabled for the organization.</summary>
    [DataMember]
    public bool IsCmkEnabled { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
