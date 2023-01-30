/*
// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ProxySerializationSurrogate
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  internal sealed class ProxySerializationSurrogate : IDataContractSurrogate
  {
    private Assembly _proxyTypesAssembly;

    internal ProxySerializationSurrogate(Assembly proxyTypesAssembly) => _proxyTypesAssembly = proxyTypesAssembly;

    object IDataContractSurrogate.GetCustomDataToExport(Type clrType, Type dataContractType) => null;

    object IDataContractSurrogate.GetCustomDataToExport(
      MemberInfo memberInfo,
      Type dataContractType)
    {
      return null;
    }

    Type IDataContractSurrogate.GetDataContractType(Type type)
    {
      if (type.IsAssignableFrom(typeof (OrganizationRequest)))
        return typeof (OrganizationRequest);
      if (type.IsAssignableFrom(typeof (OrganizationResponse)))
        return typeof (OrganizationResponse);
      return type.IsAssignableFrom(typeof (Entity)) ? typeof (Entity) : type;
    }

    object IDataContractSurrogate.GetDeserializedObject(object obj, Type targetType)
    {
      var supportIndividualAssemblies = _proxyTypesAssembly != null;
      switch (obj)
      {
        case OrganizationResponse organizationResponse:
          var typeForName1 = KnownProxyTypesProvider.GetInstance(supportIndividualAssemblies).GetTypeForName(organizationResponse.ResponseName, _proxyTypesAssembly);
          if (typeForName1 == null)
            return obj;
          var instance1 = (OrganizationResponse) Activator.CreateInstance(typeForName1);
          instance1.ResponseName = organizationResponse.ResponseName;
          instance1.Results = organizationResponse.Results;
          return instance1;
        case Entity entity:
          var typeForName2 = KnownProxyTypesProvider.GetInstance(supportIndividualAssemblies).GetTypeForName(entity.LogicalName, _proxyTypesAssembly);
          if (typeForName2 == null)
            return obj;
          var instance2 = (Entity) Activator.CreateInstance(typeForName2);
          entity.ShallowCopyTo(instance2);
          return instance2;
        default:
          return obj;
      }
    }

    void IDataContractSurrogate.GetKnownCustomDataTypes(Collection<Type> customDataTypes)
    {
    }

    object IDataContractSurrogate.GetObjectToSerialize(object obj, Type targetType)
    {
      if (obj.GetType().IsSubclassOf(typeof (OrganizationRequest)))
      {
        var organizationRequest = (OrganizationRequest) obj;
        if (KnownProxyTypesProvider.GetInstance(_proxyTypesAssembly != null).GetTypeForName(organizationRequest.RequestName, _proxyTypesAssembly) == null)
          return obj;
        return new OrganizationRequest()
        {
          RequestName = organizationRequest.RequestName,
          Parameters = organizationRequest.Parameters,
          RequestId = organizationRequest.RequestId
        };
      }
      if (!obj.GetType().IsSubclassOf(typeof (Entity)))
        return obj;
      var entity = (Entity) obj;
      var objectToSerialize = new Entity();
      var target = objectToSerialize;
      entity.ShallowCopyTo(target);
      return objectToSerialize;
    }

    Type IDataContractSurrogate.GetReferencedTypeOnImport(
      string typeName,
      string typeNamespace,
      object customData)
    {
      return null;
    }

    CodeTypeDeclaration IDataContractSurrogate.ProcessImportedType(
      CodeTypeDeclaration typeDeclaration,
      CodeCompileUnit compileUnit)
    {
      return null;
    }
  }
}
*/
