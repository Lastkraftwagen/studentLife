using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Friends
{
    internal class SpeekWithFriends : BaseEvent
    {
        public SpeekWithFriends()
        {
            ID = 34;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            return false;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description = "Поговорити з друзями";
            return Description;

        }

        public override string GenerateName(Player p, DayStep time)
        {
            return p.Gender == GenderType.Man?"Спілкуватися з друзями":"Обговорити важливі новини";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Universitat,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Universitat,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Universitat,
                CompanyType = CompanyType.Alone
            });

        }
    }
}
