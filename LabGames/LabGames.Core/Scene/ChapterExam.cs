using LabGames.Core.Events.Universitat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Scene
{
        [Serializable]
    internal class ChapterExam : Chapter
    {
        public ChapterExam()
        {
            this.ChapterEvents.Add(new EnterTheExams());
            this.ChapterEvents.Add(new PassExam());
        }

        public override List<string> ExecuteSpecialEvents(Player player, TimeManager time)
        {
            List<string> result = new List<string>();
            return result;
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
                        description = item.GenerateDescription(player, time.CurrentStep),
                        name = item.GenerateName(player, time.CurrentStep)
                    });
            }
            return result;
        }
    }
}
