using System;
using System.Reflection;
using HaisaBaseLibrary.Uitity;
using log4net;

namespace HaisaBaseLibrary.LogLib
{
    public class Logger : SingletonFactory<Logger>
    {
        private  ILog _log;
        private bool IsInitialized { get; set; }
        

        public Logger()
        {
            Initialize();
        }
        /// <summary>
        /// 使用之前必须初始化
        /// </summary>
        public void Initialize()
        {
            _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //_log = log4net.LogManager.GetLogger("HaisaLogger");

        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="errorMessage"></param>
        public void Error(string errorMessage)
        {
            _log.Error(errorMessage);
        }

        /// <summary>
        /// 记录致命错误日志
        /// </summary>
        /// <param name="fatalMessage"></param>
        public void Fatal(string fatalMessage)
        {
            _log.Fatal(fatalMessage, new Exception("发生一个致命错误"));
        }

        /// <summary>
        /// 记录一般信息日志
        /// </summary>
        /// <param name="infoMessage"></param>
        public void Info(string infoMessage)
        {
            _log.Info(infoMessage);
        }

        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="debugMessage"></param>
        public void Debug(string debugMessage)
        {
            _log.Info(debugMessage);
        }

        /// <summary>
        /// 记录警告信息
        /// </summary>
        /// <param name="warnMessage"></param>
        public void Warn(string warnMessage)
        {
            _log.Warn(warnMessage);
        }

    }
}
