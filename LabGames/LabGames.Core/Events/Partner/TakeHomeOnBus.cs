using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Partner
{
    public class TakeHomeOnBus : BaseEvent
    {
        public TakeHomeOnBus()
        {
            ID = 41;
            this.CreateConditions();
        }
        int cost = 10;

        private List<string> ZatorReaction(Player p)
        {
            string withPartner = p.Gender == GenderType.Man ? "з дівчиною" : "з хлопцем";
            List<string> reaction = new List<string>();
            if (p.FollowerRaiting < 30)
            {
                reaction.Add($"Стоячи у заторі, {p.Name} {withPartner} " +
                    $"раптово розуміють, що не мають про що поговорити, аби скоротати" +
                    $" час. Треба більше часу приділяти відносинам з другою половинкою! {Resource.MINUS_FOLLOWER}");
                p.ChangeFollowerRait(-5);
            }
            else
            {
                reaction.Add($"Довкола коптять старі ржаві брички, що їх ведуть " +
                    $"неголені втомлені водії, потік машин повзе повільніше ніж " +
                    $"годинна стрілка, бабусі кричать і сваряться, водій психує, а" +
                    $" {p.Name} {withPartner} не помічають нічого довкола, і слухають" +
                    $" одну музику на двох з телефона. Правду кажуть - з милим рай і в шалаші. {Resource.PLUS_FOLLOWER}");
                p.ChangeFollowerRait(5);
            }
            return reaction;
        }

        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Clear();

            Random r = new Random();
            int RandomValue;
            bool Zator = false;

            if (time.partOfDay == PartOfDay.Night)
                RandomValue = r.Next(0, 100);
            else
                RandomValue = r.Next(0, 10);

            if (RandomValue < 5)
                Zator = true;

            p.Place = PlaceType.Home;
            p.DistanceFromUniver = DistanceType.Medium;
            p.Company = CompanyType.WithGF;
            p.ChangeMoney(-cost);
            string withPartner = p.Gender == GenderType.Man ? "з дівчиною" : "з хлопцем";


            switch (p.DistanceFromHome)
            {
                case DistanceType.Low:
                    this.EventText.Add($"{p.Name} {withPartner} вдома.");
                    p.DistanceFromHome = DistanceType.InPlace;
                    return false;
                case DistanceType.Medium:
                    if (Zator)
                    {
                        this.EventText.AddRange(this.ZatorReaction(p));
                    }
                    p.DistanceFromHome = DistanceType.InPlace;
                    this.EventText.Add($"{p.Name} нарешті вдома.");
                    return false;
                case DistanceType.Large:
                    this.EventText.Add("Їхати треба дууууууже далеко...");
                    if (Zator)
                    {
                        this.EventText.AddRange(this.ZatorReaction(p));
                    }
                    this.EventText.Add("Така довга подорож в громадському транспорті " +
                        $"виснажить кого завгодно. {Resource.MINUS_HAPPY}");
                    p.ChangeHappines(-5);
                    p.DistanceFromHome = DistanceType.InPlace;
                    return true;
                default:
                    return false;
            }
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
                string Description = $"Відправитися з {partner} додому на таксі. ";
                Random r = new Random();
                if (p.DistanceFromHome == DistanceType.Large)
                {
                    Description += $"Звідси до дому з пересадкою" +
                    $" хвилин 40, і то якщо заторів не буде. Краще вже на таксі. " +
                    $"Закохані ж не помічають доскомфорту громадського транспорту?";
                }
                else if (p.DistanceFromHome == DistanceType.Medium)
                {
                    Description += $"(Звідси без заторів доїдете за 15хв (Ціна 10грн). " +
                    $"Закохані ж не помічають доскомфорту громадського транспорту?";
                }
                else
                {
                    Description += $"Навіщо, Але, насправді, пішки тут 5 хвилин.";
                }
                return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
            return $"Відправитися додому з {partner} на автобусі";
        }

        protected override void CreateConditions()
        {
            this.Conditions.Clear();
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
