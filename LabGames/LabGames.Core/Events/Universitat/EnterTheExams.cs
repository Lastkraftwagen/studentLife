using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Universitat
{
    [Serializable]
    internal class EnterTheExams : BaseEvent
    {
        public EnterTheExams()
        {
            this.ID = 44;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string word = p.Gender == GenderType.Man ? "встиг" : "встигла";
            return "Ця історія підходить до свого фіналу. Зараз " +
                "лишається лише зайти в ці двері та написати фінальний екзамен." +
                $" Його успішність буде залежати від того, що {p.Name} {word} вивчити " +
                $"за цей час в універі, від відносин зі вчителем, і, звичайно, від " +
                $"деякої кількості удачі.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Увійти в екзаменаційну";
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
