using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("TB_ROOMS")]
    public class Rooms
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Seats")]
        public int Seats { get; set; }

        public IList<Session> Sessions { get; set; } = new List<Session>();

    }
}
