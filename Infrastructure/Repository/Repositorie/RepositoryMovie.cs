using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositorie
{
    public class RepositoryMovie : RepositoryGenerics<Movie>, IMovie
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryMovie()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<string> GetMovieTitle(Movie movie)
        {
            using (var context = new ContextBase(_OptionsBuilder))
            {
                return await context.Movies.Where(x => x.Title.ToLower().Trim() == movie.Title.ToLower().Trim()).Select(x => x.Title).FirstOrDefaultAsync();
            }
        }

        public async Task<List<Session>> ListSessionsByMovie(Movie movie)
        {
            using (var context = new ContextBase(_OptionsBuilder))
            {
                return await context.Sessions.Where(x => x.MovieId == movie.Id).ToListAsync();
            }
        }
    }
}