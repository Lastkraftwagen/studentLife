using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    [Serializable]
    internal class UseSmartphone : BaseEvent
    {
        public UseSmartphone()
        {
            ID = 33;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Clear();

            EventText.Add($"{p.Name} вбиває час в універі, втикаючи в мобільний.");
            p.ChangeFollowerRait(3);
            p.ChangeFriendsRait(3);
            p.ChangePower(-3);
            p.ChangeHappines(3);

            if (time.isLearningTime)
            {
                if (p.TeacherRaiting < 70)
                {
                    EventText.Add($"Вчителю не подобається подібна поведінка. {Resource.MINUS_TEACHER}");
                    p.ChangeOP(-7);
                }
                else
                {
                    EventText.Add($"{p.Name} вже дуже добре спілкується з " +
                        $"викладачем, і подібна поведінка не повпливає на їх відносини. {Resource.PLUS_TEACHER}");
                }
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string word = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
            string s = "Можна просто вбити час, погравши в ігри, " +
                $"попереписуватись з {word}, друзями, продивитися новини.";

            return s;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Продивлятися новини в інтернеті";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Universitat,
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
        }
    }
}
