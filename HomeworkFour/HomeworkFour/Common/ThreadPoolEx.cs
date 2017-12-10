using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkFour.Common
{
    public class ThreadPoolEx
    {
        private ManualResetEvent eventX = new ManualResetEvent(false);
        private ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        private ManualResetEvent manualResetEventForWhenAll = new ManualResetEvent(false);
        private static object _lockObject = new object(); 
        private List<Action> actionList = new List<Action>();

        /// <summary>
        /// 带回调函数的ThreadPool
        /// </summary>
        /// <param name="action">执行方法</param>
        /// <param name="callBack">回调方法</param>
        public void ThreadPoolWithCallBack(Action<object> action, Action callBack)
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                action.Invoke(obj);
                callBack.Invoke();
            });
        }

        /// <summary>
        /// 带返回参数的ThreadPool
        /// </summary>
        /// <param name="func">传入一个带有返回值的委托</param>
        /// <returns>返回一个泛型委托，必须执行才能得到结果</returns>
        public Func<T> ThreadPoolWithReturn<T>(Func<object, T> func)
        {
            T t = default(T);
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                t = func.Invoke(obj);
                eventX.Set();
            });
            return new Func<T>(() =>
            {
                eventX.WaitOne();
                eventX.Reset();
                return t;
            });
        }

        /// <summary>
        ///  带返回参数,回调函数的ThreadPool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="callBack"></param>
        /// <returns></returns>
        public Func<T> ThreadPoolWithReturnCallBack<T>(Func<object, T> func, Action callBack)
        {
            T t = default(T);
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                t = func.Invoke(obj);
                callBack.Invoke();
                eventX.Set();

            });
            return new Func<T>(() =>
            {
                return t;
            });
        }

        /// <summary>
        /// 创建一个线程
        /// </summary>
        /// <param name="action"></param>
        public void CreateThread(Action action)
        {
            ThreadPool.QueueUserWorkItem((obj)=> 
            {
                action.Invoke();
                manualResetEvent.Set();
                DeteleAction(action);
            });
        }

        /// <summary>
        /// 其中某一条任务完成执行
        /// </summary>
        /// <param name="action"></param>
        public void ContinueWhenAny(Action action)
        {
            ThreadPool.QueueUserWorkItem((obj)=>
            {
                manualResetEvent.WaitOne();
                manualResetEvent.Reset();
                action.Invoke();
            });
        }
        
        /// <summary>
        /// 所有任务完成执行
        /// </summary>
        /// <param name="action"></param>
        public void ContinueWhenAll(Action action)
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                manualResetEventForWhenAll.WaitOne();
                manualResetEventForWhenAll.Reset();
                action.Invoke();
            });
        }

        public void AddWaitThread(Action action)
        {
            actionList.Add(action);
        }

        private void DeteleAction(Action action)
        {
            lock(_lockObject)
            {
                actionList.Remove(action);
                if(!actionList.Any())
                {
                    manualResetEventForWhenAll.Set();
                }
            }
        }
    }
}
