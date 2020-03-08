using LabGames.Core.Events.Base;
using LabGames.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    public class SleepMore : BaseEvent, IEvent
    {
        public SleepMore(Player player) : base(player)
        {
            Conditions.Add(new Condition()
            {
                Day = Constant.SATURDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.SUNDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
        }
        public bool Execute()
        {
            if (!this.IsExecutable) return false;
            this.EventText = "sleepMore";
            //TODO: Change player state
            TimeManager.NextPart();
            return true;
        }
    }
}
