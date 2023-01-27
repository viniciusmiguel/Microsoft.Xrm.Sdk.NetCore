// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.QueryProvider
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: CB9267C5-A024-49B5-925F-75FBF25C45C6
// Assembly location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.dll
// XML documentation location: C:\Users\hello\.nuget\packages\microsoft.crmsdk.coreassemblies\9.0.2.46\lib\net462\Microsoft.Xrm.Sdk.xml

using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace Microsoft.Xrm.Sdk.Linq
{
  /// <summary>
  /// Represents the main entry point for LINQ based CRM queries.
  /// </summary>
  [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "The extra coupling is temporary.")]
  [SuppressMessage("Microsoft.Security", "CA9881:ClassesShouldBeSealed", Justification = "OData service implementation uses this as base class.")]
  internal class QueryProvider : IQueryProvider
  {
    private readonly OrganizationServiceContext _context;
    private static readonly IEnumerable<string> _followingRoot = new string[1];
    private static readonly IEnumerable<string> _followingFirst = _followingRoot.Concat<string>(new string[1]
    {
      "ToList"
    });
    private static readonly IEnumerable<string> _followingTake = _followingFirst.Concat<string>(new string[6]
    {
      "Select",
      "First",
      "FirstOrDefault",
      "Single",
      "SingleOrDefault",
      "Distinct"
    });
    private static readonly IEnumerable<string> _followingSkip = _followingTake.Concat<string>(new string[1]
    {
      "Take"
    });
    private static readonly IEnumerable<string> _followingSelect = _followingSkip.Concat<string>(new string[1]
    {
      "Skip"
    });
    private static readonly IEnumerable<string> _followingOrderBy = _followingSelect.Concat<string>(new string[6]
    {
      "Select",
      "Where",
      "OrderBy",
      "OrderByDescending",
      "ThenBy",
      "ThenByDescending"
    });
    private static readonly IEnumerable<string> _followingWhere = _followingOrderBy.Concat<string>(new string[1]
    {
      "SelectMany"
    });
    private static readonly IEnumerable<string> _followingJoin = _followingWhere.Concat<string>(new string[1]
    {
      "Join"
    });
    private static readonly IEnumerable<string> _followingGroupJoin = _followingRoot.Concat<string>(new string[1]
    {
      "SelectMany"
    });
    private static readonly Dictionary<string, IEnumerable<string>> _followingMethodLookup = new()
    {
      {
        "Join",
        _followingJoin
      },
      {
        "GroupJoin",
        _followingGroupJoin
      },
      {
        "Where",
        _followingWhere
      },
      {
        "OrderBy",
        _followingOrderBy
      },
      {
        "OrderByDescending",
        _followingOrderBy
      },
      {
        "ThenBy",
        _followingOrderBy
      },
      {
        "ThenByDescending",
        _followingOrderBy
      },
      {
        "Select",
        _followingSelect
      },
      {
        "Skip",
        _followingSkip
      },
      {
        "Take",
        _followingTake
      },
      {
        "First",
        _followingFirst
      },
      {
        "FirstOrDefault",
        _followingFirst
      },
      {
        "Single",
        _followingFirst
      },
      {
        "SingleOrDefault",
        _followingFirst
      },
      {
        "SelectMany",
        _followingOrderBy
      },
      {
        "Distinct",
        _followingSkip
      },
      {
        "Cast",
        new string[1]{ "Select" }
      }
    };
    private static readonly string[] _supportedMethods = new string[4]
    {
      "Equals",
      "Contains",
      "StartsWith",
      "EndsWith"
    };
    private static readonly string[] _validMethods = _supportedMethods.Concat<string>(new string[3]
    {
      "Compare",
      "Like",
      "GetValueOrDefault"
    }).ToArray<string>();
    private static readonly string[] _validProperties = new string[2]
    {
      "Id",
      "Value"
    };
    private static readonly Dictionary<ExpressionType, ConditionOperator> _conditionLookup = new()
    {
      {
        ExpressionType.Equal,
        ConditionOperator.Equal
      },
      {
        ExpressionType.GreaterThan,
        ConditionOperator.GreaterThan
      },
      {
        ExpressionType.GreaterThanOrEqual,
        ConditionOperator.GreaterEqual
      },
      {
        ExpressionType.LessThan,
        ConditionOperator.LessThan
      },
      {
        ExpressionType.LessThanOrEqual,
        ConditionOperator.LessEqual
      },
      {
        ExpressionType.NotEqual,
        ConditionOperator.NotEqual
      }
    };
    private static readonly Dictionary<ConditionOperator, ConditionOperator> _operatorNegationLookup = new()
    {
      {
        ConditionOperator.Equal,
        ConditionOperator.NotEqual
      },
      {
        ConditionOperator.NotEqual,
        ConditionOperator.Equal
      },
      {
        ConditionOperator.GreaterThan,
        ConditionOperator.LessEqual
      },
      {
        ConditionOperator.GreaterEqual,
        ConditionOperator.LessThan
      },
      {
        ConditionOperator.LessThan,
        ConditionOperator.GreaterEqual
      },
      {
        ConditionOperator.LessEqual,
        ConditionOperator.GreaterThan
      },
      {
        ConditionOperator.Like,
        ConditionOperator.NotLike
      },
      {
        ConditionOperator.NotLike,
        ConditionOperator.Like
      },
      {
        ConditionOperator.Null,
        ConditionOperator.NotNull
      },
      {
        ConditionOperator.NotNull,
        ConditionOperator.Null
      }
    };
    private static readonly Dictionary<ExpressionType, LogicalOperator> _booleanLookup = new()
    {
      {
        ExpressionType.And,
        LogicalOperator.And
      },
      {
        ExpressionType.Or,
        LogicalOperator.Or
      },
      {
        ExpressionType.AndAlso,
        LogicalOperator.And
      },
      {
        ExpressionType.OrElse,
        LogicalOperator.Or
      }
    };
    private static readonly Dictionary<LogicalOperator, LogicalOperator> _logicalOperatorNegationLookup = new()
    {
      {
        LogicalOperator.And,
        LogicalOperator.Or
      },
      {
        LogicalOperator.Or,
        LogicalOperator.And
      }
    };

    public QueryProvider(OrganizationServiceContext context) => _context = context;

    protected OrganizationServiceContext OrganizationServiceContext => _context;

    /// <summary>Binds to the set of entities of a specified type.</summary>
    /// <param name="entityType"></param>
    /// <returns></returns>
    private IQueryable CreateQuery(Type entityType)
    {
      CheckEntitySubclass(entityType);
      var nameForType = KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType);
      return CreateQueryInstance(entityType, new object[2]
      {
        this,
        nameForType
      });
    }

    private IQueryable<TElement> CreateQuery<TElement>(Expression expression) => new Query<TElement>(this, expression);

    private IQueryable CreateQuery(Expression expression) => CreateQueryInstance(expression.Type.GetGenericArguments()[0], new object[2]
    {
      this,
      expression
    });

    IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
    {
      ClientExceptionHelper.ThrowIfNull(expression, nameof (expression));
      return CreateQuery<TElement>(expression);
    }

    IQueryable IQueryProvider.CreateQuery(Expression expression)
    {
      ClientExceptionHelper.ThrowIfNull(expression, nameof (expression));
      return CreateQuery(expression);
    }

    TResult IQueryProvider.Execute<TResult>(Expression expression)
    {
      ClientExceptionHelper.ThrowIfNull(expression, nameof (expression));
      return Execute<TResult>(expression).FirstOrDefault<TResult>();
    }

    object IQueryProvider.Execute(Expression expression)
    {
      ClientExceptionHelper.ThrowIfNull(expression, nameof (expression));
      return Execute<object>(expression).FirstOrDefault<object>();
    }

    public virtual IEnumerator<TElement> GetEnumerator<TElement>(Expression expression) => Execute<TElement>(expression).GetEnumerator();

    private IQueryable CreateQueryInstance(Type elementType, object[] args)
    {
      try
      {
        return Activator.CreateInstance(typeof (Query<>).MakeGenericType(elementType), args) as IQueryable;
      }
      catch (TargetInvocationException ex)
      {
        ThrowException(ex.InnerException);
        throw;
      }
    }

    private void CheckEntitySubclass(Type entityType)
    {
      if (!entityType.IsSubclassOf(typeof (Entity)))
        ThrowException(new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The specified type '{0}' must be a subclass of '{1}'.", entityType, typeof (Entity))));
      if (!string.IsNullOrWhiteSpace(KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType)))
        return;
      ThrowException(new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The specified type '{0}' is not a known entity type.", entityType)));
    }

    public IEnumerable<TElement> Execute<TElement>(Expression expression)
    {
      NavigationSource source = null;
      var linkLookups = new List<LinkLookup>();
      bool throwIfSequenceIsEmpty;
      bool throwIfSequenceNotSingle;
      Projection projection;
      return Execute<TElement>(GetQueryExpression(expression, out throwIfSequenceIsEmpty, out throwIfSequenceNotSingle, out projection, ref source, ref linkLookups), throwIfSequenceIsEmpty, throwIfSequenceNotSingle, projection, source, linkLookups);
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "The enumerator will be disposed by the calling method.")]
    protected IEnumerable<TElement> Execute<TElement>(
      QueryExpression qe,
      bool throwIfSequenceIsEmpty,
      bool throwIfSequenceNotSingle,
      Projection projection,
      NavigationSource source,
      List<LinkLookup> linkLookups)
    {
      string pagingCookie = null;
      var moreRecords = false;
      return new PagedItemCollection<TElement>(Execute(qe, throwIfSequenceIsEmpty, throwIfSequenceNotSingle, projection, source, linkLookups, out pagingCookie, out moreRecords).Cast<TElement>(), qe, pagingCookie, moreRecords);
    }

    private IEnumerable Execute(
      QueryExpression qe,
      bool throwIfSequenceIsEmpty,
      bool throwIfSequenceNotSingle,
      Projection projection,
      NavigationSource source,
      List<LinkLookup> linkLookups,
      out string pagingCookie,
      out bool moreRecords)
    {
      IEnumerable<Entity> entities = null;
      pagingCookie = null;
      moreRecords = false;
      OrganizationRequest request;
      if (source != null)
      {
        var relationshipQueryCollection1 = new RelationshipQueryCollection();
        relationshipQueryCollection1.Add(source.Relationship, qe);
        var relationshipQueryCollection2 = relationshipQueryCollection1;
        request = new RetrieveRequest()
        {
          Target = source.Target,
          ColumnSet = new ColumnSet(),
          RelatedEntitiesQuery = relationshipQueryCollection2
        };
      }
      else
        request = new RetrieveMultipleRequest()
        {
          Query = qe
        };
      var nullable1 = new int?();
      if (qe.PageInfo != null)
        nullable1 = new int?(qe.PageInfo.Count);
      var moreRecordAfterAdjust = true;
      var entityCollection1 = (AdjustPagingInfo(request, qe, source, out moreRecordAfterAdjust) ? 1 : 0) == 0 ? AdjustEntityCollection(request, qe, source) : (moreRecordAfterAdjust ? RetrieveEntityCollection(request, source) : new EntityCollection());
      if (throwIfSequenceIsEmpty && (entityCollection1 == null || entityCollection1.Entities.Count == 0))
        ThrowException(new InvalidOperationException("Sequence contains no elements"));
      if (throwIfSequenceNotSingle && entityCollection1 != null && entityCollection1.Entities.Count > 1)
        ThrowException(new InvalidOperationException("Sequence contains more than one element"));
      if (entityCollection1 != null)
      {
        pagingCookie = entityCollection1.PagingCookie;
        moreRecords = entityCollection1.MoreRecords;
        var count = entityCollection1.Entities.Count;
        var entityCollection2 = entityCollection1;
        while (moreRecords)
        {
          int? nullable2;
          if (nullable1.HasValue)
          {
            nullable2 = nullable1;
            var num = count;
            if (nullable2.GetValueOrDefault() > num & nullable2.HasValue)
            {
              qe.PageInfo.Count = nullable1.Value - count;
              goto label_16;
            }
          }
          if (nullable1.HasValue)
          {
            nullable2 = nullable1;
            var num = 0;
            if (nullable2.GetValueOrDefault() > num & nullable2.HasValue)
              break;
          }
label_16:
          if (string.IsNullOrEmpty(pagingCookie))
            ThrowException(new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "Paging cookie required to retrieve more records. Update your query to retrieve with total records below {0}", RetrievalUpperLimitWithoutPagingCookie)));
          qe.PageInfo.PagingCookie = entityCollection2.PagingCookie;
          ++qe.PageInfo.PageNumber;
          qe.PageInfo.Count = qe.PageInfo.Count < RetrievalUpperLimitWithoutPagingCookie ? qe.PageInfo.Count : RetrievalUpperLimitWithoutPagingCookie;
          entityCollection2 = RetrieveEntityCollection(request, source);
          if (entityCollection2 != null && entityCollection2.Entities.Count > 0)
          {
            pagingCookie = entityCollection2.PagingCookie;
            moreRecords = entityCollection2.MoreRecords;
            count += entityCollection2.Entities.Count;
            entityCollection1.Entities.AddRange(entityCollection2.Entities);
          }
          else
            break;
        }
        entities = entityCollection1.Entities;
      }
      return projection != null ? ExecuteAnonymousType(entities, projection, linkLookups) : entities.Select<Entity, Entity>(new Func<Entity, Entity>(AttachToContext));
    }

    private EntityCollection RetrieveEntityCollection(
      OrganizationRequest request,
      NavigationSource source)
    {
      if (request == null || string.IsNullOrEmpty(request.RequestName) || !(request.RequestName == "Retrieve") && !(request.RequestName == "RetrieveMultiple"))
        ThrowException(new ArgumentException("Invalid request", nameof (request)));
      EntityCollection entityCollection;
      if (source != null)
      {
        var retrieveResponse = _context.Execute(request) as RetrieveResponse;
        entityCollection = retrieveResponse.Entity.RelatedEntities.Contains(source.Relationship) ? retrieveResponse.Entity.RelatedEntities[source.Relationship] : null;
      }
      else
        entityCollection = (_context.Execute(request) as RetrieveMultipleResponse).EntityCollection;
      return entityCollection;
    }

    /// <summary>Reset the page number with the new value.</summary>
    /// <param name="pagingCookie"></param>
    /// <param name="newPage"></param>
    /// <returns></returns>
    private static string ResetPagingNumber(string pagingCookie, int newPage)
    {
      if (string.IsNullOrEmpty(pagingCookie))
        return pagingCookie;
      var pageNumber = 0;
      return PagingCookieHelper.ToPagingCookie(PagingCookieHelper.ToContinuationToken(pagingCookie, newPage), out pageNumber, new StringBuilder());
    }

    /// <summary>Reset the paging info.</summary>
    /// <param name="pagingInfo">PagingInfo object to reset.</param>
    /// <param name="pagingCookie">Paging cookie to use, if available.</param>
    /// <param name="skipValue">Records to skip.</param>
    private static void ResetPagingInfo(PagingInfo pagingInfo, string pagingCookie, int skipValue)
    {
      if (string.IsNullOrEmpty(pagingCookie))
      {
        pagingInfo.PageNumber = skipValue;
        pagingInfo.Count = 1;
      }
      else
      {
        pagingInfo.PagingCookie = ResetPagingNumber(pagingCookie, 1);
        pagingInfo.PageNumber = skipValue + 1;
        pagingInfo.Count = 1;
      }
    }

    private static bool IsPagingCookieNull(EntityCollection entityCollection) => entityCollection != null && string.IsNullOrEmpty(entityCollection.PagingCookie);

    /// <summary>
    /// Positions the paging cookie to start at the requested record.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="pagingInfo"></param>
    /// <param name="source"></param>
    /// <param name="moreRecordAfterAdjust">False if no more records are found after skip.</param>
    /// <returns>Paging cookie strategy applied.</returns>
    private bool AdjustPagingInfo(
      OrganizationRequest request,
      QueryExpression qe,
      NavigationSource source,
      out bool moreRecordAfterAdjust)
    {
      moreRecordAfterAdjust = true;
      if (request == null || qe == null || qe.PageInfo == null || !string.IsNullOrEmpty(qe.PageInfo.PagingCookie))
        return true;
      var pageInfo = qe.PageInfo;
      EntityCollection entityCollection = null;
      var pageNumber = pageInfo.PageNumber;
      var count = pageInfo.Count;
      var num1 = count > RetrievalUpperLimitWithoutPagingCookie ? RetrievalUpperLimitWithoutPagingCookie : count;
      if (pageNumber > 0)
      {
        var num2 = pageNumber / RetrievalUpperLimitWithoutPagingCookie;
        var skipValue = pageNumber % RetrievalUpperLimitWithoutPagingCookie;
        if (num2 > 0)
        {
          for (var index = 0; index < num2; ++index)
          {
            ResetPagingInfo(pageInfo, entityCollection == null ? null : entityCollection.PagingCookie, RetrievalUpperLimitWithoutPagingCookie);
            entityCollection = RetrieveEntityCollection(request, source);
            if (IsPagingCookieNull(entityCollection))
            {
              pageInfo.PageNumber = pageNumber;
              pageInfo.Count = num1;
              return false;
            }
            if (entityCollection != null && !entityCollection.MoreRecords)
            {
              moreRecordAfterAdjust = false;
              return true;
            }
          }
        }
        if (skipValue > 0 && !IsPagingCookieNull(entityCollection))
        {
          ResetPagingInfo(pageInfo, entityCollection == null ? null : entityCollection.PagingCookie, skipValue);
          entityCollection = RetrieveEntityCollection(request, source);
          if (IsPagingCookieNull(entityCollection))
          {
            pageInfo.PageNumber = pageNumber;
            pageInfo.Count = num1;
            return false;
          }
          if (entityCollection != null && !entityCollection.MoreRecords)
          {
            moreRecordAfterAdjust = false;
            return true;
          }
        }
        pageInfo.PagingCookie = ResetPagingNumber(entityCollection.PagingCookie, 1);
        pageInfo.PageNumber = 2;
        pageInfo.Count = num1;
      }
      if (pageInfo.PageNumber == 0)
        pageInfo.PageNumber = 1;
      return true;
    }

    /// <summary>
    /// Strategy to be used only for calls with skip clause that do not return paging cookie.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="qe"></param>
    /// <param name="source"></param>
    /// <returns>Skipped entity collection.</returns>
    private EntityCollection AdjustEntityCollection(
      OrganizationRequest request,
      QueryExpression qe,
      NavigationSource source)
    {
      if (request == null || qe == null || qe.PageInfo == null || !string.IsNullOrEmpty(qe.PageInfo.PagingCookie))
        return new EntityCollection();
      var pageInfo = qe.PageInfo;
      var pageNumber = pageInfo.PageNumber;
      var count = pageInfo.Count;
      if (pageNumber >= RetrievalUpperLimitWithoutPagingCookie)
        ThrowException(new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "Skipping records beyond {0} is not supported", RetrievalUpperLimitWithoutPagingCookie)));
      pageInfo.PageNumber = 1;
      if (count > 0)
        pageInfo.Count = pageNumber + count > RetrievalUpperLimitWithoutPagingCookie ? RetrievalUpperLimitWithoutPagingCookie : pageNumber + count;
      var entityCollection1 = RetrieveEntityCollection(request, source);
      if (entityCollection1 != null && !string.IsNullOrEmpty(entityCollection1.PagingCookie))
        ThrowException(new InvalidOperationException("Queries with valid paging cookie should not be executed in this strategy"));
      if (pageNumber <= 0)
        return entityCollection1;
      var entityCollection2 = pageNumber >= entityCollection1.Entities.Count ? new EntityCollection() : new EntityCollection(entityCollection1.Entities.Skip<Entity>(pageNumber).ToList<Entity>());
      entityCollection2.EntityName = entityCollection1.EntityName;
      entityCollection2.MoreRecords = entityCollection1.MoreRecords;
      return entityCollection2;
    }

    protected virtual int RetrievalUpperLimitWithoutPagingCookie => 5000;

    private IEnumerable ExecuteAnonymousType(
      IEnumerable<Entity> entities,
      Projection projection,
      List<LinkLookup> linkLookups)
    {
      var project = CompileExpression(projection.Expression);
      return entities.Select(entity => new
      {
        entity = entity,
        args = BuildProjection(projection, entity, linkLookups)
      }).Select(_param1 => new
      {
        Eh__TransparentIdentifier0 = _param1,
        element = DynamicInvoke(project, _param1.args)
      }).Select(_param1 => new
      {
        Eh__TransparentIdentifier1 = _param1,
        result = _param1.element as Entity
      }).Select(_param1 => _param1.result == null || !(_param1.result.Id != Guid.Empty) ? _param1.Eh__TransparentIdentifier1.element : AttachToContext(_param1.result));
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    [SecuritySafeCritical]
    private Delegate CompileExpression(LambdaExpression expression)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
        return expression.Compile();
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    [SecuritySafeCritical]
    private object DynamicInvoke(Delegate project, params object[] args)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
        return project.DynamicInvoke(args);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    [SecuritySafeCritical]
    private object ConstructorInvoke(ConstructorInfo ci, object[] parameters)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Assert();
        return ci.Invoke(parameters);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    private Entity AttachToContext(Entity entity) => _context.MergeEntity(entity);

    private object[] BuildProjection(
      Projection projection,
      Entity entity,
      IList<LinkLookup> linkLookups)
    {
      if (entity == null)
        return null;
      if (linkLookups.Count == 0)
        return new Entity[1]
        {
          AttachToContext(entity)
        };
      var parameters = projection.Expression.Parameters;
      if (linkLookups.Count != 2 || parameters.Count != 2)
        return parameters.Select<ParameterExpression, object>(parameter => BuildProjection(null, projection.MethodName, parameter.Type, entity, linkLookups)).ToArray<object>();
      return new object[2]
      {
        linkLookups[1].Link.JoinOperator == JoinOperator.LeftOuter ? BuildProjection(null, projection.MethodName, parameters[0].Type, entity, linkLookups) : entity,
        BuildProjectionParameter(parameters[1].Type, entity, linkLookups[1])
      };
    }

    private object BuildProjection(
      string environment,
      string projectingMethodName,
      Type entityType,
      Entity entity,
      IEnumerable<LinkLookup> linkLookups)
    {
      if (IsEntity(entityType))
        return BuildProjectionParameter(null, projectingMethodName, entityType, entity, linkLookups) ?? entity;
      var constructors = entityType.GetConstructors();
      if (IsAnonymousType(entityType) && constructors.Length != 1)
        ThrowException(new InvalidOperationException("The result selector of the 'Join' operation is not returning a valid anonymous type."));
      var ci = constructors.First<ConstructorInfo>();
      var parameters = ci.GetParameters();
      if (parameters.Length != 2)
        ThrowException(new InvalidOperationException("The result selector of the 'Join' operation must return an anonymous type of two properties."));
      var parameterInfo1 = parameters[0];
      var parameterInfo2 = parameters[1];
      if (IsEntity(parameterInfo1.ParameterType) && IsEntity(parameterInfo2.ParameterType))
      {
        var obj1 = BuildProjectionParameter(parameterInfo1, environment, projectingMethodName, parameterInfo1.ParameterType, entity, linkLookups);
        var obj2 = BuildProjectionParameter(parameterInfo2, environment, projectingMethodName, parameterInfo2.ParameterType, entity, linkLookups);
        return ConstructorInvoke(ci, new object[2]
        {
          obj1,
          obj2
        });
      }
      if (IsEntity(parameterInfo2.ParameterType))
      {
        var obj3 = BuildProjectionParameter(parameterInfo1, environment, projectingMethodName, entity, linkLookups);
        var obj4 = BuildProjectionParameter(parameterInfo2, environment, projectingMethodName, parameterInfo2.ParameterType, entity, linkLookups);
        return ConstructorInvoke(ci, new object[2]
        {
          obj3,
          obj4
        });
      }
      if (IsEntity(parameterInfo1.ParameterType))
      {
        var obj5 = BuildProjectionParameter(parameterInfo1, environment, projectingMethodName, parameterInfo1.ParameterType, entity, linkLookups);
        var obj6 = BuildProjectionParameter(parameterInfo2, environment, projectingMethodName, entity, linkLookups);
        return ConstructorInvoke(ci, new object[2]
        {
          obj5,
          obj6
        });
      }
      ThrowException(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Invalid left '{0}' and right '{1}' parameters.", parameterInfo1.ParameterType.Name, parameterInfo2.ParameterType.Name)));
      return null;
    }

    private object BuildProjectionParameter(
      ParameterInfo parameter,
      string environment,
      string projectingMethodName,
      Entity entity,
      IEnumerable<LinkLookup> linkLookups)
    {
      return parameter.ParameterType.IsGenericType && parameter.ParameterType.GetGenericTypeDefinition() == typeof (IEnumerable<>) ? null : BuildProjection(GetEnvironment(parameter, environment), projectingMethodName, parameter.ParameterType, entity, linkLookups);
    }

    private object BuildProjectionParameter(
      ParameterInfo pi,
      string environment,
      string projectingMethodName,
      Type entityType,
      Entity entity,
      IEnumerable<LinkLookup> linkLookups)
    {
      return BuildProjectionParameter(GetEnvironment(pi, environment), projectingMethodName, entityType, entity, linkLookups);
    }

    private object BuildProjectionParameter(
      string environment,
      string projectingMethodName,
      Type entityType,
      Entity entity,
      IEnumerable<LinkLookup> linkLookups)
    {
      var link = projectingMethodName == "SelectMany" ? linkLookups.SingleOrDefault<LinkLookup>(l => l.SelectManyEnvironment != null && l.SelectManyEnvironment == environment) : linkLookups.SingleOrDefault<LinkLookup>(l => l.Environment == environment);
      if (link != null)
        return BuildProjectionParameter(entityType, entity, link);
      ThrowException(new InvalidOperationException("The projection property does not match an existing entity binding."));
      return null;
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private object BuildProjectionParameter(
      Type entityType,
      Entity entity,
      LinkLookup link)
    {
      if (link.Link == null)
        return entity;
      var entity1 = entityType == typeof (Entity) ? new Entity(link.Link.LinkToEntityName) : Activator.CreateInstance(entityType) as Entity;
      var entityAlias = string.Format(CultureInfo.InvariantCulture, "{0}.", link.Link.EntityAlias);
      var aliasIndex = entityAlias.Length;
      foreach (var data in entity.Attributes.Where<KeyValuePair<string, object>>(a => a.Value is AliasedValue && a.Key.StartsWith(entityAlias, StringComparison.Ordinal)).Select(a => new
      {
        Key = a.Key.Substring(aliasIndex),
        Value = (a.Value as AliasedValue).Value
      }))
        entity1.Attributes.Add(data.Key, data.Value);
      return entity1;
    }

    private static string GetEnvironment(ParameterInfo pi, string environment) => environment == null ? pi.Name : string.Format(CultureInfo.InvariantCulture, "{0}.{1}", environment, pi.Name);

    /// <summary>
    /// Converts an expression to a <see cref="T:Microsoft.Xrm.Sdk.Query.QueryExpression" /> without executing the query.
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public QueryExpression Translate(Expression expression)
    {
      NavigationSource source = null;
      List<LinkLookup> linkLookups = null;
      return GetQueryExpression(expression, out var _, out var _, out var _, ref source, ref linkLookups);
    }

    protected virtual bool IsValidFollowingMethod(string method, string next)
    {
      IEnumerable<string> source;
      return _followingMethodLookup.TryGetValue(method, out source) && source.Contains<string>(next);
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private bool IsValidMethod(string method) => _followingMethodLookup.ContainsKey(method);

    [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    private QueryExpression GetQueryExpression(
      Expression expression,
      out bool throwIfSequenceIsEmpty,
      out bool throwIfSequenceNotSingle,
      out Projection projection,
      ref NavigationSource source,
      ref List<LinkLookup> linkLookups)
    {
      throwIfSequenceIsEmpty = false;
      throwIfSequenceNotSingle = false;
      projection = null;
      var skipVal = new int?();
      var takeVal = new int?();
      var qe = new QueryExpression();
      var list = expression.GetMethodsPostorder().ToList<MethodCallExpression>();
      var flag = list.Count > 0 && (list[0].Method.Name == "Join" || list[0].Method.Name == "GroupJoin");
      for (var i = 0; i < list.Count; ++i)
      {
        var mce = list[i];
        var name1 = mce.Method.Name;
        if (!IsValidMethod(name1))
          ThrowException(new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "The method '{0}' is not supported.", name1)));
        if (i > 0)
        {
          var name2 = list[i - 1].Method.Name;
          if (!IsValidFollowingMethod(name2, name1))
            ThrowException(new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "The method '{0}' cannot follow the method '{1}' or is not supported. Try writing the query in terms of supported methods or call the 'AsEnumerable' or 'ToList' method before calling unsupported methods.", name1, name2)));
        }
        int? nullable;
        switch (name1)
        {
          case "Distinct":
            qe.Distinct = true;
            break;
          case "First":
          case "FirstOrDefault":
          case "Single":
          case "SingleOrDefault":
          case "Where":
            if (name1 != "Where")
              takeVal = new int?(1);
            if (name1 == "First" || name1 == "Single")
              throwIfSequenceIsEmpty = true;
            if (name1 == "SingleOrDefault" || name1 == "Single")
            {
              takeVal = new int?(2);
              throwIfSequenceNotSingle = true;
            }
            string parameterName1;
            var methodCallBody1 = GetMethodCallBody(mce, out parameterName1);
            if (methodCallBody1 != null)
            {
              TranslateWhere(qe, parameterName1, methodCallBody1, linkLookups);
              break;
            }
            break;
          case "GroupJoin":
            TranslateGroupJoin(qe, list, ref i, out projection, out linkLookups);
            break;
          case "Join":
            TranslateJoin(qe, list, ref i, out projection, out linkLookups);
            break;
          case "OrderBy":
          case "ThenBy":
            string parameterName2;
            var methodCallBody2 = GetMethodCallBody(mce, out parameterName2);
            TranslateOrderBy(qe, methodCallBody2, OrderType.Ascending, parameterName2, linkLookups);
            break;
          case "OrderByDescending":
          case "ThenByDescending":
            string parameterName3;
            var methodCallBody3 = GetMethodCallBody(mce, out parameterName3);
            TranslateOrderBy(qe, methodCallBody3, OrderType.Descending, parameterName3, linkLookups);
            break;
          case "Select":
            if (linkLookups != null && !flag)
              linkLookups.Clear();
            TranslateEntityName(qe, expression, mce);
            var operand1 = (mce.Arguments[1] as UnaryExpression).Operand as LambdaExpression;
            projection = new Projection(name1, operand1);
            var expression1 = TranslateSelect(list, i, qe, operand1, ref source);
            if (expression1 != null)
              return GetQueryExpression(expression1, out throwIfSequenceIsEmpty, out throwIfSequenceNotSingle, out projection, ref source, ref linkLookups);
            break;
          case "SelectMany":
            if (linkLookups != null && !flag)
              linkLookups.Clear();
            TranslateEntityName(qe, expression, mce);
            var operand2 = (mce.Arguments[1] as UnaryExpression).Operand as LambdaExpression;
            return GetQueryExpression(TranslateSelectMany(list, i, qe, operand2, ref source), out throwIfSequenceIsEmpty, out throwIfSequenceNotSingle, out projection, ref source, ref linkLookups);
          case "Skip":
            skipVal = new int?((int) (mce.Arguments[1] as ConstantExpression).Value);
            if (skipVal.HasValue)
            {
              nullable = skipVal;
              var num = 0;
              if (nullable.GetValueOrDefault() < num & nullable.HasValue)
              {
                ThrowException(new NotSupportedException("Skip operator does not support negative values."));
                break;
              }
              break;
            }
            break;
          case "Take":
            takeVal = new int?((int) (mce.Arguments[1] as ConstantExpression).Value);
            if (takeVal.HasValue)
            {
              nullable = takeVal;
              var num = 0;
              if (nullable.GetValueOrDefault() <= num & nullable.HasValue)
              {
                ThrowException(new NotSupportedException("Take/Top operators only support positive values."));
                break;
              }
              break;
            }
            break;
        }
      }
      if (projection != null)
      {
        TranslateSelect(qe, projection.Expression, linkLookups);
        FixOrderBy(qe, projection.Expression);
      }
      if (!BuildPagingInfo(qe, skipVal, takeVal))
        ThrowException(new NotSupportedException("The 'Skip' value must be a multiple of the 'Take/Top' value."));
      FixEntityName(qe, expression);
      FixColumnSet(qe);
      return qe;
    }

    protected virtual bool BuildPagingInfo(QueryExpression qe, int? skipVal, int? takeVal)
    {
      if (!skipVal.HasValue && !takeVal.HasValue)
        return true;
      if (qe.PageInfo == null)
        qe.PageInfo = new PagingInfo();
      if (skipVal.HasValue && skipVal.Value > 0)
        qe.PageInfo.PageNumber = skipVal.Value;
      if (takeVal.HasValue && takeVal.Value > 0)
        qe.PageInfo.Count = takeVal.Value;
      return true;
    }

    protected virtual void FixOrderBy(QueryExpression qe, LambdaExpression exp)
    {
    }

    protected virtual void FixEntityName(QueryExpression qe, Expression expression) => TranslateEntityName(qe, expression, null);

    protected virtual void FixColumnSet(QueryExpression qe) => qe.ColumnSet = qe.ColumnSet == null || qe.ColumnSet.Columns.Count == 0 ? new ColumnSet(true) : qe.ColumnSet;

    private void TranslateJoin(
      QueryExpression qe,
      IList<MethodCallExpression> methods,
      ref int i,
      out Projection projection,
      out List<LinkLookup> linkLookups)
    {
      var num = 0;
      List<Tuple<string, string, LinkEntity, string>> source = null;
      do
      {
        var method = methods[i];
        projection = new Projection(method.Method.Name, (method.Arguments[4] as UnaryExpression).Operand as LambdaExpression);
        string str;
        string environment;
        if (i < methods.Count - 1)
        {
          environment = GetEnvironmentForParameter(projection.Expression, 0);
          str = GetEnvironmentForParameter(projection.Expression, 1);
        }
        else
          environment = str = null;
        string alias = null;
        var operand1 = (method.Arguments[2] as UnaryExpression).Operand as LambdaExpression;
        var name1 = operand1.Parameters.First<ParameterExpression>().Name;
        var entityExpression = FindValidEntityExpression(operand1.Body, "join");
        var attributeName1 = TranslateExpressionToAttributeName(entityExpression, false, out alias);
        var operand2 = (method.Arguments[3] as UnaryExpression).Operand as LambdaExpression;
        var name2 = operand2.Parameters.First<ParameterExpression>().Name;
        var attributeName2 = TranslateExpressionToAttributeName(FindValidEntityExpression(operand2.Body, "join"), false, out alias);
        var entityLogicalName = ((method.Arguments[1] as ConstantExpression).Value as IEntityQuery).EntityLogicalName;
        LinkEntity linkEntity1;
        if (source == null)
        {
          qe.EntityName = ((method.Arguments[0] as ConstantExpression).Value as IEntityQuery).EntityLogicalName;
          source = new List<Tuple<string, string, LinkEntity, string>>()
          {
            new(environment, environment, null, name1)
          };
          linkEntity1 = qe.AddLink(entityLogicalName, attributeName1, attributeName2, JoinOperator.Inner);
        }
        else
        {
          if (environment != null)
            source = source.Select<Tuple<string, string, LinkEntity, string>, Tuple<string, string, LinkEntity, string>>(l => new Tuple<string, string, LinkEntity, string>(l.Item1, environment + "." + l.Item2, l.Item3, l.Item4)).ToList<Tuple<string, string, LinkEntity, string>>();
          var parentMember = GetUnderlyingMemberExpression(entityExpression).Member.Name;
          var linkEntity2 = source.Single<Tuple<string, string, LinkEntity, string>>(l => l.Item1 == parentMember).Item3;
          linkEntity1 = linkEntity2 == null ? qe.AddLink(entityLogicalName, attributeName1, attributeName2, JoinOperator.Inner) : linkEntity2.AddLink(entityLogicalName, attributeName1, attributeName2, JoinOperator.Inner);
        }
        linkEntity1.EntityAlias = string.Format(CultureInfo.InvariantCulture, "{0}_{1}", name2, num++);
        source.Add(new Tuple<string, string, LinkEntity, string>(str, str, linkEntity1, name2));
        ++i;
      }
      while (i < methods.Count && methods[i].Method.Name == "Join");
      --i;
      linkLookups = source.Select<Tuple<string, string, LinkEntity, string>, LinkLookup>(l => new LinkLookup(l.Item4, l.Item2, l.Item3)).ToList<LinkLookup>();
    }

    private void TranslateGroupJoin(
      QueryExpression qe,
      IList<MethodCallExpression> methods,
      ref int i,
      out Projection projection,
      out List<LinkLookup> linkLookups)
    {
      var method1 = methods[i];
      List<LinkLookup> linkLookups1;
      TranslateJoin(qe, methods, ref i, out projection, out linkLookups1);
      ++i;
      if (i + 1 > methods.Count || !IsValidLeftOuterSelectManyExpression(methods[i]))
        ThrowException(new NotSupportedException("The 'GroupJoin' operation must be followed by a 'SelectMany' operation where the collection selector is invoking the 'DefaultIfEmpty' method."));
      var method2 = methods[i];
      LambdaExpression expression;
      if (method2.Arguments.Count == 3)
      {
        expression = (method2.Arguments[2] as UnaryExpression).Operand as LambdaExpression;
      }
      else
      {
        var parameter1 = ((method2.Arguments[1] as UnaryExpression).Operand as LambdaExpression).Parameters[0];
        var parameter2 = ((method1.Arguments[3] as UnaryExpression).Operand as LambdaExpression).Parameters[0];
        expression = Expression.Lambda(parameter2, parameter1, parameter2);
      }
      projection = new Projection(method2.Method.Name, expression);
      var environmentForParameter1 = GetEnvironmentForParameter(projection.Expression, 0);
      var environmentForParameter2 = GetEnvironmentForParameter(projection.Expression, 1);
      linkLookups = new List<LinkLookup>()
      {
        new(linkLookups1[0].ParameterName, environmentForParameter1 != null ? string.Format(CultureInfo.InvariantCulture, "{0}.{1}", environmentForParameter1, linkLookups1[0].Environment) : linkLookups1[0].Environment, linkLookups1[0].Link, linkLookups1[0].Environment),
        new(linkLookups1[1].ParameterName, environmentForParameter2, linkLookups1[1].Link)
      };
      linkLookups1[1].Link.JoinOperator = JoinOperator.LeftOuter;
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private bool IsValidLeftOuterSelectManyExpression(MethodCallExpression mce) => !(mce.Method.Name != "SelectMany") && mce.Arguments[1] is UnaryExpression unaryExpression1 && unaryExpression1.Operand is LambdaExpression operand1 && operand1.Body is MethodCallExpression body && !(body.Method.Name != "DefaultIfEmpty") && body.Arguments.Count == 1 && (mce.Arguments.Count == 2 || mce.Arguments.Count == 3 && mce.Arguments[2] is UnaryExpression unaryExpression2 && unaryExpression2.Operand is LambdaExpression operand2 && operand2.Parameters.Count == 2);

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private string GetEnvironmentForParameter(LambdaExpression projection, int index)
    {
      if (!(projection.Body is NewExpression body))
        return null;
      var parameter = projection.Parameters[index];
      var arguments = body.Arguments;
      var expression = arguments.FirstOrDefault<Expression>(arg => arg == parameter);
      if (expression == null)
        return null;
      var index1 = arguments.IndexOf(expression);
      return body.Members[index1].Name;
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private ConditionOperator NegateOperator(ConditionOperator op) => _operatorNegationLookup[op];

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private LogicalOperator NegateOperator(LogicalOperator op) => _logicalOperatorNegationLookup[op];

    private void TranslateWhere(
      QueryExpression qe,
      string parameterName,
      Expression exp,
      List<LinkLookup> linkLookups)
    {
      TranslateWhereBoolean(parameterName, exp, null, GetFilter(parameterName, qe, linkLookups), linkLookups, null, false);
    }

    private void TranslateWhere(
      string parameterName,
      BinaryExpression be,
      FilterExpressionWrapper parentFilter,
      Func<Expression, FilterExpressionWrapper> getFilter,
      List<LinkLookup> linkLookups,
      bool negate)
    {
      if (_booleanLookup.ContainsKey(be.NodeType))
      {
        parentFilter = GetFilter(FindEntityExpression(be.Left), parentFilter, getFilter);
        var parentFilter1 = new FilterExpressionWrapper(parentFilter.Filter.AddFilter(_booleanLookup[be.NodeType]), parentFilter.Alias);
        parentFilter1.Filter.FilterOperator = negate ? NegateOperator(parentFilter1.Filter.FilterOperator) : parentFilter1.Filter.FilterOperator;
        TranslateWhereBoolean(parameterName, be.Left, parentFilter1, getFilter, linkLookups, be, negate);
        TranslateWhereBoolean(parameterName, be.Right, parentFilter1, getFilter, linkLookups, be, negate);
      }
      else
      {
        if (!_conditionLookup.ContainsKey(be.NodeType))
          return;
        var negate1 = negate;
        if (TranslateWhere(be.Left, ref negate1) is MethodCallExpression exp && (exp.Method.Name == "Compare" || _supportedMethods.Contains<string>(exp.Method.Name)))
          TranslateWhereBoolean(parameterName, exp, parentFilter, getFilter, linkLookups, be, negate1);
        else
          TranslateWhereCondition(be, parentFilter, getFilter, GetLinkLookup(parameterName, linkLookups), negate);
      }
    }

    protected virtual Expression TranslateWhere(Expression exp, ref bool negate)
    {
      if (!(exp is UnaryExpression unaryExpression) || unaryExpression.NodeType != ExpressionType.Not)
        return exp;
      negate = !negate;
      return TranslateWhere(unaryExpression.Operand, ref negate);
    }

    protected virtual void TranslateWhereBoolean(
      string parameterName,
      Expression exp,
      FilterExpressionWrapper parentFilter,
      Func<Expression, FilterExpressionWrapper> getFilter,
      List<LinkLookup> linkLookups,
      BinaryExpression parent,
      bool negate)
    {
      var be = exp as BinaryExpression;
      var unaryExpression = exp as UnaryExpression;
      var mce = exp as MethodCallExpression;
      if (be != null)
      {
        if (be.Left is ConstantExpression left && (be.NodeType == ExpressionType.AndAlso && Equals(left.Value, true) || be.NodeType == ExpressionType.OrElse && Equals(left.Value, false)))
          TranslateWhereBoolean(parameterName, be.Right, parentFilter, getFilter, linkLookups, parent, negate);
        else
          TranslateWhere(parameterName, be, parentFilter, getFilter, linkLookups, negate);
      }
      else if (mce != null)
        TranslateWhereMethodCall(mce, parentFilter, getFilter, GetLinkLookup(parameterName, linkLookups), parent, negate);
      else if (unaryExpression != null)
      {
        if (unaryExpression.NodeType == ExpressionType.Convert)
        {
          TranslateWhereBoolean(parameterName, unaryExpression.Operand, parentFilter, getFilter, linkLookups, parent, negate);
        }
        else
        {
          if (unaryExpression.NodeType != ExpressionType.Not)
            return;
          TranslateWhereBoolean(parameterName, unaryExpression.Operand, parentFilter, getFilter, linkLookups, parent, !negate);
        }
      }
      else
      {
        if (!(exp.Type == typeof (bool)))
          return;
        TranslateWhere(parameterName, Expression.Equal(exp, Expression.Constant(true)), parentFilter, getFilter, linkLookups, negate);
      }
    }

    private string GetLinkEntityAlias(
      Expression expression,
      Func<Expression, LinkLookup> getLinkLookup)
    {
      string linkEntityAlias = null;
      var linkLookup = getLinkLookup(expression);
      if (linkLookup != null && linkLookup.Link != null)
        linkEntityAlias = linkLookup.Link.EntityAlias;
      return linkEntityAlias;
    }

    private void TranslateWhereCondition(
      BinaryExpression be,
      FilterExpressionWrapper parentFilter,
      Func<Expression, FilterExpressionWrapper> getFilter,
      Func<Expression, LinkLookup> getLinkLookup,
      bool negate)
    {
      var entityExpression = FindValidEntityExpression(be.Left);
      string alias = null;
      var attributeName = TranslateExpressionToAttributeName(entityExpression, false, out alias);
      var conditionValue = TranslateExpressionToConditionValue(be.Right);
      var linkEntityAlias = GetLinkEntityAlias(entityExpression, getLinkLookup);
      ConditionExpression condition = null;
      if (conditionValue != null)
        condition = new ConditionExpression(linkEntityAlias, attributeName, _conditionLookup[be.NodeType], conditionValue);
      else if (be.NodeType == ExpressionType.Equal)
        condition = new ConditionExpression(linkEntityAlias, attributeName, ConditionOperator.Null);
      else if (be.NodeType == ExpressionType.NotEqual)
        condition = new ConditionExpression(linkEntityAlias, attributeName, ConditionOperator.NotNull);
      else
        ThrowException(new NotSupportedException("Invalid 'where' condition."));
      condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
      AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
    }

    private void TranslateWhereMethodCall(
      MethodCallExpression mce,
      FilterExpressionWrapper parentFilter,
      Func<Expression, FilterExpressionWrapper> getFilter,
      Func<Expression, LinkLookup> getLinkLookup,
      BinaryExpression parent,
      bool negate)
    {
      string alias = null;
      if (_supportedMethods.Contains<string>(mce.Method.Name) && mce.Arguments.Count == 1)
      {
        var entityExpression = FindValidEntityExpression(mce.Object);
        var linkEntityAlias = GetLinkEntityAlias(entityExpression, getLinkLookup);
        var attributeName = TranslateExpressionToAttributeName(entityExpression, false, out alias);
        var conditionValue = TranslateExpressionToConditionValue(mce.Arguments[0]);
        if (parent != null)
        {
          if (parent.NodeType == ExpressionType.NotEqual)
            negate = !negate;
          if ((parent.NodeType == ExpressionType.Equal || parent.NodeType == ExpressionType.NotEqual) && Equals(TranslateExpressionToConditionValue(parent.Right), false))
            negate = !negate;
        }
        var condition = TranslateConditionMethodExpression(mce, attributeName, conditionValue);
        condition.EntityName = linkEntityAlias;
        condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
        AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
      }
      else if (mce.Method.Name == "Compare" && mce.Arguments.Count == 2)
      {
        var entityExpression = FindValidEntityExpression(mce.Arguments[0]);
        var linkEntityAlias = GetLinkEntityAlias(entityExpression, getLinkLookup);
        var attributeName = TranslateExpressionToAttributeName(entityExpression, false, out alias);
        var conditionValue = TranslateExpressionToConditionValue(mce.Arguments[1]);
        ConditionOperator conditionOperator;
        if (parent == null || !Equals(TranslateExpressionToConditionValue(parent.Right), 0) || !_conditionLookup.TryGetValue(parent.NodeType, out conditionOperator))
          return;
        var condition = new ConditionExpression(linkEntityAlias, attributeName, conditionOperator, conditionValue);
        condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
        AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
      }
      else if (mce.Method.Name == "Like" && mce.Arguments.Count == 2)
      {
        var entityExpression = FindValidEntityExpression(mce.Arguments[0]);
        var linkEntityAlias = GetLinkEntityAlias(entityExpression, getLinkLookup);
        var attributeName1 = TranslateExpressionToAttributeName(entityExpression, false, out alias);
        var conditionValue = TranslateExpressionToConditionValue(mce.Arguments[1]);
        var attributeName2 = attributeName1;
        var obj = conditionValue;
        var condition = new ConditionExpression(linkEntityAlias, attributeName2, ConditionOperator.Like, obj);
        condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
        AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
      }
      else
      {
        if (parent != null && !_booleanLookup.ContainsKey(parent.NodeType) || !(mce.Type.GetUnderlyingType() == typeof (bool)))
          return;
        var entityExpression = FindValidEntityExpression(mce);
        var condition = new ConditionExpression(GetLinkEntityAlias(entityExpression, getLinkLookup), TranslateExpressionToAttributeName(entityExpression, false, out alias), ConditionOperator.Equal, true);
        condition.Operator = negate ? NegateOperator(condition.Operator) : condition.Operator;
        AddCondition(GetFilter(entityExpression, parentFilter, getFilter), condition, alias);
      }
    }

    private ConditionExpression TranslateConditionMethodExpression(
      MethodCallExpression mce,
      string attributeName,
      object value)
    {
      ConditionExpression conditionExpression = null;
      switch (mce.Method.Name)
      {
        case "Equals":
          conditionExpression = value == null ? new ConditionExpression(attributeName, ConditionOperator.Null) : new ConditionExpression(attributeName, ConditionOperator.Equal, value);
          break;
        case "Contains":
          conditionExpression = new ConditionExpression(attributeName, ConditionOperator.Like, "%" + value?.ToString() + "%");
          break;
        case "StartsWith":
          conditionExpression = new ConditionExpression(attributeName, ConditionOperator.Like, value?.ToString() + "%");
          break;
        case "EndsWith":
          conditionExpression = new ConditionExpression(attributeName, ConditionOperator.Like, "%" + value?.ToString());
          break;
        default:
          ThrowException(new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "The method '{0}' is not supported.", mce.Method.Name)));
          break;
      }
      return conditionExpression;
    }

    /// <summary>Add condition to the filter.</summary>
    /// <param name="filter">Filter.</param>
    /// <param name="condition">Condition to add.</param>
    /// <param name="alias">Alias used to identity the condition.</param>
    private void AddCondition(
      FilterExpressionWrapper filter,
      ConditionExpression condition,
      string alias)
    {
      if (filter.Alias != alias)
        ThrowException(new NotSupportedException("filter conditions of different entity types, in the same expression, are not supported"));
      filter.Filter.AddCondition(condition);
    }

    private FilterExpressionWrapper GetFilter(
      Expression entityExpression,
      FilterExpressionWrapper parentFilter,
      Func<Expression, FilterExpressionWrapper> getFilter)
    {
      return parentFilter != null ? parentFilter : getFilter(entityExpression);
    }

    /// <summary>
    /// Returns a delegate which is used to map where clause expression to a link entity
    /// </summary>
    /// <param name="parameterName">Link entity name prefix from join clause</param>
    /// <param name="linkLookups">Collection of link entities to search in</param>
    /// <returns>A reference to link entity if it is found, null otherwise</returns>
    protected virtual Func<Expression, LinkLookup> GetLinkLookup(
      string parameterName,
      List<LinkLookup> linkLookups)
    {
      return exp =>
      {
        var expName = GetUnderlyingParameterExpressionName(exp);
        return linkLookups.SingleOrDefault<LinkLookup>(link =>
        {
          var str = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", parameterName, link.Environment);
          if (expName == str)
            return true;
          return expName.StartsWith(str) && expName[str.Length] == '.';
        });
      };
    }

    protected virtual Func<Expression, FilterExpressionWrapper> GetFilter(
      string parameterName,
      QueryExpression qe,
      List<LinkLookup> linkLookups)
    {
      return exp => new FilterExpressionWrapper(qe.Criteria, null);
    }

    protected virtual void TranslateOrderBy(
      QueryExpression qe,
      Expression exp,
      OrderType orderType,
      string parameterName,
      List<LinkLookup> linkLookups)
    {
      if (IsEntityExpression(exp))
      {
        ValidateRootEntity("orderBy", exp, parameterName, linkLookups);
        string alias = null;
        var attributeName = TranslateExpressionToAttributeName(exp, false, out alias);
        qe.AddOrder(attributeName, orderType);
      }
      else
        TranslateNonEntityExpressionOrderBy(qe, exp, orderType);
    }

    protected virtual void TranslateNonEntityExpressionOrderBy(
      QueryExpression qe,
      Expression exp,
      OrderType orderType)
    {
      ThrowException(new NotSupportedException("The 'orderBy' call must specify property names."));
    }

    private void ValidateRootEntity(
      string operationName,
      Expression exp,
      string parameterName,
      List<LinkLookup> linkLookups)
    {
      if (linkLookups == null)
        return;
      var parameterExpressionName = GetUnderlyingParameterExpressionName(exp);
      var linkLookup = linkLookups.SingleOrDefault<LinkLookup>(l => l.Link == null);
      if (linkLookup == null || !(string.Format(CultureInfo.InvariantCulture, "{0}.{1}", parameterName, linkLookup.Environment) != parameterExpressionName))
        return;
      ThrowException(new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "The '{0}' expression is limited to invoking the '{1}' parameter.", operationName, linkLookup.ParameterName)));
    }

    private Expression TranslateSelect(
      IList<MethodCallExpression> methods,
      int i,
      QueryExpression qe,
      LambdaExpression exp,
      ref NavigationSource source)
    {
      var subExpression = TranslateSelect(exp, qe, ref source);
      return subExpression == null ? null : MergeSubExpression(subExpression, methods, i);
    }

    private Expression TranslateSelect(
      LambdaExpression exp,
      QueryExpression qe,
      ref NavigationSource source)
    {
      if (qe.Criteria.Conditions.Count != 1 || qe.Criteria.Conditions[0].Values.Count != 1 || !(qe.Criteria.Conditions[0].Values[0] is Guid))
        return null;
      var condition = qe.Criteria.Conditions[0];
      var target = new EntityReference(qe.EntityName, (Guid) condition.Values[0]);
      Relationship relationship;
      var relationshipQuery = GetSelectRelationshipQuery(qe, exp, true, out relationship);
      if (relationshipQuery != null)
      {
        source = new NavigationSource(target, relationship);
        return relationshipQuery.Expression;
      }
      source = null;
      return null;
    }

    private void TranslateSelect(
      QueryExpression qe,
      LambdaExpression exp,
      IEnumerable<LinkLookup> linkLookups)
    {
      var parameterName = exp.Parameters[0].Name;
      foreach (var column in TraverseSelect(exp.Body))
      {
        if (linkLookups != null)
        {
          var expName = column.ParameterName;
          var linkLookup1 = linkLookups.SingleOrDefault<LinkLookup>(l => string.Format(CultureInfo.InvariantCulture, "{0}.{1}", parameterName, l.Environment) == expName);
          if (linkLookup1 != null && linkLookup1.Link != null)
          {
            TranslateSelect(column, linkLookup1.Link.Columns);
            continue;
          }
          if (linkLookup1 == null && exp.Parameters.Count > 1)
          {
            var name = exp.Parameters[1].Name;
            var linkLookup2 = column.ParameterName == name ? linkLookups.Last<LinkLookup>() : (!(column.ParameterName == parameterName) || linkLookups.Count<LinkLookup>() != 2 ? null : linkLookups.First<LinkLookup>());
            if (linkLookup2 != null && linkLookup2.Link != null)
            {
              TranslateSelect(column, linkLookup2.Link.Columns);
              continue;
            }
          }
        }
        TranslateSelect(column, qe.ColumnSet);
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private void TranslateSelect(EntityColumn column, ColumnSet columnSet)
    {
      if (column.AllColumns)
      {
        columnSet.AllColumns = true;
      }
      else
      {
        if (columnSet.AllColumns || columnSet.Columns.Contains(column.Column))
          return;
        columnSet.AddColumn(column.Column);
      }
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<EntityColumn> TraverseSelect(Expression exp)
    {
      var entityColumn1 = TranslateSelectColumn(exp);
      if (entityColumn1 != null)
      {
        if (entityColumn1.AllColumns || entityColumn1.Column != null)
          yield return entityColumn1;
      }
      else
      {
        foreach (var child in exp.GetChildren())
        {
          foreach (var entityColumn2 in TraverseSelect(child))
            yield return entityColumn2;
        }
      }
    }

    private EntityColumn TranslateSelectColumn(Expression exp)
    {
      var memberExpression = exp as MemberExpression;
      var methodCallExpression = exp as MethodCallExpression;
      var pe = exp as ParameterExpression;
      if (memberExpression != null && memberExpression.Expression != null && IsEntity(memberExpression.Expression.Type) || methodCallExpression != null && methodCallExpression.Object != null && IsEntity(methodCallExpression.Object.Type))
      {
        if (memberExpression != null && memberExpression.Member.DeclaringType == typeof (Entity))
          return new EntityColumn();
        string alias = null;
        var attributeName = TranslateExpressionToAttributeName(exp, true, out alias);
        if (!string.IsNullOrEmpty(attributeName))
          return new EntityColumn(GetUnderlyingParameterExpressionName(exp), attributeName);
      }
      else
      {
        if (memberExpression != null && IsEntity(memberExpression.Type) || methodCallExpression != null && IsEntity(methodCallExpression.Type))
          return new EntityColumn(exp.ToString(), true);
        if (memberExpression != null && IsEnumerableEntity(memberExpression.Type) || methodCallExpression != null && IsEnumerableEntity(methodCallExpression.Type))
          ThrowException(new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "The expression '{0}' is an invalid column projection expression. Entity collections cannot be selected.", exp)));
      }
      return TranslateSelectColumn(pe);
    }

    protected virtual EntityColumn TranslateSelectColumn(ParameterExpression pe)
    {
      if (pe != null && IsEntity(pe.Type))
        return new EntityColumn(pe.ToString(), true);
      if (pe != null && IsEnumerableEntity(pe.Type))
        ThrowException(new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "The expression '{0}' is an invalid column projection expression. Entity collections cannot be selected.", pe)));
      return null;
    }

    private Expression TranslateSelectMany(
      IList<MethodCallExpression> methods,
      int i,
      QueryExpression qe,
      LambdaExpression exp,
      ref NavigationSource source)
    {
      var subExpression = TranslateSelectMany(qe, exp, ref source);
      return subExpression == null ? null : MergeSubExpression(subExpression, methods, i);
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private Expression MergeSubExpression(
      Expression subExpression,
      IList<MethodCallExpression> methods,
      int i)
    {
      for (var index = i + 1; index < methods.Count; ++index)
      {
        var method = methods[index];
        subExpression = Expression.Call(null, method.Method, new Expression[1]
        {
          subExpression
        }.Concat<Expression>(method.Arguments.Skip<Expression>(1)));
      }
      return subExpression;
    }

    private Expression TranslateSelectMany(
      QueryExpression qe,
      LambdaExpression exp,
      ref NavigationSource source)
    {
      if (qe.Criteria.Conditions.Count != 1 || qe.Criteria.Conditions[0].Values.Count != 1 || !(qe.Criteria.Conditions[0].Values[0] is Guid))
        ThrowException(new InvalidOperationException("A 'SelectMany' operation must be preceeded by a 'Where' operation that filters by an entity ID."));
      var condition = qe.Criteria.Conditions[0];
      var target = new EntityReference(qe.EntityName, (Guid) condition.Values[0]);
      Relationship relationship = null;
      var relationshipQuery = GetSelectRelationshipQuery(qe, exp, false, out relationship);
      if (relationshipQuery != null)
      {
        source = new NavigationSource(target, relationship);
        return relationshipQuery.Expression;
      }
      source = null;
      return null;
    }

    protected virtual IQueryable GetSelectRelationshipQuery(
      QueryExpression qe,
      LambdaExpression exp,
      bool isSelect,
      out Relationship relationship)
    {
      if (!(FindEntityExpression(exp.Body) is MemberExpression entityExpression))
      {
        relationship = null;
        return null;
      }
      var defaultCustomAttribute = entityExpression.Member.GetFirstOrDefaultCustomAttribute<RelationshipSchemaNameAttribute>();
      if (defaultCustomAttribute == null)
      {
        if (isSelect)
        {
          relationship = null;
          return null;
        }
        ThrowException(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The relationship property '{0}' is invalid.", entityExpression.Member.Name)));
      }
      relationship = defaultCustomAttribute.Relationship;
      return CreateQuery(isSelect ? entityExpression.Type : entityExpression.Type.GetGenericArguments()[0]);
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private Expression GetMethodCallBody(MethodCallExpression mce, out string parameterName)
    {
      if (mce.Arguments.Count <= 1)
      {
        parameterName = null;
        return null;
      }
      var operand = (mce.Arguments[1] as UnaryExpression).Operand as LambdaExpression;
      parameterName = operand.Parameters[0].Name;
      return operand.Body;
    }

    protected virtual string TranslateExpressionToAttributeName(
      Expression exp,
      bool isSelectExpression,
      out string alias)
    {
      alias = null;
      switch (exp)
      {
        case MethodCallExpression methodCallExpression:
          return TranslateExpressionToValue(methodCallExpression.Method.IsStatic ? methodCallExpression.Arguments.Skip<Expression>(1).First<Expression>() : methodCallExpression.Arguments.First<Expression>()) as string;
        case MemberExpression memberExpression:
          if (memberExpression.Member != null)
          {
            var expression1 = memberExpression.Expression as MemberExpression;
            var expression2 = memberExpression.Expression as ParameterExpression;
            if (expression1 != null)
            {
              var defaultCustomAttribute = expression1.Member.GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>();
              if (defaultCustomAttribute != null)
                return defaultCustomAttribute.LogicalName;
            }
            else if (expression2 != null && memberExpression.Member.Name == "Id" && IsStaticEntity(expression2.Type))
            {
              var defaultCustomAttribute = expression2.Type.GetProperty("Id").GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>();
              if (defaultCustomAttribute != null)
                return defaultCustomAttribute.LogicalName;
            }
            return memberExpression.Member.GetLogicalName();
          }
          break;
      }
      ThrowException(new InvalidOperationException("Cannot determine the attribute name."));
      return null;
    }

    protected virtual bool IsEnumerableEntity(Type type)
    {
      if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof (IEnumerable<>))
        return false;
      var genericArguments = type.GetGenericArguments();
      return genericArguments.Length == 1 && IsEntity(genericArguments[0]);
    }

    private static bool IsAnonymousType(Type type) => type.GetCustomAttributes(typeof (CompilerGeneratedAttribute), false).Any<object>() & type.FullName.Contains("AnonymousType");

    protected virtual bool IsEntity(Type type) => IsDynamicEntity(type) || IsStaticEntity(type);

    protected virtual bool IsDynamicEntity(Type type) => type.IsA<Entity>();

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    private bool IsStaticEntity(Type type) => type.GetLogicalName() != null;

    protected virtual Expression FindValidEntityExpression(Expression exp, string operation = "where")
    {
      if (exp is UnaryExpression unaryExpression && (unaryExpression.NodeType == ExpressionType.Convert || unaryExpression.NodeType == ExpressionType.TypeAs))
        return FindValidEntityExpression(unaryExpression.Operand, operation);
      if (exp is NewExpression newExpression && newExpression.Type == typeof (EntityReference) && newExpression.Arguments.Count >= 2)
        return FindValidEntityExpression(newExpression.Arguments[1], operation);
      if (IsEntityExpression(exp))
        return exp;
      switch (exp)
      {
        case MemberExpression memberExpression when _validProperties.Contains<string>(memberExpression.Member.Name):
          return FindValidEntityExpression(memberExpression.Expression, operation);
        case MethodCallExpression methodCallExpression when _validMethods.Contains<string>(methodCallExpression.Method.Name):
          return FindValidEntityExpression(methodCallExpression.Object, operation);
        default:
          ThrowException(new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "Invalid '{0}' condition. An entity member is invoking an invalid property or method.", operation)));
          return null;
      }
    }

    protected Expression FindEntityExpression(Expression exp) => exp.FindPreorder(new Predicate<Expression>(IsEntityExpression));

    protected virtual bool IsEntityExpression(Expression e)
    {
      var me = e as MemberExpression;
      if (e is MethodCallExpression methodCallExpression)
      {
        if (methodCallExpression.Object != null)
          return IsDynamicEntity(methodCallExpression.Object.Type);
        if (methodCallExpression.Method.IsStatic)
          return IsDynamicEntity(methodCallExpression.Arguments[0].Type);
      }
      else if (me != null)
        return IsEntityMemberExpression(me);
      return false;
    }

    protected virtual bool IsEntityMemberExpression(MemberExpression me) => me.Member != null && IsEntity(me.Member.DeclaringType);

    private MemberExpression GetUnderlyingMemberExpression(Expression exp)
    {
      var memberExpression = exp as MemberExpression;
      var methodCallExpression = exp as MethodCallExpression;
      if (memberExpression != null)
        return memberExpression.Expression as MemberExpression;
      if (methodCallExpression != null)
        return methodCallExpression.Object as MemberExpression;
      ThrowException(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The expression '{0}' must be a '{1}' or a '{2}'.", exp, typeof (MemberExpression), typeof (MethodCallExpression))));
      return null;
    }

    private string GetUnderlyingParameterExpressionName(Expression exp)
    {
      var memberExpression = exp as MemberExpression;
      var methodCallExpression = exp as MethodCallExpression;
      if (memberExpression != null)
        return memberExpression.Expression.ToString();
      if (methodCallExpression != null)
        return methodCallExpression.Object.ToString();
      ThrowException(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The expression '{0}' must be a '{1}' or a '{2}'.", exp, typeof (MemberExpression), typeof (MethodCallExpression))));
      return null;
    }

    private object TranslateExpressionToValue(
      Expression exp,
      params ParameterExpression[] parameters)
    {
      if (exp is ConstantExpression constantExpression)
        return constantExpression.Value;
      if (exp is MemberExpression memberExpression && memberExpression.Expression is ConstantExpression expression)
      {
        var target = expression.Value;
        var member1 = memberExpression.Member as FieldInfo;
        if (member1 != null)
          return GetFieldValue(member1, target);
        var member2 = memberExpression.Member as PropertyInfo;
        if (member2 != null)
          return GetPropertyValue(member2, target);
      }
      return exp is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Convert ? TranslateExpressionToValue(unaryExpression.Operand) : DynamicInvoke(CompileExpression(Expression.Lambda(exp, parameters)));
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    [SecuritySafeCritical]
    private object GetFieldValue(FieldInfo fieldInfo, object target)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
        return fieldInfo.GetValue(target);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
    [SecuritySafeCritical]
    private object GetPropertyValue(PropertyInfo propertyInfo, object target)
    {
      try
      {
        new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
        return propertyInfo.GetValue(target, null);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
    }

    private object TranslateExpressionToConditionValue(
      Expression exp,
      params ParameterExpression[] parameters)
    {
      var conditionValue = TranslateExpressionToValue(exp, parameters);
      var entityReference = conditionValue as EntityReference;
      var optionSetValue = conditionValue as OptionSetValue;
      var money = conditionValue as Money;
      if (entityReference != null)
        conditionValue = entityReference.Id;
      else if (money != null)
        conditionValue = money.Value;
      else if (optionSetValue != null)
        conditionValue = optionSetValue.Value;
      else if (conditionValue != null && conditionValue.GetType().IsEnum)
        conditionValue = (int) conditionValue;
      return conditionValue;
    }

    protected virtual void TranslateEntityName(
      QueryExpression qe,
      Expression expression,
      MethodCallExpression mce)
    {
      if (qe.EntityName != null)
        return;
      var constantExpression = expression is MethodCallExpression ? expression.GetMethodsPreorder().Last<MethodCallExpression>().Arguments[0] as ConstantExpression : expression as ConstantExpression;
      if (constantExpression == null || !(constantExpression.Value is IEntityQuery entityQuery))
        return;
      qe.EntityName = entityQuery.EntityLogicalName;
    }

    /// <summary>Overridable Throw mehtod</summary>
    /// <param name="exception">Exception to throw</param>
    protected virtual void ThrowException(Exception exception) => throw exception;

    protected sealed class NavigationSource
    {
      public EntityReference Target { get; private set; }

      public Relationship Relationship { get; private set; }

      public NavigationSource(EntityReference target, Relationship relationship)
      {
        Target = target;
        Relationship = relationship;
      }
    }

    /// <summary>
    /// Class to Track the filter expression that is being build and the alias used for it.
    /// In LINQ layer, alias is alwasy null.
    /// In ODATA layer, the alias is null for qe.Criteria filter and is set to the expanded property name for conditions on expanded property.
    /// </summary>
    protected sealed class FilterExpressionWrapper
    {
      public FilterExpression Filter { get; private set; }

      public string Alias { get; private set; }

      public FilterExpressionWrapper(FilterExpression filter, string alias)
      {
        Filter = filter != null ? filter : throw new ArgumentNullException(nameof (filter));
        Alias = alias;
      }
    }

    protected sealed class LinkLookup
    {
      public string ParameterName { get; private set; }

      public string Environment { get; private set; }

      public LinkEntity Link { get; private set; }

      public string SelectManyEnvironment { get; private set; }

      public LinkLookup(string parameterName, string environment, LinkEntity link)
        : this(parameterName, environment, link, null)
      {
      }

      public LinkLookup(
        string parameterName,
        string environment,
        LinkEntity link,
        string selectManyEnvironment)
      {
        ParameterName = parameterName;
        Environment = environment;
        Link = link;
        SelectManyEnvironment = selectManyEnvironment;
      }
    }

    protected sealed class Projection
    {
      public string MethodName { get; private set; }

      public LambdaExpression Expression { get; private set; }

      public Projection(string methodName, LambdaExpression expression)
      {
        MethodName = methodName;
        Expression = expression;
      }
    }

    protected sealed class EntityColumn
    {
      public string ParameterName { get; private set; }

      public string Column { get; private set; }

      public bool AllColumns { get; private set; }

      public EntityColumn()
      {
      }

      public EntityColumn(string parameterName, string column)
      {
        ParameterName = parameterName;
        Column = column;
      }

      public EntityColumn(string parameterName, bool allColumns)
      {
        ParameterName = parameterName;
        AllColumns = allColumns;
      }
    }
  }
}
