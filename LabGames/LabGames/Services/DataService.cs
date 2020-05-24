using LabGames.API.Interfaces;
using LabGames.API.Results;
using LabGames.Core;
using LabGames.Core.Scene;
using LabGames.Data;
using LabGames.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace LabGames.API.Services
{
    public class DataService : IDataService
    {
        public User LogIn(string email, string password)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                User res = db.Users.FirstOrDefault((x => x.Email == email && x.Password == password));
                return res;
            }
        }

        public RegisterResult RegisterUser(User user)
        {
            try
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    RegisterResult result = new RegisterResult();
                    result.User = db.Users.FirstOrDefault(x => x.Id == user.Id);
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private User GetUserById(int Id)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return db.Users.Where(x => x.Id == Id).FirstOrDefault();
            }
        }

        public bool SaveGame(Game game, int userId, string saveName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (!Directory.Exists($"{ Constants.SAVE_PATH}\\{ userId.ToString()}"))
                Directory.CreateDirectory($"{ Constants.SAVE_PATH}\\{ userId.ToString()}");
            string PathToLoad = $"{Constants.SAVE_PATH}\\{userId.ToString()}\\{saveName}.saved";
            using (FileStream fs = new FileStream(PathToLoad, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,game);
            }
            using (UnitOfWork db = new UnitOfWork())
            {
                db.SavedGames.Add(new SavedGame()
                {
                    PathToLoad = PathToLoad,
                    SaveDate = DateTime.Now,
                    SaveName = $"{saveName}.saved",
                    UserId = userId
                });
                db.SaveChanges();
            }
            return true;

        }

        public List<SavedGame> GetUserSavedGames(int userId)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return db.SavedGames.Where(x => x.UserId == userId).ToList();
            }
        }

        public Game LoadGame(int userId, int savedGameId)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (UnitOfWork db = new UnitOfWork())
            {
                SavedGame s = db.SavedGames.Where(x => x.GameId == savedGameId).Where(x => x.UserId == userId).FirstOrDefault();
                if (s == null) return null;
                FileStream fs = new FileStream(s.PathToLoad, FileMode.Open);
                Game game = (Game)formatter.Deserialize(fs);
                fs.Close();
                return game;
            }

        }
    }
}
