using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Hobby
{
    internal class HobbyGames : BaseEvent
    {
        public HobbyGames()
        {
            ID = 24;
            Random r = new Random();
            int n = r.Next(0, 5);
            switch (n)
            {
                case 1:
                    GameName = "\"Dota 2\"";
                    break;
                case 2:
                    GameName = "\"CS GO\"";
                    break;
                case 3:
                    GameName = "\"World Of Tanks\"";
                    break;
                case 4:
                    GameName = "\"Apex Legends\"";
                    break;
                case 0:
                    GameName = "\"Civilization 6\"";
                    break;
                default:
                    break;
            }
            this.CreateConditions();
        }

        string GameName = "";

        public override bool Execute(Player p, DayStep time)
        {
            p.ChangeFriendsRait(7);
            p.ChangeFollowerRait(-5);
            this.EventText.Add($"{p.Name} з друзями заходить в {GameName}");
            if (time.isLearningTime)
            {
                p.ChangeOP(-5);
            }
            if (p.isDrunk)
            {
                if (p.DrunkLevel <= 2)
                {
                    this.EventText.Add($"Авхахаххах, всю гру Роман сповіщав місцезнаходження" +
                        $" ворогів з виключеним мікрофоном)) {Resource.PLUS_FRIENDS}");
                    this.EventText.Add($"Злили гру, проте все одно весело.  {Resource.PLUS_HAPPY} ");
                    p.ChangeHappines(10);
                    this.EventText.Add($"Від всього цього мерехтіння перед " +
                        $"очима {p.Name} відчуває втому. {Resource.PLUS_ATTENTION} {Resource.MINUS_ENERGY}");
                    p.ChangePower(-10);
                    p._attention += 1;
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
                this.EventText.Add($"О ГОСПОДИ БОЖЕ! Які дива витворяє {p.Name}, " +
                    $"граючи на  клавіатурі як на піаніно! " +
                    $"{Resource.PLUS_AGILITY} {Resource.PLUS_ATTENTION}");
                this.EventText.Add($"Клас, вінрейт сьогодні більш ніж задовільний. {Resource.PLUS_HAPPY}");
                this.EventText.Add($"Очі і спина поболюють після довгого сидіння. {Resource.MINUS_ENERGY}");
                p.ChangeHappines(10);
                p.ChangePower(-10);
                p._attention += 1;
                p._agility+= 1;
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Комп'ютерні ігри підвищують увагу, спритність, покращують" +
                " відносини з друзями. Але головне - вони завжди веселі.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Грати в комп'ютерні ігри";
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
