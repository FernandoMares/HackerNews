using DeveloperCodingTestFGM.Models;
using DeveloperCodingTestFGM.Services;
using Moq;
using Moq.Protected;
using System.Net;
using Xunit;
public class HackerNewsServiceTests
{
    private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
    private readonly HttpClient _mockHttpClient;
    private readonly HackerNewsService _hackerNewsService;

    /// <summary>
    /// Constructor initializes the mocked HTTP handler and client,
    /// then creates an instance of HackerNewsService with the mocked HttpClient.
    /// </summary>
    public HackerNewsServiceTests()
    {
        // Set up a mock HttpMessageHandler to intercept the HTTP requests
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        _mockHttpClient = new HttpClient(_mockHttpMessageHandler.Object);

        // Create the service with the mocked HttpClient
        _hackerNewsService = new HackerNewsService(_mockHttpClient);
    }

    /// <summary>
    /// Tests that GetBestStoriesAsync returns a single story when
    /// the count parameter is set to 1.
    /// </summary>
    [Fact]
    public async Task SingleBestStory_IsProvided_WhenLimitIsOne()
    {
        // Mock the response for story IDs and a single story
        var mockBestStoryIds = new List<int> { 1 };
        var mockStory = new Story
        {
            Title = "An NFC movie library for my kids",
            Uri = "https://simplyexplained.com/blog/how-i-built-an-nfc-movie-library-for-my-kids/",
            PostedBy = "kzrdude",
            UnixTime = 1694167591, // Corresponding to "2024-09-08T09:06:31+00:00"
            Score = 1287,
            CommentCount = 294
        };

        // Set up the mocked HTTP responses
        SetupMockHttpResponses(mockBestStoryIds, mockStory);

        // Call the method being tested
        var result = await _hackerNewsService.GetBestStoriesAsync(1);

        // Assert: Verify the result
        Assert.Single(result); // Ensure only one story is returned
        Assert.Equal("An NFC movie library for my kids", result[0].Title); // Verify title
        Assert.Equal(1287, result[0].Score); // Verify score
    }

    /// <summary>
    /// Tests that GetBestStoriesAsync returns exactly ten stories when
    /// the count parameter is set to 10.
    /// </summary>
    [Fact]
    public async Task TenBestStories_AreProvided_WhenLimitIsTen()
    {
        // Mock the response for 10 story IDs and corresponding stories
        var mockBestStoryIds = Enumerable.Range(1, 10).ToList(); // Mock 10 story IDs
        var mockStories = GetMockTenStories(); // Get mock stories

        // Set up the mocked HTTP responses
        SetupMockHttpResponses(mockBestStoryIds, mockStories);

        // Call the method being tested
        var result = await _hackerNewsService.GetBestStoriesAsync(10);

        // Assert: Verify that 10 stories are returned
        Assert.Equal(10, result.Count);
        Assert.Equal("An NFC movie library for my kids", result[0].Title); // Verify first story title
        Assert.Equal("Why GitHub won", result[9].Title); // Verify last story title
    }

    /// <summary>
    /// Helper method to set up mock responses for a list of story IDs
    /// and a single story. Used to mock the Hacker News API responses.
    /// </summary>
    private void SetupMockHttpResponses(List<int> storyIds, Story mockStory)
    {
        // Mock response for story IDs
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString().Contains("beststories.json")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(storyIds))
            });

        // Mock response for each individual story
        foreach (var id in storyIds)
        {
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString().Contains($"{id}.json")),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(mockStory))
                });
        }
    }

    /// <summary>
    /// Helper method to set up mock responses for a list of story IDs
    /// and multiple stories. Used to mock the Hacker News API responses.
    /// </summary>
    private void SetupMockHttpResponses(List<int> storyIds, List<Story> mockStories)
    {
        // Mock response for story IDs
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString().Contains("beststories.json")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(storyIds))
            });

        // Mock response for each individual story
        for (int i = 0; i < storyIds.Count; i++)
        {
            var id = storyIds[i];
            var story = mockStories[i];
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.RequestUri.ToString().Contains($"{id}.json")),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(story))
                });
        }
    }

    /// <summary>
    /// Returns a mock list of ten stories to simulate Hacker News API responses.
    /// </summary>
    private List<Story> GetMockTenStories()
    {
        return new List<Story>
        {
            new Story { Title = "An NFC movie library for my kids", Uri = "https://simplyexplained.com/blog/how-i-built-an-nfc-movie-library-for-my-kids/", PostedBy = "kzrdude", UnixTime = 1694167591, Score = 1287, CommentCount = 294 },
            new Story { Title = "Show HN: Wealthfolio: Private, open-source investment tracker", Uri = "https://wealthfolio.app", PostedBy = "a-fadil", UnixTime = 1694014575, Score = 915, CommentCount = 261 },
            new Story { Title = "Synthetic diamonds are now purer, more beautiful, and cheaper than mined", Uri = "https://worksinprogress.co/issue/lab-grown-diamonds/", PostedBy = "bswud", UnixTime = 1694275842, Score = 814, CommentCount = 465 },
            new Story { Title = "Tell HN: Burnout is bad to your brain, take care", Uri = null, PostedBy = "tuyguntn", UnixTime = 1693954742, Score = 732, CommentCount = 326 },
            new Story { Title = "2M users but no money in the bank", Uri = "https://exercism.org/blog/september-2024-restructure", PostedBy = "leandot", UnixTime = 1694002598, Score = 693, CommentCount = 348 },
            new Story { Title = "Did Sandia use a thermonuclear secondary in a product logo?", Uri = "https://blog.nuclearsecrecy.com/2024/09/04/did-sandia-use-a-thermonuclear-secondary-in-a-product-logo/", PostedBy = "terryf", UnixTime = 1694003226, Score = 658, CommentCount = 205 },
            new Story { Title = "James Earl Jones has died", Uri = "https://variety.com/2024/film/news/james-earl-jones-dead-darth-vader-lion-king-1236138656/", PostedBy = "birriel", UnixTime = 1694279416, Score = 648, CommentCount = 176 },
            new Story { Title = "QUIC is not quick enough over fast internet", Uri = "https://dl.acm.org/doi/10.1145/3589334.3645323", PostedBy = "Shank", UnixTime = 1694214855, Score = 646, CommentCount = 314 },
            new Story { Title = "Keyhole – Forge own Windows Store licenses", Uri = "https://massgrave.dev/blog/keyhole", PostedBy = "tuxuser", UnixTime = 1694164380, Score = 628, CommentCount = 294 },
            new Story { Title = "Why GitHub won", Uri = "https://blog.gitbutler.com/why-github-actually-won/", PostedBy = "hardwaregeek", UnixTime = 1694157159, Score = 623, CommentCount = 298 }
        };
    }
}
