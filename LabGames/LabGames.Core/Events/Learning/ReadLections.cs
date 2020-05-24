using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Learning
{
    class ReadLections : BaseEvent
    {
        public ReadLections()
        {
            ID = 6;
            Conditions.Clear();
            this.CreateConditions();
        }


        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Clear();
            p.ChangeFollowerRait(-3);
            p.ChangeFriendsRait(-3);
            this.EventText.Add($"Навчання ніколи не дається просто. {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
            p.ChangePower(-10);
            p.ChangeHappines(-10);
            if (!p.isDrunk)
            {
                p.Theory += 20;
                this.EventText.Add($"Перечитавши тонну літератури можна бути значно " +
                    $"більш впевненим у своїх силах. {Resource.PLUS_THEORY}");
            }
            else
            {
                this.EventText.Add($"Особливо під мухою. {Resource.MINUS_ENERGY}");
                p.ChangePower(-5);
                if (p.DrunkLevel <= 2)
                {
                    p.Theory += 15;
                    this.EventText.Add($"Долаючи непереборну жагу відволікатися {p.Name} " +
                        $"вчить новий для себе матеріал. Наступного разу краще робити це на тверезу голову {Resource.PLUS_THEORY}");
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
                this.EventText.Add("Вчитися звичайно добре, але зараз викладач сумує, " +
                    $"не побачивши одного студента на {para}. {Resource.MINUS_TEACHER}");
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            if (p.isDrunk)
            {
                return p.Theory < 70 ? "Хм, ну читати лекції воно конєшно треба," +
                    "але чи буде з того сенс зараз? Ну щось-то і запам'ятаєш, " +
                    "можна спробувати."
                    :
                    "Ай, нашо треба, і так непогано шариш, краще відпочинь і протверезій.";
            }
            else
            {
                return "Вік живи - вік учися. Теорія - вкрай необхідна " +
                    "штука у навчанні. Люди з гарною теоретичною базою " +
                    "швидше здобувають практичні навички, та до них " +
                    "менше досіпуються на здачі лабораторних.";
            }
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Читати лекції";
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
