using LabGames.Core.Events;
using LabGames.Core.Events.Base;
using LabGames.Core.Events.Friends;
using LabGames.Core.Events.Hobby;
using LabGames.Core.Events.Learning;
using LabGames.Core.Events.Movement;
using LabGames.Core.Events.Partner;
using LabGames.Core.Events.Universitat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core
{
    public static class EventManager
    {
        public static List<BaseEvent> EventList = new List<BaseEvent>();
        static EventManager()
        {
            Player p = new Player()
            {
                Company = CompanyType.Alone,
                Place = PlaceType.Home
            };
            EventList.Add(new HobbyReading());
            EventList.Add(new HobbySport());
            EventList.Add(new ReadLections());
            EventList.Add(new DoMorningExercises());
            EventList.Add(new SleepMore());
            EventList.Add(new GoHomeOnFoot());
            EventList.Add(new GoHomeWithBus());
            EventList.Add(new WalkWithFriends());
            EventList.Add(new WalkAlone());
            EventList.Add(new WalkWithPartner());
            EventList.Add(new DrinkWithFriends());
            EventList.Add(new GoToCinema());
            EventList.Add(new WatchSeries());
            EventList.Add(new DoWhatLove());
            EventList.Add(new DoSex());
            EventList.Add(new GoToCafe());
            EventList.Add(new MakeLaba());
            EventList.Add(new StudyHard());
            EventList.Add(new MakePractice());
            EventList.Add(new TakeANap());
            EventList.Add(new GoStudyOnFoot());
            EventList.Add(new GoStudyOnBus());
            EventList.Add(new HelpPopleInTrouble());
            EventList.Add(new RobberPeople());
            EventList.Add(new Sleep());
            EventList.Add(new DrinkBeerAndSleep());
            EventList.Add(new PointlessStagnate());
            EventList.Add(new SleepToogether());
            EventList.Add(new ShowCityForTourists());
            EventList.Add(new GoStudyOnTaxi());
            EventList.Add(new ListenLection());
            EventList.Add(new Konspekt());
            EventList.Add(new UseSmartphone());
            EventList.Add(new SpeekWithFriends());
            EventList.Add(new ListenPractice());
            EventList.Add(new HelpPopleInTrouble());
        }
        public static BaseEvent GetEventById(int ID)
        {
            switch (ID)
            {
                case 1: return new SleepMore();
                case 2: return new DoMorningExercises();
                case 3: return new HobbySport();
                case 4: return new GoHomeOnFoot();
                case 5: return new HobbyReading();
                case 6: return new ReadLections();
                case 7: return new GoHomeWithBus();
                case 8: return new WalkWithFriends();
                case 9: return new WalkAlone();
                case 10: return new WalkWithPartner();
                case 11: return new DrinkWithFriends();
                case 12: return new GoToCinema();
                case 13: return new WatchSeries();
                case 14: return new DoWhatLove();
                case 15: return new DoSex();
                case 16: return new GoToCafe();
                case 17: return new MakeLaba();
                case 18: return new StudyHard();
                case 19: return new MakePractice();
                case 20: return new TakeANap();
                case 21: return new GoStudyOnFoot();
                case 36: return new GoHomeOnTaxi();
                default:
                    return null;
            }
        }
    }
}
