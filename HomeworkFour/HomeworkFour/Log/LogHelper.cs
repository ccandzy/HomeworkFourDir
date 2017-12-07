using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkFour.Log
{
    
    public static class LogHelper
    {
        private static readonly object _lockObject = new object(); 
        public static string LogPath = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";
        
        public static void WriteTxtLog(string content)
        {
            lock (_lockObject)
            {
                Console.WriteLine(content);
                File.AppendAllText(LogPath, content+"\r\n");
            }
        }

        public static void WriteTxtLogWithOutLock(string content)
        {
            Console.WriteLine(content);
            File.AppendAllText(LogPath, content + "\r\n");
        }
    }
}
