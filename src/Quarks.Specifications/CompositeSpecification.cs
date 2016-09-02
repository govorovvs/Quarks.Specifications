using System;

namespace Quarks.Specifications
{
	/// <summary>
	/// Base class for composite specifications
	/// </summary>
	/// <typeparam name="TEntity">Type of entity that check this specification</typeparam>
	public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
		 where TEntity : class
	{
        /// <summary>
        /// Initializes a new instance of <see cref="CompositeSpecification{TEntity}" /> class.
        /// </summary>
        /// <param name="leftSide">Left side specification</param>
		/// <param name="rightSide">Right side specification</param>
		protected CompositeSpecification(Specification<TEntity> leftSide, Specification<TEntity> rightSide)
		{
			if (leftSide == null) throw new ArgumentNullException(nameof(leftSide));
			if (rightSide == null) throw new ArgumentNullException(nameof(rightSide));

			LeftSideSpecification = leftSide;
			RightSideSpecification = rightSide;
		}

		/// <summary>
		/// Left side specification for this composite element
		/// </summary>
		public Specification<TEntity> LeftSideSpecification { get; private set; }

		/// <summary>
		/// Right side specification for this composite element
		/// </summary>
		public Specification<TEntity> RightSideSpecification { get; private set; }
	}
}