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
	}
}