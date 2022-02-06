using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTest
{
    public class ThreeSumTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource(nameof(TestDataCases))]
        public void Can_get_answer(int[] input, List<IList<int>> expect)
        {
            var result = ThreeSum.ThreeSum.GetAnswer(input);
            result.Should().BeEquivalentTo(expect, opt => opt.WithStrictOrdering());
        }

        public static IEnumerable TestDataCases
        {
            get
            {
                yield return new TestCaseData(null, new List<int[]>());

                yield return new TestCaseData(new int[] { }, new List<int[]>());

                yield return new TestCaseData(new int[] {0}, new List<int[]>());

                yield return new TestCaseData(new[] {-1, 0, 1, 2, -1, -4},
                    new List<IList<int>>
                    {
                        new[] {-1, -1, 2}, new[] {-1, 0, 1}
                    });
            }
        }
    }
}