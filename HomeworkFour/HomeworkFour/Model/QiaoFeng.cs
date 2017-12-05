using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkFour.Model
{
    public class QiaoFeng
    {
        public void GaiBangZhu()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("丐帮帮主 " + Thread.CurrentThread.ManagedThreadId);
        }

        public void QiDanRen()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("契丹人 " + Thread.CurrentThread.ManagedThreadId);
        }

        public void NanGongDaWang()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("南院大王 " + Thread.CurrentThread.ManagedThreadId);
        }

        public void GuaYinLiKai()
        {
            Random random = new Random();
            Thread.Sleep(random.Next(1, 5) * 1000);
            Console.WriteLine("挂印离开 " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
