using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Friends
{
    internal class SpeekWithFriends : BaseEvent
    {
        public SpeekWithFriends()
        {
            ID = 34;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Clear();

            EventText.Add($"{p.Name} вбиває час в універі за розмовою з друзями.");
            p.ChangeFollowerRait(-3);
            p.ChangeFriendsRait(7);
            p.ChangePower(-2);
            p.ChangeHappines(5);

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
            string Description = "Можна підняти собі настрій, та покращити " +
                "відносини з друзями, обговоривши останні події в житті і у світі.";
            return Description;

        }

        public override string GenerateName(Player p, DayStep time)
        {
            return p.Gender == GenderType.Man?"Спілкуватися з друзями":"Обговорити важливі новини";
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
