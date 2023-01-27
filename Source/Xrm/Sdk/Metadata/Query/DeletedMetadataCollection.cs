// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.DeletedMetadataCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  /// <summary>
  /// Data collection of metadata that has been deleted from the server since the client last synced
  /// </summary>
  [CollectionDataContract(Name = "DeletedMetadataCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class DeletedMetadataCollection : 
    DataCollection<DeletedMetadataFilters, DataCollection<Guid>>
  {
  }
}
