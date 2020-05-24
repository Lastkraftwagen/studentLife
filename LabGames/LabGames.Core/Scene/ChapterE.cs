using LabGames.Core.Events;
using LabGames.Core.Events.Friends;
using LabGames.Core.Events.Hobby;
using LabGames.Core.Events.Learning;
using LabGames.Core.Events.Movement;
using LabGames.Core.Events.Partner;
using LabGames.Core.Events.Universitat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Scene
{
    public class ChapterE : Chapter
    {
        public ChapterE()
        {
            this.ChapterEvents.Add(new GoHomeOnTaxi());
            this.ChapterEvents.Add(new GoHomeOnFoot());
            this.ChapterEvents.Add(new GoHomeWithBus());
            this.ChapterEvents.Add(new GoStudyOnBus());
            this.ChapterEvents.Add(new GoStudyOnFoot());
            this.ChapterEvents.Add(new GoStudyOnTaxi());
            this.ChapterEvents.Add(new WalkWithFriends());
            this.ChapterEvents.Add(new DrinkWithFriends());
            this.ChapterEvents.Add(new WalkAlone());
            this.ChapterEvents.Add(new GoToCafe());
            this.ChapterEvents.Add(new WalkWithPartner());
            this.ChapterEvents.Add(new GoToCinema());
            this.ChapterEvents.Add(new ReadLections());
            this.ChapterEvents.Add(new MakeLaba());
            this.ChapterEvents.Add(new StudyHard());
            this.ChapterEvents.Add(new MakePractice());
            this.ChapterEvents.Add(new WatchInformativeVideos());
            this.ChapterEvents.Add(new HobbyReading());
            this.ChapterEvents.Add(new HobbySport());
            this.ChapterEvents.Add(new HobbyGames());

            this.ChapterEvents.Add(new Work());
            this.ChapterEvents.Add(new TakeHome());
            this.ChapterEvents.Add(new TakeHomeOnBus());
            this.ChapterEvents.Add(new TakeHomeOnFoot());
            this.ChapterEvents.Add(new SayGoodbye());
            this.ChapterEvents.Add(new WatchSeries());
            this.ChapterEvents.Add(new DoSex());
            this.ChapterEvents.Add(new DoWhatLove());
            this.ChapterEvents.Add(new FindAJob());


            this.ChapterEvents.Add(new UseSmartphone());
            this.ChapterEvents.Add(new SpeekWithFriends());
            this.ChapterEvents.Add(new ListenLection());
            this.ChapterEvents.Add(new Konspekt());
            this.ChapterEvents.Add(new LeftUniver());
            this.ChapterEvents.Add(new TakeANap());
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
                if (this.combineAble[1].Contains(item.ID))
                {
                    if (result.Where(x => x.id == 102).Count() == 0)
                    {
                        EventModel res = new EventModel();
                        res.id = 102;
                        res.description = "Хоббі підвищують показники героя";
                        res.name = "Позайматися хоббі...";
                        foreach (var subeventId in this.combineAble[1])
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
                        if (res.submodels.Count == this.combineAble[1].Count)
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
                if (this.combineAble[2].Contains(item.ID))
                {
                    if (result.Where(x => x.id == 103).Count() == 0)
                    {
                        EventModel res = new EventModel();
                        res.id = 103;
                        res.description = "Приділити час коханій людині завжди необхідно, " +
                            "а то знаєш, люди іноді і розходяться...";
                        string word = player.Gender == GenderType.Man ? "дівчині" : "хлопцю";
                        res.name = $"Приділити час {word}...";
                        foreach (var subeventId in this.combineAble[2])
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
                        if (res.submodels.Count == this.combineAble[2].Count)
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
                if (this.combineAble[3].Contains(item.ID))
                {
                    if (result.Where(x => x.id == 104).Count() == 0)
                    {
                        EventModel res = new EventModel();
                        res.id = 104;
                        res.description = "Обери спосіб аби відправитися на навчання.";
                        res.name = $"Відправитися в універ...";
                        foreach (var subeventId in this.combineAble[3])
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
                        if (res.submodels.Count == this.combineAble[3].Count)
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
