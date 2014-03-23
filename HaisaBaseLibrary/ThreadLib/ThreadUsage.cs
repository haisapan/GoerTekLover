using System.Threading;

namespace HaisaBaseLibrary.ThreadLib
{
    /// <summary>
    /// Thread 用法
    /// </summary>
    public class ThreadUsage
    {
        public void StartNewThread()
        {
            Thread sendThread = new Thread(() =>
            {
                //TODO
            });
            sendThread.Name = "SMS Send Thread";
            sendThread.Start();
        }
    }
}
