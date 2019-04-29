using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LogDelegateDemo
{
    public partial class FormMain : Form
    {
        delegate void del();
        /// <summary>
        ///  输出执行过程概要日志
        /// </summary> 
        public event Action<string> OnLogOutPut;

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击刷新界面显示数字-跨线程赋值文本框信息
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRefush_Click(object sender, EventArgs e)
        {
            this.textBoxNum.Text = "10";
            Thread th = new Thread(new ThreadStart(SetValue));
            th.Start();
        }

        /// <summary>
        ///循环显示数字
        /// </summary>
        public void SetValue()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i == 10) i = 1;
                Refush(i.ToString());
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 文本框赋值
        /// </summary>
        /// <param name="num">The number.</param>
        private void Refush(string num)
        {
            if (this.InvokeRequired)
            {
                // BeginInvoke(new Action<string>(Refush));
                Action<string> act = s => Refush(num);
                // this.Invoke(new Action<string>(Refush),num);
                BeginInvoke(act, num);
            }
            else
            {
                this.textBoxNum.Text = num.ToString();
            }
        }

        /// <summary>
        ///显示日志信息事件
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonLog_Click(object sender, EventArgs e)
        {
            Oper();
        }

        public void Oper()
        {
            ICal multiply = new Multiply();
            Devide dev = new Devide();
            List<ICal> calList = new List<ICal>() { multiply, dev };
            foreach (ICal cl in calList)
            {
                cl.OnLogOutPut += Cl_OnLogOutPut;
                cl.Process(this.textBoxmsg.Text);
            }
        }

        /// <summary>
        /// 日志事件
        /// </summary>
        /// <param name="obj">The object.</param>
        private void Cl_OnLogOutPut(string obj)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(Cl_OnLogOutPut), obj);
            }
            else
            {
                this.richTextBox1.Text += obj + Environment.NewLine;
            }
        }

    }
}
