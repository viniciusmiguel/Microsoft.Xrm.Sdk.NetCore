// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IExecutionContext
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;

namespace Microsoft.Xrm.Sdk
{
  public interface IExecutionContext
  {
    /// <summary>Gets mode of the processing.</summary>
    int Mode { get; }

    /// <summary>Gets indicates the plug-in's isolation mode.</summary>
    int IsolationMode { get; }

    int Depth { get; }

    /// <summary>Gets name of the message being processed.</summary>
    string MessageName { get; }

    /// <summary>
    /// Gets name of the primary entity that is associated with the message.
    /// </summary>
    string PrimaryEntityName { get; }

    /// <summary>Gets requestId if specified by SDK client</summary>
    Guid? RequestId { get; }

    /// <summary>
    /// Gets name of the secondary entity that is associated with the message.
    /// </summary>
    string SecondaryEntityName { get; }

    /// <summary>Gets input parameters from the caller.</summary>
    ParameterCollection InputParameters { get; }

    /// <summary>Gets output parameters to be returned back to caller.</summary>
    ParameterCollection OutputParameters { get; }

    /// <summary>Gets temporary parameters passing between plug-ins.</summary>
    ParameterCollection SharedVariables { get; }

    /// <summary>Gets id of user that plug-in is executing as.</summary>
    Guid UserId { get; }

    /// <summary>Gets id of user that initiates web service.</summary>
    Guid InitiatingUserId { get; }

    /// <summary>
    /// Gets id of business unit that user that plug-in is executing as.
    /// </summary>
    Guid BusinessUnitId { get; }

    /// <summary>
    /// Gets id of the organization that the plug-in is executing in.
    /// </summary>
    Guid OrganizationId { get; }

    /// <summary>
    /// Gets unique name of organization that plug-in is executing in.
    /// </summary>
    string OrganizationName { get; }

    /// <summary>Gets id of the Entity that trigged the extension.</summary>
    Guid PrimaryEntityId { get; }

    /// <summary>
    /// Gets contains a copy of the Entity prior to the platform taking action on it.
    /// </summary>
    EntityImageCollection PreEntityImages { get; }

    /// <summary>
    /// Gets contains a copy of the Entity after the platform has taken action on it.
    /// </summary>
    EntityImageCollection PostEntityImages { get; }

    /// <summary>
    /// Gets either the Workflow record representing the Activation or the SdkMessageProcessingStep the is currently executing
    /// </summary>
    EntityReference OwningExtension { get; }

    /// <summary>Gets id to correlate between multiple requests.</summary>
    Guid CorrelationId { get; }

    /// <summary>
    /// Gets a value indicating whether indicates whether the plugin is running in offline mode
    /// </summary>
    bool IsExecutingOffline { get; }

    /// <summary>
    /// Gets a value indicating whether indicates whether the plugin is running during offline playback
    /// </summary>
    bool IsOfflinePlayback { get; }

    /// <summary> Gets a value indicating whether
    /// Indicates whether the context is executing in transaction or not
    /// </summary>
    bool IsInTransaction { get; }

    /// <summary>
    /// Gets the AsyncOperationId that is executing the current extension.
    /// </summary>
    Guid OperationId { get; }

    /// <summary>Gets the time that the AsyncOperation was created on.</summary>
    DateTime OperationCreatedOn { get; }
  }
}
