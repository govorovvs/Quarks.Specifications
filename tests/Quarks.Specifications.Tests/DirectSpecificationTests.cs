using System;
using NUnit.Framework;

namespace Quarks.Specifications.Tests
{
	[TestFixture]
	public class DirectSpecificationTests
	{
		[Test]
		public void Can_Be_Constructed_With_Expression()
		{
			var spec = new DirectSpecification<object>(obj => true);

			Assert.That(spec.Predicate.ToString(), Is.EqualTo(new Func<object, bool>(o => true).ToString()));
		}

		[Test]
		public void IsSatisfied_Calls_To_Expression()
		{
			var spec = new DirectSpecification<object>(obj => true);

			Assert.That(spec.IsSatisfiedBy(new object()), Is.True);
		}
	}
}