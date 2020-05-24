using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Partner
{
    [Serializable]
    class WatchSeries : BaseEvent
    {
        public WatchSeries()
        {
            ID = 13;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Clear();
            this.EventText.Add($"Серія ковтається за серією, час з коханою людиної " +
                $"плине швидко, але так весело! {Resource.PLUS_HAPPY}");
            this.EventText.Add($"{p.Name} відчуває теплоту у сердці. " +
                $"І це взаємно) {Resource.PLUS_FOLLOWER}");
            p.ChangeHappines(7);
            p.ChangePower(-10);
            p.ChangeFollowerRait(10);
            p.ChangeFriendsRait(-3);
            if (p.isDrunk)
            {
                EventText.Add(p.ResetDrunk(1));
            }
            if (time.isLearningTime)
            {
                p.ChangeOP(-5);
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
            return $"Дивитися серіали разом з {partner}. Науково доведено, що, " +
                $"проводячи час разом, пари зближуються і вірогідність їх розриву зменшується.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Дивитися серіали разом";
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
