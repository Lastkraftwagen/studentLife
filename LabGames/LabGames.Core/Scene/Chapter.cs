using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LabGames.Core.Scene
{
    [Serializable]
    public abstract class Chapter
    {
        public BaseEvent SelectedEvent;

        public List<BaseEvent> ChapterEvents = new List<BaseEvent>();
        protected List<List<int>> combineAble = new List<List<int>>();
        public Chapter()
        {
            List<int> goHome = new List<int>();
            goHome.Add(4);
            goHome.Add(7);
            goHome.Add(36);

            List<int> hobby = new List<int>();
            hobby.Add(3);
            hobby.Add(5);
            hobby.Add(24);

            List<int> girl = new List<int>();
            girl.Add(10);
            girl.Add(16);
            girl.Add(12);

            List<int> goStudy = new List<int>();
            goStudy.Add(21);
            goStudy.Add(22);
            goStudy.Add(30);

            List<int> study = new List<int>();
            study.Add(6);
            study.Add(19);
            study.Add(18);

            combineAble.Add(goHome);
            combineAble.Add(hobby);
            combineAble.Add(girl);
            combineAble.Add(goStudy);
            combineAble.Add(study);
        }

        public BaseEvent SelectEvent(int id)
        {
            return this.ChapterEvents.Where(x => x.ID == id).FirstOrDefault();  
        }

        public abstract List<EventModel> GetChapterEventModels(Player player, TimeManager time);
        public abstract List<string> ExecuteSpecialEvents(Player player, TimeManager time);
    }
}