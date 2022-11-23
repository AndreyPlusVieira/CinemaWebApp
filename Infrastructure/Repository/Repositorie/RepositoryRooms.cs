using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositorie
{
    public class RepositoryRooms : RepositoryGenerics<Rooms>, IRooms
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryRooms()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
