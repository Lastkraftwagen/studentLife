using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Universitat
{
    [Serializable]
    public class PassExam : BaseEvent
    {
        public PassExam()
        {
            ID = 45;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Add("Екзамени здано успішно");
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Сдавати екзамени спираючись на власні знання і досвід";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Сдавати екзамени спираючись на власні знання і досвід";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Universitat,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
