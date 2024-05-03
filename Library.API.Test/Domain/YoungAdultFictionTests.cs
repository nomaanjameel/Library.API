using Xunit;

namespace Library.API.Domain
{
    public class YoungAdultFictionTests
    {
        [Fact]
        public void YoungAdultFiction_SetCategory_SetsCorrectCategory()
        {
            var book = new YoungAdultFiction();
            Assert.Null(book.Category);

            book.SetCategory();

            Assert.Equal("Young Adult Fiction", book.Category);
        }
    }
}
