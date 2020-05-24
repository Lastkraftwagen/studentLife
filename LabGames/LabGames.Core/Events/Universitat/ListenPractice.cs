using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Universitat
{
    internal class ListenPractice : BaseEvent
    {
        public ListenPractice()
        {
            ID = 35;
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
            EventText.Add($"Подібна концентрація уваги на одному предметі трохи втомлює. {Resource.MINUS_ENERGY}");
            p.ChangePower(-5);
            p.ChangeFollowerRait(-5);
            p.ChangeFriendsRait(-5);
            p.Theory += 2;
            p.Practic += Convert.ToUInt32(10 + p.Theory / 10);
            EventText.Add($"Практичне заняття завершено. {Resource.PLUS_PRACTICE}");
            EventText.Add($"Завдяки теоретичним знанням прогресс практики підвищено на {p.Theory / 10}.");
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Слухати вчителя щоб покращити свої практичні навички.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Слухати вчителя";
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
