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

        public ShellViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.GatherFiles();
            var compiler = new Compiler();
            var compiledCommands = bootstrapper.Files
                .Select(file => new Dictionary<string, string> {
                    {file, compiler.Compile(file) }
                });
            this.registry = new CommandRegistry(compiledCommands.First());
        }

        public void ExecuteCommand(KeyEventArgs args)
        {
            if(args.Key == Key.Return)
            {
                Console.WriteLine(args.Key);
                var parser = new CommandParser();
                var commandParts = parser.Parse(CurrentLine);
                var command = registry.Resolve(commandParts.First());
                command.Execute(commandParts.Skip(1).ToArray());
            }
        }
    }
}
