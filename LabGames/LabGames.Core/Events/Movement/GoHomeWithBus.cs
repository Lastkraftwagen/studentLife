using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Movement
{
    class GoHomeWithBus : BaseEvent
    {
        public GoHomeWithBus()
        {
            ID = 7;
            this.CreateConditions();
        }

        int cost = 10;

        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Clear();

            Random r = new Random();
            int RandomValue;
            bool Zator = false;

            if (time.partOfDay == PartOfDay.Night)
                RandomValue = r.Next(0, 100);
            else
                RandomValue = r.Next(0, 10);

            if (RandomValue < 5)
                Zator = true;


            p.Place = PlaceType.Home;
            p.Company = CompanyType.Alone;
            p.ChangeMoney(-cost);

            switch (p.DistanceFromHome)
            {
                case DistanceType.Low:
                    p.DistanceFromHome = DistanceType.Home;
                    this.EventText.Add($"{p.Name} вдома.");
                    return false;
                case DistanceType.Medium:
                    if (Zator)
                    {
                        this.EventText.Add("Автобус потравляє у затор. Бабуськи вважають" +
                            $" за необхідне дуже голосно сповіщати про це всіх довкола, а {p.Name}" +
                            $" не може навіть послухати музику, бо телефон сів. {Resource.MINUS_HAPPY}");
                        p.ChangeHappines(-5);
                    }
                    this.EventText.Add($"{p.Name} нарешті вдома.");
                    p.DistanceFromHome = DistanceType.Home;
                   
                    return false;
                case DistanceType.Large:
                    this.EventText.Add("Половину шляху треба їхати на трамваї.");
                    this.EventText.Add("Трамвай успішно доїхав до центру. Звідси на автобусі.");
                    if (Zator)
                    {
                        this.EventText.Add("Автобус потравляє у затор. Бабуськи вважають" +
                        $" за необхідне дуже голосно сповіщати про це всіх довкола, а {p.Name}" +
                        $"не може навіть послухати музику, бо телефон сів. {Resource.MINUS_HAPPY}");
                        p.ChangeHappines(-5);
                    }
                    if (p.isDrunk)
                    {
                        if (p.DrunkLevel == 1 || p.DrunkLevel == 2)
                        {
                            EventText.Add($"В дорозі п'яне тіло почуває себе не дуже добре, " +
                                $"{p.Name} відчуває нудоту і тримається з останніх сил на поворотах. {Resource.MINUS_HAPPY}");
                            EventText.Add(p.ResetDrunk(1));
                            p.ChangeHappines(-5);
                        }
                        else
                        {
                            string s = p.Gender == GenderType.Man ? "його" : "її";
                            string s1 = p.Gender == GenderType.Man ? "позеленів" : "позеленіла";
                            EventText.Add($"Ох ні, оце халепа! {p.Name} аж {s1} від нудоти і {s} " +
                                $"все-таки знудило на одній із зупинок! Тепер треба чекати наступного " +
                                $"автобусу під ядовитими поглядами оточуючих. {Resource.MINUS_HAPPY}");
                            EventText.Add(p.ResetDrunk(1));
                            p.ChangeHappines(-10);
                        }
                    }
                    this.EventText.Add("Така довга подорож в громадському транспорті " +
                        $"виснажить кого завгодно. {Resource.MINUS_HAPPY}");
                    p.ChangeHappines(-5);
                    p.DistanceFromHome = DistanceType.Home;
                  
                    return true;
                default:
                    return false;
            }
        }

        public override string GenerateDescription(Player p, DayStep time)
        {

            string Description;
            if (p.DistanceFromHome == DistanceType.Low)
            {
                Description = "Можна проїхатися до дому на автобусі, проте тут пішки 5 хвилин. Нашо витрачати гроші?";
            }
            else if (p.DistanceFromHome == DistanceType.Medium)
            {
                Description = "Якщо не стане в затор, можна дістатися додому за 15 хвилин. (Ціна 10грн)";
                if (p.isDrunk && p.DrunkLevel >= 2)
                    Description += " Головне, щоб в дорозі не захитало.";
            }
            else if (p.DistanceFromHome == DistanceType.Large)
            {
                Description = $"Звідси їхати хвилин 30, якщо без заторів. (Ціна 10грн)";
                if (p.isDrunk && p.DrunkLevel >= 2)
                    Description += " Головне, щоб в дорозі не захитало.";
            }
            else
            {
                Description = $"Це якась помилка, ти маєш бути і так вдома. Баг!";
            }

            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Додому на автобусі";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            #region Weekend morning
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            #endregion

            #region Weekend evening
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            #endregion

            #region Workday morning
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            #endregion

            #region Para1
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            #endregion

            #region Para2
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            #endregion

            #region Para3
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            #endregion

            #region Workday evening
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            #endregion
        }
    }
}
