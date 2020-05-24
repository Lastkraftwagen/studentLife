using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Movement
{
    [Serializable]
    public class GoStudyOnFoot : BaseEvent
    {
        public GoStudyOnFoot()
        {
            ID = 21;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Clear();
            if (p.DistanceFromUniver == DistanceType.InPlace)
            {
                this.EventText.Add($"Це якась помилка, ти маєш бути і так на парах. Баг!");
                return false;
            }

            p.Place = PlaceType.Universitat;
            p.DistanceFromHome = DistanceType.Medium;
            p.Company = CompanyType.Alone;
            switch (p.DistanceFromUniver)
            {
                case DistanceType.Low:
                    p.ChangePower(-2);
                    p.DistanceFromUniver = DistanceType.InPlace;
                    this.EventText.Add($"{p.Name} приходить на пари.");
                    if (time.partOfDay == PartOfDay.Morning)
                        EventText.Add($"До пар ще є час - можна чимось позайматись.");
                    return false;
                case DistanceType.Medium:
                    p.ChangePower(-7);
                    p.ChangeHappines(-5);
                    if (p.isDrunk)
                        this.EventText.Add(p.ResetDrunk(1));
                    this.EventText.Add($"{p.Name} трохи втомлюється по дорозі." +
                        $" {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
                    if(time.isLearningTime)
                    {
                        EventText.Add($"Викладач дуже красномовно одним лиш поглядом дав зрозуміти, " +
                            $"що йому не сподобалося це запізнення.");
                        p.ChangeOP(-5);
                    }
                    p.DistanceFromUniver = DistanceType.InPlace;
                    return false;
                case DistanceType.Large:
                    p.ChangePower(-15);
                    p.ChangeHappines(-8);
                    p.ChangeFollowerRait(-3);
                    if (p.isDrunk)
                        this.EventText.Add(p.ResetDrunk(2));
                    this.EventText.Add($"{p.Name} виснажується від такої довгої подорожі." +
                        $" {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
                    if (time.isLearningTime)
                    {
                        p.ChangeOP(-10);
                    }
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
                Description = "Оптимальний варіант, будеш вдома за 5 хвилин.";
            }
            else if (p.DistanceFromUniver == DistanceType.Medium)
            {
                if(time.partOfDay == PartOfDay.Morning)
                    Description = "Вийдеш прямо зараз - встигнеш як раз до початку пар.";
                else
                    Description = "Тут йти хвилин 30, а пара вже йде. Сподіваємося, " +
                        "нічого не пропустиш серйозного?";
            }
            else if (p.DistanceFromUniver == DistanceType.Large)
            {
                Description = $"{p.Name} дуже далеко від універу, часу і сил піде багато. " +
                    $"Будеш на початку наступної пари.";
            }
            else
            {
                Description = $"Це якась помилка, ти маєш бути і так на парах. Баг!";
            }

            if (p.isDrunk && p.DistanceFromHome != DistanceType.Low)
                Description += " По дорозі отверезієш трохи.";

            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "На навчання пішки";
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
