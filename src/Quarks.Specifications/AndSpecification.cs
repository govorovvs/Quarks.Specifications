using System.Linq;

namespace Quarks.Specifications
{
	/// <summary>
	/// A logic AND Specification
	/// </summary>
	/// <typeparam name="T">Type of entity that check this specification</typeparam>
	public sealed class AndSpecification<T> : CompositeSpecification<T>
	   where T : class
	{
		/// <summary>
		/// Default constructor for AndSpecification
		/// </summary>
		/// <param name="leftSide">Left side specification</param>
		/// <param name="rightSide">Right side specification</param>
		public AndSpecification(Specification<T> leftSide, Specification<T> rightSide)
			: base(leftSide, rightSide)
		{
			Expression = leftSide.Expression.AndAlso(rightSide.Expression);
		}

		public static Specification<T> Multiple(params Specification<T>[] specifications)
		{
			if (specifications.Length == 0)
				return new FalseSpecification<T>();
			if (specifications.Length == 1)
				return new TrueSpecification<T>();

			Specification<T> result = specifications[0];

			return specifications.Skip(1)
				.Aggregate(result,
					(current, spec) => new AndSpecification<T>(current, spec));
		}
	}
}