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
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Clear();
            EventText.Add($"{p.Name} уважно слухає всю пару, задає питання " +
                $"і доволі непогано справляється.");
            EventText.Add($"Вчителю подобається подібна поведінка.{Resource.PLUS_TEACHER}");
            p.ChangeOP(10);
            EventText.Add($"Але як же це нудно(( {Resource.MINUS_HAPPY}");
            p.ChangeHappines(-10);
            p.ChangeFollowerRait(-5);
            p.ChangeFriendsRait(-5);
            EventText.Add($"Подібна концентрація уваги на одному предметі трохи втомлює. {Resource.MINUS_ENERGY}");
            p.ChangePower(-5);
            p.Theory += 20;
            EventText.Add($"Лекцію завершено, переходимо до практики. {Resource.PLUS_THEORY}");
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Поки дають знання - їх треба брати";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Слухати лекцію";
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
