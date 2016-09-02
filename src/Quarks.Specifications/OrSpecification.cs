using System.Linq;

namespace Quarks.Specifications
{
	/// <summary>
	/// A Logic OR Specification
	/// </summary>
	/// <typeparam name="T">Type of entity that check this specification</typeparam>
	public sealed class OrSpecification<T> : CompositeSpecification<T>
		where T : class
	{
        /// <summary>
        /// Initializes a new instance of <see cref="OrSpecification{T}"/> class.
        /// </summary>
        /// <param name="leftSide">Left side specification</param>
        /// <param name="rightSide">Right side specification</param>
        public OrSpecification(Specification<T> leftSide, Specification<T> rightSide)
			: base(leftSide, rightSide)
		{
			Expression = leftSide.Expression.OrElse(rightSide.Expression);
		}

        /// <summary>
        /// Creates a <see cref="OrSpecification{T}"/> that is a composition of other ones.
        /// </summary>
        /// <param name="specifications">A collection of composed specifications.</param>
        /// <returns>The <see cref="OrSpecification{T}"/> that is a composition of other ones.</returns>
        public static Specification<T> Multiple(params Specification<T>[] specifications)
        {
            if (specifications.Length == 0)
                return new FalseSpecification<T>();
            if (specifications.Length == 1)
                return new TrueSpecification<T>();

            Specification<T> result = specifications[0];

            return specifications.Skip(1)
                .Aggregate(result,
                    (current, spec) => new OrSpecification<T>(current, spec));
        }
    }
}