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
        public void XiaoHeShang()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5)*1000);
            Console.WriteLine("小和尚 " + Thread.CurrentThread.ManagedThreadId);
        }

        public void XiaoYaoZhangMen()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("逍遥掌门 " + Thread.CurrentThread.ManagedThreadId);
        }

        public void LingJiuGongZhu()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("灵鹫宫宫主 " + Thread.CurrentThread.ManagedThreadId);
        }

        public void XiXiaFuMa()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("西夏驸马 " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
