using Caliburn.Micro;
using System;
using System.Linq;
using System.Windows.Input;

namespace Silly.UI.Shell.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                if(text == value)
                {
                    return;
                }
                text = value;
                NotifyOfPropertyChange(() => text);
            }
        }

        public string CurrentLine
        {
            get
            {
                if (String.IsNullOrEmpty(Text))
                    return String.Empty;
                var lines = Text.Split(new [] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                return lines.Last().Replace("\r", String.Empty);
            }
        }

        public void ExecuteCommand(KeyEventArgs args)
        {
            if(args.Key == Key.Return)
            {
                Console.WriteLine(args.Key);
                Console.WriteLine(CurrentLine);
            }
        }
    }
}
