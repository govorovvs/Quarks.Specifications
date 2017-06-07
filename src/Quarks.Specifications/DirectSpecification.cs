using System;
using System.Linq.Expressions;

namespace Quarks.Specifications
{
    /// <summary>
	/// A Direct Specification is a simple implementation
	/// of specification that acquire this from a lambda expression
	/// in  constructor
	/// </summary>
	/// <typeparam name="TEntity">Type of entity that check this specification</typeparam>
	public sealed class DirectSpecification<TEntity> : Specification<TEntity>
		where TEntity : class
	{
        /// <summary>
        /// Initializes a new instance of <see cref="DirectSpecification{TEntity}" /> class.
        /// </summary>
        /// <param name="matchingCriteria">A Matching Criteria</param>
        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
		{
			if (matchingCriteria == null) throw new ArgumentNullException(nameof(matchingCriteria));

			Expression = matchingCriteria;
		}
    }
}