using LabGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Data
{
    class DataContext : DbContext
    {
        public DataContext()
            : base("DbConnection")
        { }
        public DbSet<User> Users { get; set; }
    }
}
