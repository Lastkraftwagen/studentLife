using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Movement
{
    public class GoStudyOnBus : BaseEvent
    {
        public GoStudyOnBus()
        {
            ID = 22;
            CreateConditions();
        }
        int cost = 10;

        private void ZatorReaction(Player p, DayStep t)
        {
            EventText.Add("Автобус потрапляє у затор, пара вже от-от почнеться," +
                           $" а {p.Name} ще на дуже серйозній відстані від корпусу! {Resource.MINUS_HAPPY}");
            EventText.Add($"{p.Name} нарешті прибуває до університету із " +
                $"запізненням. {Resource.MINUS_TEACHER}");
            p.ChangeHappines(-5);
            p.ChangeOP(-5);
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Clear();

            Random r = new Random();
            int RandomValue;
            bool Zator = false;

            RandomValue = r.Next(0, 10);

            if (time.partOfDay == PartOfDay.Morning && RandomValue < 3)
                Zator = true;
            else if(RandomValue < 2)
                Zator = true;


            p.Place = PlaceType.Universitat;
            p.DistanceFromHome = DistanceType.Medium;
            p.Company = CompanyType.Alone;
            p.ChangeMoney(-cost);

            switch (p.DistanceFromUniver)
            {
                case DistanceType.Low:
                    p.DistanceFromUniver = DistanceType.InPlace;
                    EventText.Add($"{p.Name} в університеті.");
                    if(time.partOfDay == PartOfDay.Morning)
                        EventText.Add($"До пар ще є час - можна чимось позайматись.");
                    return false;

                case DistanceType.Medium:
                    if (Zator)
                        ZatorReaction(p,time);
                    EventText.Add($"{p.Name} приїжджає до університету.");
                    if (time.partOfDay == PartOfDay.Morning)
                        EventText.Add($"До пар ще є час - можна чимось позайматись.");
                    return false;

                case DistanceType.Large:
                    EventText.Add("Половину шляху треба їхати на трамваї.");
                    EventText.Add("Трамвай успішно доїхав до центру. Звідси на автобусі.");
                    if (Zator)
                        ZatorReaction(p, time);
                    
                    if (p.DrunkLevel == 1 || p.DrunkLevel == 2)
                    {
                        EventText.Add($"В дорозі п'яне тіло почуває себе не дуже добре, " +
                            $"{p.Name} відчуває нудоту і тримається з останніх сил на поворотах. {Resource.MINUS_HAPPY}");
                        EventText.Add(p.ResetDrunk(1));
                        p.ChangeHappines(-5);
                    }
                    else if(p.isDrunk)
                    {
                        string s = p.Gender == GenderType.Man ? "його" : "її";
                        string s1 = p.Gender == GenderType.Man ? "позеленів" : "позеленіла";
                        EventText.Add($"Ох ні, оце халепа! {p.Name} аж {s1} від нудоти і {s} " +
                            $"все-таки знудило на одній із зупинок! Тепер треба чекати наступного " +
                            $"автобусу під ядовитими поглядами оточуючих. {Resource.MINUS_HAPPY}");
                        EventText.Add(p.ResetDrunk(1));
                        p.ChangeHappines(-10);
                    }
                    EventText.Add("Така довга подорож в громадському транспорті " +
                        $"виснажить кого завгодно. {Resource.MINUS_HAPPY}");
                    p.ChangeHappines(-5);
                    p.ChangeFollowerRait(-3);
                    p.DistanceFromUniver = DistanceType.InPlace;
                    return true;
                default:
                    return false;
            }
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description;
            if (p.DistanceFromUniver == DistanceType.Low)
            {
                Description = $"Можна відправитися на навчання на автобусі, " +
                    $"проте тут пішки 5 хвилин. Нашо витрачати гроші?";
            }
            else if (p.DistanceFromUniver == DistanceType.Medium)
            {
                Description = "Якщо не стане в затор, будеш на парах за 15 хвилин. (Ціна 10грн)";
                if (p.isDrunk && p.DrunkLevel >= 2)
                    Description += " Головне, щоб в дорозі не захитало.";
            }
            else if (p.DistanceFromUniver == DistanceType.Large)
            {
                    Description = $"Звідси до універу десь година, якщо без заторів. (Ціна 10грн) ";
                if(time.partOfDay != PartOfDay.Morning)
                    Description += $"На цю пару встигнути - нуль шансів, встигнеш до наступної.";
                if (p.isDrunk && p.DrunkLevel >= 2)
                    Description += " Головне, щоб в дорозі не захитало.";
            }
            else
            {
                Description = $"Це якась помилка, ти маєш бути і так в універі. Баг!";
            }

            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "На навчання на автобусі";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
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
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
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
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });

            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Outside,
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
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
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
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });

            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Outside,
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
                Place = PlaceType.Place,
                CompanyType = CompanyType.Alone
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
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
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
        }
    }
}
