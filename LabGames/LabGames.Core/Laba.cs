using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core
{

    public enum LabaProgress {
        NotStarted = 1,
        Started = 2,
        Half = 3,
        Ready = 4
    }

    public class Laba
    {
        public Laba()
        {
            Progress = LabaProgress.NotStarted;
            Ready = false;
        }
        public Laba(bool own)
        {
            Own = own;
            Progress = LabaProgress.NotStarted;
            Ready = false;
        }
        public LabaProgress Progress { get; private set; }
        public bool Own { get; set; }
        public bool Ready { get; set; }
        public void DoPart()
        {
            Progress += 1;
            if (Progress == LabaProgress.Ready)
                Ready = true;
        }
        public void DoAll()
        {
            Progress = LabaProgress.Ready;
            Ready = true;
        }

    }
}
