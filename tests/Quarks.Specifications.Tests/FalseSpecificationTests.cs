using NUnit.Framework;

namespace Quarks.Specifications.Tests
{
	[TestFixture]
	public class FalseSpecificationTests
	{
		[Test]
		public void ArgumentLess_Constructor()
		{
			var spec = new FalseSpecification<object>();

			Assert.That(spec, Is.Not.Null);
		}

		[Test]
		public void IsSatisfied_Always_False()
		{
			var spec = new FalseSpecification<object>();

			Assert.That(spec.IsSatisfiedBy(new object()), Is.False);
			Assert.That(spec.IsSatisfiedBy(null), Is.False);
		}
	}
}