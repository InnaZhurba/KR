using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Result
    {
        public int Id { get; set; }
        public string WinerId { get; set; }
        public string LoserId { get; set; }
        public bool Both { get; set; }
        public bool GameStatus { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
