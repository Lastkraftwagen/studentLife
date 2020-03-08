using LabGames.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Base
{ 
    public abstract class BaseEvent
    {
        public BaseEvent(Player player)
        {
            if (p == null) { throw new ArgumentNullException(); }
            p = player;
        }
        public int ID;
        public string EventText { get; protected set; }
        public bool IsExecutable { get => isExecutable(); }

        protected Player p = null;

        public List<Condition> Conditions = null;

        private bool isExecutable()
        {
            if (Conditions == null || p == null) { return false; }
            Condition currentCondition = new Condition()
            {
                CompanyType = p.Company,
                Day = TimeManager.CurrentStep.Description,
                Place = p.Place
            };
            if (Conditions.Contains(currentCondition)) return true;
            return false;
            
        }
        
    }
}
    