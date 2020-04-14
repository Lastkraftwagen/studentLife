using LabGames.API.Results;
using LabGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGames.API.Interfaces
{
    public interface IDataService
    {
        User LogIn(string email, string password);

        RegisterResult RegisterUser(User user);
    }
}
