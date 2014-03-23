using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HaisaBaseLibrary.ThreadLib
{
    /// <summary>
    /// BackgroundWorkerUsage 是BackgroundWorker的用法
    /// </summary>
    public class BackgroundWorkerUsage
    {
        public BackgroundWorkerUsage()
        {
            BackgroundWorker backgroundWorker=new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

            int userStateNum = 9;
            backgroundWorker.RunWorkerAsync(userStateNum);
        }

        /// <summary>
        /// 这里进行background 线程中进行的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //TODO
        }

        /// <summary>
        /// 这里是background 线程中操作完成后返回的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = e.Result;
            var userState = e.UserState; //RunWorkerAsync method 传入的参数
            //TODO
        }
    }
}
