﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace DemoDataToFNCCard
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ACR122U NFC读卡器在winform中的使用，可以往卡里写入中文汉字
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NFCCardForm());
        }
    }
}
