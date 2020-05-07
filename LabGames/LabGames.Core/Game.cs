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
        private TimeManager TimeManager;
        private int iteration = 0;
        List<Chapter> chapters = new List<Chapter>();
        public Game()
        {
            TimeManager = new TimeManager();
            for (int i = 0; i < 5; i++)
            {
                chapters.Add(new ChapterA());
                chapters.Add(new ChapterA());
            }
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
                    result.Success(baseEvent.EventText);
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
