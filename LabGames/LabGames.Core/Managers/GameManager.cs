using LabGames.Core.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core
{
    public static class GameManager
    {
        public static Dictionary<string, Game> Games = new Dictionary<string, Game>();

        static GameManager()
        {
            Games.Add("1", new Game()
            {
                p = new Player()
                {
                    _agility = 4,
                    _glamor = 4,
                    _intelligence = 3,
                    _speek = 2,
                    _power = 3,
                    _attention = 1,
                    Gender = GenderType.Man,
                    Name = "Василь",
                    Place = PlaceType.Home,
                    Company = CompanyType.Alone
                }
            });
        }

    }
}
