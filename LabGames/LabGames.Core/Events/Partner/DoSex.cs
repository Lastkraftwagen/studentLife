using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Partner
{
    public class DoSex : BaseEvent
    {
        public DoSex()
        {
            ID = 15;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Add($"Довелося витратися на презервативи. (-60 грн)");
            p.ChangeMoney(-90);
            p.ChangePower(45);
            p.ChangeHappines(15);
            p.ChangeFriendsRait(-2);
            EventText.Add($"Після подібних навантажень сон особливо " +
             $"приємний. {Resource.PLUS_ENERGY} {Resource.PLUS_HAPPY}");
            if (p.isDrunk)
                EventText.Add(p.ResetDrunk(2));
            p.ChangeFollowerRait(10);
            return true;
        }
        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Ну там шурум-пурум, самі розумієте. А потім - спати.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Займатися любов'ю";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Home,
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
                Day = Constant.PARA_1,
                Place = PlaceType.Home,
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
                Day = Constant.PARA_3,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
        }
    }
}
