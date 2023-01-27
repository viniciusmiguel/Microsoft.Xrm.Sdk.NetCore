// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ManagedPropertyMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalName = "ManagedPropertyMetadata", LogicalCollectionName = "ManagedPropertyDefinitions")]
  public sealed class ManagedPropertyMetadata : MetadataBase
  {
    private string _logicalName;
    private Label _displayName;
    private Label _description;
    private ManagedPropertyType? _managedPropertyType;
    private ManagedPropertyOperation? _operation;
    private ManagedPropertyEvaluationPriority? _evaluationPriority;
    private string _enablesAttributeName;
    private string _enablesEntityName;
    private int? _errorCode;
    private bool? _isPrivate;
    private bool? _isGlobalForOperation;
    private string _introducedVersion;

    [DataMember]
    [Alternatekey]
    public string LogicalName
    {
      get => _logicalName;
      internal set => _logicalName = value;
    }

    [DataMember]
    public Label DisplayName
    {
      get => _displayName;
      internal set => _displayName = value;
    }

    [DataMember]
    public ManagedPropertyType? ManagedPropertyType
    {
      get => _managedPropertyType;
      internal set => _managedPropertyType = value;
    }

    [DataMember]
    public ManagedPropertyOperation? Operation
    {
      get => _operation;
      internal set => _operation = value;
    }

    [DataMember]
    public bool? IsGlobalForOperation
    {
      get => _isGlobalForOperation;
      internal set => _isGlobalForOperation = value;
    }

    [DataMember]
    public ManagedPropertyEvaluationPriority? EvaluationPriority
    {
      get => _evaluationPriority;
      internal set => _evaluationPriority = value;
    }

    [DataMember]
    public bool? IsPrivate
    {
      get => _isPrivate;
      internal set => _isPrivate = value;
    }

    [DataMember]
    public int? ErrorCode
    {
      get => _errorCode;
      internal set => _errorCode = value;
    }

    [DataMember]
    public string EnablesEntityName
    {
      get => _enablesEntityName;
      internal set => _enablesEntityName = value;
    }

    [DataMember]
    public string EnablesAttributeName
    {
      get => _enablesAttributeName;
      internal set => _enablesAttributeName = value;
    }

    [DataMember]
    public Label Description
    {
      get => _description;
      internal set => _description = value;
    }

    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => _introducedVersion;
      internal set => _introducedVersion = value;
    }
  }
}
