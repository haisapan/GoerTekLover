using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace HaisaBaseLibrary.LogLib
{
    public class TraceLogWriter
    {
        /// <summary>
        /// 上面的示例代码只是加入了Txt文件，Xml文件，EvengLog的Listerners
        /// 调用都是直接用Trace.Write()之类的方法。
        /// …还可以通过从TraceListerner类派生出一个新的类，重载其中的Write()，WriteLine()方法，实现数据放到日志中
        /// </summary>
        public void AddTraceWriter()
        {
            Stream sLogFile = File.Create("Log.txt");
            Trace.AutoFlush = true; ;
            Trace.Listeners.Add(new TextWriterTraceListener(sLogFile));
            Trace.Listeners.Add(new EventLogTraceListener("myEventLogSource"));
            Trace.Listeners.Add(new XmlWriterTraceListener(File.Create("Log.xml")));

            Trace.WriteLine("haha");
            Trace.WriteLine("LogText");
            Trace.Flush();
        }
    }
}
