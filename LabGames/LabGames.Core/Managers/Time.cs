using System;
using System.Collections.Generic;
using System.Text;

namespace LabGames.Core
{
    public enum DayOfWeek
    {
        Monday = 1,
        Tuseday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    public enum PartOfDay
    {
        Morning = 1,
        Day = 2,
        Para = 3,
        Evening = 4,
        Night = 5
    }

    public class Time
    {
        public DayOfWeek dayOfWeek;
        public PartOfDay partOfDay;
    }

    public class DayStep
    {
        public string Description { get; set; }
        public bool isLearningTime { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        public PartOfDay partOfDay{ get; set; }
    }

    public class TimeManager
    {
        public bool isLearningTime = false;
        public int Week = 0;
        public int Step = 0;

        private List<DayStep> Steps = new List<DayStep>();
        public bool isWorkDay
        {
            get
            {
                if (CurrentTime.dayOfWeek != DayOfWeek.Sunday && CurrentTime.dayOfWeek != DayOfWeek.Saturday)
                {
                    return true;
                }
                return false;
            }
        }
        public Time CurrentTime { get => new Time() { dayOfWeek = Steps[Step].dayOfWeek, partOfDay = Steps[Step].partOfDay }; private set { } }
        public DayStep CurrentStep { get => Steps[Step]; private set { } }

        public TimeManager()
        {
            FillWeek();
        }

        public void NextPart()
        {
            Step++;
            if (Step >= Steps.Count)
            {
                Step = 0;
                Week++;
            }
        }

        private void FillWeek()
        {
            #region Weekends
            for (int i = 0; i < 2; i++)
            {
                DayOfWeek temp = i == 0 ? DayOfWeek.Saturday : DayOfWeek.Sunday;
                Steps.Add(new DayStep()
                {
                    Description = Constant.WEEKEND_MORNING,
                    dayOfWeek = temp,
                    partOfDay = PartOfDay.Morning,
                    isLearningTime = false
                });
                Steps.Add(new DayStep()
                {
                    Description = Constant.WEEKEND_EVENING,
                    dayOfWeek = temp,
                    partOfDay = PartOfDay.Evening,
                    isLearningTime = false
                });
                Steps.Add(new DayStep()
                {
                    Description = Constant.NIGHT,
                    dayOfWeek = temp,
                    partOfDay = PartOfDay.Night,
                    isLearningTime = false
                });
            }

            #endregion
            for (int i = 0; i < 5; i++)
            {
                Steps.Add(new DayStep()
                {
                    Description = Constant.WORKDAY_MORNING,
                    dayOfWeek = (DayOfWeek)i + 1,
                    partOfDay = PartOfDay.Morning,
                    isLearningTime = false
                }); ;
                Steps.Add(new DayStep()
                {
                    Description = Constant.PARA_1,
                    dayOfWeek = (DayOfWeek)i + 1,
                    partOfDay = PartOfDay.Para,
                    isLearningTime = true
                });
                Steps.Add(new DayStep()
                {
                    Description = Constant.PARA_2,
                    dayOfWeek = (DayOfWeek)i + 1,
                    partOfDay = PartOfDay.Para,
                    isLearningTime = true
                });
                Steps.Add(new DayStep()
                {
                    Description = Constant.PARA_3,
                    dayOfWeek = (DayOfWeek)i + 1,
                    partOfDay = PartOfDay.Para,
                    isLearningTime = true
                });
                Steps.Add(new DayStep()
                {
                    Description = Constant.WORKDAY_EVENING,
                    dayOfWeek = (DayOfWeek)i + 1,
                    partOfDay = PartOfDay.Evening,
                    isLearningTime = false
                });
                Steps.Add(new DayStep()
                {
                    Description = Constant.NIGHT,
                    dayOfWeek = (DayOfWeek)i + 1,
                    partOfDay = PartOfDay.Night,
                    isLearningTime = false
                });
            }
        }
    }
}
