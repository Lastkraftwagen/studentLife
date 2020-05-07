using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Learning
{
    public class MakeLaba : BaseEvent
    {
        public MakeLaba()
        {
            ID = 17;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            if(p.Place == PlaceType.Universitat)
            {
                throw new NotImplementedException();
            }
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string Description = "Робити лабораторні - найважливіше в універі! ";
            if (!p.IsOkWithLabs)
            {
                if (time.dayOfWeek == DayOfWeek.Saturday || time.dayOfWeek == DayOfWeek.Sunday)
                {
                    Description += "Краще зроби наперед, на тижні завал буде. ";
                }
                else
                {
                    if (time.Description == Constant.PARA_2)
                    {
                        Description += "Останній шанс - наступна пара вже захист."; ;
                    }
                    else
                    {
                        Description += "Вже прям піджимає, треба встигнути до лабораторної!";
                    }
                }
            }
            else
            {
                Description += "На цей тиждень лаба вже готова, але завжди " +
                    "можна зробити наперед.";
            }
            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Робити лабораторну";
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
                Day = Constant.WEEKEND_EVENING,
                Place = PlaceType.Home,
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
                Day = Constant.PARA_1,
                Place = PlaceType.Universitat,
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
                Place = PlaceType.Universitat,
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
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
