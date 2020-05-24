using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    public class WatchInformativeVideos : BaseEvent
    {
        public WatchInformativeVideos()
        {
            this.ID = 37;
            this.CreateConditions();
        }

        public override bool Execute(Player p, DayStep time)
        {
            p.ChangeFriendsRait(-5);
            p.ChangeFollowerRait(-5);
            this.EventText.Add($"{p.Name} вирішує пошукати чогось цікавого на ютубі.");
            if (time.isLearningTime)
            {
                p.ChangeOP(-5);
            }
            if (p.isDrunk)
            {
                EventText.Add("Просто безглуздо проведений час, " +
                    "на п'яну голову ніякої користі.");
                p.ChangePower(-5);
                EventText.Add(p.ResetDrunk(1));
            }
            else
            {
                Random r = new Random();
                this.EventText.Add($"Корисні поради в навчальних відео підвищують якості героя. ");
                switch (r.Next(0,6))
                {
                    case 0:
                        this.EventText.Add($"Тема цього відео " +
                            $"пересікалася з областтю, яку вивчає {p.Name}. " +
                            $"Це точно буде мати позитивні наслідки. {Resource.PLUS_INTELLIGENSE}");
                        p._intelligence += 1;
                        break;
                    case 1:
                        this.EventText.Add($"Туторіал з красномовності від зірок ютубу. " +
                           $"{Resource.PLUS_SPEEK}");
                        p._speek += 1;
                        break;
                    case 2:
                        this.EventText.Add($"Цікаві поради щодо мови тіла і поведінки. {Resource.PLUS_AGILITY}");
                        p._agility += 1;
                        break;
                    case 3:
                        this.EventText.Add($"Цікаві поради щодо мови тіла і поведінки. {Resource.PLUS_ATTENTION}");
                        p._attention += 1;
                        break;
                    case 4:
                        this.EventText.Add($"З відосів про зірок {p.Name} " +
                            $"дізнається як правильно одягатися і поводити себе на людях. {Resource.PLUS_GLAMOUR}");
                        p._glamor += 1;
                        break;
                    case 5:
                        this.EventText.Add($"Поради професійного тренера щодо правильного " +
                            $"харчування допоможуть у спорті. {Resource.PLUS_POWER}");
                        p._power += 1;
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            return "Завжди цікаво дізнатися, чим відрізняється морський котик " +
                "від морського лева, як виник Всесвіт, або просто що там " +
                "нового у блогерів. Це покращить кругосзір і допоможе вбити час " +
                "звичайно, якщо нема більш важливих справ.";
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Продивлятися пізнавальні відоси";
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
                Place = PlaceType.Universitat,
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
