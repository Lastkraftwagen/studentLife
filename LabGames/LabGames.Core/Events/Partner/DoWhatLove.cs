using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Partner
{
    [Serializable]
    public class DoWhatLove : BaseEvent
    {
        public DoWhatLove()
        {
            ID = 14;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
            EventText.Add($"{p.Name} розмальовує по номерам картину з" +
                $" {partner}. {Resource.PLUS_FOLLOWER}");
            p.ChangeFollowerRait(10);
            p.ChangeFriendsRait(-3);
            p.ChangeHappines(5);
            p.ChangePower(-5);
            if (p.isDrunk)
            {
                EventText.Add(p.ResetDrunk(1));
            }
            EventText.Add("Час проведено приємно і з користю.");
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Це завжди гарна ідея для підтримання стосунків у формі.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Займатися улюбленою справою";
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
