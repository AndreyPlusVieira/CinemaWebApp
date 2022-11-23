using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceRooms : IServiceRooms
    {
        private readonly IRooms _IRooms;

        public ServiceRooms(IRooms IRooms)
        {
            _IRooms = IRooms;
        }
    }
}
