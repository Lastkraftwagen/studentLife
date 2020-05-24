using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Hobby
{
    class HobbySport : BaseEvent
    {
        public HobbySport()
        {
            ID = 3;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            p.ChangeFriendsRait(-5);
            p.ChangeFollowerRait(-5);
            this.EventText.Add($"Саме час приділити увагу своєму тілу.");
            if (time.isLearningTime)
            {
                p.ChangeOP(-5);
            }
            if (p.isDrunk)
            {
                if (p.DrunkLevel <= 2)
                {
                    this.EventText.Add($"На підпитку фізичні навантаження " +
                        $"погано впливають на серце. {Resource.MINUS_ENERGY}");
                    p.ChangeHappines(10);
                    this.EventText.Add($"Дивитися в дзеркало після вправ" +
                        $"значно приємніше. {Resource.PLUS_HAPPY}");
                    string genderText = p.Gender == GenderType.Man ? "кубики пресу" : "струнка талія";
                    this.EventText.Add($"Хехехе, {genderText}, класс. {Resource.PLUS_GLAMOUR}");
                    p.ChangePower(-20);
                    p._glamor += 1;
                }
                else
                {
                    this.EventText.Add($"Не треба було до того братися у такому стані..." +
                        $" {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
                    p.ChangePower(-10);
                    p.ChangeHappines(-10);
                    return false;
                }
                this.EventText.Add(p.ResetDrunk(1));
            }
            else
            {
                this.EventText.Add($"Вправи доволі виснажливі. {Resource.MINUS_ENERGY}");
                this.EventText.Add($"Але результати того варті. {Resource.PLUS_HAPPY}");
                this.EventText.Add($"Зроби сьогодні скільки зможеш - завтра зможеш ще " +
                    $"більше. {Resource.PLUS_POWER} {Resource.PLUS_GLAMOUR}");
                p.ChangeHappines(10);
                p.ChangePower(-5);
                p._power  += 1;
                p._glamor += 1;
            }
            return true;
        }
            
        public override string GenerateDescription(Player p, DayStep time)
        {
            string people = p.Gender == GenderType.Man ? "дівчат" : "хлопців";
            string Description = "Фізичні навантаження покращують самопочуття" +
                $", підвищують настрій та популярність у {people}. ";
            if (p.isDrunk)
            {
                if (p.DrunkLevel <= 2)
                    Description += "Але треба пам'ятати, що на підпитку подібні " +
                        "вправи не дають стовідсоткового результату.";
                else
                {
                    Description = $"Серйозно? {p.Name} в такому стані " +
                        $"навіть стояти нормально не може, які вправи?";
                }
            }
            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Займатися спортом";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Home,
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
                Day = Constant.PARA_1,
                Place = PlaceType.Home,
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
                Place = PlaceType.Home,
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
        }

    }
}
