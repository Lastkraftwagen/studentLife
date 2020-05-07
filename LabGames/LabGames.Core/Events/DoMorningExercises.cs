using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    public class DoMorningExercises : BaseEvent
    {
        public DoMorningExercises() 
        {
            ID = 2;
            this.CreateConditions();
        }

    
        public override bool Execute(Player p, DayStep time)
        {
            string text;
            if (p.isDrunk)
            {
                this.EventText.Add($"Зайняття спортом на п'яну голову було поганою ідеєю. {Resource.MINUS_HAPPY}");
                text = p.Gender == GenderType.Man ? "Всього від десяти віджимань " +
                    $"{p.Name} починає відчувати нудоту і буквально чує власне сердцебиття! {Resource.MINUS_ENERGY}" 
                    : $"Під час розтяжки, {p.Name} потягнула зв'язки, забилася об край столу, та вирішила " +
                    $"зупинитися, відчувши присмак вчорашньої їжі у роті. {Resource.MINUS_ENERGY}";
                this.EventText.Add(text);
                p.ChangePower(-10);
                p.ChangeHappines(-10);
                return false;
            }
            this.EventText.Add($"Зайняття спортом робить щасливим. {Resource.PLUS_HAPPY}");
            this.EventText.Add($"{p.Name} підвищує спортивні навички. (+1)");
            if (p._power < 5)
            {
                this.EventText.Add($"Заняття спортом трохи втомлює. {Resource.MINUS_ENERGY}");
                p.ChangePower(-10);
            }
            else
            {
                string pronoun = p.Gender == GenderType.Man ? "його" : "її";
                this.EventText.Add($"{p.Name} непоганий спортсмен, і подібні навантаження" +
                    $" {pronoun} взагалі не втомлюють!");
            }
            p.ChangeHappines(10);
            p._power += 1;
            return false;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description = "";
            if (p.isDrunk)
            {
                Description = "Це була би дуже хороша ідея, якби не " +
                    "паморичилося в голові від алкоголю.";
            }
            else
            {
                if(p.Gender == GenderType.Man)
                {
                    Description = "М'язи треба тримати в тонусі: тіло не втратить форму, " +
                        "наповниться силами і енергією."; 
                }
                else
                {
                    Description = "Ранкова гімнастика дозволить наповнитися енергією і " +
                        "збереже привабливі форми тіла.";
                }
            }
            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Робити зарядку";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
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
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });

        }

    }
}
