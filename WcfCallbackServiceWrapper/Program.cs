using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using WcfCallbackService;

namespace WcfCallbackServiceWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            StartServer();
        }
        /// <summary>
        /// 启动服务器
        /// </summary>
        public static void StartServer()
        {
            Console.WriteLine("开启服务");

            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService));
            NetTcpBinding binding = new NetTcpBinding
            {
                Security =
                {
                    Mode = SecurityMode.None,
                    Transport =
                    {
                        ClientCredentialType = TcpClientCredentialType.None
                    },
                    Message =
                    {
                        ClientCredentialType = MessageCredentialType.None
                    }
                },
                MaxBufferPoolSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
                ReceiveTimeout = new TimeSpan(0, 0, 10, 0),
                SendTimeout = new TimeSpan(0, 0, 10, 0)
            };
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, "net.tcp://127.0.0.1:2017");
            serviceHost.Open();
            Console.WriteLine("开启服务成功");
            Console.ReadKey();
        }
    }
}
