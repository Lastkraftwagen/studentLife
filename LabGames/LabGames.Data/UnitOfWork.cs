using LabGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Data
{
    public class UnitOfWork : DbContext
    {
        public UnitOfWork(): base("Connection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<SavedGame> SavedGames { get; set; }
    }
}
