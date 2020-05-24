using LabGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGames.API.Results
{
    public class RegisterResult
    {
        public User User { get; set; } = null;
        public bool Exist { get => User != null; }
    }
}
