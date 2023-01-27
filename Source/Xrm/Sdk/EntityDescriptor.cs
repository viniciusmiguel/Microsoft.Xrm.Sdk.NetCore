// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntityDescriptor
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// A container of entity changes performed by the <see cref="!:OrganizationServiceContext" />.
  /// </summary>
  internal sealed class EntityDescriptor : Descriptor
  {
    public EntityReference Identity { get; private set; }

    public Entity Entity { get; private set; }

    public EntityDescriptor(EntityStates state, EntityReference identity, Entity entity)
      : base(state)
    {
      Identity = identity;
      Entity = entity;
    }
  }
}
