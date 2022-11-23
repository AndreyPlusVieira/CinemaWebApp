using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceSession
    {
        Task<Session> AddSession(Session session);
        Task<Session> VerifyMovie(Session session);
        Task<Session> UpdateSession(Session session, int id);
        Task<Session> RemoveSession(int id);
        Task<Session> GetSession(int id);
        Task<List<Session>> GetAllSession();
        Task<List<Session>> GetSessionsByMovieId(int id);




    }
}
