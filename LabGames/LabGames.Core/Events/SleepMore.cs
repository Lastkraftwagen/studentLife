using LabGames.Core.Events.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    [Serializable]
    public class SleepMore : BaseEvent
    {
        public SleepMore()
        {
            ID = 1;
            this.CreateConditions();
        }
        public override bool Execute(Player p, DayStep time)
        {
            EventText.Add($"Трохи перепочити в першій половині дня - " +
                $"дуже приємно, тут не посперечаєшся. {Resource.PLUS_ENERGY}{Resource.PLUS_HAPPY}");
            if (p.isDrunk)
                EventText.Add(p.ResetDrunk(2));
            p.ChangePower(15);
            p.ChangeHappines(15);
            p.ChangeFriendsRait(-7);
            p.ChangeFollowerRait(-7);
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string descr;
            if (p.isDrunk)
                descr = "З похмілля краще залишатися в горизонтальному положенні";
            else
                descr = "Ну хто ж не хоче подовше повалятися у ліжечку зранку?" +
                " Це стовідсотково підвищить настрій, та можливо навіть продуктивність. " +
                " Головне - не проспати весь день.";
            return descr;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Повалятися у ліжечку";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
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
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            
        }
    }
}
