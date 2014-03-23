using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HaisaBaseLibrary.ThreadLib
{
    /// <summary>
    /// ThreadPool 线程池用法
    /// </summary>
    public class ThreadPoolLib
    {
        public void StartThreadPool()
        {
            //第一个参数为一个执行函数，第二个参数是传入函数的值
            ThreadPool.QueueUserWorkItem(SendSms, new object());
        }


        /// <summary>
        /// 线程池里发送Mt Sms
        /// </summary>
        /// <param name="state"></param>
        private static void SendSms(object state)
        {
            List<string> messages = state as List<string>;
            if (messages != null)
            {
                //TODO
            }
        }
    }

}
