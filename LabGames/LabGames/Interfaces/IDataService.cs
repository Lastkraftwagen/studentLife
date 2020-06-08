using LabGames.API.Results;
using LabGames.Core;
using LabGames.Core.Scene;
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
        bool SaveGame(Game game, int userId, string saveName);
        List<SavedGame> GetUserSavedGames(int userId);
        Game LoadGame(int userId, int savedGameId);
        List<Record> GetRecords();
    }
}
