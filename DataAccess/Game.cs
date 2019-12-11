using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Game
    {
        public int Id { get; set; }
        public string CommandFirst { get; set; }
        public string CommandSecond { get; set; }
        public int StadionId { get; set; }
        public DateTime Data { get; set; }
        public int NumberOfViewers { get; set; }
        public int ResultId { get; set; }

        public virtual Stadion Stadion { get; set; }
        public virtual Result Result { get; set; }

        //public virtual ICollection<Stadion> Stadions { get; set; }
    }
}
