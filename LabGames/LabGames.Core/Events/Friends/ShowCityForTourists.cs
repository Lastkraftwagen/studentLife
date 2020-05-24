using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Friends
{
    internal class ShowCityForTourists : BaseEvent

    {
        public ShowCityForTourists()
        {
            ID = 29;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            throw new NotImplementedException();
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "description";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Показати нічне місто туристам";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
        }
    }
}
