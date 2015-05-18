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
        private ScriptRuntime runtime;

        private Silly.Shell.Environment currentEnvironment;

        public Silly.Shell.Environment CurrentEnvironment
        {
            get { return currentEnvironment; }
            set
            {
                if (currentEnvironment == value)
                    return;
                currentEnvironment = value;
                NotifyOfPropertyChange(() => CurrentEnvironment);
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
            Initialize();
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
                    var result = runtime.Execute(commandParts.First(), CurrentEnvironment, parameters);
                    if (result is Silly.Shell.Environment)
                    {
                        currentEnvironment = result as Silly.Shell.Environment;
                    }
                    else
                    {
                        var output = new OutputViewModel { Output = result.ToString() };
                        History.Add(output);
                    }
                }
                catch (Exception exc)
                {
                    History.Add(new OutputViewModel { Output = exc.Message });
                }

                Freeze();
                NewCommand();
            }
        }

        private void Initialize()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.GatherFiles();
            this.runtime = new ScriptRuntime(bootstrapper.Files);
            CurrentEnvironment = new Silly.Shell.Environment(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
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
