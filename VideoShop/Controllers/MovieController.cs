using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoShop.DataAccess;
using VideoShop.Models;
using VideoShop.Services;

namespace VideoShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
        }



        //GET: Movie
        [HttpGet()]
        public List<Movie> GetAll()
        {
            return _movieService.GetAll();
        }



        //GET: Movie/Details/5
        [HttpGet("{id?}")]
        //[Route ("/GetById?Id={id}")]
        public Movie GetById(int id)
        {
            return _movieService.GetById(id);
        }

        //POST: Movie Create
        [HttpPost("Create")]
        public void Create([FromBody]Movie movie)
        {
            _movieService.Create(movie);
        }

        //POST: Movie Update
        [HttpPost("Update")]
        public void Update([FromBody]Movie movie)
        {
            _movieService.Update(movie);
        }

        //DELETE: Movie
        [HttpDelete("{id?}")]
        public void Delete(int id)
        {
            _movieService.Delete(id);
        }

    }
}
