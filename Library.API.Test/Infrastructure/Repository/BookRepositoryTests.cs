﻿using Library.API.Infrastructure;
using Library.API.Infrastructure.Repository;
using Xunit;

namespace Library.API.Test.Infrastructure.Repository
{
    public class BookRepositoryTests
    {
        [Fact]
        public async Task BookRespository_Search_ShouldReturnCorrectBook()
        {
            // Arrange
            
            // Note: in real world 'data' should be a IClassFixture Seeded object in memory for sharing across tests
            var data = new DataContext();
            var searchTitle = "Book 1";
            var expectedTitle = "Book 1";
            var sut = new BookRepository(data);

            // Act
            var results = await sut.Search(searchTitle);

            // Assert
            Assert.NotNull(results);
            Assert.Equal(1, results.Count());
            Assert.Equal(expectedTitle, results.First().Title);
        }

        [Fact(Skip = "Todo")]
        public void BookRespository_FindByISBN_ShouldFindBook()
        {

        }

        [Fact(Skip = "Todo")]
        public void BookRespository_Add_ShouldSaveBook()
        {

        }

        [Fact(Skip = "Todo")]
        public void BookRespository_Update_ShouldUpdateBook()
        {

        }

        // Unhappy path tests
        [Fact(Skip = "Todo")]
        public void BookRespository_FindByISBN_ShouldThrowNotFoundException()
        {

        }

        [Fact(Skip = "Todo")]
        public void BookRespository_Add_ShouldThrowBadRequestException()
        {

        }

        [Fact(Skip = "Todo")]
        public void BookRespository_Update_ShouldThrowBadRequestException()
        {

        }
    }
}
