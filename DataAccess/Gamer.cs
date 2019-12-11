using System;
using System.Collections;

namespace DataAccess
{
    public class Gamer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }        
        public int CompanyId { get; set; }
        public int StatusId { get; set; }
        public double Salery { get; set; }
        
        public virtual Company Company { get; set; }
        public virtual Status Status { get; set; }
    }
}
