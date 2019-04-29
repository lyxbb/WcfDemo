using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ServiceModel;

namespace WcfCallbackService
{
    /// <summary>
    /// 回调协定接口
    /// </summary>
    public interface ICallback
    {
        [OperationContract(IsOneWay =true)]
        void DisplayResult(double x, double y, double result);
    }
}
