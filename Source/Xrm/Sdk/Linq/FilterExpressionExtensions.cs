// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.FilterExpressionExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal static class FilterExpressionExtensions
  {
    public static void ForSubtreePreorder(
      this FilterExpression exp,
      FilterAction action)
    {
      exp.ForSubtreePreorder(null, action);
    }

    public static void ForSubtreePreorder(
      this FilterExpression exp,
      FilterExpression parent,
      FilterAction action)
    {
      action(exp, parent);
      if (exp.Filters == null)
        return;
      foreach (var filter in exp.Filters)
        filter.ForSubtreePreorder(exp, action);
    }

    public static void ForSubtreePreorder(
      this FilterExpression exp,
      FilterAction filterAction,
      ConditionAction conditionAction)
    {
      exp.ForSubtreePreorder(null, filterAction, conditionAction);
    }

    public static void ForSubtreePreorder(
      this FilterExpression exp,
      FilterExpression parent,
      FilterAction filterAction,
      ConditionAction conditionAction)
    {
      exp.ForSubtreePreorder(parent, (e, p) =>
      {
        filterAction(e, p);
        if (e.Conditions == null)
          return;
        foreach (var condition in e.Conditions)
          conditionAction(condition, e);
      });
    }

    public static void ForSubtreePostorder(
      this FilterExpression exp,
      FilterAction action)
    {
      exp.ForSubtreePostorder(null, action);
    }

    public static void ForSubtreePostorder(
      this FilterExpression exp,
      FilterExpression parent,
      FilterAction action)
    {
      if (exp.Filters != null)
      {
        foreach (var filter in exp.Filters)
          filter.ForSubtreePostorder(exp, action);
      }
      action(exp, parent);
    }

    public static void ForSubtreePostorder(
      this FilterExpression exp,
      FilterAction filterAction,
      ConditionAction conditionAction)
    {
      exp.ForSubtreePostorder(null, filterAction, conditionAction);
    }

    public static void ForSubtreePostorder(
      this FilterExpression exp,
      FilterExpression parent,
      FilterAction filterAction,
      ConditionAction conditionAction)
    {
      exp.ForSubtreePostorder(parent, (e, p) =>
      {
        if (e.Conditions != null)
        {
          foreach (ConditionExpression condition in e.Conditions)
            conditionAction(condition, e);
        }
        filterAction(e, p);
      });
    }

    public delegate void FilterAction(FilterExpression exp, FilterExpression parent);

    public delegate void ConditionAction(ConditionExpression exp, FilterExpression parent);
  }
}
