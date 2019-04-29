using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DeleteEventDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            people peo = new people();
            englishPeople eng = new englishPeople(peo);
            chinaPeople chi = new chinaPeople(peo);
            peo.Greate("张三","english");
            peo.Greate("张三", "china");
            Console.ReadKey();
        }
    }
}
