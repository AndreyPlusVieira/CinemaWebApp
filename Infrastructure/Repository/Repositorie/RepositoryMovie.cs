using System.Text.RegularExpressions;
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

        public async Task<bool> CheckIfMovieTitleExists(Movie movie)
        {
            using (var context = new ContextBase(_OptionsBuilder))
            {
                var movieTitleWithoutSpaces = Regex.Replace(movie.Title, @"\s", "").ToLower().Trim();

                var listOfTitles = await context.Movies.Where(x => x.Title != null).Select(x => x.Title).ToListAsync();

                var results = ComparableTitle(movieTitleWithoutSpaces, listOfTitles);

                if (results)
                    return true;

                return false;
            }
        }

        public async Task<List<Session>> ListSessionsByMovie(Movie movie)
        {
            using (var context = new ContextBase(_OptionsBuilder))
            {
                return await context.Sessions.Where(x => x.MovieId == movie.Id).ToListAsync();
            }
        }

        public bool ComparableTitle(string title, List<string> list)
        {

            foreach (var item in list)
            {
                if (Regex.Replace(item, @"\s", "").ToLower().Trim() == title)
                {
                    return true;
                }
            }
            return false;
        }
    }
}