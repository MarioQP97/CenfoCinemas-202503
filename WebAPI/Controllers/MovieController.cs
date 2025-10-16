using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities_DTO;
using CoreApp;

namespace WebAPI.Controllers
{
    //http://servidor:puerto/api/Movie
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        //Igual respetamos el patron del CRUD
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Movie movie)
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

        [HttpGet]
        [Route("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var mm = new MovieManager();
                var lstResults = mm.RetrieveAll();
                return Ok(lstResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByMovieId")]
        public ActionResult RetrieveByMovieId(Movie movie)
        {
            try
            {
                var mm = new MovieManager();
                var mResult = mm.RetrieveMovieById(movie.Id);
                return Ok(mResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Movie movie)
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

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Movie movie)
        {
            try
            {
                var mm = new MovieManager();
                mm.Delete(movie);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}