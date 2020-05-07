using LabGames.Core.Events.Base;
using System.Collections.Generic;
using System.Linq;

namespace LabGames.Core.Scene
{
    public abstract class Chapter
    {
        public BaseEvent SelectedEvent;

        public List<BaseEvent> ChapterEvents = new List<BaseEvent>();
        public Chapter()
        {
        }

        public BaseEvent SelectEvent(int id)
        {
            return this.ChapterEvents.Where(x => x.ID == id).FirstOrDefault();  
        }

        public abstract List<EventModel> GetChapterEventModels(Player player, TimeManager time);
    }
}