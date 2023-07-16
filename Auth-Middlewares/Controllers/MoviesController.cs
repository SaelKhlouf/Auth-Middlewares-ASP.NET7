using Auth_Middlewares.Dtos;
using Auth_Middlewares.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Middlewares.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly JwtService _jwtService;
        public MoviesController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("generate-token")]
        public IActionResult GenerateToken([FromBody] GenerateTokenRequestDto generateTokenRequestDto)
        {
            var token = _jwtService.GenerateToken(generateTokenRequestDto);
            return Ok(new
            {
                token
            });
        }

        [HttpGet("")]
        public IActionResult GetMovies()
        {
            return Ok("Success");
        }

        [Authorize]
        [HttpGet("trending")]
        public IActionResult GetTrendingMovies()
        {
            return Ok("Success");
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id?}")]
        public IActionResult DeleteMovie(string id)
        {
            return Ok($"Deleted Movie {id}");
        }
    }
}
