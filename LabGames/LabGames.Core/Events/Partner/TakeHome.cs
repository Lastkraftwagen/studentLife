using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Partner
{
    [Serializable]
    public class TakeHome : BaseEvent
    {
        public TakeHome()
        {
            ID = 38;
            this.CreateConditions();
        }

        int cost = 50;
        public override bool Execute(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчина" : "хлопець";
            string withPartner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";

            if (time.isLearningTime)
            {
                Random r = new Random();
                if(r.Next(0, 4) == 0)
                {
                    this.EventText.Add($"{partner} відмовляється їхати, бо треба йти на пари" +
                        $" і {p.Name} залишається сам.");
                    p.Place = p.Place == PlaceType.Home ? PlaceType.Home : PlaceType.Outside;
                    p.Company = CompanyType.Alone;
                    return false;
                }
            }
            if (p.Company == CompanyType.WithGF)
            {
                this.EventText.Add($"{p.Name} з {withPartner} приїжджають додому.");
            }
            else
            {
                this.EventText.Add($"{partner} приїжджає додому.");
            }
            p.Place = PlaceType.Home;
            p.Company = CompanyType.WithGF;
            p.DistanceFromUniver = DistanceType.Medium;
            p.ChangeMoney(-cost);
            return false;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
            if (p.Place == PlaceType.Home)
            {
                return $"Завжди веселіше знаходитися вдома не самому. З {partner}" +
                    $" {p.Name} може весело провести час і покращити стосунки.";
            }
            else
            {
                string Description =  $"Відправитися з {partner} додому на таксі. ";
                Random r = new Random();
                if (p.DistanceFromHome == DistanceType.Large)
                {
                    cost = 150 + r.Next(-40, 40);
                    Description += $"(Звідси буде коштувати {cost} грн)";
                }
                else if (p.DistanceFromHome == DistanceType.Medium)
                {
                    cost = 50 + r.Next(40);
                    Description += $"(Звідси буде коштувати {cost} грн)";
                }
                else
                {
                    cost = 20 + r.Next(5);
                    Description += $"Звідси буде коштувати {cost} грн. Але, насправді, пішки тут 5 хвилин.";
                }
                return Description;
            }
        }

        public override string GenerateName(Player p, DayStep time)
        {
            if (p.Place == PlaceType.Home)
            {
                string partner = p.Gender == GenderType.Man ? "дівчину" : "хлопця";
                return $"Запросити {partner} додому";
            }
            else
            {
                string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
                return $"Відправитися з {partner} додому на таксі";
            }
        }

        protected override void CreateConditions()
        {
            this.Conditions.Clear();
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


        }
    }
}
