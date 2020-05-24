using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    internal class PointlessStagnate : BaseEvent
    {
        public PointlessStagnate()
        {
            ID = 28;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Add($"Эмм, ну {p.Name} просто нічого не робить.");
            EventText.Add($"Діла навколо йдуть.");
            EventText.Add($"А {p.Name} нікуди не йде.");
            EventText.Add($"Енергія не витрачається, ані краще, ані гірше не стає.");
            EventText.Add($"В цілому, нормально.");
            p.ChangeFriendsRait(-5);
            p.ChangeFollowerRait(-5);
            if (time.isLearningTime)
            {
                p.ChangeOP(-5);
            }
            return true;

        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Не робити АБСОЛЮТНО нічого. Не повпливає ні на що.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Безглуздо стагнувати";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Home,
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
        }
    }
}
