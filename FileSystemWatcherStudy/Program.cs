using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWatcherStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            Console.WriteLine("Note : First create folder structure C:\\One\\Two\\Three" + Environment.NewLine +
                               "Then create any files in folder Three. Say You created text document then change,rename,delete that document file." +
                               "You will be able to track document changes in console" + Environment.NewLine + Environment.NewLine+
                               "Are folders C:\\One\\Two\\Three created? If yes then press 'Y/y'");
            ConsoleKeyInfo key = Console.ReadKey();
            if(!(key.KeyChar == 'Y' || key.KeyChar == 'y'))
            {
                return;
            }

            Console.Clear();
            Console.WriteLine("Starting watcher on C:\\One\\Two\\Three!");

            FileSystemWatcher fsw = new FileSystemWatcher(@"C:\One\Two\Three");
            fsw.EnableRaisingEvents = true;

            //Create Folder

            fsw.Deleted += Fsw_Deleted;
            fsw.Renamed += Fsw_Renamed;
            fsw.Changed += Fsw_Changed;
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        private static void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Changed Folder/File : {e.Name}");
        }

        private static void Fsw_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed Folder/File {e.OldName} to: {e.Name}");
        }

        private static void Fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted Folder/File: {e.Name}");
        }
    }
}
