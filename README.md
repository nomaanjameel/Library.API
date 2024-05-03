# Library API

## Installation

1. Clone Repository
2. Navigate to directory Library.API and open Library.API.sln.
3. In Visual Studio Build the solution and Run the Library.API web api

## Running API
The Library.APi project has been cofigured to use and run Swagger.  
Run the Library.API Project to see the Swagger UI load.  
The Search endpoint can be tested locally using the Swagger UI by expanding the GET `/Library/search/{title}` method.  
To test the search method use the following title: `Book 0`.  
This should result in a request to `https://localhost:7102/Library/search/Book%200` and return one book result
```
[
  {
    "title": "Book 0",
    "isbn": "123456789",
    "author": "Zak Bagens",
    "published": "2024-05-03T15:00:32.4356923+01:00"
  }
]
```

## Project Structure
The solution has been organised based on the clean architecture design.
- Application - contains command lists, custom exceptions and validation logic
- Domain - business entities represented as objects with validation criteria and any logic associated with said object
- Infrastructure - Data context definition and Repository pattern implemenation to access, modify data.

See https://github.com/jasontaylordev/CleanArchitecture/tree/main for details and notes

## Unit Tests
Library.API.Test contains Unit tests. The tests are written using xUnit and can be run in Visual Studio Test Runner or via terminal.

First navigate to `\Library.API` where the .sln file lives
then run
```
dotnet test
```

Test classes should be organised to reflect the project structure

e.g. A class in 

`Library.API\Infrastructure\Repository\BookRepository.cs` 

would be covered by a corresponding test class in 

`Library.API.Test\Infrastructure\Repository\BookRepositoryTests.cs`