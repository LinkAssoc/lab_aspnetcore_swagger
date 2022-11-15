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
    public class WordController : ControllerBase
    {
        private readonly IWordService _wordService;

        public WordController(IWordService wordService)
        {
            _wordService = wordService;
        }

        /// <summary>
        /// Generates words randomly with letters and count provided.
        /// </summary>
        /// <param name="letters">String of letters to use during generation.</param>
        /// <param name="count">Length of words and letters in them.</param>
        /// <returns></returns>
        [HttpGet("{letters}/{count}", Name = "GetWordsByLetters")]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public IResult Generate(string letters, int count)
        {
            if (count < 1)
            {
                return Results.BadRequest("Count must be >= 1");
            }
            var lettersCharArray = letters.ToCharArray();
            if (lettersCharArray.Length != lettersCharArray.Distinct().Count())
            {
                return Results.BadRequest("All letters must be unique.");
            }
            return Results.Ok(_wordService.Generate(lettersCharArray, count));
        }

        /*public IResult Generate(WordRequest request)
        {
            return Results.Ok(_wordService.Generate(request.Letters));
        }*/
    }
}
