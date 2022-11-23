using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositorie
{
    public class RepositorySession : RepositoryGenerics<Session>, ISessions
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorySession()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Session>> ListByMovieAndRoom(Session session)
        {
            using (var context = new ContextBase(_OptionsBuilder))
            {
                var sessionsList = await context.Sessions.Where(x => x.RoomsId == session.RoomsId).ToListAsync();
                return sessionsList;
            }
        }

        public async Task<List<Session>> ListByMovieId(int id)
        {
            using (var context = new ContextBase(_OptionsBuilder))
            {
                var sessionsList = await context.Sessions.Where(x => x.MovieId == id).ToListAsync();
                return sessionsList;
            }
        }
    }
}