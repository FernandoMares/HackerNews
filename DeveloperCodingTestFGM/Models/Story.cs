using System.Text.Json.Serialization;

namespace DeveloperCodingTestFGM.Models
{
    /// <summary>
    /// Represents a story fetched from the Hacker News API.
    /// Maps the properties from the JSON response of Hacker News to C# properties.
    /// </summary>
    public class Story
    {
        /// <summary>
        /// The title of the story.
        /// This property is serialized to JSON with the name 'title'.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The URL of the story.
        /// This property is serialized to JSON with the name 'url'.
        /// </summary>
        [JsonPropertyName("url")]
        public string Uri { get; set; }

        /// <summary>
        /// The username of the person who posted the story.
        /// This property is serialized to JSON with the name 'by'.
        /// </summary>
        [JsonPropertyName("by")]
        public string PostedBy { get; set; }

        /// <summary>
        /// The time the story was posted, represented as Unix time (seconds since the Unix epoch).
        /// This property is serialized to JSON with the name 'time'.
        /// </summary>
        [JsonPropertyName("time")]
        public long UnixTime { get; set; }

        /// <summary>
        /// The score or ranking of the story.
        /// This property is serialized to JSON with the name 'score'.
        /// </summary>
        [JsonPropertyName("score")]
        public int Score { get; set; }

        /// <summary>
        /// The number of comments on the story.
        /// This property is serialized to JSON with the name 'descendants'.
        /// </summary>
        [JsonPropertyName("descendants")]
        public int CommentCount { get; set; }

        /// <summary>
        /// A computed property that converts the Unix timestamp into a readable date-time format (ISO 8601).
        /// This property is ignored during serialization to JSON.
        /// </summary>
        [JsonIgnore]
        public string Time => DateTimeOffset.FromUnixTimeSeconds(UnixTime).ToString("yyyy-MM-ddTHH:mm:ss+00:00");
    }
}
