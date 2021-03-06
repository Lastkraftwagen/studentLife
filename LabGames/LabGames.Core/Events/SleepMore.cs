﻿using LabGames.Core.Events.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    public class SleepMore : BaseEvent
    {
        public SleepMore()
        {
            ID = 1;
            this.CreateConditions();
        }
        public override bool Execute(Player p, DayStep time)
        {
            this.EventText.Add($"{p.Name} обирає поспати трохи зранку");
            p.ChangePower(10);
            return true;
        }

        public override string GenerateDescription(Player p, DayStep time)
        {
            string descr;
            if (p.isDrunk)
                descr = "З похмілля краще залишатися в горизонтальному положенні";
            else
                descr = "Ну хто ж не хоче подовше повалятися у ліжечку зранку?" +
                " Це стовідсотково підвищить настрій, та можливо навіть продуктивність. " +
                " Головне - не проспати весь день.";
            return descr;
        }

        public override string GenerateName(Player p, DayStep time)
        {
            return "Повалятися у ліжечку";
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WEEKEND_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            Conditions.Add(new Condition()
            {
                Day = Constant.WORKDAY_MORNING,
                Place = PlaceType.Home,
                CompanyType = CompanyType.WithGF
            });
            
        }
    }
}
