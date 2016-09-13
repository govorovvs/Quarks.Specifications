using NUnit.Framework;
using System.Linq;

namespace Quarks.Specifications.Tests
{
	[TestFixture]
	public class SpecificationExtensionsTests
	{
		[Test]
		public void Where()
		{
			var spec = new DirectSpecification<string>(str => str.Length >= 2);

			var result = new[] { "aa", "a", "", "aaa" }.Where(spec).ToArray();

			Assert.That(result, Is.EquivalentTo(new[] { "aa", "aaa" }));
		}

		[Test]
		public void First()
		{
			var spec = new DirectSpecification<string>(str => str.Length > 2);

			var result = new[] { "aa", "a", "aaa", "aa" }.First(spec);

			Assert.That(result, Is.EqualTo("aaa"));
		}

		[Test]
		public void FirstOrDefault()
		{
			var spec = new DirectSpecification<string>(str => str.Length > 2);

			var result1 = new[] { "aa", "a", "aaa", "aa" }.FirstOrDefault(spec);
			var result2 = new[] { "aa" }.FirstOrDefault(spec);

			Assert.That(result1, Is.EqualTo("aaa"));
			Assert.That(result2, Is.Null);
		}

        [TestCase(true, true, ExpectedResult = true)]
        [TestCase(true, false, ExpectedResult = false)]
        [TestCase(false, true, ExpectedResult = false)]
        [TestCase(false, false, ExpectedResult = false)]
        public bool And(bool leftResult, bool rightResult)
        {
            var left = new DirectSpecification<object>(o => leftResult);
            var right = new DirectSpecification<object>(o => rightResult);

            var spec = left.And(right);

            return spec.IsSatisfiedBy(new object());
        }

        [TestCase(true, true, ExpectedResult = true)]
        [TestCase(true, false, ExpectedResult = true)]
        [TestCase(false, true, ExpectedResult = true)]
        [TestCase(false, false, ExpectedResult = false)]
        public bool Or(bool leftResult, bool rightResult)
        {
            var left = new DirectSpecification<object>(o => leftResult);
            var right = new DirectSpecification<object>(o => rightResult);

            var spec = left.Or(right);

            return spec.IsSatisfiedBy(new object());
        }

        [TestCase(true, ExpectedResult = false)]
        [TestCase(false, ExpectedResult = true)]
        public bool Not(bool originalResult)
        {
            var original = new DirectSpecification<object>(o => originalResult);

            var spec = original.Not();

            return spec.IsSatisfiedBy(new object());
        }
    }
}