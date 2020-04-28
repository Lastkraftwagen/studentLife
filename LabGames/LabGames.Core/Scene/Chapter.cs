using LabGames.Core.Events.Base;
using System.Collections.Generic;

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
            return EventManager.GetEventById(id);
        }

        public abstract List<EventModel> GetChapterEventModels(Player player, TimeManager time);
    }
}