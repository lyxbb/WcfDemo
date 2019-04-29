using System;
using System.Collections.Generic;
using System.Text;
using WcfCallbackService;

namespace WcfCallbackClient
{
    /// <summary>
    /// 回调协定接口的实现类
    /// </summary>
    public class CalculateCallback: ICallback
    {
        public void DisplayResult(double x, double y, double result)
        {
            Console.WriteLine("x + y = {2} when x = {0} and y = {1}", x, y, result);
        }
    }
}
