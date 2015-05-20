using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            this.Load();
            App.Current.Exit += Current_Exit;
        }

        private void Current_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            this.Save();
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
            if (history.Count == 0)
                return string.Empty;
            if (counter == 0)
                return history.ElementAt(counter);
            return history.ElementAt(counter--);
        }

        public string NextCommand()
        {
            if (history.Count == 0)
                return string.Empty;
            if(counter + 1 == history.Count)
                return history.Last();
            return history.ElementAt(counter++);
        }

        private void Load()
        {
            var personal = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var folderPath = Path.Combine(personal, ".silly");
            var historyFilename = Path.Combine(folderPath, "history.xml");
            if (!Directory.Exists(folderPath))
                return;
            if (!File.Exists(historyFilename))
                return;
            using (var streamReader = new StreamReader(historyFilename))
            {
                var serializer = new XmlSerializer(typeof(List<string>));
                this.history = serializer.Deserialize(streamReader) as List<String>;
            }
        }

        private void Save()
        {
            var personal = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var folderPath = Path.Combine(personal, ".silly");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            using(var streamWriter = new StreamWriter(Path.Combine(folderPath, "history.xml")))
            {
                var serializer = new XmlSerializer(typeof(List<string>));
                serializer.Serialize(streamWriter, history);
            }
        }
    }
}
