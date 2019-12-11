using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Gamer> Gamers { get; set; }
       //public virtual ICollection<Comand> ComandFirst { get; set; }
        //public virtual ICollection<Comand> ComandSecond { get; set; }
    }
}
