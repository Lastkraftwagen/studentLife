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
        private DbSet<User> users;

        public UnitOfWork(): base("UnitOfWork")
        { }
        public DbSet<User> Users { get => users; set => users = value; }
    }
}
