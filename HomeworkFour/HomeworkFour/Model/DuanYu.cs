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
        public string ZhongLingEr()
        {
            return "钟灵儿 "+ Thread.CurrentThread.ManagedThreadId;
        }

        public string MuWanQing()
        {
            return "木婉清 " + Thread.CurrentThread.ManagedThreadId;
        }

        public string WangYuYan()
        {
            return "王语嫣 " + Thread.CurrentThread.ManagedThreadId;
        }

        public string  DaLiGuoWang()
        {
            return "大理国王 " + Thread.CurrentThread.ManagedThreadId;
        }
    }
}
