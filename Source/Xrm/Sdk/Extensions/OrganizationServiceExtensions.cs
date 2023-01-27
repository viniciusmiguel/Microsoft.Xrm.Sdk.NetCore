// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Extensions.OrganizationServiceExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Extensions
{
  public static class OrganizationServiceExtensions
  {
    public static EntityMetadata GetEntityMetadata(
      this IOrganizationService serviceProxy,
      string logicalName)
    {
      var request = new RetrieveEntityRequest()
      {
        EntityFilters = EntityFilters.Entity | EntityFilters.Attributes | EntityFilters.Relationships,
        LogicalName = logicalName
      };
      return ((RetrieveEntityResponse) serviceProxy.Execute(request)).EntityMetadata;
    }
  }
}
