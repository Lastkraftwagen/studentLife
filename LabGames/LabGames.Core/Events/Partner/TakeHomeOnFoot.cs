using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events.Partner
{
    [Serializable]
    class TakeHomeOnFoot : BaseEvent
    {
        public TakeHomeOnFoot()
        {
            ID = 42;
            CreateConditions();
        }

        private void PathDescription(Player p, DayStep time)
        {
            string withPartner = p.Gender == GenderType.Man ? "з дівчиною" : "з хлопцем";
            if (p.FollowerRaiting < 30)
            {
                p.ChangePower(-10);
                p.ChangeHappines(-5);
                EventText.Add($"По дорозі {p.Name} розуміє, що абсолютно не " +
                     $"знає про що поговорити {withPartner}, і це пригнічує. Треба більше " +
                     $"часу проводити разом {Resource.MINUS_HAPPY}");
                if (time.partOfDay == PartOfDay.Evening || time.partOfDay == PartOfDay.Night)
                {
                    EventText.Add("Незграбні діалоги про зоряне небо, та відстороненні фрази " +
                        $"на загальні теми - так і пройшла нічна прогулянка. {Resource.MINUS_ENERGY}");
                }
                else if (time.partOfDay == PartOfDay.Morning)
                {
                    EventText.Add($"Прохолодний ранок та такі ж самі діалоги на шляху додому. {Resource.MINUS_ENERGY}");
                }
                else
                {
                    EventText.Add($"Довгий шлях поміж людей, вулицями, провулками та дворами. Можливо, він " +
                        $"був би коротший за теплою бесідою, але відчувається деяке напруження. {Resource.MINUS_ENERGY}");
                }
                EventText.Add($"Нарешті вдома, треба терміново повертати відносини до життя!");
            }
            else
            {
                p.ChangePower(-7);
                p.ChangeHappines(5);
                p.ChangeFollowerRait(5);
                EventText.Add($"З коханою людиною поруч {p.Name} набагато менше втомлюється від " +
                    $"подібних прогулянок. Істинно: любов - це прекрасно!");
                if (time.partOfDay == PartOfDay.Evening || time.partOfDay == PartOfDay.Night)
                {
                    string streets = time.partOfDay == PartOfDay.Evening ? "вечірніми" : "нічними";
                    EventText.Add($"Під розсипом яскравих зірок, тримаючись за руки, з палаючими " +
                        $"очима і сердцями, наші закохані йдуть {streets} вулицями міста. {Resource.PLUS_HAPPY}");
                    EventText.Add(p.Gender == GenderType.Man ? $"{p.Name} бачить, що кохана змерзла, і " +
                        $"віддає свою кофтину. Банально, прохолодно, проте дівчині приємно. А що ще треба? {Resource.PLUS_FOLLOWER}"
                        :
                        $"{p.Name} трохи змерзла по дорозі. Коханий, побачивши це, відразу поділився своєю кофтиною, " +
                        $" а далі ще й купив кави. Зайка просто. {Resource.PLUS_FOLLOWER}");
                }
                else if (time.partOfDay == PartOfDay.Morning)
                {
                    EventText.Add($"В прохолодних променях ранкового сонця, збиваючи ногами краплі роси з придорожніх рослин, " +
                        $"з параючими очима і сердцями, наші закохані йдуть вулицями міста. {Resource.PLUS_HAPPY}");
                    EventText.Add(p.Gender == GenderType.Man ? $"{p.Name} бачить, що кохана змерзла, і " +
                        $"віддає свою кофтину. Банально, прохолодно, проте дівчині приємно. А що ще треба? {Resource.PLUS_FOLLOWER}"
                        :
                        $"{p.Name} трохи змерзла по дорозі. Коханий, побачивши це, відразу поділився своєю кофтиною, " +
                        $" а далі ще й купив кави. Зайка просто. {Resource.PLUS_FOLLOWER}");
                }
                else
                {
                    EventText.Add($"Наші закохані ідуть поміж людей, вулицями, провулками та дворами. Здається," +
                        $" все навколо світиться від щастя і любові, принаймні {p.Name} {withPartner} точно. {Resource.PLUS_HAPPY} {Resource.PLUS_FOLLOWER}");
                }
            }
        }
        public override bool Execute(Player p, DayStep time)
        {
            EventText.Clear();
            if (p.DistanceFromHome == DistanceType.InPlace)
            {
                EventText.Add($"Це якась помилка, ти маєш бути і так вдома. Баг!");
                return false;
            }

            p.Place = PlaceType.Home;
            p.DistanceFromUniver = DistanceType.Medium;
            p.Company = CompanyType.WithGF;

            string withPartner = p.Gender == GenderType.Man ? "з дівчиною" : "з хлопцем";
            switch (p.DistanceFromHome)
            {
                case DistanceType.Low:
                    p.ChangePower(-2);
                    p.DistanceFromHome = DistanceType.InPlace;
                    EventText.Add($"{p.Name} {withPartner} приходить додому.");
                    return false;
                case DistanceType.Medium:
                    p.DistanceFromHome = DistanceType.InPlace;
                    if (p.isDrunk)
                        EventText.Add(p.ResetDrunk(1));
                    this.PathDescription(p,time);
                    return false;
                case DistanceType.Large:
                    p.ChangePower(-10);
                    p.ChangeFriendsRait(-3);
                    if (p.isDrunk)
                        EventText.Add(p.ResetDrunk(2));
                    this.PathDescription(p, time);
                    EventText.Add($"{p.Name} виснажується від такої довгої подорожі." +
                        $" {Resource.MINUS_ENERGY} {Resource.MINUS_HAPPY}");
                    if (time.isLearningTime)
                        p.ChangeOP(-10);
                    p.DistanceFromHome = DistanceType.InPlace;
                    if (time.partOfDay != PartOfDay.Night)
                        return true;
                    return false;
                default:
                    return false;
            }
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
            string Description = $"Відправитися додому з {partner} пішки";
            if (p.DistanceFromHome == DistanceType.Low)
            {
                Description = "Оптимальний варіант, будете вдома за 5 хвилин.";
            }
            else if (p.DistanceFromHome == DistanceType.Medium)
            {
                Description = "Ну тут немало йти доведеться. " +
                    "Головне, щоб вам було комфортно одне з одним по дорозі.";
            }
            else if (p.DistanceFromHome == DistanceType.Large)
            {
                Description = $"{p.Name} зараз дуже далеко від дому, часу і сил піде багато. " +
                    $"Краще якось інакше дістатися додому.";
            }
            else
            {
                Description = $"Це якась помилка, ти маєш бути і так вдома. Баг!";
            }

            if (p.isDrunk && p.DistanceFromHome != DistanceType.Low)
            {
                Description += " По дорозі отверезієш трохи.";
            }
            return Description;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            string partner = p.Gender == GenderType.Man ? "дівчиною" : "хлопцем";
            return $"Відправитися додому з {partner} пішки";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
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
