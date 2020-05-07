using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    public class Work : BaseEvent
    {
        public Work()
        {
            ID = 40;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            throw new NotImplementedException();
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Працювати";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Працювати";
        }

        protected override void CreateConditions()
        {
            this.Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Place,
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
                Day = Constant.PARA_3,
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
