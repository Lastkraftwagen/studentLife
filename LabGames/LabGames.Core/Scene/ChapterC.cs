using LabGames.Core.Events;
using LabGames.Core.Events.Friends;
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
    [Serializable]
    public class ChapterC : Chapter
    {
        public ChapterC()
        {
            this.ChapterEvents.Add(new WalkWithFriends());
            this.ChapterEvents.Add(new DrinkWithFriends());
            this.ChapterEvents.Add(new WalkAlone());
            this.ChapterEvents.Add(new GoToCafe());
            this.ChapterEvents.Add(new WalkWithPartner());
            this.ChapterEvents.Add(new GoHomeOnTaxi());
            this.ChapterEvents.Add(new GoHomeOnFoot());
            this.ChapterEvents.Add(new ReadLections());
            this.ChapterEvents.Add(new MakeLaba());
            this.ChapterEvents.Add(new StudyHard());
            this.ChapterEvents.Add(new MakePractice());
            this.ChapterEvents.Add(new PointlessStagnate());
            this.ChapterEvents.Add(new Sleep());
            this.ChapterEvents.Add(new TakeHome());
            this.ChapterEvents.Add(new WatchInformativeVideos());
            this.ChapterEvents.Add(new TakeHomeOnBus());
            this.ChapterEvents.Add(new TakeHomeOnFoot());
            this.ChapterEvents.Add(new SayGoodbye());
            this.ChapterEvents.Add(new WatchSeries());
            this.ChapterEvents.Add(new DoSex());
            this.ChapterEvents.Add(new DoWhatLove());
            this.ChapterEvents.Add(new SleepToogether());
        }

        public override List<EventModel> GetChapterEventModels(Player player, TimeManager time)
        {
            List<EventModel> result = new List<EventModel>();
            foreach (var item in ChapterEvents)
            {
                if (this.combineAble[0].Contains(item.ID))
                {
                    if (result.Where(x => x.id == 101).Count() == 0)
                    {
                        EventModel res = new EventModel();
                        res.id = 101;
                        res.description = "Відправитися додому";
                        res.name = "Відправитися додому...";
                        foreach (var subeventId in this.combineAble[0])
                        {
                            var ev = ChapterEvents.Where(x => x.ID == subeventId).FirstOrDefault();
                            if (ev != null)
                            {
                                if (ev.IsExecutable(time.CurrentStep, player))
                                {
                                    res.submodels.Add(new EventModel()
                                    {
                                        id = ev.ID,
                                        description = ev.GenerateDescription(player, time.CurrentStep),
                                        name = ev.GenerateName(player, time.CurrentStep)
                                    });
                                }
                            }
                        }
                        if (res.submodels.Count == this.combineAble[0].Count)
                        {
                            res.isMulti = true;
                            result.Add(res);
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                if (this.combineAble[4].Contains(item.ID))
                {
                    if (result.Where(x => x.id == 105).Count() == 0)
                    {
                        EventModel res = new EventModel();
                        res.id = 105;
                        res.description = "Навчатися в університеті - головне! ;)";
                        res.name = $"Навчатися...";
                        foreach (var subeventId in this.combineAble[4])
                        {
                            var ev = ChapterEvents.Where(x => x.ID == subeventId).FirstOrDefault();
                            if (ev != null)
                            {
                                if (ev.IsExecutable(time.CurrentStep, player))
                                {
                                    res.submodels.Add(new EventModel()
                                    {
                                        id = ev.ID,
                                        description = ev.GenerateDescription(player, time.CurrentStep),
                                        name = ev.GenerateName(player, time.CurrentStep)
                                    });
                                }
                            }
                        }
                        if (res.submodels.Count == this.combineAble[4].Count)
                        {
                            res.isMulti = true;
                            result.Add(res);
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
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

        public override List<string> ExecuteSpecialEvents(Player player, TimeManager time)
        {
            List<string> result = new List<string>();
            return result;
        }
    }
}
