// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IOrganizationService
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;
using System;
using System.ServiceModel;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>
  /// Interface containing methods provided by Organization Service.
  /// </summary>
  [ServiceContract(Name = "IOrganizationService", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Services")]
  [KnownAssembly]
  public interface IOrganizationService
  {
    /// <summary>Create an entity and process any related entities</summary>
    /// <param name="entity">entity to create</param>
    /// <param name="relatedActions">related entity actions</param>
    /// <returns></returns>
    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    Guid Create(Entity entity);

    /// <summary>Retrieves instance of an entity</summary>
    /// <param name="entityName">Logical name of entity</param>
    /// <param name="id">Id of entity</param>
    /// <returns>Entiy</returns>
    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    Entity Retrieve(string entityName, Guid id, ColumnSet columnSet);

    /// <summary>Updates an entity and process any related entities</summary>
    /// <param name="entity">entity to update</param>
    /// <param name="relatedActions">related entity actions</param>
    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    void Update(Entity entity);

    /// <summary>Delete instance of an entity</summary>
    /// <param name="entityName">Logical name of entity</param>
    /// <param name="id">Id of entity</param>
    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    void Delete(string entityName, Guid id);

    /// <summary>
    /// Perform an action in an organization specified by the request.
    /// </summary>
    /// <param name="request">Refer to SDK documentation for list of messages that can be used.</param>
    /// <returns>Results from processing the request</returns>
    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    OrganizationResponse Execute(OrganizationRequest request);

    /// <summary>Associate an entity with a set of entities</summary>
    /// <param name="entityName"></param>
    /// <param name="entityId"></param>
    /// <param name="relationship"></param>
    /// <param name="relatedEntities"></param>
    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    void Associate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities);

    /// <summary>Disassociate an entity with a set of entities</summary>
    /// <param name="entityName"></param>
    /// <param name="entityId"></param>
    /// <param name="relationship"></param>
    /// <param name="relatedEntities"></param>
    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    void Disassociate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities);

    /// <summary>Retrieves a collection of entities</summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    EntityCollection RetrieveMultiple(QueryBase query);
  }
}
