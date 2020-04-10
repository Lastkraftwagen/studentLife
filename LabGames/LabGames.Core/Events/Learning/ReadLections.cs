using LabGames.Core.Events.Base;
using LabGames.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Learning
{
    class ReadLections : BaseEvent
    {
        public ReadLections(Player player) : base(player)
        {
            ID = 6;
            this.EventText = "reed lections";
            Conditions.Clear();
            this.CreateConditions();
        }

        protected override void CreateConditions()
        {
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
        }

        public override bool Execute()
        {
            if (!this.IsExecutable) return false;
            //TODO: Change player state
            TimeManager.NextPart();
            return true;
        }
    }
}
