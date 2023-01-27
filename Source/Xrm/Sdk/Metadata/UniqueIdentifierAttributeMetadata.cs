// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.UniqueIdentifierAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "UniqueIdentifierAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/7.1/Metadata")]
  [MetadataName(LogicalName = "UniqueIdentifierAttributeMetadata", LogicalCollectionName = "UniqueIdentifierAttributeDefinitions")]
  [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "UniqueIdentifier", Justification = "compound word UniqueIdentifier should be cased correctly")]
  public sealed class UniqueIdentifierAttributeMetadata : AttributeMetadata
  {
    public UniqueIdentifierAttributeMetadata()
      : this(null)
    {
    }

    public UniqueIdentifierAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Uniqueidentifier, schemaName)
    {
    }
  }
}
