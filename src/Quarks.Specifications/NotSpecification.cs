using System;
using System.Linq;
using System.Linq.Expressions;

namespace Quarks.Specifications
{
	/// <summary>
	/// NotSpecification convert a original specification with NOT logic operator
	/// </summary>
	/// <typeparam name="TEntity">Type of element for this specificaiton</typeparam>
	public sealed class NotSpecification<TEntity> : Specification<TEntity>
		where TEntity : class
	{
		private Specification<TEntity> _originalSpecification;

        /// <summary>
        /// Initializes a new instance of <see cref="NotSpecification{TEntity}"/> class.
        /// </summary>
        /// <param name="originalSpecification">Original specification</param>
        public NotSpecification(Specification<TEntity> originalSpecification)
		{
			OriginalSpecification = originalSpecification;
		}

        /// <summary>
        /// Initializes a new instance of <see cref="NotSpecification{TEntity}"/> class.
        /// </summary>
        /// <param name="originalSpecification">Original specificaiton</param>
        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
		{
			OriginalSpecification = new DirectSpecification<TEntity>(originalSpecification);
		}

		internal Specification<TEntity> OriginalSpecification
		{
			get { return _originalSpecification; }
			private set
			{
				if (value?.Expression == null) throw new ArgumentNullException(nameof(OriginalSpecification));

				_originalSpecification = value;

				Expression<Func<TEntity, bool>> originalCriteria = value.Expression;

				Expression =
					System.Linq.Expressions.Expression.Lambda<Func<TEntity, bool>>(
						System.Linq.Expressions.Expression.Not(originalCriteria.Body), originalCriteria.Parameters.Single());
			}
		}
	}
}