// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.ExpressionExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal static class ExpressionExtensions
  {
    /// <summary>Preorder traversal of the expression.</summary>
    /// <param name="exp"></param>
    /// <param name="action"></param>
    public static void ForSubtreePreorder(
      this Expression exp,
      ExpressionAction action)
    {
      exp.ForSubtreePreorder(null, action);
    }

    /// <summary>Preorder traversal of the expression.</summary>
    /// <param name="exp"></param>
    /// <param name="parent"></param>
    /// <param name="action"></param>
    public static void ForSubtreePreorder(
      this Expression exp,
      Expression parent,
      ExpressionAction action)
    {
      action(exp, parent);
      foreach (var child in exp.GetChildren())
        child.ForSubtreePreorder(exp, action);
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Target = "local$0", Justification = "Value is returned from method and cannot be disposed.")]
    public static IEnumerable<Expression> GetChildren(this Expression exp)
    {
      switch (exp)
      {
        case UnaryExpression _:
          yield return ((UnaryExpression) exp).Operand;
          break;
        case BinaryExpression _:
          yield return ((BinaryExpression) exp).Left;
          yield return ((BinaryExpression) exp).Right;
          yield return ((BinaryExpression) exp).Conversion;
          break;
        case TypeBinaryExpression _:
          yield return ((TypeBinaryExpression) exp).Expression;
          break;
        case ConditionalExpression _:
          yield return ((ConditionalExpression) exp).Test;
          yield return ((ConditionalExpression) exp).IfTrue;
          yield return ((ConditionalExpression) exp).IfFalse;
          break;
        case MemberExpression _:
          yield return ((MemberExpression) exp).Expression;
          break;
        case MethodCallExpression _:
          yield return ((MethodCallExpression) exp).Object;
          foreach (var expression in ((MethodCallExpression) exp).Arguments)
            yield return expression;
          break;
        case LambdaExpression _:
          yield return ((LambdaExpression) exp).Body;
          foreach (Expression parameter in ((LambdaExpression) exp).Parameters)
            yield return parameter;
          break;
        case NewExpression _:
          foreach (var expression in ((NewExpression) exp).Arguments)
            yield return expression;
          break;
        case NewArrayExpression _:
          foreach (var expression in ((NewArrayExpression) exp).Expressions)
            yield return expression;
          break;
        case InvocationExpression _:
          yield return ((InvocationExpression) exp).Expression;
          foreach (var expression in ((InvocationExpression) exp).Arguments)
            yield return expression;
          break;
        case MemberInitExpression _:
          yield return ((MemberInitExpression) exp).NewExpression;
          foreach (var child in GetChildren(((MemberInitExpression) exp).Bindings))
            yield return child;
          break;
        case ListInitExpression _:
          yield return ((ListInitExpression) exp).NewExpression;
          foreach (var child in GetChildren(((ListInitExpression) exp).Initializers))
            yield return child;
          break;
      }
    }

    private static IEnumerable<Expression> GetChildren(IEnumerable<MemberBinding> bindings) => bindings.SelectMany<MemberBinding, Expression>(new Func<MemberBinding, IEnumerable<Expression>>(GetChildren));

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Target = "local$0", Justification = "Value is returned from method and cannot be disposed.")]
    private static IEnumerable<Expression> GetChildren(MemberBinding binding)
    {
      switch (binding.BindingType)
      {
        case MemberBindingType.Assignment:
          yield return ((MemberAssignment) binding).Expression;
          break;
        case MemberBindingType.MemberBinding:
          foreach (var child in GetChildren(((MemberMemberBinding) binding).Bindings))
            yield return child;
          break;
        case MemberBindingType.ListBinding:
          foreach (var child in GetChildren(((MemberListBinding) binding).Initializers))
            yield return child;
          break;
      }
    }

    private static IEnumerable<Expression> GetChildren(IEnumerable<ElementInit> initializers) => initializers.SelectMany<ElementInit, Expression>(initializer => initializer.Arguments);

    /// <summary>Postorder traversal of the expression.</summary>
    /// <param name="exp"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Target = "local$0", Justification = "Value is returned from method and cannot be disposed.")]
    public static IEnumerable<Expression> GetSubtreePreorder(this Expression exp)
    {
      yield return exp;
      foreach (Expression expression in exp.GetChildren().SelectMany<Expression, Expression>(child => child.GetSubtreePreorder()))
        yield return expression;
    }

    /// <summary>
    /// Returns the first matching expression performing a preorder traversal of the expression.
    /// </summary>
    /// <param name="exp"></param>
    /// <param name="match"></param>
    /// <returns></returns>
    public static Expression FindPreorder(this Expression exp, Predicate<Expression> match) => exp.GetSubtreePreorder().FirstOrDefault<Expression>(child => match(child));

    /// <summary>
    /// Traverses a chain of method calls in order of invocation.
    /// </summary>
    /// <param name="exp"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Target = "local$0", Justification = "Value is returned from method and cannot be disposed.")]
    public static IEnumerable<MethodCallExpression> GetMethodsPreorder(this Expression exp)
    {
      if (exp is MethodCallExpression mce)
      {
        yield return mce;
        foreach (MethodCallExpression methodCallExpression in mce.Arguments[0].GetMethodsPreorder())
          yield return methodCallExpression;
      }
    }

    /// <summary>
    /// Traverses a chain of method calls in reverse order of invocation.
    /// </summary>
    /// <param name="exp"></param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Target = "local$0", Justification = "Value is returned from method and cannot be disposed.")]
    public static IEnumerable<MethodCallExpression> GetMethodsPostorder(this Expression exp)
    {
      if (exp is MethodCallExpression mce)
      {
        foreach (MethodCallExpression methodCallExpression in mce.Arguments[0].GetMethodsPostorder())
          yield return methodCallExpression;
        yield return mce;
      }
    }

    public delegate void ExpressionAction(Expression exp, Expression parent);
  }
}
