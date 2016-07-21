using NUnit.Framework;

namespace Quarks.Specifications.Tests
{
	[TestFixture]
	public class NotSpecificationTests
	{
		[Test]
		public void Can_Be_Constructed_With_Specification()
		{
			var originalSpec = new TrueSpecification<object>();

			var spec = new NotSpecification<object>(originalSpec);

			Assert.That(spec.OriginalSpecification, Is.EqualTo(originalSpec));
		}

		[TestCase(true, ExpectedResult = false)]
		public bool IsSatisfied_Reverses_Original_One(bool origResult)
		{
			var originalSpec = new DirectSpecification<object>(obj => origResult);

			var spec = new NotSpecification<object>(originalSpec);

			return spec.IsSatisfiedBy(new object());
		}

		[Test]
		public void Can_Be_Constructed_With_Expression()
		{
			var spec = new NotSpecification<object>(obj => true);

			Assert.That(spec.IsSatisfiedBy(new object()), Is.False);
		}
	}
}