using LabGames.Core.Events.Base;
using LabGames.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    public class DoMorningExercises : BaseEvent
    {
        public DoMorningExercises(Player player) : base(player)
        {
            ID = 2;
            this.EventText = "Заниматься спортом";
            this.CreateConditions();
        }

    
        public override bool Execute()
        {
            if (!this.IsExecutable) return false;
            //TODO: Change player state
            TimeManager.NextPart();
            return true;
        }
        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            
        }

    }
}
