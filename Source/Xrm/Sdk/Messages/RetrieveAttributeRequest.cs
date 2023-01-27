// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveAttributeRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAttributeRequest : OrganizationRequest
  {
    public string EntityLogicalName
    {
      get => Parameters.Contains(nameof (EntityLogicalName)) ? (string) Parameters[nameof (EntityLogicalName)] : null;
      set => Parameters[nameof (EntityLogicalName)] = value;
    }

    public string LogicalName
    {
      get => Parameters.Contains(nameof (LogicalName)) ? (string) Parameters[nameof (LogicalName)] : null;
      set => Parameters[nameof (LogicalName)] = value;
    }

    public int ColumnNumber
    {
      get => Parameters.Contains(nameof (ColumnNumber)) ? (int) Parameters[nameof (ColumnNumber)] : 0;
      set => Parameters[nameof (ColumnNumber)] = value;
    }

    public Guid MetadataId
    {
      get => Parameters.Contains(nameof (MetadataId)) ? (Guid) Parameters[nameof (MetadataId)] : new Guid();
      set => Parameters[nameof (MetadataId)] = value;
    }

    public bool RetrieveAsIfPublished
    {
      get => Parameters.Contains(nameof (RetrieveAsIfPublished)) && (bool) Parameters[nameof (RetrieveAsIfPublished)];
      set => Parameters[nameof (RetrieveAsIfPublished)] = value;
    }

    public RetrieveAttributeRequest()
    {
      RequestName = "RetrieveAttribute";
      MetadataId = new Guid();
      RetrieveAsIfPublished = false;
    }
  }
}
