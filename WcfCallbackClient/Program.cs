using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using WcfCallbackService;

namespace WcfCallbackClient
{
    public class Program
    {
        static void Main(string[] args)
        {
     
            AddCallback();
            Minus(20, 1);
            Console.Read();

          
            //Operation op = new Operation();
            //op.Oper();
        }

        /// <summary>
        /// 加法回调
        /// </summary>
        public static void AddCallback()
        {
            InstanceContext instanceContext = new InstanceContext(new CalculateCallback());
            DuplexChannelFactory<ICalculator> channelFactory = new DuplexChannelFactory<ICalculator>(instanceContext, TcpBindingInfo.TcpBinding);
            ICalculator proxy = channelFactory.CreateChannel(TcpBindingInfo.Endpointaddress);
            if (proxy != null)
            {
                proxy.Add(2, 3);
            }
        }

        /// <summary>
        /// 调用减法服务
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Minus(double x, double y)
        {
            InstanceContext instanceContext = new InstanceContext(new CalculateCallback());
            DuplexChannelFactory<ICalculator> channelFactory = new DuplexChannelFactory<ICalculator>(instanceContext, TcpBindingInfo.TcpBinding);
            ICalculator proxy = channelFactory.CreateChannel(TcpBindingInfo.Endpointaddress);
            if (proxy != null)
            {
                double value = proxy.Minus(x, y);
            }
            Console.WriteLine($"x-y={x - y}");
        }
    }
}
