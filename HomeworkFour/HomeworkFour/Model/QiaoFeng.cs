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
        public string GaiBangZhu()
        {
            return "丐帮帮主 " + Thread.CurrentThread.ManagedThreadId;
        }

        public string QiDanRen()
        {
            return "契丹人 " + Thread.CurrentThread.ManagedThreadId;
        }

        public string NanGongDaWang()
        {
            return "南院大王 " + Thread.CurrentThread.ManagedThreadId;
        }

        public string GuaYinLiKai()
        {
            return "挂印离开 " + Thread.CurrentThread.ManagedThreadId;
        }
    }
}
