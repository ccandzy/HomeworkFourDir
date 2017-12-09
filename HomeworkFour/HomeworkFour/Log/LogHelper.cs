using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkFour.Log
{
    
    public static class LogHelper
    {
        private static readonly object _lockObject = new object();
        private static readonly object _editListStoryLock = new object();
        public static string LogPath = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";

        private static List<string> _listStory = new List<string>();
        private static string _consoleString = string.Empty;
        public static void WriteTxtLog(string content)
        {
            EditListStory(OperateEnum.Write, content);

            lock (_lockObject)
            {
                File.AppendAllText(LogPath, content + "\r\n");
            }
        }

        public static void EditListStory(OperateEnum op,string content = null)
        {
            lock(_editListStoryLock)
            {
                if(op==OperateEnum.Write)
                {
                    _listStory.Add(content);
                }
                else if(op==OperateEnum.Reader)
                {
                    if(_listStory.Count>0)
                    {
                        _consoleString = _listStory[0];
                        _listStory.RemoveAt(0);
                    }
                }
            }
        }

        public static void CustomConsoleWirte()
        {
            if (string.IsNullOrEmpty(_consoleString))
            {
                EditListStory(OperateEnum.Reader);
            }
            if (_consoleString.Length>0)
            {
                for (int i = 0; i < _consoleString.Length; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(_consoleString[i]);
                }
                Console.WriteLine();
                _consoleString = string.Empty;
            }
        }
    }
}
