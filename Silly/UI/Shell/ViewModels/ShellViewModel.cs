using Caliburn.Micro;
using Silly.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Silly.UI.Shell.ViewModels
{
    public class ShellViewModel : Screen
    {

        private CommandRunner commandRunner;

        public CommandRunner CommandRunner
        {
            get { return commandRunner; }
            set
            {
                if (commandRunner == value)
                    return;
                commandRunner = value;
                NotifyOfPropertyChange(() => CommandRunner);
            }
        }

        private BindableCollection<Screen> history;

        public BindableCollection<Screen> History
        {
            get { return history; }
            set
            {
                if (history == value)
                {
                    return;
                }
                history = value;
                NotifyOfPropertyChange(() => History);
            }
        }

        public CommandViewModel CurrentLine
        {
            get
            {
                return History.Last(c => c is CommandViewModel) as CommandViewModel;
            }
        }

        public ShellViewModel()
        {
            History = new BindableCollection<Screen>();
            CommandRunner = new CommandRunner(System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile));
            NewCommand();
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            DisplayName = "Silly";
        }

        public void ExecuteCommand(KeyEventArgs args)
        {
            if (args.Key == Key.Return || args.Key == Key.Enter)
            {
                var parser = new CommandParser();
                if (string.IsNullOrEmpty(CurrentLine.Command))
                    return;
                try
                {
                    var commandParts = parser.Parse(CurrentLine.Command);
                    string[] parameters = null;
                    if (commandParts.Length > 1)
                    {
                        parameters = commandParts.Skip(1).ToArray();
                    }
                    var result = CommandRunner.Execute(commandParts.First(), parameters);
                    if (result is Silly.Shell.Environment)
                    {
                        return;
                    }
                    var output = new OutputViewModel { Output = result.ToString() };
                    History.Add(output);
                }
                catch (Exception exc)
                {
                    History.Add(new OutputViewModel { Output = exc.Message });
                }

                Freeze();
                NewCommand();
            }
        }

        private void NewCommand()
        {
            History.Add(new CommandViewModel());
        }

        private void Freeze()
        {
            foreach (var vm in History)
            {
                if (vm is CommandViewModel)
                {
                    var cmd = vm as CommandViewModel;
                    cmd.IsReadOnly = true;
                }
            }
        }
    }
}
