using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Universitat
{
    internal class ListenLection : BaseEvent
    {
        public ListenLection()
        {
            ID = 31;
            this.EventText = "Слушать лекцию";
            this.CreateConditions();
        }

        public override bool Execute(Player p)
        {
            throw new NotImplementedException();
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Universitat,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
