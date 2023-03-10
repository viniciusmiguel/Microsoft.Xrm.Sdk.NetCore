// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.UpdateMultipleRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Organization request for UpdateMultiple SDK message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateMultipleRequest : OrganizationRequest
  {
    /// <summary>
    /// Gets or Sets the EntityCollection that is used to create new entity records.
    /// </summary>
    public EntityCollection Targets
    {
      get => Parameters.Contains(nameof (Targets)) ? (EntityCollection) Parameters[nameof (Targets)] : null;
      set => Parameters[nameof (Targets)] = value;
    }

    /// <summary>
    /// Specifies the type of optimistic concurrency behavior that should be performed when processing this request.
    /// </summary>
    public ConcurrencyBehavior ConcurrencyBehavior
    {
      get => Parameters.Contains(nameof (ConcurrencyBehavior)) ? (ConcurrencyBehavior) Parameters[nameof (ConcurrencyBehavior)] : ConcurrencyBehavior.Default;
      set => Parameters[nameof (ConcurrencyBehavior)] = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateMultipleRequest" /> class.
    /// </summary>
    public UpdateMultipleRequest()
    {
      RequestName = "UpdateMultiple";
      Targets = null;
    }
  }
}
