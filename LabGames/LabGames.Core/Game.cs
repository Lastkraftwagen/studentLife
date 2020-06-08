using LabGames.Core.Events.Base;
using LabGames.Core.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core
{
    [Serializable]
    public class Game
    {
        public Player p;
        private TimeManager TimeManager;
        private int iteration = 0;
        public Dictionary<int, int> LabCount = new Dictionary<int, int>()
        {
            {1, 2},
            {2, 4},
            {3, 6}
        };
        public List<int> actionEventsIds = new List<int>();
        List<Chapter> chapters = new List<Chapter>();
        public Game()
        {
            TimeManager = new TimeManager();
            actionEventsIds.Add(40);
            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    chapters.Add(new ChapterA());
                    chapters.Add(new ChapterB());
                    chapters.Add(new ChapterC());
                }
                for (int i = 0; i < 5; i++)
                {
                    chapters.Add(new ChapterD());
                    chapters.Add(new ChapterE());
                    chapters.Add(new ChapterF());
                    chapters.Add(new ChapterG());
                    chapters.Add(new ChapterH());
                    chapters.Add(new ChapterC());
                }
            }
            chapters.Add(new ChapterA());
            chapters.Add(new ChapterB());
            chapters.Add(new ChapterC());
            chapters.Add(new ChapterD());
            chapters.Add(new ChapterExam());
            chapters.Add(new ChapterExam());
        }

        public List<EventModel> GetCurrentEvents()
        {
            Chapter scene = chapters[iteration];
            return scene.GetChapterEventModels(p, TimeManager);
        }

        public TimeManager GetCurrentTime()
        {
            return this.TimeManager;
        }

        public ExecutionResult ExecuteEvent(int Id)
        {
            Chapter scene = chapters[iteration];
            BaseEvent baseEvent = scene.SelectEvent(Id);
            ExecutionResult result = new ExecutionResult();
            if (baseEvent == null) return null;
            if (baseEvent.IsExecutable(TimeManager.CurrentStep, p))
            {
                bool executed = baseEvent.Execute(p, TimeManager.CurrentStep);
                if (executed)
                {
                    List<string> additional = scene.ExecuteSpecialEvents(p, TimeManager);
                    if (additional.Count > 0)
                        baseEvent.EventText.AddRange(additional);

                    if (p.DrunkLevel == 4)
                    {
                        baseEvent.EventText.Add($"{p.Name} проводить деякий час у відключці.");
                        baseEvent.EventText.Add(p.ResetDrunk(2));
                        this.iteration+=2;
                        TimeManager.NextPart();
                        TimeManager.NextPart();
                    }
                    result.Success(baseEvent.EventText);
                    if(baseEvent.ID == 45 || baseEvent.ID == 46)
                    {
                        result.Win = true;
                    }
                    else if (iteration>=chapters.Count())
                    {
                        result.Win = true;
                    }
                    this.iteration++;
                    TimeManager.NextPart();
                }
                else
                {
                    result.Continue(baseEvent.EventText);
                }

                ReasonsToDeath r = p.IsWantToLive();
                if (r ==  ReasonsToDeath.None)
                    return result;

                string deathreason = "";
                switch (r)
                {
                    case ReasonsToDeath.NoHappy:
                        deathreason = "Вашому герою дуже сумно, і ніхто не в змозі" +
                                        "втримати його від стрибка з криші. Добре," +
                                        "що це всього лиш гра!";
                        break;
                    case ReasonsToDeath.NoPower:
                        deathreason = "Ваш герой відчуває неймовірну втому. Очі ..." +
                                        "зачиняються... і так важко.... хапатися..." +
                                        "за світло...";
                        break;
                    case ReasonsToDeath.NoMoney:
                        deathreason = "Вашого героя забирають до шпиталю у зв'язку" +
                                        "з гострою язвою. Вартувало б трохи зберігти грошей" +
                                        "на їжу.";
                        break;
                }
                result.Death(deathreason, baseEvent.EventText);
                return result;
            }
            else
            {
                result.Fail();
                return result;
            }
        }
    }
}
