using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    internal class HelpPopleInTrouble : BaseEvent
    {
        public HelpPopleInTrouble()
        {
            ID = 23;
            this.EventText = "Помочь людям в беде";
            this.CreateConditions();
        }

        public override bool Execute(Player p)
        {
            throw new NotImplementedException();
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
        }
    }
}
