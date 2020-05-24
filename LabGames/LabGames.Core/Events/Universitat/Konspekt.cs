using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Universitat
{
    [Serializable]
    internal class Konspekt : BaseEvent
    {
        public Konspekt()
        {
            ID = 32;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            EventText.Clear();
            EventText.Add($"{p.Name} уважно законспектовує за вчителем.");
            p.ChangeFollowerRait(3);
            p.ChangeFriendsRait(3);
            p.ChangePower(-8);
            p.ChangeHappines(-8);
            if (!p.isDrunk)
            {
                if (time.Description == Constant.PARA_1)
                {
                    p.Theory += 20;
                    this.EventText.Add($"Так усердно вчитися - " +
                        $"дуже корисно для навчального прогресу. {Resource.PLUS_THEORY}");
                }
                else
                {
                    p.Theory += 2;
                    p.Practic += Convert.ToUInt32(10 + p.Theory / 10);
                    this.EventText.Add($"Так усердно вчитися дуже корисно для" +
                        $" навчального прогресу. {Resource.PLUS_PRACTICE}");
                    this.EventText.Add($"Завдяки теоретичним знанням прогресс практики підвищено на {p.Theory / 10}.");
                }
                EventText.Add($"Вчителю подобається подібна поведінка. {Resource.PLUS_TEACHER}");
                p.ChangeOP(10);
            }
            else
            {
                this.EventText.Add($"П'яним це не так просто... {Resource.MINUS_ENERGY}");
                p.ChangePower(-5);
                if (p.DrunkLevel <= 2)
                {
                    if (time.Description == Constant.PARA_1)
                    {
                        p.Theory += 15;
                        this.EventText.Add($"Долаючи непереборну жагу відволікатися {p.Name} " +
                            $"намагається конспектувати. Наступного разу краще робити це на " +
                            $"тверезу голову {Resource.PLUS_THEORY}");
                    }
                    else
                    {
                        p.Practic += Convert.ToUInt32(7 + p.Theory / 10);
                        this.EventText.Add($"Долаючи непереборну жагу відволікатися {p.Name} " +
                             $"намагається конспектувати. Наступного разу краще робити це на " +
                             $"тверезу голову {Resource.PLUS_THEORY}");
                        this.EventText.Add($"Завдяки теоретичним знанням прогресс практики підвищено на {p.Theory / 10}.");
                    }
                    EventText.Add($"Вчитель бачить як сильно старається {p.Name}. {Resource.PLUS_TEACHER}");
                    p.ChangeOP(7);
                }
                else
                {
                    p.ChangeHappines(-5);
                    this.EventText.Add($"В такому стані всі зусилля хоч щось вивчити були марні. {Resource.MINUS_HAPPY}");
                    EventText.Add($"Вчителю приємно бачити студента на парі. {Resource.PLUS_TEACHER}");
                    p.ChangeOP(5);
                }
                this.EventText.Add(p.ResetDrunk(1));
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Завжди приємно бути найкращим учнем, так?";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Писати конспект";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_1,
                Place = PlaceType.Universitat,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_2,
                Place = PlaceType.Universitat,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
