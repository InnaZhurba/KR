using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Status
    {
        public int Id { get; set; }
        public bool HealthStatus { get; set; }
        public bool StatusForGame { get; set; }
        
        public virtual ICollection<Gamer> Gamers { get; set; }

    }
}
