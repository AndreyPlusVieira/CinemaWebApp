using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISessions : IGeneric<Session>
    {
        Task<List<Session>> ListByMovieAndRoom(Session session);


        Task<List<Session>> ListByMovieId(int id);



    }
}
