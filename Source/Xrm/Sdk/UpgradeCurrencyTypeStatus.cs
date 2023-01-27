// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.UpgradeCurrencyTypeStatus
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>UpgradeCurrencyType Status</summary>
  [DataContract(Name = "UpgradeCurrencyTypeStatus", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class UpgradeCurrencyTypeStatus : IExtensibleDataObject
  {
    [DataMember]
    public int TotalTableCount { get; set; }

    [DataMember]
    public int PendingTableCount { get; set; }

    [DataMember]
    public int InProgressTableCount { get; set; }

    [DataMember]
    public int CompletedTableCount { get; set; }

    [DataMember]
    public int TableOrColumnDeletedAfterUpgradeTableCount { get; set; }

    [DataMember]
    public int FailedTableCount { get; set; }

    [DataMember]
    public string UpgradeStatus { get; set; }

    [DataMember]
    public DateTime StartTime { get; set; }

    [DataMember]
    public DateTime LastUpdatedTime { get; set; }

    [DataMember]
    public List<UpgradeCurrencyTypeTable> Tables { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
