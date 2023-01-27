// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.PrivilegeRoleMapping
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract]
  public sealed class PrivilegeRoleMapping
  {
    /// <summary>Gets or sets the privileges info.</summary>
    [DataMember]
    public IList<PrivilegeInfo> Privileges { get; set; }

    /// <summary>Gets or sets the Role ids.</summary>
    [DataMember]
    public IList<Guid> RoleIds { get; set; }

    /// <summary>
    /// Gets or sets if RoleId is a Role (As opposed to RoleTemplate.) Default - false (Role Template)
    /// </summary>
    [DataMember]
    public bool IsRole { get; set; }
  }
}
