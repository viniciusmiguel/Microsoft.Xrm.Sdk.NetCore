// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SelectColumn
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// EntityCollection does not have a columnset schema header. So if the EntityCollection is empty then TDS endpoint will not know how to generate
  /// the column header. With guidance from sdk team we decided not to modify the EntityCollection, but expose a seperate property that represents
  /// a columnset header for the entity collection.
  /// </summary>
  [DataContract(Name = "SelectColumn", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  [Serializable]
  public sealed class SelectColumn : IExtensibleDataObject
  {
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public string ColumnName { get; set; }

    [DataMember]
    public string DataTypeName { get; set; }

    public SelectColumn()
    {
    }

    public SelectColumn(string columnName, string dataTypeName)
    {
      ColumnName = columnName;
      DataTypeName = dataTypeName;
    }

    ExtensionDataObject IExtensibleDataObject.ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
