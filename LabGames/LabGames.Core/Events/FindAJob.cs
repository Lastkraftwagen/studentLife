using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    [Serializable]
    internal class FindAJob : BaseEvent
    {
        public FindAJob()
        {
            ID = 29;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Add($"Тепер {p.Name} має кожен робочий день" +
                $" відправлятися на роботу і виконувати норму завдань. Тільки" +
                $" якщо завдання будуть виконані в достатньому обсязі і з достатнім " +
                $" рівнем якості, {p.Name} отримає зарплату. Зарплата виплачується в" +
                $" кінці тижня.");
            p.hasJob = true;
            p.AssignedWork = 15;
            return false;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Якщо по універу все в порядку - можна пошукати роботу, " +
                "аби трохи підзаробити. Але врахуй - робота забирає БАГАТО часу!";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Знайти роботу";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
