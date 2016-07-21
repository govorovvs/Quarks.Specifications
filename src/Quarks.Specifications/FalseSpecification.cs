namespace Quarks.Specifications
{
	/// <summary>
	/// False specification
	/// </summary>
	/// <typeparam name="TEntity">Type of entity in this specification</typeparam>
	public sealed class FalseSpecification<TEntity> : Specification<TEntity>
		where TEntity : class
	{
		public FalseSpecification()
		{
			//Create "result variable" transform adhoc execution plan in prepared plan
			//for more info: http://geeks.ms/blogs/unai/2010/07/91/ef-4-0-performance-tips-1.aspx
			const bool result = false;

			Expression = t => result;
		}
	}
}