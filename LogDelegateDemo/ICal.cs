using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogDelegateDemo
{
    public interface ICal
    {
        /// <summary>
        ///  输出执行过程概要日志
        /// </summary>
        event Action<string> OnLogOutPut;

        void Process(string msg);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WcfCallbackClient.ICal" />
    public class Multiply : ICal
    {
        #region 接口ICal
        public event Action<string> OnLogOutPut;
         public void LogOutPut(string msg)
        {
            if(OnLogOutPut!=null)
            {
                OnLogOutPut(msg);
            }
        }

         void ICal.Process(string msg)
        {
            LogOutPut("开始执行乘法运算");
            msg = "乘法运算消息：" + msg;
            LogOutPut(msg);
            LogOutPut("乘法运算执行完成");
        }
        #endregion
    }

    public class Devide : ICal
    {
        #region 接口ICal
        public event Action<string> OnLogOutPut;
        public void LogOutPut(string msg)
        {
            if (OnLogOutPut != null)
            {
                OnLogOutPut(msg);
            }
        }

        void ICal.Process(string msg)
        {
            LogOutPut("开始执行除法运算");
            msg = "除法运算消息：" + msg;
            LogOutPut(msg);
            LogOutPut("除法运算执行完成");
        }
        #endregion
    }
}
