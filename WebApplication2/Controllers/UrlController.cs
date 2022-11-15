using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    /// <summary>
    /// Word controller for word type functions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        /// <summary>
        /// Gets all urls from the website.
        /// </summary>
        /// <param name="url">Url to the website to get urls from.</param>
        /// <returns></returns>
        [HttpPost("{url}", Name = "GetUrlsFromWebsite")]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetUrlsOnWebsite(string url)
        {
            try
            {
                if (url.Length == 0 || url == null)
                {
                    return Results.BadRequest("Url must be provided.");
                }
                url = url.Replace("%2F", "/");
                if (url.StartsWith("https:/r"))
                    url = url.Replace("https:/r", "https://r");
                var response = await _urlService.GetUrls(url);
                return Results.Ok(response);
            }
            catch (Exception e)
            {
                return Results.Problem(statusCode: 500, detail: e.Message);
            }
        }

        /*public IResult Generate(WordRequest request)
        {
            return Results.Ok(_wordService.Generate(request.Letters));
        }*/
    }
}
