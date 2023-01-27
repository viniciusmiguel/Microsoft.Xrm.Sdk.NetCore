// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Xrm.Sdk
{
  [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "Nullable arguments cause issues for compiler.")]
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class RelationshipSchemaNameAttribute : Attribute
  {
    private readonly Relationship _relationship;

    /// <summary>Gets or sets the CRM schema name of the relationship.</summary>
    public string SchemaName => _relationship.SchemaName;

    /// <summary>
    /// Gets or sets the name of the <see cref="T:Microsoft.Xrm.Sdk.EntityRole" /> of the relationship.
    /// </summary>
    public EntityRole? PrimaryEntityRole => _relationship.PrimaryEntityRole;

    /// <summary>
    /// Gets the <see cref="P:Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute.Relationship" /> of the attribute.
    /// </summary>
    internal Relationship Relationship => _relationship;

    public RelationshipSchemaNameAttribute(string schemaName)
      : this(schemaName, new EntityRole?())
    {
    }

    public RelationshipSchemaNameAttribute(string schemaName, EntityRole primaryEntityRole)
      : this(schemaName, new EntityRole?(primaryEntityRole))
    {
    }

    private RelationshipSchemaNameAttribute(string schemaName, EntityRole? primaryEntityRole)
    {
      _relationship = !string.IsNullOrWhiteSpace(schemaName) ? new Relationship(schemaName) : throw new ArgumentNullException(nameof (schemaName));
      _relationship.PrimaryEntityRole = primaryEntityRole;
    }
  }
}
