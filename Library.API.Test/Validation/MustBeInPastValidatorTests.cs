using Library.API.Validation;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Library.API.Test.Validation
{
    public class MustBeInPastValidatorTests
    {
        public static IEnumerable<Object[]> TestDates()
        {
            yield return new object[] { DateTime.Today.AddDays(-1), null };
            yield return new object[] { DateTime.Today, "Published date must be in the past" };
            yield return new object[] { DateTime.Today.AddDays(1), "Published date must be in the past" };
        }

        [Theory]
        [MemberData(nameof(TestDates))]
        public void MustBeInPastValidator_When_ReturnsCorrectValidationResult(DateTime date, string expectedResult)
        {
            var sut = new MustBeInPast();
            var context = new ValidationContext(date);
            var result = sut.GetValidationResult(date, context);
            Assert.Equal(expectedResult, result?.ErrorMessage);
        }
    }
}
