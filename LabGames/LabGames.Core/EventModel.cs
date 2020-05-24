using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core
{
    public class EventModel
    {
        public int id;
        public string name;
        public string description;
        public bool isMulti = false;
        public List<EventModel> submodels = new List<EventModel>();
    }
}
