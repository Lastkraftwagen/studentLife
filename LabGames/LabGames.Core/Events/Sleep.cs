using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    [Serializable]
    internal class Sleep : BaseEvent
    {
        public Sleep()
        {
            ID = 25;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Add($"Прекрасні сни, м'якеньке ліжко, а що ще треба? {Resource.PLUS_ENERGY} {Resource.PLUS_HAPPY}");
            if (p.isDrunk)
                EventText.Add(p.ResetDrunk(2));
            p.ChangePower(30);
            p.ChangeHappines(5);
            p.ChangeFriendsRait(-2);
            p.ChangeFollowerRait(-2);
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Сон вночі - нормальна справа. Виснаження зніме як рукою.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Спати";
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
        }
    }
}
