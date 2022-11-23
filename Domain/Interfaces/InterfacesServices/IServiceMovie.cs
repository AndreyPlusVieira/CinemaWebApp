using Entities.Entities;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceMovie
    {
        Task<Movie> AddMovie(Movie movie);


        Task<Movie> UpdateMovie(Movie movie, int id);

        Task<Movie> DeleteMovie(int id);


        Task<Movie> GetMovie(int id);

        Task<List<Movie>> GetAllMovie();
    }
}