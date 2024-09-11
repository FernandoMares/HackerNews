using DeveloperCodingTestFGM.DTOs;
using DeveloperCodingTestFGM.Models;
using DeveloperCodingTestFGM.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperCodingTestFGM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly HackerNewsService _hackerNewsService;

        public StoriesController(HackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        /// <summary>
        /// Endpoint to retrieve the best stories from Hacker News.
        /// Accepts an optional query parameter 'count' to specify how many stories to return.
        /// </summary>
        /// <param name="count">Number of best stories to return. Must be greater than 0.</param>
        /// <returns>An ActionResult containing a list of StoryDto objects.</returns>
        [HttpGet("GetStories")]
        public async Task<ActionResult<IEnumerable<StoryDto>>> GetBestStories([FromQuery] int count = 0)
        {
            //Return badRequest if count is less than zero
            if (count <= 0)
            {
                return BadRequest("Count must be greater than 0.");
            }

            var stories = await _hackerNewsService.GetBestStoriesAsync(count);
            //Pass the retrieved information according the expected response body
            var storyDtos = stories.Select(story => new StoryDto
            {
                Title = story.Title,
                Uri = story.Uri,
                PostedBy = story.PostedBy,
                Time = story.Time,
                Score = story.Score,
                CommentCount = story.CommentCount
            });

            return Ok(storyDtos);
        }
    }
}
