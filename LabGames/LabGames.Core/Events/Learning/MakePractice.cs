using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Learning
{
    [Serializable]
    public class MakePractice : BaseEvent
    {
        public MakePractice()
        {
            ID = 19;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Clear();
            p.ChangeFollowerRait(-5);
            p.ChangeFriendsRait(-5);
            this.EventText.Add($"Навчання ніколи не дається просто. {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
            p.ChangePower(-10);
            p.ChangeHappines(-10);
            if (!p.isDrunk)
            {
                p.Theory += 5;
                p.Practic += Convert.ToUInt32(10 + p.Theory / 10);
                string spend = p.Gender == GenderType.Man ? "витрачав" : "витрачала";
                this.EventText.Add($"Проте результати відчуваються, тепер ті завдання," +
                    $" на які {p.Name} {spend} більше години зараз лускаються як горішки! {Resource.PLUS_PRACTICE}");
                this.EventText.Add($"Завдяки теоретичним знанням прогресс практики підвищено на {p.Theory / 10}.");
            }
            else
            {
                this.EventText.Add($"Особливо під мухою. {Resource.MINUS_ENERGY}");
                p.ChangePower(-5);
                if (p.DrunkLevel <= 2)
                {
                    p.Practic += Convert.ToUInt32(8 + p.Theory / 10);
                    this.EventText.Add($"Долаючи непереборну жагу відволікатися {p.Name} " +
                        $"вчить новий для себе матеріал. Наступного разу краще робити це на тверезу голову {Resource.PLUS_PRACTICE}");
                    this.EventText.Add($"Завдяки теоретичним знанням прогресс практики підвищено на {p.Theory / 10}.");
                }
                else
                {
                    p.ChangeHappines(-5);
                    this.EventText.Add($"В такому стані всі зусилля хоч щось вивчити були марні. {Resource.MINUS_HAPPY}");
                }
                this.EventText.Add(p.ResetDrunk(1));
            }

            if (time.isLearningTime)
            {
                string para = "парі";

                if (time.Description == Constant.PARA_1)
                {
                    para = "лекції";
                }
                else if (time.Description == Constant.PARA_2)
                {
                    para = "практичній";

                }
                else if (time.Description == Constant.PARA_3)
                {
                    para = "лабі";

                }
                this.EventText.Add("Вчитися звичайно добре, але конкретно зараз викладач сумує, " +
                    $"не побачивши одного студента на {para}. {Resource.MINUS_TEACHER}");
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description;
            if (p.isDrunk && p.DrunkLevel > 2)
            {
                Description = $"Практичні навички - найнеобхідніші у навчанні, " +
                    $"проте здобувати їх треба на тверезу голову. Зараз не найкращий час.";
            }
            else
            {
                Description = "Практичні навички - найнеобхідніші у навчанні. Їх здобути" +
                "можна тільки методичною роботою над собою і своїми знаннями." +
                "Вони знадобляться і при сдачі лабораторних, і на екзамені, і у " +
                "реальному житті(але тільки якщо справді докласти зусиль).";
            }
            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Практикуватися у слабких місцях";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
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
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
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
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
