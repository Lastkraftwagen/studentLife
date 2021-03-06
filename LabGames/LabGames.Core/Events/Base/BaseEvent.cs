﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Base
{ 
    public abstract class BaseEvent
    {
        //public BaseEvent(Player player)
        //{
        //    if (player == null) { throw new ArgumentNullException(); }
        //    p = player;
        //}
        public int ID;
        public List<string> EventText { get; protected set; } = new List<string>();

        public List<Condition> Conditions = new List<Condition>();

        public bool IsExecutable(DayStep CurrentStep, Player p)
        {
            if (Conditions == null || p == null) { return false; }
            Condition currentCondition = new Condition()
            {
                CompanyType = p.Company,
                Day = CurrentStep.Description,
                Place = p.Place
            };
            if (Conditions.Where(x=>x.CompanyType == currentCondition.CompanyType && 
                                    x.Day == currentCondition.Day &&
                                    x.Place == currentCondition.Place).Count()>0) return true;
            return false;
        }

        public abstract bool Execute(Player p, DayStep time);

        public abstract string GenerateDescription(Player p, DayStep time);
        public abstract string GenerateName(Player p, DayStep time);
        protected abstract void CreateConditions();

       
    }
}
    