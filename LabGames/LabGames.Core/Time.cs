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

    public static class TimeManager
    {
        public static bool isLearningTime = false;
        public static int Week = 0; 
        public static int Step = 0;

        private static List<DayStep> Steps = new List<DayStep>(); 
        public static bool isWorkDay
        {
            get
            {
                if(CurrentTime.dayOfWeek!= DayOfWeek.Sunday && CurrentTime.dayOfWeek != DayOfWeek.Saturday)
                {
                    return true;
                }
                return false;
            }
        }
        public static Time CurrentTime { get => new Time() {dayOfWeek = Steps[Step].dayOfWeek, partOfDay = Steps[Step].partOfDay }; private set { } }
        public static DayStep CurrentStep { get => Steps[Step]; private set { } }

        static TimeManager()
        {
            FillWeek();
        }

        public static void NextPart()
        {
            Step++;
            if (Step >= Steps.Count)
            {
                Step = 0;
                Week++;
            }
        }

        private static void FillWeek()
        {
            #region Saturday
            Steps.Add(new DayStep()
            {
                Description = Constant.SATURDAY_MORNING,
                dayOfWeek = DayOfWeek.Saturday,
                partOfDay = PartOfDay.Morning,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.SATURDAY_EVENING,
                dayOfWeek = DayOfWeek.Saturday,
                partOfDay = PartOfDay.Evening,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.SATURDAY_NIGHT,
                dayOfWeek = DayOfWeek.Saturday,
                partOfDay = PartOfDay.Night,
                isLearningTime = false
            });
            #endregion
            #region Sunday
            Steps.Add(new DayStep()
            {
                Description = Constant.SUNDAY_MORNING,
                dayOfWeek = DayOfWeek.Sunday,
                partOfDay = PartOfDay.Morning,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.SUNDAY_EVENING,
                dayOfWeek = DayOfWeek.Sunday,
                partOfDay = PartOfDay.Evening,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.SUNDAY_NIGHT,
                dayOfWeek = DayOfWeek.Sunday,
                partOfDay = PartOfDay.Night,
                isLearningTime = false
            });
            #endregion
            #region Monday
            Steps.Add(new DayStep()
            {
                Description = Constant.MONDAY_MORNING,
                dayOfWeek = DayOfWeek.Monday,
                partOfDay = PartOfDay.Morning,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.MONDAY_PARA_1,
                dayOfWeek = DayOfWeek.Monday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.MONDAY_PARA_2,
                dayOfWeek = DayOfWeek.Monday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.MONDAY_PARA_3,
                dayOfWeek = DayOfWeek.Monday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.MONDAY_EVENING,
                dayOfWeek = DayOfWeek.Monday,
                partOfDay = PartOfDay.Evening,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.MONDAY_NIGHT,
                dayOfWeek = DayOfWeek.Monday,
                partOfDay = PartOfDay.Night,
                isLearningTime = false
            });
            #endregion
            #region Tuseday
            Steps.Add(new DayStep()
            {
                Description = Constant.TUESDAY_MORNING,
                dayOfWeek = DayOfWeek.Tuseday,
                partOfDay = PartOfDay.Morning,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.TUESDAY_PARA_1,
                dayOfWeek = DayOfWeek.Tuseday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.TUESDAY_PARA_2,
                dayOfWeek = DayOfWeek.Tuseday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.TUESDAY_PARA_3,
                dayOfWeek = DayOfWeek.Tuseday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.TUESDAY_EVENING,
                dayOfWeek = DayOfWeek.Tuseday,
                partOfDay = PartOfDay.Evening,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.TUESDAY_NIGHT,
                dayOfWeek = DayOfWeek.Tuseday,
                partOfDay = PartOfDay.Night,
                isLearningTime = false
            });
            #endregion
            #region Wednesday
            Steps.Add(new DayStep()
            {
                Description = Constant.WEDNESDAY_MORNING,
                dayOfWeek = DayOfWeek.Wednesday,
                partOfDay = PartOfDay.Morning,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.WEDNESDAY_PARA_1,
                dayOfWeek = DayOfWeek.Wednesday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.WEDNESDAY_PARA_2,
                dayOfWeek = DayOfWeek.Wednesday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.WEDNESDAY_PARA_3,
                dayOfWeek = DayOfWeek.Wednesday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.WEDNESDAY_EVENING,
                dayOfWeek = DayOfWeek.Wednesday,
                partOfDay = PartOfDay.Evening,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.WEDNESDAY_NIGHT,
                dayOfWeek = DayOfWeek.Wednesday,
                partOfDay = PartOfDay.Night,
                isLearningTime = false
            });
            #endregion
            #region Thursday
            Steps.Add(new DayStep()
            {
                Description = Constant.THURSDAY_MORNING,
                dayOfWeek = DayOfWeek.Thursday,
                partOfDay = PartOfDay.Morning,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.THURSDAY_PARA_1,
                dayOfWeek = DayOfWeek.Thursday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.THURSDAY_PARA_2,
                dayOfWeek = DayOfWeek.Thursday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.THURSDAY_PARA_3,
                dayOfWeek = DayOfWeek.Thursday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.TUESDAY_EVENING,
                dayOfWeek = DayOfWeek.Thursday,
                partOfDay = PartOfDay.Evening,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.THURSDAY_NIGHT,
                dayOfWeek = DayOfWeek.Thursday,
                partOfDay = PartOfDay.Night,
                isLearningTime = false
            });
            #endregion
            #region Friday
            Steps.Add(new DayStep()
            {
                Description = Constant.FRIDAY_MORNING,
                dayOfWeek = DayOfWeek.Friday,
                partOfDay = PartOfDay.Morning,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.FRIDAY_PARA_1,
                dayOfWeek = DayOfWeek.Friday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.FRIDAY_PARA_2,
                dayOfWeek = DayOfWeek.Friday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.FRIDAY_PARA_3,
                dayOfWeek = DayOfWeek.Friday,
                partOfDay = PartOfDay.Para,
                isLearningTime = true
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.FRIDAY_EVENING,
                dayOfWeek = DayOfWeek.Friday,
                partOfDay = PartOfDay.Evening,
                isLearningTime = false
            });
            Steps.Add(new DayStep()
            {
                Description = Constant.FRIDAY_NIGHT,
                dayOfWeek = DayOfWeek.Thursday,
                partOfDay = PartOfDay.Night,
                isLearningTime = false
            });
            #endregion
        }
    }
}
