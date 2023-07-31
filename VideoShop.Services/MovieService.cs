using VideoShop.DataAccess;
using VideoShop.Models;

namespace VideoShop.Services
{
    public class MovieService
    {
        private readonly MovieRepository _movieRepository;
        public MovieService()
        {
            _movieRepository = new MovieRepository();
        }

        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public void Create(Movie movie)
        {
            _movieRepository.Create(movie);
        }

        public void Update(Movie movie)
        {
            _movieRepository.Update(movie);
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }


    }
}