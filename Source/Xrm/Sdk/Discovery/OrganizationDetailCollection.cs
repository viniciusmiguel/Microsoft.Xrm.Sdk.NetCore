// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.OrganizationDetailCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
  /// <summary>
  /// Contains the result returned by Validate() method of an IInputValidator object.
  /// TODO - consider renaming this class.
  /// These types should match the types in src/SDK/Core/OrganizationDetail.cs.
  /// The converters in src/SDK/Core/OrganizationDetail.cs should be updated if the classes are changed in either file.
  /// </summary>
  [CollectionDataContract(Name = "OrganizationDetailCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
  public sealed class OrganizationDetailCollection : DataCollection<OrganizationDetail>
  {
  }
}
