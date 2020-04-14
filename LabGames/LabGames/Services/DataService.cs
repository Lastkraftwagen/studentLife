using LabGames.API.Interfaces;
using LabGames.API.Results;
using LabGames.Data;
using LabGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGames.API.Services
{
    public class DataService : IDataService
    {
        private UnitOfWork db = new UnitOfWork();
        public User LogIn(string email, string password)
        {
            User res = db.Users.FirstOrDefault((x => x.Email == email && x.Password == password));
            return res;
        }

        public RegisterResult RegisterUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                RegisterResult result = new RegisterResult();
                result.User = db.Users.FirstOrDefault(x => x.Id == user.Id);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
