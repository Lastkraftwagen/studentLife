using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Movement
{
    internal class GoWorkOnFoot : BaseEvent
    {
        public GoWorkOnFoot()
        {
            ID = 26;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            p.Place = PlaceType.Place;
            p.Company = CompanyType.Alone;
            p.DistanceFromHome = DistanceType.Large;
            p.DistanceFromUniver = DistanceType.Medium;
            p.ChangeMoney(-15);
            this.EventText.Add($"{p.Name} прибуває на роботу! Це має бути чудовий робочий день.");
            return false;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "На роботу відправитися можна на щогодинному автобусі. Коштує 15грн.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Відправитися на роботу";
        }

        protected override void CreateConditions()
        {
            this.Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
