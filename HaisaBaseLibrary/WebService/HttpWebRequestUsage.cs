using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace HaisaBaseLibrary.WebService
{
    /// <summary>
    /// HttpWebRequest 和 HttpWebResponse的用法
    /// </summary>
    public class HttpWebRequestUsage
    {
        private object _lock;
        public HttpWebRequestUsage()
        {
            lock (_lock)
            {
                DataSet ds = new DataSet();
               
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://219.146.59.6:38000/MONITOR_WEB/servlet/QueryTerminalOnlineTime?starttime=" );
                request.Timeout = 50000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(resStream);

                XmlDocument d = new XmlDocument();
                d.Load(readStream);
                d.Save("a.xml");
                ds.ReadXml("a.xml");

               

                // Close the stream object.
                resStream.Close();

                resStream.Dispose();
                readStream.Close();
                readStream.Dispose();

                // Release the HttpWebResponse.
                response.Close();
            }
        }
    }
}
