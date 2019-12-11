using System;
using System.Data.Entity;

namespace DataAccess
{
    public class DB : DbContext
    {
        public DB() : base("DBConnectionString")
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<Stadion> Stadions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
