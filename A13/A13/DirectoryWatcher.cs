using System;
using System.IO;
using System.Linq;

namespace A13
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private FileSystemWatcher Watcher;
        Action<string> test;
        public DirectoryWatcher(string dir)
        {
            Watcher = new FileSystemWatcher(dir);
        }

        public void Dispose()
        {
            
        }

        public void Register(Action<string> notifyMe, ObserverType create)
        {
            Watcher.EnableRaisingEvents = true;
            if (create == ObserverType.Create)
            {
                Watcher.Created += Watcher_Created;
                test += notifyMe;
            }

            if (create == ObserverType.Delete)
            {
                Watcher.Deleted += Watcher_Deleted;
                test += notifyMe;
            }
           
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            test(e.FullPath);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            test(e.FullPath);
        }

        public void Unregister(Action<string> notifyMe, ObserverType delete)
        {
            if (delete == ObserverType.Create)
            {
                test -= notifyMe;
                Watcher.Created += Watcher_Created;
                
            }

            if (delete == ObserverType.Delete)
            {
                test -= notifyMe;
                Watcher.Deleted += Watcher_Deleted;
                
            }
        }
    }
}