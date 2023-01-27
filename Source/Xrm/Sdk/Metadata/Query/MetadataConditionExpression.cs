// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.MetadataConditionExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  /// <summary>
  /// Class that is used to specify a condition for a metadata type
  /// </summary>
  [KnownType("GetKnownConditionValueTypes")]
  [DataContract(Name = "MetadataConditionExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class MetadataConditionExpression : IExtensibleDataObject
  {
    public MetadataConditionExpression()
    {
    }

    public MetadataConditionExpression(
      string propertyName,
      MetadataConditionOperator conditionOperator,
      object value)
    {
      PropertyName = propertyName;
      ConditionOperator = conditionOperator;
      Value = value;
    }

    /// <summary>Name of the property the condition is applied on</summary>
    [DataMember]
    public string PropertyName { get; set; }

    /// <summary>Operator for the condition expression</summary>
    [DataMember]
    public MetadataConditionOperator ConditionOperator { get; set; }

    /// <summary>Object that the property is compared against</summary>
    [DataMember]
    public object Value { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
    private static IEnumerable<Type> GetKnownConditionValueTypes() => KnownTypesProvider.GetKnownMetadataEnumTypes();
  }
}
