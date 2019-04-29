using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WcfCallbackService
{
    /// <summary>
    /// 定义回调契约CallbackContract属性指定
    /// </summary>
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface ICalculator
    {
        [OperationContract(IsOneWay = true)]
        void Add(double x, double y);

        [OperationContract(IsOneWay = false)]
        double Minus(double x, double y);
    }
}
