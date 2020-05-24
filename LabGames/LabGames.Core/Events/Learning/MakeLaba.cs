using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Learning
{
    [Serializable]
    public class MakeLaba : BaseEvent
    {
        public MakeLaba()
        {
            ID = 17;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Clear();

            p.CurrentLaba = p.Labs.Where(x => x.Own).Where(x => !x.Ready).FirstOrDefault();
            if (p.CurrentLaba == null)
            {
                EventText.Add($"Наразі всі доступні лаби вже виконано, наступного " +
                    $"тижня будуть ще. Або можна попросити на практичній взяти собі лаби наперед.");
                return false;
            }
            if (p.Place == PlaceType.Universitat)
            {
                p.ChangeHappines(-5);
                p.ChangeFriendsRait(-3);
                p.ChangeFollowerRait(-3);
                if (!p.isDrunk)
                {
                    p.ChangePower(-3);
                    EventText.Add($"{p.Name} встигає нашвидкоруч зробити невелику частину лабораторної.");
                    if (time.isLearningTime)
                    {
                        EventText.Add($"Викладачу явно не подобається така поведінка на " +
                            $"парі. {Resource.MINUS_TEACHER}");
                        p.ChangeOP(-5);
                    }
                    p.CurrentLaba.DoPart();
                }
                else if (p.DrunkLevel == 1)
                {
                    p.ChangePower(-5);
                    EventText.Add($"Йой, фух, трохи вата в голові і сухість в роті заважає якісно " +
                        $"робити діло. Але шось вийшло, най буде.");
                    EventText.Add(p.ResetDrunk(1));
                    p.CurrentLaba.DoPart();
                }
                else
                {
                    string w = p.Gender == GenderType.Man ? "старався" : "старалася";
                    p.ChangePower(-5);
                    p.ChangeHappines(-5);
                    EventText.Add($"Як {p.Name} не {w}, все одно в такому стані " +
                        $"нічого не вийшло. {Resource.MINUS_HAPPY} {Resource.MINUS_ENERGY}");
                    EventText.Add(p.ResetDrunk(1));
                }
                return true;
            }
            else
            {
                p.ChangeFriendsRait(-7);
                p.ChangeFollowerRait(-7);
                if (!p.isDrunk)
                {
                    EventText.Add($"{p.Name} приступає до виконання лаби.");
                    p.ChangeHappines(-12);
                    EventText.Add($"Подібні завдання завжди забирають багато часу та сил. {Resource.MINUS_ENERGY}");
                    p.ChangePower(-12);
                    EventText.Add($"Чорт, все ніяк не виходить дозаповнити останн таблицю! {Resource.MINUS_HAPPY}");
                    p.CurrentLaba.DoAll();
                    EventText.Add($"Фух, лаба нарешті виконана! Повністю!) {Resource.PLUS_HAPPY}");
                    p.ChangeHappines(4);
                }
                else
                {
                    p.ChangePower(-18);
                    p.ChangeHappines(-12);
                    if (p.DrunkLevel <= 2)
                    {
                        EventText.Add($"{p.Name} приступає до виконання лаби трохи під мухою.");
                        EventText.Add($"П'яненьким складно вправно оперувати даними.  {Resource.MINUS_ENERGY}");
                        p.CurrentLaba.DoPart();
                        p.CurrentLaba.DoPart();
                        if (p.CurrentLaba.Ready)
                        {
                            EventText.Add($"Це було дуже важко, проте лаба готова.");
                        }
                        {
                            EventText.Add($"Все, сил більше немає, і так непогано. Якшо шо - ще потім " +
                                $"можна доробити.");
                        }
                        EventText.Add(p.ResetDrunk(1));
                    }
                    else
                    {
                        EventText.Add($"Не треба було братися до того в такому стані. " +
                            $"Нічого не вийшло, тільки даремна трата часу... {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
                        EventText.Add(p.ResetDrunk(1));
                    }
                }
                return true;
            }
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description = "Робити лабораторні - найважливіше в універі! ";
            if (!p.IsOkWithLabs)
            {
                if (time.dayOfWeek == DayOfWeek.Saturday || time.dayOfWeek == DayOfWeek.Sunday)
                {
                    Description += "Краще зроби наперед, на тижні завал буде. ";
                }
                else
                {
                    if (time.Description == Constant.PARA_2)
                    {
                        Description += "Останній шанс - наступна пара вже захист."; ;
                    }
                    else
                    {
                        Description += "Вже прям піджимає, треба встигнути до лабораторної!";
                    }
                }
            }
            else
            {
                Description += "На цей тиждень лаба вже готова, але завжди " +
                    "можна зробити наперед.";
            }
            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Робити лабораторну";
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
                Day = Constant.PARA_1,
                Place = PlaceType.Universitat,
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
                Day = Constant.PARA_2,
                Place = PlaceType.Universitat,
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
