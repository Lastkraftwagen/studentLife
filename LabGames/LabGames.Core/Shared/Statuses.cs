using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core
{
    public class Statuses
    {
        private Statuses() { }

        public const string FAIL = "failed";
        public const string SUCCESS = "ok";
        public const string CONTINUED = "continued";
        public const string DEAD = "dead";
    }
}
