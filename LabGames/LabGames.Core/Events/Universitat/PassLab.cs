using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Universitat
{
    [Serializable]
    internal class PassLab : BaseEvent
    {
        public PassLab()
        {
            ID = 23;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            p.ChangeHappines(-5);
            p.ChangePower(-5);
            p.ChangeFriendsRait(-2);
            p.ChangeFollowerRait(-2);
            p.ChangeOP(5);
            Laba lab = p.Labs[p.Labs.Where(x => x.Passed == true).Count()];
            if(lab.Progress == LabaProgress.NotStarted)
            {
                this.EventText.Add("Здавати повністю не готову лабораторну - " +
                    "погана ідея. Треба було хоча б почитати про що вона.");
                this.EventText.Add("Викладач завернув лабу і навіть нуля " +
                    $"не поставив - потрібно буде здавати ще раз. {Resource.MINUS_TEACHER}");
                p.ChangeOP(-3);
            }
            else if(lab.Progress == LabaProgress.Started)
            {
                this.EventText.Add("Добре, що вийшло хоч як-небудь приготуватися, оцінка - 2/10");
                this.EventText.Add($"Викладачі люблять більш підготовлених студентів. {Resource.MINUS_TEACHER}");
                p.ChangeOP(-1);
            }
            else if (lab.Progress == LabaProgress.Half)
            {
                this.EventText.Add("Добре, що вийшло хоч як-небудь приготуватися, оцінка - 5/10");
                this.EventText.Add($"Доволі непогано викручуючись, вдалося впевнити " +
                    $"викладача в наявності деяких знань в цій макітрі. {Resource.PLUS_TEACHER}");
                p.ChangeOP(1);
            }
            else if (lab.Progress == LabaProgress.Ready)
            {
                this.EventText.Add("Повністю робоча і доведена до ідеалу лаба здається на ура! - 10/10");
                this.EventText.Add($"Викладач був явно вражений якістю підготовки. {Resource.PLUS_TEACHER}");
                p.ChangeOP(5);
            }
            lab.PassLab();
            p.CurrentLaba = p.Labs[p.Labs.Where(x => x.Passed == true).Count()];
            p.Place = PlaceType.Outside;
            p.Company = CompanyType.Alone;
            p.DistanceFromUniver = DistanceType.Low;
            p.DistanceFromHome = DistanceType.Medium;
            return true;

        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Здавати лабораторну";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Здавати лабораторну";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.PARA_3,
                Place = PlaceType.Universitat,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
