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

namespace LabGames.Core.Scene
{
    class ChapterA : Chapter
    {

        public ChapterA()
        {
            this.ChapterEvents.Add(new SleepMore());
            this.ChapterEvents.Add(new WalkWithPartner());
            this.ChapterEvents.Add(new GoToCafe());
            this.ChapterEvents.Add(new GoToCinema());
            this.ChapterEvents.Add(new WatchInformativeVideos());
            this.ChapterEvents.Add(new TakeHome());
            this.ChapterEvents.Add(new SayGoodbye());
            this.ChapterEvents.Add(new WatchSeries());
            this.ChapterEvents.Add(new DoWhatLove());
            this.ChapterEvents.Add(new DoSex());
            this.ChapterEvents.Add(new TakeHomeOnBus());
            this.ChapterEvents.Add(new TakeHomeOnFoot());
            this.ChapterEvents.Add(new ReadLections());
            this.ChapterEvents.Add(new MakeLaba());
            this.ChapterEvents.Add(new StudyHard());
            this.ChapterEvents.Add(new MakePractice());
            this.ChapterEvents.Add(new DoMorningExercises());
            this.ChapterEvents.Add(new WalkAlone());
            this.ChapterEvents.Add(new WalkWithFriends());
            this.ChapterEvents.Add(new DrinkWithFriends());
            this.ChapterEvents.Add(new HobbyReading());
            this.ChapterEvents.Add(new HobbySport());
            this.ChapterEvents.Add(new GoHomeWithBus());
            this.ChapterEvents.Add(new GoHomeOnTaxi());
            this.ChapterEvents.Add(new GoHomeOnFoot());
        }
        
        public override List<EventModel> GetChapterEventModels(Player player, TimeManager time)
        {
            List<EventModel> result = new List<EventModel>();
            foreach (var item in ChapterEvents)
            {
                if (item.IsExecutable(time.CurrentStep, player))
                    result.Add(new EventModel()
                    {
                        id = item.ID,
                        description = item.GenerateDescription(player,time.CurrentStep),
                        name = item.GenerateName(player, time.CurrentStep)
                    });
            }
            return result;
        }
    }
}
