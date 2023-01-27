// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntityCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "EntityCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class EntityCollection : IExtensibleDataObject
  {
    private string _entityName;
    private DataCollection<Entity> _entities;
    private bool _moreRecords;
    private string _pagingCookie;
    private string _minActiveRowVersion;
    private int _totalRecordCount;
    private bool _totalRecordCountLimitExceeded;
    private bool _isReadOnly;
    private ExtensionDataObject _extensionDataObject;

    public EntityCollection()
    {
    }

    public EntityCollection(IList<Entity> list) => _entities = new DataCollection<Entity>(list);

    [DataMember]
    public DataCollection<Entity> Entities
    {
      get
      {
        if (_entities == null)
          _entities = new DataCollection<Entity>();
        return _entities;
      }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set => _entities = value;
    }

    [DataMember]
    public bool MoreRecords
    {
      get => _moreRecords;
      set
      {
        CheckIsReadOnly();
        _moreRecords = value;
      }
    }

    [DataMember]
    public string PagingCookie
    {
      get => _pagingCookie;
      set
      {
        CheckIsReadOnly();
        _pagingCookie = value;
      }
    }

    [DataMember]
    public string MinActiveRowVersion
    {
      get => _minActiveRowVersion;
      set
      {
        CheckIsReadOnly();
        _minActiveRowVersion = value;
      }
    }

    [DataMember]
    public int TotalRecordCount
    {
      get => _totalRecordCount;
      set
      {
        CheckIsReadOnly();
        _totalRecordCount = value;
      }
    }

    [DataMember]
    public bool TotalRecordCountLimitExceeded
    {
      get => _totalRecordCountLimitExceeded;
      set
      {
        CheckIsReadOnly();
        _totalRecordCountLimitExceeded = value;
      }
    }

    public Entity this[int index]
    {
      get => Entities[index];
      set
      {
        CheckIsReadOnly();
        Entities[index] = value;
      }
    }

    [DataMember]
    public string EntityName
    {
      get => _entityName;
      set
      {
        CheckIsReadOnly();
        _entityName = value;
      }
    }

    internal bool IsReadOnly
    {
      get => _isReadOnly;
      set => _isReadOnly = value;
    }

    private void CheckIsReadOnly()
    {
      if (IsReadOnly)
        throw new InvalidOperationException("The collection is read-only.");
    }

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
