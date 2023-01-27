// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.RemoteExecutionContext
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
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [KnownType("GetKnownParameterTypes")]
  public sealed class RemoteExecutionContext : 
    IPluginExecutionContext,
    IExecutionContext,
    IExtensibleDataObject
  {
    private int _stage;
    private int _mode;
    private int _depth;
    private int _isolationMode;
    private string _messageName;
    private string _primaryEntityName;
    private string _secondaryEntityName;
    private string _organizationName;
    private bool _isOffline;
    private bool _isOfflinePlayback;
    private bool _isInTransaction;
    private ParameterCollection _inputParameters;
    private ParameterCollection _outputParameters;
    private ParameterCollection _sharedVariables;
    private Guid _userId;
    private Guid _initiatingUserId;
    private Guid _userAzureActiveDirectoryObjectId;
    private Guid _initiatingUserAzureActiveDirectoryObjectId;
    private Guid _businessUnitId;
    private Guid _organizationId;
    private Guid _correlationId;
    private Guid _primaryEntityId;
    private Guid _asyncOperationId;
    private Guid? _requestId;
    private EntityReference _owningExtension;
    private EntityImageCollection _preImages;
    private EntityImageCollection _postImages;
    private DateTime _operationCreatedOnTime;
    private RemoteExecutionContext _parentContext;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public int Stage
    {
      get => _stage;
      set => _stage = value;
    }

    [DataMember]
    public int Mode
    {
      get => _mode;
      set => _mode = value;
    }

    [DataMember]
    public string MessageName
    {
      get => _messageName;
      set => _messageName = value;
    }

    [DataMember]
    public string PrimaryEntityName
    {
      get => _primaryEntityName;
      set => _primaryEntityName = value;
    }

    [DataMember]
    public string SecondaryEntityName
    {
      get => _secondaryEntityName;
      set => _secondaryEntityName = value;
    }

    [DataMember]
    public Guid? RequestId
    {
      get => _requestId;
      set => _requestId = value;
    }

    [DataMember]
    public ParameterCollection InputParameters
    {
      get
      {
        if (_inputParameters == null)
          _inputParameters = new ParameterCollection();
        return _inputParameters;
      }
    }

    [DataMember]
    public ParameterCollection OutputParameters
    {
      get
      {
        if (_outputParameters == null)
          _outputParameters = new ParameterCollection();
        return _outputParameters;
      }
    }

    [DataMember]
    public ParameterCollection SharedVariables
    {
      get
      {
        if (_sharedVariables == null)
          _sharedVariables = new ParameterCollection();
        return _sharedVariables;
      }
    }

    [DataMember]
    public Guid UserId
    {
      get => _userId;
      set => _userId = value;
    }

    [DataMember]
    public Guid InitiatingUserId
    {
      get => _initiatingUserId;
      set => _initiatingUserId = value;
    }

    [DataMember]
    public Guid BusinessUnitId
    {
      get => _businessUnitId;
      set => _businessUnitId = value;
    }

    [DataMember]
    public Guid OrganizationId
    {
      get => _organizationId;
      set => _organizationId = value;
    }

    [DataMember]
    public string OrganizationName
    {
      get => _organizationName;
      set => _organizationName = value;
    }

    [DataMember]
    public EntityImageCollection PreEntityImages
    {
      get
      {
        if (_preImages == null)
          _preImages = new EntityImageCollection();
        return _preImages;
      }
    }

    [DataMember]
    public EntityImageCollection PostEntityImages
    {
      get
      {
        if (_postImages == null)
          _postImages = new EntityImageCollection();
        return _postImages;
      }
    }

    [DataMember]
    public Guid CorrelationId
    {
      get => _correlationId;
      set => _correlationId = value;
    }

    [DataMember]
    public int Depth
    {
      get => _depth;
      set => _depth = value;
    }

    [DataMember]
    public bool IsExecutingOffline
    {
      get => _isOffline;
      set => _isOffline = value;
    }

    [DataMember]
    public bool IsOfflinePlayback
    {
      get => _isOfflinePlayback;
      set => _isOfflinePlayback = value;
    }

    [DataMember]
    public int IsolationMode
    {
      get => _isolationMode;
      set => _isolationMode = value;
    }

    [DataMember]
    public bool IsInTransaction
    {
      get => _isInTransaction;
      set => _isInTransaction = value;
    }

    [DataMember]
    public Guid OperationId
    {
      get => _asyncOperationId;
      set => _asyncOperationId = value;
    }

    [DataMember]
    public EntityReference OwningExtension
    {
      get => _owningExtension;
      set => _owningExtension = value;
    }

    [DataMember]
    public Guid PrimaryEntityId
    {
      get => _primaryEntityId;
      set => _primaryEntityId = value;
    }

    [DataMember]
    public DateTime OperationCreatedOn
    {
      get => _operationCreatedOnTime;
      set => _operationCreatedOnTime = value;
    }

    [DataMember]
    public RemoteExecutionContext ParentContext
    {
      get => _parentContext;
      set => _parentContext = value;
    }

    IPluginExecutionContext IPluginExecutionContext.ParentContext => ParentContext;

    [DataMember(IsRequired = false)]
    public Guid UserAzureActiveDirectoryObjectId
    {
      get => _userAzureActiveDirectoryObjectId;
      set => _userAzureActiveDirectoryObjectId = value;
    }

    [DataMember(IsRequired = false)]
    public Guid InitiatingUserAzureActiveDirectoryObjectId
    {
      get => _initiatingUserAzureActiveDirectoryObjectId;
      set => _initiatingUserAzureActiveDirectoryObjectId = value;
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
    private static IEnumerable<Type> GetKnownParameterTypes() => KnownTypesProvider.RetrieveKnownValueTypes();

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
