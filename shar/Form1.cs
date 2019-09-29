using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shar
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //var setting = new CefSettings();
            //// 设置语言
            //setting.Locale = "zh-CN";
            ////cef设置userAgent
            //setting.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            ////配置浏览器路径
            //setting.BrowserSubprocessPath = @"x86\CefSharp.BrowserSubprocess.exe";
            //Cef.Initialize(setting, performDependencyCheck: true, browserProcessHandler: null);
            //chromeBrowser = new ChromiumWebBrowser("https://www.baidu.com");
            //// Add it to the form and fill it to the form window.
            //this.Controls.Add(chromeBrowser);
            //chromeBrowser.Dock = DockStyle.Fill;



            CefSettings cSettings = new CefSettings();
            cSettings.MultiThreadedMessageLoop = true;
            cSettings.CefCommandLineArgs.Add("--disable-web-security", "");
            cSettings.CefCommandLineArgs.Add("--user-data-dir", "C:\\MyChromeDevUserData");
            Cef.Initialize(cSettings);
            String path = AppDomain.CurrentDomain.BaseDirectory + @"www\index.html";
            chromeBrowser = new ChromiumWebBrowser(path);
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
