using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Movement
{
    public class GoStudyOnFoot : BaseEvent
    {
        public GoStudyOnFoot(Player player) : base(player)
        {
            ID = 21;
            this.EventText = "Отправиться на учебу пешком";
            this.CreateConditions();
        }

        public override bool Execute()
        {
            throw new NotImplementedException();
        }

        protected override void CreateConditions()
        {
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
