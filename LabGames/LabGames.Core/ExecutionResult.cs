using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Core
{
    [Serializable]
    public class ExecutionResult
    {
        private List<string> result = null;

        public bool IsExecuted { get; private set; } = false;
        public bool Continued { get; private set; } = false;
        public bool Dead { get; private set; } = false;
        public bool Win { get; set; } = false;

        public string message;

        public List<string> Result
        {
            get => (IsExecuted || Continued) ? result : new List<string>();
            private set => this.result = value;
        }

        public void Death(string text, List<string> result)
        {
            this.Result = result;
            this.IsExecuted = false;
            this.Continued = false;
            this.Dead = true;
            message = text;
        }

        public void Success(List<string> result)
        {
            this.Result = result;
            this.IsExecuted = true;
            this.Continued = false;
        }

        public void Fail()
        {
            this.Result = null;
            this.Continued = false;
            this.IsExecuted = false;
        }
        public void Continue(List<string> result)
        {
            this.Result = result;
            this.Continued = true;
            this.IsExecuted = false;
        }
    }
}
