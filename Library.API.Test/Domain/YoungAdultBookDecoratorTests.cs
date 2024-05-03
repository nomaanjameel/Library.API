using Library.API.Domain;
using Xunit;

namespace Library.API.Test.Domain
{
    public class YoungAdultBookDecoratorTests
    {
        [Fact]
        public void YoungAdultBookDecorator_SetCategory_ShouldSetCorrectCategory()
        {
            var book = new YoungAdultFiction();
            var sut = new YoungAdultBookDecorator(book);
            sut.SetBook(book);
            var expectedCategory = "Young Adult Fiction";

            sut.SetCategory();

            Assert.Equal(expectedCategory, sut.Category);
        }
    }
}
