// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Extensions.LinkEntityExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Microsoft.Xrm.Sdk.Extensions
{
  public static class LinkEntityExtensions
  {
    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Target = "local$0", Justification = "Value is returned from method and cannot be disposed.")]
    public static IEnumerable<LinkEntity> GetChildLinkEntities(this LinkEntity link)
    {
      yield return link;
      foreach (var linkEntity in link.LinkEntities.SelectMany<LinkEntity, LinkEntity>(new Func<LinkEntity, IEnumerable<LinkEntity>>(GetChildLinkEntities)))
        yield return linkEntity;
    }
  }
}
