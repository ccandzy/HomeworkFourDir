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
using HomeworkFour.Common;

namespace HomeworkFour
{
    class Program
    {

        private static object _lockOne = new object();

        static List<Action> listAction = new List<Action>();
        static List<Task> task = new List<Task>();

        private static object _taskLock = new object();
        static void Main(string[] args)
        {
            #region 故事实现第一版
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

            #region 故事实现升级版

            //ConfigHelper.CreateData();
            //Dictionary<string,List<string>> dictionary = ConfigHelper.GetDictionary();
            //CancellationTokenSource cts = new CancellationTokenSource();

            //Stopwatch stopwatchUpgradeOne = new Stopwatch();
            //stopwatchUpgradeOne.Start();

            //Task listenTask = new Task(() =>
            //{
            //    while (!cts.IsCancellationRequested)
            //    {
            //        Thread.Sleep(800);
            //        int randomInt = new Random().Next(0, 2020);
            //        //Console.WriteLine(randomInt);
            //        if (randomInt == 2017)
            //        {
            //            cts.Cancel();
            //            Console.WriteLine("世界末日！！！");
            //        }
            //    }
            //});
            //listenTask.Start();


            //Task write = new Task(() =>
            //{
            //    while(!cts.IsCancellationRequested)
            //    {
            //        Thread.Sleep(500);
            //        LogHelper.CustomConsoleWirte();
            //    }
            //});
            //write.Start();

            //Action<string> storyNodeUpgradeOne = (node) =>
            //{
            //    try
            //    {
            //        var randomInt = new RandomHelper().GetNumber(1, 5000);
            //        Thread.Sleep(randomInt);
            //        if (cts.IsCancellationRequested) return;
            //        if (!_isStart)
            //        {
            //            lock (_lockOne)
            //            {
            //                LogHelper.WriteTxtLog(node + $"等{randomInt}秒，进了LOCK");
            //                if (!_isStart)
            //                {
            //                    _isStart = true;
            //                    LogHelper.WriteTxtLog("******天龙八部拉开序幕******");
            //                }
            //            }
            //        }
            //        else
            //        {
            //            LogHelper.WriteTxtLog(node + $"等{randomInt}秒，直接出去");
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //        cts.Cancel();
            //        throw;
            //    }

            //};
            //var taskFactoryUpgradeOne = new TaskFactory();

            //var taskListUpgradeOne = dictionary.Select(dic => taskFactoryUpgradeOne.StartNew(() =>
            //    {
            //        dic.Value.ForEach(storyNodeUpgradeOne);
            //        return dic.Key;
            //    })).ToList();
            //var endTask = new Task(() => LogHelper.WriteTxtLog("中原群雄大战辽兵,忠义两难一死谢天"), cts.Token);

            //try
            //{
            //    Task.Factory.ContinueWhenAny(taskListUpgradeOne.ToArray(), t =>LogHelper.WriteTxtLog(t.Result.ToString() + "已经做好准备啦"),cts.Token);
            //    Task.Factory.ContinueWhenAll(taskListUpgradeOne.ToArray(), t => endTask.Start(), cts.Token);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //try
            //{
            //    Task.WaitAll(endTask);
            //    stopwatchUpgradeOne.Stop();
            //    LogHelper.WriteTxtLog("******全剧时长:" + stopwatchUpgradeOne.Elapsed + "******");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.InnerException.Message);
            //}
            #endregion

            #region ThreadPool 带参数，返回值 ContinueWhenAll ContinueWhenAny实现

            Console.WriteLine("Main ThreadID:" + Thread.CurrentThread.ManagedThreadId+"begin");

            ThreadPoolEx threadPoolEx = new ThreadPoolEx();
            
            Console.WriteLine("**********带回调的ThreadTool**********");
            threadPoolEx.ThreadPoolWithCallBack(Dosomething, CallBackMethod);
            
            Console.WriteLine("**********带带返回参数的ThreadPool**********");
            var iResult = threadPoolEx.ThreadPoolWithReturn(DosomethingWithReturn);
            var resultValue = iResult.Invoke();
            Console.WriteLine("result value:" + resultValue);
            
            Console.WriteLine("**********带返回参数,回调函数的ThreadPool**********");
            var iResultWithReturnCallBack = threadPoolEx.ThreadPoolWithReturnCallBack(DosomethingWithReturn, CallBackMethod);
            var resultValueWithReturnCallBack = iResultWithReturnCallBack.Invoke();
            Console.WriteLine("result value:" + resultValueWithReturnCallBack);

            Console.WriteLine("**********ContinueWhenAny    ContinueWhenAll的实现**********");
            threadPoolEx.AddWaitThread(ThreadThree); //加入要等待的线程 ContinueWhenAll 需要加入等待列表
            threadPoolEx.AddWaitThread(ThreadTwo);//加入要等待的线程 ContinueWhenAll 需要加入等待列表

            threadPoolEx.CreateThread(ThreadOne);//通过CreateThread方法创建的，其中一个完成就会触发ContinueWhenAny
            threadPoolEx.CreateThread(ThreadTwo);//通过CreateThread方法创建的，其中一个完成就会触发ContinueWhenAny
            threadPoolEx.CreateThread(ThreadThree);//通过CreateThread方法创建的，其中一个完成就会触发ContinueWhenAny
            threadPoolEx.ContinueWhenAny(() => 
            {
                Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create whenAny begin");
                Console.WriteLine("whenAny excute");
                Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create whenAny end");
            });

            threadPoolEx.ContinueWhenAll(() => 
            {
                Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create whenAll begin");
                Console.WriteLine("whenAll excute");
                Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create whenAll end");
            });
            Console.WriteLine("Main ThreadID:" + Thread.CurrentThread.ManagedThreadId+"end");
            #endregion

            #region 1000任务实现
            
           
            for(int i = 0; i<100; i++)
            {
                Action acttion = new Action(() => Console.WriteLine(i.ToString()));
                listAction.Add(acttion);
            }

          
            for(int j=0;j<10; j++)
            {
                Task taskItem = new Task(listAction[j]).ContinueWith(t =>
                {
                    lock(_taskLock)
                    {
                        listAction.Remove(listAction[j]);
                    }
                });
                taskItem.Start();
            }

            //while (listAction.Count == 0)
            //{

            //}

            #endregion
            Console.ReadKey();
        }
        
        static void ContinueTask(Task task)
        {
            if(listAction.Count > 0)
            {
                //int index = listAction[]
                task = new Task(listAction[0]).ContinueWith(t =>
                {
                    lock (_taskLock)
                    {
                        //listAction.Remove(listAction[j]);
                    }
                });
                task.Start();
            }
        }

        static void Dosomething(object obj)
        {
            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            Console.WriteLine("Dosomething");
        }
        static void CallBackMethod()
        {
            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("This is CallBackMethod");
        }
        static int DosomethingWithReturn(object obj)
        {
            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            int value = new RandomHelper().GetNumber(1, 10);
            Console.WriteLine("create value:"+value);
            return value;
        }
        private static void ThreadOne()
        {
            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create 1 begin");
            Thread.Sleep(5000);
            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create 1 end");
        }
        private static void ThreadTwo()
        {
            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create 2 begin");
            Thread.Sleep(3000);
            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create 2 end");
        }
        private static void ThreadThree()
        {
            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create 3 begin");
            Thread.Sleep(1000);
            Console.WriteLine("ThreadID:" + Thread.CurrentThread.ManagedThreadId + "begin create 3 end");
        }
    }
}
