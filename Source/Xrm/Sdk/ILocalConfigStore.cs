// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ILocalConfigStore
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System.Collections.Generic;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Access for Secure data storage for CRM</summary>
  public interface ILocalConfigStore
  {
    /// <summary>Sets Secure data into the local secure data store.</summary>
    /// <param name="keyName">Key to use the set the data. </param>
    /// <param name="data">Object data that is being stored</param>
    void SetData(string keyName, object data);

    /// <summary>Sets Secure data into the local secure data store.</summary>
    /// <param name="keyData">Key value pair collection of secure data. </param>
    void SetData(Dictionary<string, object> keyData);

    /// <summary>Returns Data from the Secure Store</summary>
    /// <typeparam name="T">Object type of the returned data</typeparam>
    /// <param name="keyName">Key to use to retrieve the data</param>
    /// <returns>Resulting data</returns>
    T GetData<T>(string keyName);

    /// <summary>
    /// Returns a collection of key value pairs of all data that the caller can access.
    /// </summary>
    /// <returns>Key value pair collection of secure data. </returns>
    Dictionary<string, object> GetAllData();

    /// <summary>
    /// Returns a collection of key value pairs based on the collection of keys that the caller passes in.
    /// </summary>
    /// <param name="keyNames">List of keys that a caller is interested in data for</param>
    /// <returns>Key value pair collection of secure data. </returns>
    Dictionary<string, object> GetDataByKeyNames(List<string> keyNames);
  }
}
