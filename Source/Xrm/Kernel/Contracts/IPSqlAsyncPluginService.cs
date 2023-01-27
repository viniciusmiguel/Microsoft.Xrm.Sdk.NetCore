// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Kernel.Contracts.IPSqlAsyncPluginService
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Metadata;
using System;

namespace Microsoft.Xrm.Kernel.Contracts
{
  /// <summary>Interface to regenerate TDS views service</summary>
  public interface IPSqlAsyncPluginService
  {
    /// <summary>
    /// Regenerates the TDS filtered views for all the relevant entities in the organization
    /// </summary>
    /// <param name="organizationId">organization for which the views need to be generated</param>
    /// <returns>true if the TDS view generation was successful, false otherwise</returns>
    bool RegenerateTDSViews(Guid organizationId);

    /// <summary>
    /// Regenerates the TDS filtered view for the entity specified
    /// </summary>
    /// <param name="createTDSViewAsyncRequest">Request object for which the view needs to be generated</param>
    void RegenerateTDSViewForEntity(
      CreateTDSViewAsyncRequest createTDSViewAsyncRequest);
  }
}
