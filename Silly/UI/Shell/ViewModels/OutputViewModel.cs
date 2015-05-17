using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.UI.Shell.ViewModels
{
    public class OutputViewModel : Screen
    {
        private string output;

        public string Output
        {
            get { return output; }
            set
            {
                if(output == value)
                {
                    return;
                }
                output = value;
                NotifyOfPropertyChange(() => Output);
            }
        }
    }
}
