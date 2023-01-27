// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IOrganizationServiceFactory
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Interface to allow plug-ins to obtain IOrganizationService.
  /// </summary>
  public interface IOrganizationServiceFactory
  {
    /// <summary>
    /// Creates an instance of IOrganizationService initialized with a given user id.  Null will use the
    /// current user id.
    /// </summary>
    /// <param name="userId">Id of user.</param>
    IOrganizationService CreateOrganizationService(Guid? userId);
  }
}
