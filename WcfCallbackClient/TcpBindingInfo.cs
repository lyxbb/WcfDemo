using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.Text;

namespace WcfCallbackClient
{
    /// <summary>
    /// 绑定相关属性类
    /// </summary>
    public static class TcpBindingInfo
    {
        private static string Ip = "127.0.0.1:2017";

        /// <summary>
        /// 绑定主客户端地址
        /// </summary>
        private static EndpointAddress _ipaddress;

        /// <summary>
        /// 绑定
        /// </summary>
        private static NetTcpBinding _tcpBinding;

        public static EndpointAddress Endpointaddress
        {         
            set { _ipaddress = value; }
            get
            {
                _ipaddress = new EndpointAddress($"net.tcp://{Ip}");
                return _ipaddress;
            }
        }

        public static NetTcpBinding TcpBinding
        {
            set { _tcpBinding = value; }
            get
            {
                _tcpBinding = new NetTcpBinding
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
                return _tcpBinding;
            }
        }
    }
}
