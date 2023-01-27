// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.QuickFindResult
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Holds the Search Results per Entity which includes the Search Status (Ok, Error, Quick Find Limit Exceeded)
  /// an error message, and EntityCollection which has the data. This EntityCollection will always be present
  /// and will be empty only if the search returned no data for a given entity or is empty because of an error.
  /// </summary>
  [DataContract(Name = "QuickFindResult", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class QuickFindResult : IExtensibleDataObject
  {
    private int errorCode;
    private EntityCollection data;
    private DataCollection<string> queryColumnSet;
    private ExtensionDataObject _extensionDataObject;

    public QuickFindResult()
    {
    }

    public QuickFindResult(int error, EntityCollection entities)
    {
      errorCode = error;
      data = entities;
      queryColumnSet = null;
    }

    public QuickFindResult(
      int error,
      EntityCollection entities,
      DataCollection<string> queryColumns)
    {
      errorCode = error;
      data = entities;
      queryColumnSet = queryColumns;
    }

    [DataMember]
    public int ErrorCode
    {
      get => errorCode;
      set => errorCode = value;
    }

    [DataMember]
    public EntityCollection Data
    {
      get => data;
      set => data = value;
    }

    [DataMember]
    [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Collection properties should be read only")]
    public DataCollection<string> QueryColumnSet
    {
      get => queryColumnSet;
      set => queryColumnSet = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
