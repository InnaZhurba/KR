using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Stadion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPlaces { get; set; }
        public double PriceForPlace { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        //public virtual Game Game { get; set; }
    }
}
