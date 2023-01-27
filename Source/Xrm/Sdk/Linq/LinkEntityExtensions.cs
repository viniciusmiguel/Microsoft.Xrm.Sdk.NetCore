// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.LinkEntityExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace Microsoft.Xrm.Sdk.Linq
{
  public static class LinkEntityExtensions
  {
    public static LinkEntity Find(this LinkEntity link, Predicate<LinkEntity> match) => !match(link) ? link.LinkEntities.Select<LinkEntity, LinkEntity>(child => child.Find(match)).FirstOrDefault<LinkEntity>(result => result != null) : link;
  }
}
