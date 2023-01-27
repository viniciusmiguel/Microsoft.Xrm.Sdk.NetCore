// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.LinkDescriptor
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// A container of relationship changes performed by the <see cref="!:OrganizationServiceContext" />.
  /// </summary>
  internal sealed class LinkDescriptor : Descriptor
  {
    internal static readonly IEqualityComparer<LinkDescriptor> EquivalenceComparer = new LinkDescriptorComparer();

    public Entity Source { get; private set; }

    public Relationship Relationship { get; private set; }

    public Entity Target { get; private set; }

    public LinkDescriptor(Entity source, Relationship relationship, Entity target)
      : this(EntityStates.Unchanged, source, relationship, target)
    {
    }

    public LinkDescriptor(
      EntityStates state,
      Entity source,
      Relationship relationship,
      Entity target)
      : base(state)
    {
      Source = source;
      Relationship = relationship;
      Target = target;
    }

    private class LinkDescriptorComparer : IEqualityComparer<LinkDescriptor>
    {
      public bool Equals(LinkDescriptor x, LinkDescriptor y)
      {
        if (x == null && y == null)
          return true;
        return x != null && y != null && Equals(x.Source, y.Source) && Equals(x.Relationship, y.Relationship) && Equals(x.Target, y.Target);
      }

      public int GetHashCode(LinkDescriptor obj) => obj == null ? 0 : obj.Source.GetHashCode() ^ (obj.Target != null ? obj.Target.GetHashCode() : 0) ^ (obj.Relationship != null ? obj.Relationship.GetHashCode() : 0);
    }
  }
}
