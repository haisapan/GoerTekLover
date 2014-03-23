using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Net;

namespace HaisaBaseLibrary.Sockets
{
    /// <summary>
    /// 异步Socket类，用来收发数据
    /// Silverlight中的异步Socket必须有策略文件传输验证
    /// 本类使用了System.Threading.Timer, 和界面无关的线程Timer类 进行自动重连功能
    /// 本类使用了Dispatcher.BeginInvoke 进行跨线程UI相关操作
    /// </summary>
    public class AsyncSocketUsage
    {
        // 客户端Socket对象
        
        private Socket _socket;
        // Socket 异步操作对象
        private SocketAsyncEventArgs _sendEventArgs;

        private int _maxReConnectedTime = int.MaxValue;
        private int _currentReConnectedTime = 0;

        #region 属性
        /// <summary>
        /// Server Socket IP
        /// </summary>
        public string ServerIp { get; set; }

        /// <summary>
        /// Server Socket Port
        /// </summary>
        public int ServerPort { get; set; }

        public string PhoneId { get; set; }


        public Action< MemoryStream> OnShowImage;

   #endregion

        public AsyncSocketUsage()
        {
        }

        public AsyncSocketUsage(string phoneId): this()
        {
            this.PhoneId = phoneId;
        }

        /// <summary>
        /// 开始Socket连接
        /// </summary>
        public void StartConnection()
        {
            // 实例化 Socket
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 实例化 SocketAsyncEventArgs ，用于对 Socket 做异步操作，很方便
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            // 服务器的 EndPoint
            ServerIp = "127.0.0.1";
            ServerIp = "192.168.0.100";
            ServerIp = "58.58.20.160";
            ServerPort = 4503;
            args.RemoteEndPoint = new DnsEndPoint(ServerIp, ServerPort);  //******修改IP
            // 异步操作完成后执行的事件
            args.Completed += new EventHandler<SocketAsyncEventArgs>(OnSocketConnectCompleted);

            // 异步连接服务端
            _socket.ConnectAsync(args);
            
        }

        /// <summary>
        /// 停止Socket
        /// </summary>
        public void Stop()
        {
            if (this._socket != null && this._socket.Connected)
            {
                this._socket.Close();
                this._socket.Dispose();
                this._socket = null;
            }

        }



        private Timer timer;
        private void OnSocketConnectCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success
                &&e.SocketError!=SocketError.IsConnected
                //&&e.SocketError!=SocketError.InProgress
                )  //连接异常
            {
                
                #region 连接失败自动重连

                if (timer!=null)
                {
                    timer.Dispose();
                    timer = null;
                }
                //这里使用了System.Threading.Timer, 和界面无关的线程Timer类
                //在WPF/Silverligth异步Socket的回调函数中只能使用该Timer
                //DispatcherTimer类在该情况无法使用，会有跨线程异常，而且没有必要，因为DispatchTimer主要用来UI线程相关操作
                 timer = new Timer((er) =>
                                            {
                                                _socket.ConnectAsync(e);
                                            }, null, 5000, 5000);
                
              
               
                #endregion

                return;
            }




            // 设置数据缓冲区
            byte[] response = new byte[256 * 1024];
            e.SetBuffer(response, 0, response.Length);

            // 修改 SocketAsyncEventArgs 对象的异步操作完成后需要执行的事件
            e.Completed -= new EventHandler<SocketAsyncEventArgs>(OnSocketConnectCompleted);
            e.Completed += new EventHandler<SocketAsyncEventArgs>(OnSocketReceiveCompleted);
            
            // 异步地从服务端 Socket 接收数据
            _socket.ReceiveAsync(e);

            // 构造一个 SocketAsyncEventArgs 对象，用于用户向服务端发送消息
            _sendEventArgs = new SocketAsyncEventArgs();
            _sendEventArgs.RemoteEndPoint = e.RemoteEndPoint;

            string data = "";
            if (!_socket.Connected)
            {
                data = "无法连接到服务器。。。请刷新后再试。。。";
                
            }
            else
            {
                data = "成功地连接上了服务器。。。";
                SendData(this.PhoneId);
            }


        }



        private void OnSocketReceiveCompleted(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                // 将接收到的数据转换为字符串-Image
                if (e.SocketError == SocketError.Success && e.BytesTransferred > 10)
                {
                    MemoryStream ms = new MemoryStream(e.Buffer, 0, e.BytesTransferred);

                    if (this.OnShowImage != null)
                    {
                        this.OnShowImage(ms);

                    }

                }
                else
                {
                    if (_socket != null && !_socket.Connected)
                    {
                        //断开重连
                        _socket.ConnectAsync(e);
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                if (_socket != null && !_socket.Connected)
                {
                    //断开重连
                    _socket.ConnectAsync(e);
                }
            }

            // 继续异步地从服务端 Socket 接收数据

            if (_socket != null && _socket.Connected)
            {
                _socket.ReceiveAsync(e);
            }

        }

        public bool SendData(string message)
        {
            if (this._socket != null && this._socket.Connected && this._sendEventArgs != null && !string.IsNullOrEmpty(message))
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                this._sendEventArgs.SetBuffer(data, 0, data.Length);
                this._socket.SendAsync(this._sendEventArgs);
                return true;
            }
            else
            {
                //MessageBox.Show("发送失败:"+message);
                return false;
            }
        }


        /// <summary>
        /// 根据Server返回的流显示图片, 该方法只能在UI线程里面调用，否则Dispatcher为空
        /// </summary>
        /// <param name="imageContainer"></param>
        /// <param name="stream"></param>
        public void ShowImage(MemoryStream stream)
        {
            //Dispatcher.BeginInvoke 用来唤醒UI线程操作
           /*
            Dispatcher.BeginInvoke(() =>
            {

                try
                {

                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.ImageFailed += bitmapImage_ImageFailed;
                    bitmapImage.SetSource(stream);
                    bitmapImage.ImageOpened += (s, e) =>
                    {
                        imageContainer.ImageContent.Source = bitmapImage;
                    };

                    bitmapImage.ImageFailed += (s, e) =>
                    {
                        //包异常时不处理，因此还是显示之前的图片
                        //ResetImage(imageContainer);
                    };

                }
                catch (Exception e)
                {

                }

                stream.Flush();
                stream.Close();
                stream.Dispose();


            });

            **/

        }


    }
}
