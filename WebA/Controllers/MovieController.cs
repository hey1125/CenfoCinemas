using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpPost("Create")]
        public ActionResult Create([FromBody] Movies movie)
        {
            try
            {
                var mm = new MovieManager();
                mm.Create(movie);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var mm = new MovieManager();
                return Ok(mm.RetrieveAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("RetrieveById")]
        public ActionResult RetrieveById([FromQuery] int id)
        {
            try
            {
                var mm = new MovieManager();
                var movie = mm.RetrieveById(new Movies { Id = id });
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("Update")]
        public ActionResult Update([FromBody] Movies movie)
        {
            try
            {
                var mm = new MovieManager();
                mm.Update(movie);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteById")]
        [HttpDelete("Delete")]
        public ActionResult Delete([FromBody] Movies movie)
        {
            try
            {
                var mm = new MovieManager();
                mm.Delete(movie);
                return Ok($"Película con ID {movie.Id} eliminada.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
