using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Movement
{
    class GoHomeOnFoot: BaseEvent
    {
        public GoHomeOnFoot()
        {
            ID = 4;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Clear();
            if (p.DistanceFromHome == DistanceType.Home)
            {
                this.EventText.Add($"Це якась помилка, ти маєш бути і так вдома. Баг!");
                return false;
            }

            p.Place = PlaceType.Home;
            p.Company = CompanyType.Alone;
            switch (p.DistanceFromHome)
            {
                case DistanceType.Low:
                    p.ChangePower(-5);
                    p.DistanceFromHome = DistanceType.Home;
                    this.EventText.Add($"{p.Name} вдома.");
                    return false;
                case DistanceType.Medium:
                    p.ChangePower(-10);
                    p.ChangeHappines(-5);
                    if (p.isDrunk)
                        this.EventText.Add(p.ResetDrunk(1));
                    p.DistanceFromHome = DistanceType.Home;
                    this.EventText.Add($"{p.Name} трохи втомлюється по дорозі додому." +
                        $" {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
                    return false;
                case DistanceType.Large:
                    p.ChangePower(-20);
                    p.ChangeHappines(-10);
                    p.DistanceFromHome = DistanceType.Home;
                    if (p.isDrunk)
                        this.EventText.Add(p.ResetDrunk(2));
                    this.EventText.Add($"{p.Name} виснажується від такої довгої подорожі." +
                        $" {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
                    if (time.isLearningTime)
                    {
                        p.ChangeOP(-10);
                    }
                    return true;
                default:
                    return false;
            }

        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description;
            if(p.DistanceFromHome == DistanceType.Low)
            {
                Description = "Оптимальний варіант, будеш вдома за 5 хвилин.";
            }
            else if(p.DistanceFromHome == DistanceType.Medium)
            {
                Description = "Ну тут немало йти доведеться. Втомишся дуже і часу багато забере.";
            }
            else if(p.DistanceFromHome == DistanceType.Large)
            {
                Description = $"{p.Name} дуже далеко від дому, часу і сил піде багато.";
            }
            else
            {
                Description = $"Це якась помилка, ти маєш бути і так вдома. Баг!";
            }

            if (p.isDrunk)
                Description += " По дорозі отверезієш трохи.";

            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Відправитися додому пішки";
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

            #region Night
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
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
