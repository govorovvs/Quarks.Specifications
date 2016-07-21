using NUnit.Framework;

namespace Quarks.Specifications.Tests
{
	[TestFixture]
	public class SpecificationOperatorsTests
	{
		[TestCase(true, true, ExpectedResult = true)]
		[TestCase(true, false, ExpectedResult = false)]
		[TestCase(false, true, ExpectedResult = false)]
		[TestCase(false, false, ExpectedResult = false)]
		public bool Operator_And(bool leftResult, bool rightResult)
		{
			var left = new DirectSpecification<object>(o => leftResult);
			var right = new DirectSpecification<object>(o => rightResult);

			var spec = left & right;

			return spec.IsSatisfiedBy(new object());
		}

		[TestCase(true, true, ExpectedResult = true)]
		[TestCase(true, false, ExpectedResult = true)]
		[TestCase(false, true, ExpectedResult = true)]
		[TestCase(false, false, ExpectedResult = false)]
		public bool Operator_Or(bool leftResult, bool rightResult)
		{
			var left = new DirectSpecification<object>(o => leftResult);
			var right = new DirectSpecification<object>(o => rightResult);

			var spec = left | right;

			return spec.IsSatisfiedBy(new object());
		}

		[TestCase(true, ExpectedResult = false)]
		[TestCase(false, ExpectedResult = true)]
		public bool Operator_Not(bool originalResult)
		{
			var original = new DirectSpecification<object>(o => originalResult);

			var spec = !original;

			return spec.IsSatisfiedBy(new object());
		}
	}
}