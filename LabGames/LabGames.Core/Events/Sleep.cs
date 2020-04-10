﻿using LabGames.Core.Events.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core.Events
{
    internal class Sleep : BaseEvent
    {
        public Sleep(Player player) : base(player)
        {
            ID = 25;
            this.EventText = "Спать";
            this.CreateConditions();
        }

        public override bool Execute()
        {
            throw new NotImplementedException();
        }

        protected override void CreateConditions()
        {
            Conditions.Clear();
            Conditions.Add(new Condition()
            {
                Day = Constant.NIGHT,
                Place = PlaceType.Home,
                CompanyType = CompanyType.Alone
            });
        }
    }
}
