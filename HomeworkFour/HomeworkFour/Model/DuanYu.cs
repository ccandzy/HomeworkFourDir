using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkFour.Model
{
    public class DuanYu
    {
        public void ZhongLingEr()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("钟灵儿 "+ Thread.CurrentThread.ManagedThreadId);
        }

        public void MuWanQing()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("木婉清 " + Thread.CurrentThread.ManagedThreadId);
        }

        public void WangYuYan()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("王语嫣 " + Thread.CurrentThread.ManagedThreadId);
        }

        public void  DaLiGuoWang()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("大理国王 " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
