using System;
using System.Linq.Expressions;

namespace Quarks.Specifications
{
    /// <summary>
    /// Represent a Expression Specification
    /// <remarks>
    /// Specification overload operators for create AND, OR or NOT specifications.
    /// Additionally overload AND and OR operators with the same sense of ( binary And and binary Or ).
    /// C# couldn’t overload the AND and OR operators directly since the framework doesn’t allow such craziness. But
    /// with overloading false and true operators this is posible. For explain this behavior please read
    /// http://msdn.microsoft.com/en-us/library/aa691312(VS.71).aspx
    /// </remarks>
    /// </summary>
    /// <typeparam name="TEntity">Type of item in the criteria</typeparam>
    public abstract class Specification<TEntity>
         where TEntity : class
	{
		private Expression<Func<TEntity, bool>> _expression;

		public bool IsSatisfiedBy(TEntity entity)
		{
			return Predicate == null || Predicate(entity);
		}

		public Func<TEntity, bool> Predicate { get; protected set; }

		public Expression<Func<TEntity, bool>> Expression
		{
			get { return _expression; }
			protected set
			{
				_expression = value;
				Predicate = _expression?.Compile();
			}
		}

		/// <summary>
		///  And operator
		/// </summary>
		/// <param name="leftSideSpecification">left operand in this AND operation</param>
		/// <param name="rightSideSpecification">right operand in this AND operation</param>
		/// <returns>New specification</returns>
		public static Specification<TEntity> operator &(Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
		{
			return new AndSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
		}

		/// <summary>
		/// Or operator
		/// </summary>
		/// <param name="leftSideSpecification">left operand in this OR operation</param>
		/// <param name="rightSideSpecification">left operand in this OR operation</param>
		/// <returns>New specification </returns>
		public static Specification<TEntity> operator |(Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
		{
			return new OrSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
		}

		/// <summary>
		/// Not specification
		/// </summary>
		/// <param name="specification">Specification to negate</param>
		/// <returns>New specification</returns>
		public static Specification<TEntity> operator !(Specification<TEntity> specification)
		{
			return new NotSpecification<TEntity>(specification);
		}
	}
}