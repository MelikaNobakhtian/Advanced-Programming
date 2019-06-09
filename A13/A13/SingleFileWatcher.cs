using System;
using System.IO;
using System.Linq;

namespace A13
{

    public class SingleFileWatcher: IDisposable
    {
        private FileSystemWatcher Watcher;
        Action action;
        

        public SingleFileWatcher(string fileName)
        {
            //    var path = fileName.Split('\\').ToList();
            //    var name = path[path.Count - 1];
            //    string address = fileName.Remove(fileName.Length - 10);
            FileInfo DisposeProblem = new FileInfo(fileName);


            Watcher = new FileSystemWatcher(DisposeProblem.DirectoryName,DisposeProblem.Name);
        }

        public void Dispose()
        {

            Watcher.Dispose();
        }

        public void Register(Action notify)
        {
            Watcher.EnableRaisingEvents = true;
            action += notify;
            Watcher.Changed += Watcher_Changed;
            
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            action();
        }

        public void Unregister(Action notify1)
        {
            action -= notify1;
            Watcher.Changed += Watcher_Changed;
        }
    }
}