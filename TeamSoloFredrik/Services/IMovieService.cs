using TeamSoloFredrik.Models.Db;
using TeamSoloFredrik.Models.ViewModels;

namespace TeamSoloFredrik.Services
{
    public interface IMovieService
    {
        public void AddMovie(Movie movie);
        public List<Movie> GetMovies();
        public CustomerMovieOrdersVM GetAllData();
    }
}
