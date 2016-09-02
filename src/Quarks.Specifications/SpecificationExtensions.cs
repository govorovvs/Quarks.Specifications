using System;
using System.Collections.Generic;
using System.Linq;

namespace Quarks.Specifications
{
    /// <summary>
    /// Linq extensions for specifications.
    /// </summary>
	public static class SpecificationExtensions
	{
        /// <summary>Filters a sequence of values based on a specification.</summary>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains elements from the input sequence that satisfy the condition.</returns>
        /// <param name="source">An <see cref="IEnumerable{TSource}" /> to filter.</param>
        /// <param name="specification">A specification to test each element for a condition.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="specification" /> is null.</exception>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Specification<TSource> specification)
			where TSource : class
		{
			return source.Where(specification.Predicate);
		}

        /// <summary>Returns the first element in a sequence that satisfies a specified specification.</summary>
        /// <returns>The first element in the sequence that passes the test in the specified specification.</returns>
        /// <param name="source">An <see cref="IEnumerable{TSource}" /> to return an element from.</param>
        /// <param name="specification">A specification to test each element for a condition.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="specification" /> is null.</exception>
        /// <exception cref="InvalidOperationException">No element satisfies the condition in <paramref name="specification" />.-or-The source sequence is empty.</exception>
        public static TSource First<TSource>(this IEnumerable<TSource> source, Specification<TSource> specification)
			where TSource : class
		{
			return source.First(specification.Predicate);
		}

        /// <summary>Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.</summary>
        /// <returns>default(<typeparamref name="TSource" />) if <paramref name="source" /> is empty or if no element passes the test specified by <paramref name="specification" />; otherwise, the first element in <paramref name="source" /> that passes the test specified by <paramref name="specification" />.</returns>
        /// <param name="source">An <see cref="IEnumerable{TSource}" /> to return an element from.</param>
        /// <param name="specification">A specification to test each element for a condition.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source" /> or <paramref name="specification" /> is null.</exception>
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Specification<TSource> specification)
			where TSource : class
		{
			return source.FirstOrDefault(specification.Predicate);
		}
	}
}