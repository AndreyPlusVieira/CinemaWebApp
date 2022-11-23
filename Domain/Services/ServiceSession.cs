using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;

namespace Domain.Services
{
    public class ServiceSession : IServiceSession
    {
        private readonly ISessions _ISession;
        private readonly IMovie _IMovie;

        public ServiceSession(ISessions ISession, IMovie IMovie)
        {
            _ISession = ISession;
            _IMovie = IMovie;
        }
        public async Task<Session> VerifyMovie(Session session)
        {
            var movie = await _IMovie.GetEntityById(session.MovieId);

            if (movie == null)
                return null;

            return session;
        }


        public async Task<Session> AddSession(Session session)
        {
            var movie = await _IMovie.GetEntityById(session.MovieId);

            var sessionsTimes = await _ISession.ListByMovieAndRoom(session);
            var ts = TimeSpan.FromMinutes(movie.Duration);
            session.EndTIme = session.StartTime.Add(ts);

            var verify = session.CheckSessions(sessionsTimes, session);
            if (verify)
                return null;

            await _ISession.Add(session);
            return session;
        }

        public Task<List<Session>> GetAllSession()
        {
            var sessionList = _ISession.List();

            if (sessionList == null)
                return null;

            return sessionList;
        }

        public async Task<Session> GetSession(int id)
        {
            var session = await _ISession.GetEntityById(id);

            if (session == null)
                return null;

            return session;
        }

        public async Task<List<Session>> GetSessionsByMovieId(int id)
        {
            var sessionList = new List<Session>();
            sessionList = await _ISession.ListByMovieId(id);

            if (sessionList == null)
                return null;

            return sessionList;
        }

        public async Task<Session> RemoveSession(int id)
        {
            var session = await _ISession.GetEntityById(id);
            var verify = session.CheckForDelete(session);
            if (verify)
            {
                return null;
            }
            else
            {
                await _ISession.Delete(session);
                return session;
            }
        }

        public async Task<Session> UpdateSession(Session session, int id)
        {
            var movie = await _IMovie.GetEntityById(session.MovieId);
            var sessionsTimes = await _ISession.ListByMovieAndRoom(session);
            var ts = TimeSpan.FromMinutes(movie.Duration);

            session.EndTIme = session.StartTime.Add(ts);
            session.Id = id;

            var verify = session.CheckSessions(sessionsTimes, session);
            if (verify)
                return null;

            await _ISession.Update(session);
            return session;
        }
    }
}