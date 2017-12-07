using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkFour.Config
{
    public static class ConfigHelper
    {
        private static Dictionary<string,List<string>> _storyDictionary = new Dictionary<string, List<string>>();

        public static void CreateData()
        {
            _storyDictionary.Add("乔峰",new List<string>{ "丐帮帮主", "契丹人", "南院大王", "挂印离开" });
            _storyDictionary.Add("虚竹", new List<string> { "小和尚", "逍遥掌门", "灵鹫宫宫主", "西夏驸马" });
            _storyDictionary.Add("段誉", new List<string> { "钟灵儿", "木婉清", "王语嫣", "大理国王" });
            _storyDictionary.Add("cc", new List<string> { "初级程序员1", "初级程序员2", "初级程序员3", "初级程序员4", "初级程序员5", "初级程序员6", "初级程序员7" });
        }

        public static Dictionary<string, List<string>> GetDictionary()
        {
            return _storyDictionary;
        }
    }
}
