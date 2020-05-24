using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Hobby
{
    class HobbyReading : BaseEvent
    {
        public HobbyReading()
        {
            ID = 5;
            Random r = new Random();
            int n = r.Next(0,6);
            switch (n)
            {
                case 1:
                    BookName = "\"Мартин Бараболя\"";
                    break;
                case 2:
                    BookName = "\"Хіба реве студент, як залік здано?\"";
                    break;
                case 3:
                    BookName = "\"Груша всохла\"";
                    break;
                case 4:
                    BookName = "\"Він вона воно (Романтика)\"";
                    break;
                case 5:
                    BookName = "\"Котолови\"";
                    break;
                case 0:
                    BookName = "\"Ти знаєш, що ти за людина?\"";
                    break;
                default:
                    break;
            }
            
            CreateConditions();
        }

        string BookName = "";

        public override bool Execute(Player p, DayStep time)
        {
            p.ChangeFriendsRait(-7);
            p.ChangeFollowerRait(-7);
            this.EventText.Add($"Час поринути у світ книжок.");
            if (time.isLearningTime)
            {
                p.ChangeOP(-5);
            }
            if (p.isDrunk) {
                if (p.DrunkLevel > 2)
                {
                    this.EventText.Add($"П'яним важно зусередитися на сюжеті. {Resource.MINUS_ENERGY}");
                    p.ChangeHappines(10);
                    this.EventText.Add($"Авхахахаха бязь вахвахвах шо це таке?)) {Resource.PLUS_HAPPY}");
                    this.EventText.Add($"Авхахахаха бязь вахвахвах шо це таке?)) {Resource.PLUS_ENERGY}");
                    p.ChangePower(-10);
                    p._speek += 1;
                }
                else
                {
                    this.EventText.Add($"Не треба було до того братися у такому стані..." +
                        $" {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
                    p.ChangePower(-10);
                    p.ChangeHappines(-10);
                }
                this.EventText.Add(p.ResetDrunk(1));
            }
            else
            {
                p.ChangeHappines(10);
                p.ChangePower(-5);
                p._intelligence += 1;
                p._speek += 1;
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description = "";
            string ending = p.Gender == GenderType.Man ? "в" : "ла";
            if (p.isDrunk)
            {
                Description = $"Йой ти шо з глузду з'їха{ending} - читати? Перед очима все пливе.";
                if (time.isLearningTime)
                {
                    switch (time.Description)
                    {
                        case Constant.PARA_1:
                            Description += $" Лекцію вже пропусти{ending}, може до практики отверезієш...";
                            break;
                        case Constant.PARA_2:
                            Description += $" Як би то отверезіти до лаби, чи може чорт з ним?";
                            break;
                        case Constant.PARA_3:
                            Description += $" Пити всередині дня було поганою ідеєю - лаба пропущена";
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Description = "Читання сприяє саморозвитку, розширенню словникового запасу та ";
                Description += p.Gender == GenderType.Man ? "популярності у дівчат." : "визнанню у хлопців.";
                if (time.isLearningTime)
                    Description += "<br>Але краще, мабуть, було б відвідати пари зараз.";
            }
            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Читати " + BookName;
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
