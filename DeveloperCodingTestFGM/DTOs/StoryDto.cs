using System.Text.Json.Serialization;

namespace DeveloperCodingTestFGM.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing a story retrieved from Hacker News.
    /// This DTO defines the structure for the data that will be returned by the API.
    /// </summary>
    public class StoryDto
    {
        /// <summary>
        /// The title of the story.
        /// This property is serialized to JSON with the name 'title'.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The URL of the story.
        /// This property is serialized to JSON with the name 'uri'.
        /// </summary>

        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The username of the person who posted the story.
        /// This property is serialized to JSON with the name 'postedBy'.
        /// </summary>
        [JsonPropertyName("postedBy")]
        public string PostedBy { get; set; }

        /// <summary>
        /// The time the story was posted, formatted as a string.
        /// This property is serialized to JSON with the name 'time'.
        /// </summary>

        [JsonPropertyName("time")]
        public string Time { get; set; }

        /// <summary>
        /// The score of the story.
        /// This property is serialized to JSON with the name 'score'.
        /// </summary>

        [JsonPropertyName("score")]
        public int Score { get; set; }

        /// <summary>
        /// The number of comments on the story.
        /// This property is serialized to JSON with the name 'commentCount'.
        /// </summary>

        [JsonPropertyName("commentCount")]
        public int CommentCount { get; set; }
    }
}
