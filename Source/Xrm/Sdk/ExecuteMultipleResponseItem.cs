// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ExecuteMultipleResponseItem
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Wrapper class for the result of each individual Organization Request processed.
  /// 
  /// </summary>
  [DataContract(Name = "ExecuteMultipleResponseItem", Namespace = "http://schemas.microsoft.com/xrm/2012/Contracts")]
  public sealed class ExecuteMultipleResponseItem : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>
    /// Gets or sets the index of the original Organization Request that was processed.
    /// </summary>
    [DataMember]
    public int RequestIndex { get; set; }

    /// <summary>
    /// Gets or sets the OrganizationResponse for the Organization Request if ReturnResponses is true.
    /// </summary>
    [DataMember]
    public OrganizationResponse Response { get; set; }

    /// <summary>
    /// Gets or sets if the Organization Request generates a fault, it will be returned here.
    /// </summary>
    [DataMember]
    public OrganizationServiceFault Fault { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
