using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
//接收方
namespace UpdSocketReceiver
{   class Program
    {   private static int receivePort = 8012;
        static void Main(string[] args)
        {   IPAddress ip = IPAddress.Parse("127.0.0.1");
            //接收准备
            Socket receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            receiveSocket.Bind(new IPEndPoint(ip, receivePort));
            //接收数据
            byte[] result = new Byte[1024];
            EndPoint senderRemote = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
            //引用类型参数为EndPoint类型，用于存放发送方的IP地址和端点
            int length = receiveSocket.ReceiveFrom(result, ref senderRemote);
            Console.WriteLine("接收到{0}消息：{1}", senderRemote.ToString(), Encoding.UTF8.GetString(result, 0, length).Trim());
            receiveSocket.Shutdown(SocketShutdown.Receive);
            Console.ReadLine();
        }
    }
}
