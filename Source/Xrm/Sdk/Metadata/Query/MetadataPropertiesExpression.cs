// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.MetadataPropertiesExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  /// <summary>
  /// Class used to specify the properties of a metadata type that need to be retrieved
  /// </summary>
  [DataContract(Name = "MetadataPropertiesExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class MetadataPropertiesExpression : IExtensibleDataObject
  {
    private DataCollection<string> _propertyNames;

    public MetadataPropertiesExpression()
    {
    }

    public MetadataPropertiesExpression(params string[] propertyNames) => PropertyNames.AddRange(propertyNames);

    public ExtensionDataObject ExtensionData { get; set; }

    /// <summary>Specifies whether all properties need to be retrieved</summary>
    [DataMember]
    public bool AllProperties { get; set; }

    /// <summary>
    /// Specifies the names of the properties that need to be retrieved
    /// </summary>
    [DataMember]
    public DataCollection<string> PropertyNames
    {
      get => _propertyNames ?? (_propertyNames = new DataCollection<string>());
      internal set => _propertyNames = value;
    }
  }
}
