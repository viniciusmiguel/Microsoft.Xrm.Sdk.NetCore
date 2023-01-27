﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SaveChangesResultCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Client;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Xrm.Sdk
{
  public sealed class SaveChangesResultCollection : Collection<SaveChangesResult>
  {
    public SaveChangesOptions Options { get; private set; }

    public bool HasError => this.Any<SaveChangesResult>(result => result.Error != null);

    internal SaveChangesResultCollection(SaveChangesOptions options) => Options = options;
  }
}
