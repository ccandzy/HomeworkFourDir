using HomeworkFour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkFour
{
    class Program
    {

        private static bool _isStart = false;

        static void Main(string[] args)
        {
            QiaoFeng qiaoFeng = new QiaoFeng();
            XuZhu xuZhu = new XuZhu();
            DuanYu duanYu = new DuanYu();

            Action<string> storyNode = (node) =>
            {
                Random random = new Random();
                Thread.Sleep(random.Next(1, 5) * 1000);
                Console.WriteLine(node);
                if(!_isStart)
                {
                    _isStart = true;
                    Console.WriteLine("天龙八部拉开序幕");
                }
            };

            List<Task<string>> taskList = new List<Task<string>>();

            var taskFactory = new TaskFactory();
            var taskQiao = taskFactory.StartNew(()=>
            {
                storyNode.Invoke(qiaoFeng.GaiBangZhu());
                storyNode.Invoke(qiaoFeng.QiDanRen());
                storyNode.Invoke(qiaoFeng.NanGongDaWang());
                storyNode.Invoke(qiaoFeng.GuaYinLiKai());
                return qiaoFeng.GetType().Name;
            });
            //Task cwt = taskQiao.ContinueWith(t => {
            //                  Console.WriteLine("任务完成后的执行结果：{0}", t.Result.ToString());
            //              });
            //taskQiao.ContinueWith(t=>
            //{
            //    Console.WriteLine(t.Result);
            //});
            taskList.Add(taskQiao);
            var taskXu = taskFactory.StartNew(() =>
            {
               storyNode.Invoke(xuZhu.XiaoHeShang());
               storyNode.Invoke(xuZhu.XiaoYaoZhangMen());
               storyNode.Invoke(xuZhu.LingJiuGongZhu());
               storyNode.Invoke(xuZhu.XiXiaFuMa());
                return xuZhu.GetType().Name;
            });
            taskList.Add(taskXu);
            var taskDuan = taskFactory.StartNew(() =>
            {
                storyNode.Invoke(duanYu.ZhongLingEr());
                storyNode.Invoke(duanYu.MuWanQing());
                storyNode.Invoke(duanYu.WangYuYan());
                storyNode.Invoke(duanYu.DaLiGuoWang());
                return duanYu.GetType().Name;
            });
            taskList.Add(taskDuan);

            Task.Factory.ContinueWhenAny(taskList.ToArray(),t=> 
            {
                Console.WriteLine(t.Result.ToString());
            });

            Task.WaitAny(taskList.ToArray());
            
            Console.WriteLine("做好半个准备了");
            Task.WaitAll(taskList.ToArray());
            Console.WriteLine("中原群雄大战辽兵,忠义两难一死谢天");

            Console.ReadKey();
        }
    }
}
