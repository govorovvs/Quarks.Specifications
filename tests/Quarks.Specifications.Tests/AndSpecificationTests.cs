using NUnit.Framework;

namespace Quarks.Specifications.Tests
{
	[TestFixture]
	public class AndSpecificationTests
	{
		[Test]
		public void Can_Be_Constructed_With_Left_And_Right_Ones()
		{
			var left = new TrueSpecification<object>();
			var right = new TrueSpecification<object>();

			var spec = new AndSpecification<object>(left, right);

			Assert.That(spec.LeftSideSpecification, Is.EqualTo(left));
			Assert.That(spec.RightSideSpecification, Is.EqualTo(right));
		}

		[TestCase(true, true, ExpectedResult = true)]
		[TestCase(false, false, ExpectedResult = false)]
		[TestCase(true, false, ExpectedResult = false)]
		[TestCase(false, true, ExpectedResult = false)]
		public bool IsSatisfied_Is_True_If_Both_Left_And_Right_Is_True(bool leftResult, bool rightResult)
		{
			var left = new DirectSpecification<object>(o => leftResult);
			var right = new DirectSpecification<object>(o => rightResult);

			var spec = new AndSpecification<object>(left, right);

			return spec.IsSatisfiedBy(new object());
		}

		[TestCase(true, true, true, ExpectedResult = true)]
		[TestCase(false, true, true, ExpectedResult = false)]
		[TestCase(false, false, false, ExpectedResult = false)]
		public bool Multiple_IsSatisfied_Is_True_If_All_Is_True(bool firstResult, bool secondResult, bool thirdResult)
		{
			var first = new DirectSpecification<object>(o => firstResult);
			var second = new DirectSpecification<object>(o => secondResult);
			var third = new DirectSpecification<object>(o => thirdResult);

			var spec = AndSpecification<object>.Multiple(first, second, third);

			return spec.IsSatisfiedBy(new object());
		}

		[Test]
		public void Multiple_IsSatisfied_Is_False_If_No_Specs()
		{
			var spec = AndSpecification<object>.Multiple();

			Assert.That(spec.IsSatisfiedBy(new object()), Is.False);
		}

		[Test]
		public void Multiple_IsSatisfied_Is_True_If_Single_Spec()
		{
			var single = new FalseSpecification<object>();

			var spec = AndSpecification<object>.Multiple(single);

			Assert.That(spec.IsSatisfiedBy(new object()), Is.True);
		}
	}
}