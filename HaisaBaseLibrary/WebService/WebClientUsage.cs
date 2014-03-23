using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HaisaBaseLibrary.WebService
{
    /// <summary>
    /// WebClient 的用法
    /// </summary>
    class WebClientUsage
    {
        public WebClientUsage(string url)
        {
            System.Net.WebClient web = new System.Net.WebClient();
            web.Encoding = Encoding.UTF8;
            string response = web.DownloadString(url);
            
        }
    }
}
