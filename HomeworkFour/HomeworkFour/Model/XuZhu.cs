using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkFour.Model
{
    public class XuZhu
    {
        public string XiaoHeShang()
        {
            return"小和尚 " + Thread.CurrentThread.ManagedThreadId;
        }

        public string XiaoYaoZhangMen()
        {
            return"逍遥掌门 " + Thread.CurrentThread.ManagedThreadId;
        }

        public string LingJiuGongZhu()
        {
            return"灵鹫宫宫主 " + Thread.CurrentThread.ManagedThreadId;
        }

        public string XiXiaFuMa()
        {
            return"西夏驸马 " + Thread.CurrentThread.ManagedThreadId;
        }
    }
}
