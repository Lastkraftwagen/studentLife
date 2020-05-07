using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Friends
{
    class DrinkWithFriends : BaseEvent
    {
        public DrinkWithFriends()
        {
            ID = 11;
            Random r = new Random();
            int n = r.Next(0, 7);
            switch (n)
            {
                case 1:
                    BarName = "Лемберг";
                    break;
                case 2:
                    BarName = "Сто рентген";
                    break;
                case 3:
                    BarName = "Крафт";
                    break;
                case 4:
                    BarName = "Ноїв ковчег";
                    break;
                case 5:
                    BarName = "Лінивий пес";
                    break;
                case 0:
                    BarName = "Велика тарілка";
                    break;
                case 6:
                    BarName = "Андеграунд";
                    break;
                default:
                    break;
            }
            this.CreateConditions();
        }

        string BarName = "Bar";

        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Clear();
            string withFriends = p.Gender == GenderType.Man ? "з хлопцями" : "з дівчатами";
            p.DistanceFromHome = DistanceType.Medium;
            p.ChangeFollowerRait(-5);
            if (p.Place == PlaceType.Place && p.Company == CompanyType.WithFriends)
            {
                EventText.Add($"Після недовгих перемовин {withFriends} було " +
                    $"вирішено продовжувати гуляння!.");
                if (time.isLearningTime)
                    p.ChangeOP(-5);
                p.ChangePower(-5);
                p.ChangeFollowerRait(-5);
                p.ChangeHappines(17);
                EventText.Add(p.GetDrunk(1));
                p.ChangeFriendsRait(20);
                return true;
            }
            else
            {
                if (time.partOfDay == PartOfDay.Evening)
                {
                    EventText.Add($"Починається вечірня вилазка " +
                        $"{withFriends} в {BarName}.");
                }
                else if (time.partOfDay == PartOfDay.Night)
                {
                    EventText.Add($"Це буде весела нічка " +
                        $"{withFriends} в {BarName}!");
                }
                else
                {
                    EventText.Add($"Гайда " +
                        $"{withFriends} в {BarName}!");
                }
                p.ChangePower(-10);

                EventText.Add(p.Gender == GenderType.Man ? $"{p.Name} {withFriends} " +
                    $"весело гуляє в барі, пиво ллється рікою а веселі історії, " +
                    $"здається, не закінчаться ніколи! {Resource.PLUS_HAPPY} {Resource.PLUS_FRIENDS}"
                    : $"{p.Name} {withFriends} п'ють вино, обговорюють важливі теми та оцінюють" +
                    $"");
                EventText.Add(p.GetDrunk(1));
                p.Company = CompanyType.WithFriends;
                p.Place = PlaceType.Place;
                p.ChangeHappines(10);
                p.ChangeFriendsRait(10);
                p.ChangeFollowerRait(-5);
                return false;
            }

        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description = "";
            if (p.Gender == GenderType.Man)
            {
                Description = "Чому б не відвідати бар з друзями, забивши на все?" +
                              " Настрій одразу підіймається за баночкою хмільного, " +
                              " в компанії друзів відчуваєш себе прекрасно!";
            }
            else
            {
               
                Description = "Чому б не відвідати кафешку з дівчатками, забивши на все?" +
                              " Може потім ще в караоке заскочимо, якщо грошей вистачить.";
            }

            if (time.isLearningTime)
                Description += " Чорт з ними, з тими парами. Вчитель не помітить моєї відсутності. " +
                               " Чи помітить..?";
            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            string action = (p.Place == PlaceType.Place && p.Company == CompanyType.WithFriends) ?
                "Продовжити сидіти " : "Погуляти ";
            return p.Gender == GenderType.Woman ? $"{action} з дівчатками в кафе" : $"{action} з друзями в барі";
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
