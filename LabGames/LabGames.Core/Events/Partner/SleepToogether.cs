using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Partner
{
    internal class SleepToogether : BaseEvent
    {
        public SleepToogether()
        {
            ID = 28;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Add($"В обіймах коханої людини " +
                $"сни солодші і ліжко м'якіше. {Resource.PLUS_ENERGY} {Resource.PLUS_HAPPY}");
            if (p.isDrunk)
                EventText.Add(p.ResetDrunk(2));
            p.ChangePower(35);
            p.ChangeHappines(10);
            p.ChangeFriendsRait(-2);
            
            p.ChangeFollowerRait(10);
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Можна спати обійнявшись одне з одним. ПРОСТО СПАТИ, нічого більше.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Спати разом в обіймах";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
        }
    }
}
