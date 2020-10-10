using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
namespace PingHost
{   class Program
    {   static void Main(string[] args)
        {   Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            //data为要发送的数据
            string data = "aaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            //ping网络IP地址为192.168.1.103的主机
            PingReply reply = pingSender.Send("14.215.177.38", timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {   Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
            else
                Console.WriteLine("目标主机Ping失败");
            Console.ReadLine();
        }
    }
}
