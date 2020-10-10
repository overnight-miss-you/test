using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
//服务器程序
namespace SocketServer
{  class Program
    {   private static byte[] result = new Byte[1024];
        private static int myprot = 8012;
        static Socket serverSocket;
        static void Main(string[] args)
        {   //服务器IP地址
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myprot));
            serverSocket.Listen(10);
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
            //通过clientsocket发送数据
            string sendMessage = "server send Message Hello";
            Socket clientsocket = serverSocket.Accept();
            clientsocket.Send(Encoding.ASCII.GetBytes(sendMessage));
            Console.WriteLine("向客户端发送消息:{0}", sendMessage);
            //通过clientsocket接收数据
            int receiveNumber = clientsocket.Receive(result);
            Console.WriteLine("接收客户端{0}消息{1}", clientsocket.RemoteEndPoint.ToString(), 
                               Encoding.ASCII.GetString(result, 0, receiveNumber));
            clientsocket.Shutdown(SocketShutdown.Both);
            clientsocket.Close();
            Console.ReadLine();
        }
    }
}
