using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.UI
{
    public class CommandHistory
    {
        private List<string> history;

        private int counter;

        public CommandHistory()
        {
            history = new List<string>();
            counter = 0; 
        }

        public void StoreCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return;
            this.history.Add(command);
            counter = history.Count - 1;
        }

        public string PreviousCommand()
        {
            if (counter == 0)
                return history.ElementAt(counter);
            return history.ElementAt(counter--);
        }

        public string NextCommand()
        {
            if(counter + 1 == history.Count)
            {
                return history.Last();
            }
            return history.ElementAt(counter++);
        }
    }
}
