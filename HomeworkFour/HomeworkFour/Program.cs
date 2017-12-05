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
        static void Main(string[] args)
        {
            QiaoFeng qiaoFeng = new QiaoFeng();
            XuZhu xuZhu = new XuZhu();
            DuanYu duanYu = new DuanYu();

            List<Task> taskList = new List<Task>();

            var taskFactory = new TaskFactory();
            var taskQiao = taskFactory.StartNew(()=>
            {
                qiaoFeng.GaiBangZhu();
                qiaoFeng.QiDanRen();
                qiaoFeng.NanGongDaWang();
                qiaoFeng.GuaYinLiKai();
            });
            taskList.Add(taskQiao);
            var taskXu = taskFactory.StartNew(() =>
            {
                xuZhu.XiaoHeShang();
                xuZhu.XiaoYaoZhangMen();
                xuZhu.LingJiuGongZhu();
                xuZhu.XiXiaFuMa();
            });
            taskList.Add(taskXu);
            var taskDuan = taskFactory.StartNew(() =>
            {
                duanYu.ZhongLingEr();
                duanYu.MuWanQing();
                duanYu.WangYuYan();
                duanYu.DaLiGuoWang();
            });
            taskList.Add(taskDuan);
            Task.WaitAny(taskList.ToArray());
            Console.WriteLine("天龙八部拉开序幕");

            Console.ReadKey();
        }
    }
}
