// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.UpgradeCurrencyTypeTable
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>UpgradeCurrencyType Table</summary>
  [DataContract(Name = "UpgradeCurrencyTypeTable", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class UpgradeCurrencyTypeTable : IExtensibleDataObject
  {
    [DataMember]
    public string TableName { get; set; }

    [DataMember]
    public string Status { get; set; }

    [DataMember]
    public int TotalRowCount { get; set; }

    [DataMember]
    public int ProcessedRowCount { get; set; }

    [DataMember]
    public int PendingRowCount { get; set; }

    [DataMember]
    public DateTime StartTime { get; set; }

    [DataMember]
    public DateTime LastUpdatedTime { get; set; }

    [DataMember]
    public string ErrorNumber { get; set; }

    [DataMember]
    public string ErrorMessage { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
