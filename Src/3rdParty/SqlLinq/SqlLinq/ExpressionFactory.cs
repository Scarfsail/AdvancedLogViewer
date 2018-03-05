using System;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;
using System.Dynamic;

using SqlLinq.SyntaxTree.Aggregates;

namespace SqlLinq
{
    static class ExpressionFactory
    {
        public static Expression<Func<TSource, TResult>> CreateIdentitySelector<TSource, TResult>()
        {
            Debug.Assert(typeof(TSource) == typeof(TResult));

            ParameterExpression arg = Expression.Parameter(typeof(TSource), "arg");

            return Expression.Lambda<Func<TSource, TResult>>(arg, arg);
        }

        public static LambdaExpression CreateIdentityExpression(Type tSource)
        {
            ParameterExpression arg = Expression.Parameter(tSource, "arg");

            return Expression.Lambda(arg, arg);
        }

        public static Expression<Func<TSource, TResult>> CreateExpandoSelector<TSource, TResult>(IEnumerable<string> sourceFields, IEnumerable<string> resultFields)
        {
            ParameterExpression arg = Expression.Parameter(typeof(TSource), "arg");

            // loop through all of the result fields and generate an expression that will 
            // add a new property to the result expando object using its IDictionary interface
            var bindings = new List<ElementInit>();
            MethodInfo addMethod = typeof(IDictionary<string, object>).GetMethod("Add", new Type[] { typeof(string), typeof(object) });
            int i = 0;
            foreach (string field in resultFields)
            {
                MemberExpression memberExpression = Expression.PropertyOrField(arg, sourceFields.ElementAt(i++));
                bindings.Add(Expression.ElementInit(addMethod, Expression.Constant(field), Expression.Convert(memberExpression, typeof(object))));
            }

            var expando = Expression.New(typeof(ExpandoObject));
            return Expression.Lambda<Func<TSource, TResult>>(Expression.ListInit(expando, bindings), arg);
        }

        public static Expression<Func<TSource, TResult>> CreateMemberInitSelector<TSource, TResult>(IEnumerable<string> sourceFields, IEnumerable<string> resultFields)
        {
            ParameterExpression arg = Expression.Parameter(typeof(TSource), "arg");

            // loop through all of the result fields and generate an expression that will assign it from the source fields of the param
            var bindings = new List<MemberAssignment>();
            int i = 0;
            foreach (string field in resultFields)
            {
                MemberInfo member = typeof(TResult).GetPropertyOrField(field);
                MemberExpression memberExpression = Expression.PropertyOrField(arg, sourceFields.ElementAt(i++));
                bindings.Add(Expression.Bind(member, memberExpression));
            }

            var init = Expression.MemberInit(Expression.New(typeof(TResult)), bindings);
            return Expression.Lambda<Func<TSource, TResult>>(init, arg);
        }

        public static Expression<Func<TSource, TResult>> CreateConstructorCallSelector<TSource, TResult>(IEnumerable<string> fields, Type[] constructorTypes)
        {
            ParameterExpression arg = Expression.Parameter(typeof(TSource), "arg");

            var bindings = fields.Select(field => Expression.PropertyOrField(arg, field));   // the values that will intialize a TResult

            ConstructorInfo constructor = typeof(TResult).GetConstructor(constructorTypes);  // the constructor for a new TResult

            NewExpression _new = Expression.New(constructor, bindings);
            return Expression.Lambda<Func<TSource, TResult>>(_new, arg);
        }

        public static Expression<Func<TSource, TResult>> CreateSinglePropertySelector<TSource, TResult>(string propertyName)
        {
            Debug.Assert(string.IsNullOrEmpty(propertyName) == false);

            ParameterExpression param = Expression.Parameter(typeof(TSource), "item");

            return Expression.Lambda<Func<TSource, TResult>>(Expression.PropertyOrField(param, propertyName), param);
        }

        public static LambdaExpression CreatePropertyOrFieldLambdaExpression(Type itemType, string propertyName)
        {
            Debug.Assert(string.IsNullOrEmpty(propertyName) == false);

            ParameterExpression param = Expression.Parameter(itemType, "item");

            return Expression.Lambda(Expression.PropertyOrField(param, propertyName), param);
        }

        public static UnaryExpression CreateReadPropertyExpression(ParameterExpression param, string propertyName, Type propertyType)
        {
            Debug.Assert(param != null);
            Debug.Assert(string.IsNullOrEmpty(propertyName) == false);
            Debug.Assert(propertyType != null);

            return Expression.Convert(Expression.PropertyOrField(param, propertyName), propertyType);
        }

        public static Expression<Func<IEnumerable<TSource>, IEnumerable<TResult>>> CreateGroupBySelector<TSource, TResult>(string groupByField, Type keyType, IEnumerable<AggregateNode> aggregates)
        {
            // create the key selector
            var keyLambdaArg = Expression.Parameter(typeof(TSource), "keyLambdaArg");       // the parameter passsed to the keySelector
            var keyLambda = Expression.Lambda(Expression.PropertyOrField(keyLambdaArg, groupByField), keyLambdaArg);

            // the grouped subset passed to resultSelector
            var group = Expression.Parameter(typeof(IEnumerable<TSource>), "group");
            
            // create an object to cache some state for the result selector
            GroupByCall<TSource, TResult> groupingCall = new GroupByCall<TSource, TResult>(groupByField);
            // for each aggregate in the query create a lambda expression and add it to the cache
            foreach (AggregateNode aggregate in aggregates)
            {
                var aggregateExpression = aggregate.GetCallExpression(typeof(IEnumerable<TSource>), typeof(TSource), group);
                groupingCall.Aggregates.Add(aggregate.Alias, Expression.Lambda(aggregateExpression, group).Compile());
            }

            // create the call to the result selector
            var key = Expression.Parameter(keyType, "key");
            var groupingFunc = Expression.Call(Expression.Constant(groupingCall), "GroupingFunc", new Type[] { keyType }, key, group);
            var resultSelectorLambda = Expression.Lambda(groupingFunc, key, group);

            // package all of that up in a call to Enumerable.GroupBy
            var data = Expression.Parameter(typeof(IEnumerable<TSource>), "data");   // the input data
            var groupByExpression = Expression.Call(typeof(Enumerable), "GroupBy", new Type[] { typeof(TSource), keyType, typeof(TResult) }, data, keyLambda, resultSelectorLambda);

            // create the labmda and compile
            return Expression.Lambda<Func<IEnumerable<TSource>, IEnumerable<TResult>>>(groupByExpression, data);
        }
    }
}
