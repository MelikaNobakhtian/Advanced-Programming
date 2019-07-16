using System;
using System.IO;
using System.Linq;

namespace A13
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private FileSystemWatcher Watcher;
        Action<string> MyAction;
        public DirectoryWatcher(string dir)
        {
            Watcher = new FileSystemWatcher(dir);
            Watcher.EnableRaisingEvents = true;
            Watcher.Created += Watcher_Created;
            Watcher.Deleted += Watcher_Deleted;
        }

        public void Dispose()
        {
            Watcher.Dispose();
        }

        public void Register(Action<string> notifyMe, ObserverType status)
        {

            if (status == ObserverType.Create)
            {
                MyAction += notifyMe;
            }

            if (status == ObserverType.Delete)
            {
                MyAction += notifyMe;
            }

        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            MyAction(e.FullPath);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            MyAction(e.FullPath);
        }

        public void Unregister(Action<string> notifyMe, ObserverType status)
        {
            if (status == ObserverType.Create)
            {
                MyAction -= notifyMe;
            }

            if (status == ObserverType.Delete)
            {
                MyAction -= notifyMe;
            }
        }
    }
}