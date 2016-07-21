using System.Collections.Generic;
using System.Linq;

namespace Quarks.Specifications
{
	public static class SpecificationExtensions
	{
		public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Specification<T> spec)
			where T : class
		{
			return collection.Where(spec.Predicate);
		}

		public static T First<T>(this IEnumerable<T> collection, Specification<T> spec)
			where T : class
		{
			return collection.First(spec.Predicate);
		}

		public static T FirstOrDefault<T>(this IEnumerable<T> collection, Specification<T> spec)
			where T : class
		{
			return collection.FirstOrDefault(spec.Predicate);
		}
	}
}