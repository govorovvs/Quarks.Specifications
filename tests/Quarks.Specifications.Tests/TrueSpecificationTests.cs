using NUnit.Framework;

namespace Quarks.Specifications.Tests
{
	[TestFixture]
	public class TrueSpecificationTests
	{
		[Test]
		public void ArgumentLess_Constructor()
		{
			var spec = new TrueSpecification<object>();

			Assert.That(spec, Is.Not.Null);
		}

		[Test]
		public void IsSatisfied_Always_True()
		{
			var spec = new TrueSpecification<object>();

			Assert.That(spec.IsSatisfiedBy(new object()), Is.True);
			Assert.That(spec.IsSatisfiedBy(null), Is.True);
		}
	}
}