using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WcfCallbackService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CalculatorService: ICalculator
    {
        public void Add(double x, double y)
        {
            double result = x + y;
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            callback.DisplayResult(x, y, result);
            Console.WriteLine("客户端已经正常显示结果为：" + result.ToString());
        }

        public double Minus(double x, double y)
        {
            double result = x - y;
            return result;
        }

        /// <summary>
        ///  输出执行过程概要日志
        /// </summary> 
        public event Action<string> OnLogOutPut;

        /// <summary>
        /// 概要日志
        /// </summary>
        /// <param name="summaryInfo"></param>
        protected void LogOutPut(string summaryInfo)
        {
            if (OnLogOutPut != null)
            {
                OnLogOutPut(summaryInfo);
            }
        }

    }
}
