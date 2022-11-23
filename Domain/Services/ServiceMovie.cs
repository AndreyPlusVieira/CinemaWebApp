using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;

namespace Domain.Services
{
    public class ServiceMovie : IServiceMovie
    {
        private readonly IMovie _IMovie;

        public ServiceMovie(IMovie IMovie)
        {
            _IMovie = IMovie;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            if (movie == null)
            {
                return null;
            }

            var title = await _IMovie.GetMovieTitle(movie);
            if (movie.Title == title)
                return null;

            await _IMovie.Add(movie);
            return movie;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            var movie = await _IMovie.GetEntityById(id);
            var sessions = await _IMovie.ListSessionsByMovie(movie);
            var verify = movie.CheckSessionsMovies(sessions);
            if (verify)
                return null;

            await _IMovie.Delete(movie);

            return movie;
        }

        public Task<List<Movie>> GetAllMovie()
        {
            var movieList = _IMovie.List();

            if (movieList == null)
                return null;

            return movieList;
        }

        public async Task<Movie> GetMovie(int id)
        {
            var movie = await _IMovie.GetEntityById(id);

            if (movie == null)
                return null;

            return movie;
        }

        public async Task<Movie> UpdateMovie(Movie movie, int id)
        {
            var movieSearch = _IMovie.GetEntityById(id).Result;
            var title = await _IMovie.GetMovieTitle(movie);

            if (movie.Title == title && movieSearch.Title != title)
                return null;

            movie.Id = id;

            await _IMovie.Update(movie);
            return movie;
        }


    }
}