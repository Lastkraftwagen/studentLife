using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Movement
{
    public class GoHomeOnTaxi : BaseEvent
    {
        public GoHomeOnTaxi()
        {
            ID = 36;
            this.CreateConditions();
        }

        int cost = 50;

        public override bool Execute(Player p, DayStep time)
        {
            p.Place = PlaceType.Home;
            p.DistanceFromHome = DistanceType.Home;
            p.Company = CompanyType.Alone;
            p.ChangeMoney(-cost);
            p.ChangeFriendsRait(-2);
            string w = p.Gender == GenderType.Man ? "приїхав" : "приїхала";
            this.EventText.Add($"{p.Name} {w} до дому на таксі.");
            p.ChangeFollowerRait(-2);
            if (time.isLearningTime)
            {
                p.ChangeOP(-10);
            }
            return false;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description =  "Найшвидший спосіб дістатися туди, куди треба.";
            Random r = new Random();
            if(p.DistanceFromHome == DistanceType.Large)
            {
                cost = 150 + r.Next(-40, 40);
                Description += $"(Звідси буде коштувати {cost} грн)";
            }
            else if(p.DistanceFromHome == DistanceType.Medium)
            {
                cost = 50 + r.Next(40);
                Description += $"(Звідси буде коштувати {cost} грн)";
            }
            else
            {
                cost = 20 + r.Next(5);
                Description += $"(Звідси буде коштувати {cost} грн. Але, насправді, пішки тут 5 хвилин.";
            }

            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Додому на таксі";
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
