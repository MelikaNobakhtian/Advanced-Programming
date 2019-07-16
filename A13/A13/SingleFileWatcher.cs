using System;
using System.IO;
using System.Linq;

namespace A13
{

    public class SingleFileWatcher : IDisposable
    {
        private FileSystemWatcher Watcher;
        Action MyAction;


        public SingleFileWatcher(string fileName)
        {
            FileInfo DisposeProblem = new FileInfo(fileName);
            Watcher = new FileSystemWatcher(DisposeProblem.DirectoryName, DisposeProblem.Name);
            Watcher.EnableRaisingEvents = true;
            Watcher.Changed += Watcher_Changed;
        }

        public void Dispose()
        {
            Watcher.Dispose();
        }

        public void Register(Action notify)
        {
            MyAction += notify;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            MyAction();
        }

        public void Unregister(Action notify1)
        {
            MyAction -= notify1;

        }
    }
}