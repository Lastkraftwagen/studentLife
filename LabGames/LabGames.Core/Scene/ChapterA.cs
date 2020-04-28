using LabGames.Core.Events;
using LabGames.Core.Events.Learning;
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
            this.ChapterEvents.Add(new ReadLections());
            this.ChapterEvents.Add(new MakeLaba());
            this.ChapterEvents.Add(new StudyHard());
            this.ChapterEvents.Add(new MakePractice());
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
                        description = "description",
                        name = item.EventText
                    });
            }
            return result;
        }
    }
}
