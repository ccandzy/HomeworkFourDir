using HomeworkFour.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HomeworkFour.Config;
using HomeworkFour.Log;

namespace HomeworkFour
{
    class Program
    {

        private static bool _isStart = false;
        private static object _lockOne = new object();
        static void Main(string[] args)
        {
            #region 第一版
            //QiaoFeng qiaoFeng = new QiaoFeng();
            //XuZhu xuZhu = new XuZhu();
            //DuanYu duanYu = new DuanYu();

            //Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start();
            //Action<string> storyNode = (node) =>
            //{
            //    Random random = new Random();
            //    Thread.Sleep(random.Next(1, 5) * 1000);
            //    LogHelper.WriteTxtLog(node);
            //    if (!_isStart)
            //    {
            //        _isStart = true;
            //        LogHelper.WriteTxtLog("******天龙八部拉开序幕******");
            //    }
            //};

            //List<Task<string>> taskList = new List<Task<string>>();

            //var taskFactory = new TaskFactory();
            //var taskQiao = taskFactory.StartNew(() =>
            //{
            //    storyNode.Invoke(qiaoFeng.GaiBangZhu());
            //    storyNode.Invoke(qiaoFeng.QiDanRen());
            //    storyNode.Invoke(qiaoFeng.NanGongDaWang());
            //    storyNode.Invoke(qiaoFeng.GuaYinLiKai());
            //    return qiaoFeng.GetType().Name;
            //});
            //taskList.Add(taskQiao);
            //var taskXu = taskFactory.StartNew(() =>
            //{
            //    storyNode.Invoke(xuZhu.XiaoHeShang());
            //    storyNode.Invoke(xuZhu.XiaoYaoZhangMen());
            //    storyNode.Invoke(xuZhu.LingJiuGongZhu());
            //    storyNode.Invoke(xuZhu.XiXiaFuMa());
            //    return xuZhu.GetType().Name;
            //});
            //taskList.Add(taskXu);
            //var taskDuan = taskFactory.StartNew(() =>
            //{
            //    storyNode.Invoke(duanYu.ZhongLingEr());
            //    storyNode.Invoke(duanYu.MuWanQing());
            //    storyNode.Invoke(duanYu.WangYuYan());
            //    storyNode.Invoke(duanYu.DaLiGuoWang());
            //    return duanYu.GetType().Name;
            //});
            //taskList.Add(taskDuan);

            //Task.Factory.ContinueWhenAny(taskList.ToArray(), t =>
            //{
            //    LogHelper.WriteTxtLog(t.Result.ToString() + "已经做好准备啦");
            //});

            //Task.WaitAll(taskList.ToArray());
            //LogHelper.WriteTxtLog("中原群雄大战辽兵,忠义两难一死谢天");
            //stopwatch.Stop();
            //LogHelper.WriteTxtLog("******全剧时长:" + stopwatch.Elapsed + "******");

            #endregion

            #region 升级版1
            
            ConfigHelper.CreateData();
            Dictionary<string,List<string>> dictionary = ConfigHelper.GetDictionary();
            CancellationTokenSource cts = new CancellationTokenSource();
            Stopwatch stopwatchUpgradeOne = new Stopwatch();

            stopwatchUpgradeOne.Start();

            Task listenTask = new Task(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    int randomInt = new Random().Next(2015, 2020);
                    //Console.WriteLine(randomInt);
                    if (randomInt == 2012)
                    {
                        cts.Cancel();
                        Console.WriteLine("世界末日！！！");
                    }
                }
            });
            listenTask.Start();


            Action<string> storyNodeUpgradeOne = (node) =>
            {
                try
                {
                    var randomInt = new Random().Next(1, 5000);
                    Thread.Sleep(randomInt);
                    if (cts.IsCancellationRequested) return;
                    if (!_isStart)
                    {
                        lock (_lockOne)
                        {
                            LogHelper.WriteTxtLog(node + $"等{randomInt}秒，进了LOCK");
                            if (!_isStart)
                            {
                                _isStart = true;
                                LogHelper.WriteTxtLog("******天龙八部拉开序幕******");
                            }
                        }
                    }
                    else
                    {
                        LogHelper.WriteTxtLog(node + $"等{randomInt}秒，直接出去");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    cts.Cancel();
                    throw;
                }
                
            };
            var taskFactoryUpgradeOne = new TaskFactory();

            //List<Task<string>> taskListUpgradeOne = new List<Task<string>>();
            //foreach (var dic in dictionary)
            //{
            //    Thread.Sleep(new Random().Next(0, 100));
            //    var task = taskFactoryUpgradeOne.StartNew(() =>
            //    {
            //        dic.Value.ForEach(storyNodeUpgradeOne);
            //        return dic.Key;
            //    });
            //    taskListUpgradeOne.Add(task);
            //}

            var taskListUpgradeOne = dictionary.Select(dic => taskFactoryUpgradeOne.StartNew(() =>
                {
                    dic.Value.ForEach(storyNodeUpgradeOne);
                    return dic.Key;
                })).ToList();
            var endTask = new Task(() => LogHelper.WriteTxtLog("中原群雄大战辽兵,忠义两难一死谢天"), cts.Token);
            try
            {
                Task.Factory.ContinueWhenAny(taskListUpgradeOne.ToArray(), t =>LogHelper.WriteTxtLog(t.Result.ToString() + "已经做好准备啦"),cts.Token);
                Task.Factory.ContinueWhenAll(taskListUpgradeOne.ToArray(), t => endTask.Start(), cts.Token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Task.WaitAll(endTask);
                stopwatchUpgradeOne.Stop();
                LogHelper.WriteTxtLog("******全剧时长:" + stopwatchUpgradeOne.Elapsed + "******");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            #endregion
            
            Console.ReadKey();
        }
    }
}
