using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Friends
{
    [Serializable]
    class WalkWithFriends : BaseEvent
    {
        public WalkWithFriends()
        {
            ID = 8;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Clear();

            p.Company = CompanyType.WithFriends;
            p.DistanceFromUniver = DistanceType.Medium;
            this.EventText.Add($"{p.Name} відправляється з друзями гуляти по місту.");
            if (p.Place == PlaceType.Home)
            {
                p.DistanceFromHome = DistanceType.Low;
                this.EventText.Add($"Парк неподалік від гуртожитків - непоганий вибір.");
            }
            else
            {
                p.DistanceFromHome = DistanceType.Medium;
                this.EventText.Add($"Під час гульок забрели далеченько - аж на погулянку.");
            }
            p.Place = PlaceType.Outside;
            if (p.isDrunk)
            {
                if (p.DrunkLevel >= 2)
                {
                    string variant = p.Gender == GenderType.Man ? "Андрюхи" : "Юлі";
                    this.EventText.Add("Хех класс, на вулиці чотко. " +
                        $"Авхвхвхвх, гуси)) Гуси в озері авхахах. {Resource.PLUS_HAPPY}");
                    this.EventText.Add($"Чорт його зна звідки в {variant} взявся хліб, але гусі нагодовані. {Resource.PLUS_FRIENDS}"); ;
                    p.ChangeHappines(6);
                }
                this.EventText.Add(p.ResetDrunk(1));
                this.EventText.Add($"Фух ходити п'яним тяжко-важко якось... {Resource.MINUS_ENERGY}");
            }
            else
            {
                this.EventText.Add($"Погода чудова, копманія приємна і на душі приємно. {Resource.PLUS_HAPPY} {Resource.PLUS_FRIENDS}");
                p.ChangeHappines(5);
                this.EventText.Add($"Непогано так пройшлись насправді. Не один кілометр, і навіть не два. {Resource.MINUS_ENERGY}");
            }
            p.ChangeFriendsRait(10);
            p.ChangeFollowerRait(-5);
            p.ChangePower(-10);

            if (time.isLearningTime)
            {
                p.ChangeOP(-10);
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description = "";
            Description = "Ніколи не завадить трохи погуляти," +
                         " покращити відношення з друзями та настрій," +
                         " не треба витрачати гроші та сидіти на нудних парах." +
                         " Неймовірно!";
            if (time.isLearningTime)
                Description += " Чорт з ними, з тими парами. Вчитель не помітить моєї відсутності. " +
                               " Чи помітить..?";
            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            if(p.Place == PlaceType.Outside && p.Company == CompanyType.WithFriends) 
                return "Продовжувати гуляти з друзями";
            return "Погуляти з друзями";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
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
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });

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
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });

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
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });

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
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Outside,
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
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Outside,
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
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
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
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });

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
                Place = PlaceType.Place,
                CompanyType = CompanyType.WithFriends
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_EVENING,
                Place = PlaceType.Outside,
                CompanyType = CompanyType.WithFriends
            });
        }
    }
}
