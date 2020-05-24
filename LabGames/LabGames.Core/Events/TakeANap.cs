using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    [Serializable]
    public class TakeANap : BaseEvent
    {
        public TakeANap()
        {
            ID = 20;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Add($"Швидкий сон вдень - те, що треба. {Resource.PLUS_ENERGY}");
            if (p.isDrunk)
                EventText.Add(p.ResetDrunk(2));
            p.ChangePower(10);
            p.ChangeFriendsRait(-3);
            p.ChangeFollowerRait(-3);
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Трохи поспати корисно для відновлення енергії. (І отверезіння)";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Подрімати";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Home,
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
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
