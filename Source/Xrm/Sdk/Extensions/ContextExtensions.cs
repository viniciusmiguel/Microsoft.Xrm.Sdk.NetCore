// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Extensions.ContextExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

namespace Microsoft.Xrm.Sdk.Extensions
{
  /// <summary>
  /// Provides a set of static methods for querying the <see cref="T:Microsoft.Xrm.Sdk.IPluginExecutionContext" />.
  /// </summary>
  public static class ContextExtensions
  {
    /// <summary>
    /// Retrieve the value of the specified input parameter, or the object type's default value.
    /// </summary>
    /// <typeparam name="T">The type of the input parameter.</typeparam>
    /// <param name="context">The <see cref="T:Microsoft.Xrm.Sdk.IPluginExecutionContext" /> from which to extract the input parameter.</param>
    /// <param name="parameterName">The name of the input parameter.</param>
    /// <returns>The specified input parameter cast to T, or default T if the parameter does not exist or cannot be cast to T.</returns>
    public static T InputParameterOrDefault<T>(
      this IPluginExecutionContext context,
      string parameterName)
    {
      object obj1;
      context.InputParameters.TryGetValue<object>(parameterName, out obj1);
      return obj1 is T obj2 ? obj2 : default (T);
    }
  }
}
