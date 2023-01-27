// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Relationship
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Globalization;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Represents a relationship to use when associating, disassociating and retrieving related entities
  /// </summary>
  [DataContract(Name = "Relationship", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class Relationship : IExtensibleDataObject
  {
    private EntityRole? _primaryEntityRole;
    private string _schemaName;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Relationship" /> class.
    /// Creates a Relationship object
    /// </summary>
    public Relationship()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Relationship" /> class.
    /// Creates a Relationship object and initilizes SchemaName member
    /// </summary>
    /// <param name="schemaName">Schema name for the relationship.</param>
    public Relationship(string schemaName) => _schemaName = schemaName;

    /// <summary>Schema name for the relationship</summary>
    [DataMember]
    public string SchemaName
    {
      get => _schemaName;
      set => _schemaName = value;
    }

    /// <summary>
    /// Role of primary entity in the relationship.
    /// Required when using a reflexive relationship
    /// Not required for non-reflexive relationship, must match the entity's role if specified
    /// </summary>
    [DataMember]
    public EntityRole? PrimaryEntityRole
    {
      get => _primaryEntityRole;
      set => _primaryEntityRole = value;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Relationship relationship) || !(SchemaName == relationship.SchemaName))
        return false;
      var primaryEntityRole1 = _primaryEntityRole;
      var primaryEntityRole2 = relationship._primaryEntityRole;
      return primaryEntityRole1.GetValueOrDefault() == primaryEntityRole2.GetValueOrDefault() & primaryEntityRole1.HasValue == primaryEntityRole2.HasValue;
    }

    public override int GetHashCode()
    {
      var hashCode = (_schemaName ?? string.Empty).GetHashCode();
      if (_primaryEntityRole.HasValue)
        hashCode ^= _primaryEntityRole.Value.GetHashCode();
      return hashCode;
    }

    public override string ToString() => string.Format(CultureInfo.InvariantCulture, "{0}.{1}", _schemaName ?? string.Empty, _primaryEntityRole.HasValue ? _primaryEntityRole.ToString() : (object) string.Empty);

    public ExtensionDataObject ExtensionData
    {
      get => _extensionDataObject;
      set => _extensionDataObject = value;
    }
  }
}
