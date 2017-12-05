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
        public static string LogPath = AppDomain.CurrentDomain.BaseDirectory + "Log";
        
        public static void WriteTxtLog()
        {
            if (File.Exists(LogPath))
            {

            }
            else
            {

            }
        }
    }
}
