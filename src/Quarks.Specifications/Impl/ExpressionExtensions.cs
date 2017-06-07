using System;
using System.Linq;
using System.Linq.Expressions;

namespace Quarks.Specifications.Impl
{
    internal static class ExpressionExtensions
	{
		public static Expression<Func<T, bool>> AndAlso<T>(
			this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
            return first.Compose(second, Expression.And);
        }

		public static Expression<Func<T, bool>> OrElse<T>(
            this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        private static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }
    }
}