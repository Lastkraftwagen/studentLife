using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    class WalkAlone : BaseEvent
    {
        public WalkAlone()
        {
            ID = 9;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Clear();
            p.Company = CompanyType.Alone;
            p.DistanceFromUniver = DistanceType.Medium;
            this.EventText.Add($"{p.Name} відправляється гуляти по місту.");
            if (p.Place == PlaceType.Home)
            {
                p.DistanceFromHome = DistanceType.Low;
                this.EventText.Add($"Парк неподалік від гуртожитків - непоганий вибір.");
            }
            else
            {
                p.DistanceFromHome = DistanceType.Medium;
                this.EventText.Add($"Під час гульок зайшов далеченько - аж на погулянку.");
            }
            p.Place = PlaceType.Outside;
            if (p.isDrunk)
            {
                if (p.DrunkLevel >= 2)
                {
                    this.EventText.Add("Хех класс, на вулиці чотко. " +
                        $"Авхвхвхвх, гуси)) Гуси в озері авхахах. {Resource.PLUS_HAPPY}");
                    p.ChangeHappines(12);
                }
                this.EventText.Add(p.ResetDrunk(1));
                this.EventText.Add($"Фух ходити п'яним тяжко-важко якось... {Resource.MINUS_ENERGY}");
            }
            else
            {
                this.EventText.Add($"Погода чудова і на душі приємно. {Resource.PLUS_HAPPY} ");
                p.ChangeHappines(10);
                this.EventText.Add($"Непогано так пройшов насправді. Не один кілометр, і навіть не два. {Resource.MINUS_ENERGY}");
            }
            p.ChangeFriendsRait(-5);
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
            string Description =  "А чому б і ні?";
            if(time.partOfDay == PartOfDay.Morning)
            {
                Description += "Ранкова прогулянка сповнює сил і покращує " +
                    "настрій. Головне - щоб погода була хороша.";
            }
            else if(time.partOfDay == PartOfDay.Evening)
            {
                Description += "Ввечері на вулиці свіжо і тихо, якщо любиш " +
                    "спокійні прогулянки наодинці - те, що треба. Настрій " +
                    "покращить і надасть сил.";
            }
            else
            {
                Description += "Ну звичайно, час може і не найкращий, проте" +
                    " настрій і запас сил точно покращиться.";
            }

            if (time.isLearningTime)
            {
                Description += " От тільки пари зараз ідуть. Знаєш, викладачі" +
                    " чомусь ой як не люблять коли їх пари пропускають";
            }

            return Description;
            
        }

        public override string GenerateName(Player p, DayStep time)
        {
            if (p.Company == CompanyType.Alone && p.Place == PlaceType.Outside)
                return "Продовжити гуляти";
            return "Прогулятися по вулиці";
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
        }
    }
}
