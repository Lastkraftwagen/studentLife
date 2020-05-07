using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Movement
{
    internal class GoStudyOnTaxi : BaseEvent
    {
        public GoStudyOnTaxi()
        {
            ID = 30;
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
            return "На навчання на таксі";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
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
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });

            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });

            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Outside,
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
                Day = Constant.PARA_2,
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });

            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Outside,
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
                Day = Constant.PARA_3,
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
        }
    }
}
