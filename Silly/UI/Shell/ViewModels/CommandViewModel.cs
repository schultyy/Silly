using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silly.UI.Shell.ViewModels
{
    public class CommandViewModel : Screen
    {
        private string command;

        public string Command
        {
            get { return command; }
            set
            {
                if (command == value)
                    return;
                command = value;
                NotifyOfPropertyChange(() => Command);
            }
        }

        private bool isReadOnly;

        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                if(isReadOnly == value)
                {
                    return;
                }
                isReadOnly = value;
                NotifyOfPropertyChange(() => IsReadOnly);
                NotifyOfPropertyChange(() => IsFocused);
            }
        }

        public bool IsFocused
        {
            get { return !IsReadOnly; }
        }
    }
}
