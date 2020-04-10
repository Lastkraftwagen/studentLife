using LabGames.Core.Events;
using LabGames.Core.Events.Base;
using LabGames.Core.Events.Friends;
using LabGames.Core.Events.Hobby;
using LabGames.Core.Events.Learning;
using LabGames.Core.Events.Movement;
using LabGames.Core.Events.Partner;
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
        public static List<BaseEvent> OutsideEventList = new List<BaseEvent>();
        public static List<BaseEvent> PlaceEventList = new List<BaseEvent>();

        static EventManager()
        {
            Player p = new Player();
            p.Company = CompanyType.Alone;
            p.Place = PlaceType.Home;
            EventList.Add(new HobbyReading(p));
            EventList.Add(new HobbySport(p));
            EventList.Add(new ReadLections(p));
            EventList.Add(new DoMorningExercises(p));
            EventList.Add(new SleepMore(p));
            EventList.Add(new GoHomeOnFoot(p));
            EventList.Add(new GoHomeWithBus(p));
            EventList.Add(new WalkWithFriends(p));
            EventList.Add(new WalkAlone(p));
            EventList.Add(new WalkWithPartner(p));
            EventList.Add(new DrinkWithFriends(p));
            EventList.Add(new GoToCinema(p));
            EventList.Add(new WatchSeries(p));
            EventList.Add(new DoWhatLove(p));
            EventList.Add(new DoSex(p));
            EventList.Add(new GoToCafe(p));
            EventList.Add(new MakeLaba(p));
            EventList.Add(new StudyHard(p));
            EventList.Add(new MakePractice(p));
            EventList.Add(new TakeANap(p));
            EventList.Add(new GoStudyOnFoot(p));
            EventList.Add(new GoStudyOnBus(p));
            EventList.Add(new HelpPopleInTrouble(p));

        }


    }
}
