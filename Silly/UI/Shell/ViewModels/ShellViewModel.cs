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
        private CommandRegistry registry;

        private BindableCollection<Screen> history;

        public BindableCollection<Screen> History
        {
            get { return history; }
            set
            {
                if(history == value)
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
                    var command = registry.Resolve(commandParts.First());
                    var result = command.Execute(commandParts.Skip(1).ToArray());
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

        private void Initialize()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.GatherFiles();
            var compiler = new Compiler();
            var compiledFiles = bootstrapper.Files.Select(f => new File
            {
                Filename = f.Filename,
                Content = compiler.Compile(f.Content)
            }).ToList();
            this.registry = new CommandRegistry(compiledFiles);
        }

        private void NewCommand()
        {
            History.Add(new CommandViewModel());
        }

        private void Freeze()
        {
            foreach(var vm in History)
            {
                if(vm is CommandViewModel)
                {
                    var cmd = vm as CommandViewModel;
                    cmd.IsReadOnly = true;
                }
            }
        }
    }
}
