namespace Quarks.Specifications
{
	/// <summary>
	/// True specification
	/// </summary>
	/// <typeparam name="TEntity">Type of entity in this specification</typeparam>
	public sealed class TrueSpecification<TEntity> : Specification<TEntity>
		where TEntity : class
	{
        /// <summary>
        /// Initializes a new instance of <see cref="TrueSpecification{TEntity}"/> class.
        /// </summary>
		public TrueSpecification()
		{
			//Create "result variable" transform adhoc execution plan in prepared plan
			//for more info: http://geeks.ms/blogs/unai/2010/07/91/ef-4-0-performance-tips-1.aspx
			const bool result = true;

			Expression = (t => result);
		}
	}
}