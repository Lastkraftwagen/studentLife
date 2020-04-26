using LabGames.Core.Events.Base;

namespace LabGames.Core.Scene
{
    public class Chapter
    {
        public BaseEvent SelectedEvent;
        public Chapter()
        {
        }

        public BaseEvent SelectEvent(int id, Player p)
        {
            return EventManager.GetEventById(id, p);
        }
    }
}