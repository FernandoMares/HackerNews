# HackerNewsTopStories
.NET Core app for fetching and ranking top Hacker News stories by score. Includes HackerNewsService for API interaction and xUnit/Moq tests for validation. Provides endpoints to retrieve and query top stories. Clone, build, and test functionality with provided instructions.

## Features

### Retrieve Top Stories:
  - Fetch the top `n` stories from Hacker News.
### Sorted by Score:
  - Stories are returned in descending order of score.
### Detailed Story Information:
  -  Includes title, URL, author, timestamp, score, and comment count.
### Efficient Data Retrieval
  - Minimizes the load on the Hacker News API by efficiently handling requests.

## Getting Started
Prerequisites
.NET 6.0 SDK

#### Running the Application
Clone the repository:

 - git clone https://github.com/FernandoMares/HackerNews.git

 - Open Visual Studio and select Open a project or solution.

 - Navigate to the HackerNews/DeveloperCodingTestFGM folder and open the solution file (.sln).
 
 - Build and run the application by pressing F5 or selecting Debug > Start Debugging from the menu.

 - The API should be available at http://localhost:7209/swagger/index.html or http://localhost:5092/swagger/index.html (Port can be different)

## Project Structure

#### Common/GlobalConstants.cs
Contains constant values used throughout the application, such as endpoint URLs.

#### Controllers/StoriesController.cs
The controller responsible for handling incoming HTTP requests related to Hacker News stories. This is where the RESTful endpoints for interacting with the service are defined.

#### DTOs/StoryDto.cs
Defines the Data Transfer Object (DTO) for a story. The DTO is used to encapsulate the data sent between the client and the server, ensuring that only the required information is exposed.

#### Models/Story.cs
This file contains the model for a story. It mirrors the data structure used by the Hacker News API, representing the fields of a story, such as the title, score, author, and URL.

#### Services/HackerNewsService.cs
This is the core service class responsible for communicating with the Hacker News API. It fetches story data, processes the response, and provides the requested number of stories.

#### Program.cs
The entry point of the application. This file configures and runs the ASP.NET Core application, setting up services.

#### Tests/
This folder contains the test suite for the application, ensuring the code works as expected.

#### Services/HackerNewsServiceTests.cs
Contains the unit tests for the HackerNewsService. These tests validate the service logic by mocking external API calls and checking for expected results under different scenarios.

## Endpoints

GET https://localhost:7209/api/stories/GetStories?count=1

#### Response example

```json
[
  {
    "title": "An NFC movie library for my kids",
    "uri": "https://simplyexplained.com/blog/how-i-built-an-nfc-movie-library-for-my-kids/",
    "postedBy": "kzrdude",
    "time": "2024-09-08T09:06:31+00:00",
    "score": 1306,
    "commentCount": 294
  }
]
```

GET https://localhost:7209/api/stories/GetStories?count=10
#### Response example

```json
[
  {
    "title": "An NFC movie library for my kids",
    "uri": "https://simplyexplained.com/blog/how-i-built-an-nfc-movie-library-for-my-kids/",
    "postedBy": "kzrdude",
    "time": "2024-09-08T09:06:31+00:00",
    "score": 1308,
    "commentCount": 294
  },
  {
    "title": "Show HN: Wealthfolio: Private, open-source investment tracker",
    "uri": "https://wealthfolio.app",
    "postedBy": "a-fadil",
    "time": "2024-09-06T12:56:15+00:00",
    "score": 916,
    "commentCount": 261
  },
  {
    "title": "Synthetic diamonds are now purer, more beautiful, and cheaper than mined",
    "uri": "https://worksinprogress.co/issue/lab-grown-diamonds/",
    "postedBy": "bswud",
    "time": "2024-09-09T13:30:42+00:00",
    "score": 829,
    "commentCount": 470
  },
  {
    "title": "Tell HN: Burnout is bad to your brain, take care",
    "uri": null,
    "postedBy": "tuyguntn",
    "time": "2024-09-05T23:59:02+00:00",
    "score": 733,
    "commentCount": 327
  },
  {
    "title": "2M users but no money in the bank",
    "uri": "https://exercism.org/blog/september-2024-restructure",
    "postedBy": "leandot",
    "time": "2024-09-06T07:16:38+00:00",
    "score": 694,
    "commentCount": 348
  },
  {
    "title": "Did Sandia use a thermonuclear secondary in a product logo?",
    "uri": "https://blog.nuclearsecrecy.com/2024/09/04/did-sandia-use-a-thermonuclear-secondary-in-a-product-logo/",
    "postedBy": "terryf",
    "time": "2024-09-06T07:27:06+00:00",
    "score": 658,
    "commentCount": 205
  },
  {
    "title": "James Earl Jones has died",
    "uri": "https://variety.com/2024/film/news/james-earl-jones-dead-darth-vader-lion-king-1236138656/",
    "postedBy": "birriel",
    "time": "2024-09-09T20:50:16+00:00",
    "score": 657,
    "commentCount": 176
  },
  {
    "title": "QUIC is not quick enough over fast internet",
    "uri": "https://dl.acm.org/doi/10.1145/3589334.3645323",
    "postedBy": "Shank",
    "time": "2024-09-09T02:34:15+00:00",
    "score": 651,
    "commentCount": 319
  },
  {
    "title": "Keyhole – Forge own Windows Store licenses",
    "uri": "https://massgrave.dev/blog/keyhole",
    "postedBy": "tuxuser",
    "time": "2024-09-07T09:13:00+00:00",
    "score": 631,
    "commentCount": 294
  },
  {
    "title": "Why GitHub won",
    "uri": "https://blog.gitbutler.com/why-github-actually-won/",
    "postedBy": "hardwaregeek",
    "time": "2024-09-09T16:27:29+00:00",
    "score": 614,
    "commentCount": 483
  }
]
```

# Testing
Unit tests are included to ensure the functionality of the HackerNewsService class. The tests use xUnit and Moq for mocking HTTP responses.

## Run tests
To run the unit tests:

  - Open Visual Studio and select Open a project or solution.

  - Navigate to the HackerNews.Tests folder and open the solution file (.sln) if it is not already open.

  - In the Solution Explorer window, right-click on the test project (HackerNews.Tests) and select Run Tests.

  - You can also open the Test Explorer window (via Test > Test Explorer from the menu) and click the Run All button to execute all tests.



