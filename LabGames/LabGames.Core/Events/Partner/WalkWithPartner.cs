using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Partner
{
    class WalkWithPartner : BaseEvent
    {
        public WalkWithPartner()
        {
            ID = 10;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Clear();
            p.Company = CompanyType.WithGF;
            p.DistanceFromUniver = DistanceType.Medium;
            string withPartner = p.Gender == GenderType.Man ? "з дівчиною" : "з хлопцем";
            this.EventText.Add($"{p.Name} відправляється гуляти по місту {withPartner}.");
            if (p.Place == PlaceType.Home)
            {
                p.DistanceFromHome = DistanceType.Low;
                this.EventText.Add($"Парк неподалік від гуртожитків - непоганий вибір.");
            }
            else
            {
                p.DistanceFromHome = DistanceType.Medium;
                this.EventText.Add($"Під час гульок зайшли далеченько.");
            }
            p.Place = PlaceType.Outside;
            if (p.isDrunk)
            {
                if (p.DrunkLevel >= 2)
                {
                    this.EventText.Add("Хех класс, на вулиці чотко. " +
                        $"Авхвхвхвх, гуси)) Гуси в озері авхахах. {Resource.PLUS_HAPPY}");
                    p.ChangeHappines(6);
                }
                this.EventText.Add(p.ResetDrunk(1));
                this.EventText.Add($"Фух ходити п'яним тяжко-важко якось... {Resource.MINUS_ENERGY}");
            }
            else
            {
                this.EventText.Add($"Погода чудова, копманія приємна і на душі приємно. {Resource.PLUS_HAPPY} {Resource.PLUS_FOLLOWER}");
                p.ChangeHappines(5);
                this.EventText.Add($"Непогано так пройшлись насправді. Не один кілометр, і навіть не два. {Resource.MINUS_ENERGY}");
            }
            p.ChangeFriendsRait(-5);
            p.ChangeFollowerRait(10);
            p.ChangePower(-10);

            if (time.isLearningTime)
            {
                p.ChangeOP(-10);
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
            return $"Прогулятися з {partner} по вулиці";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
            return $"Прогулятися з {partner} по вулиці";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            #region Weekend Morning
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
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
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
            });
            #endregion

            #region Weekend Evening
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Outside,
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
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithGF
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            #endregion

            #region Workday Morning
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            #endregion

            #region Pares
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });

            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Outside,
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            #endregion

            #region Workday Evening
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            #endregion
        }
    }
}
