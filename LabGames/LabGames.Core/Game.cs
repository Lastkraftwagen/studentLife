using LabGames.Core.Events.Base;
using LabGames.Core.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core
{
    public class Game
    {
        public Player p;
        public TimeManager TimeManager;
        private int iteration = 0;
        List<Chapter> chapters = new List<Chapter>();
        public Game()
        {
            TimeManager = new TimeManager();
            for (int i = 0; i < 5; i++)
            {
                chapters.Add(new ChapterA());
            }
        }

        public List<EventModel> GetCurrentEvents()
        {
            Chapter scene = chapters[iteration];
            return scene.GetChapterEventModels(p, TimeManager);
        }

        public void ExecuteEvent(int Id)
        {
            Chapter scene = chapters[iteration];
            BaseEvent baseEvent = scene.SelectEvent(Id);
            if (baseEvent.IsExecutable(TimeManager.CurrentStep, p))
            {
                bool executed = baseEvent.Execute(p);
                if (executed)
                {
                    string result = baseEvent.EventText;
                }
                else
                {

                }
            }
             //iteration++;
        }



    }
}
