// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceEndpointMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.ObjectModel;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class ServiceEndpointMetadata
  {
    private ServiceEndpointDictionary _serviceEndpoints = new();
    private Collection<MetadataConversionError> _metadataConversionErrors = new();

    public ServiceEndpointDictionary ServiceEndpoints => _serviceEndpoints;

    public MetadataSet ServiceMetadata { get; set; }

    public Collection<MetadataConversionError> MetadataConversionErrors => _metadataConversionErrors;

    public ServiceUrls ServiceUrls { get; internal set; }
  }
}
