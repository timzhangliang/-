﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace txtbtntest
{
    public partial class Form1 : Form
    {
        public delegate void setcallback(string str);
        public const int USER = 0x0400;//用户自定义消息的开始数值
        public Thread th;
        public setcallback settxt;
        

        [DllImport("user32.dll")]
        public static extern void PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public void fun()
        {
            textBox1.Invoke(settxt,"123");
        }

        public void settxtfun(string str)
        {
            textBox1.Text = str;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void StartProcess(string str)
        {
            MessageBox.Show("具备条件，可以正常运行了！" + str);


        }

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case USER + 1:
                    string message = string.Format("收到自己消息的参数:{0},{1}", m.WParam, m.LParam);
                    string message2 = $"收到自己消息的参数：{m.WParam},{m.LParam}";
                    StartProcess(message2);
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Thread.Sleep(100);
            //PostMessage(this.Handle, USER + 1, 168, 51898);
            //System.Windows.Forms.TextBox tb2 = textBox1;
            //tb2.Text = "1111";
            DataTable dt = new DataTable();
            dt = null;
            dt = new DataTable();
            var m = dt.Rows.Count;
            if (dt.Rows.Count > 0) textBox1.Text = dt.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ////// //string str = "111";
                ////// // textBox1.Text=str.Substring(0,6);
                ////// // Log();
                ////// // Old();
                ////// DataTable dt = new DataTable();
                //////dt = null;
                ////// dt=new DataTable();
                //////var m = dt.Rows.Count;

                ////// if (dt.Rows.Count > 0) textBox1.Text = "222";
                //// textBox1.Text = "1";
                //// textBox1.Text = "2";
                //settxt = new setcallback(settxtfun);
                //th = new Thread(fun);
                //th.IsBackground = true;
                //th.Start();
                //int i = 0;
                //int j = 1/i;
                textBox1.Text = "1";

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.StackTrace);
            }
           


        }

        public void Log([CallerLineNumber] int line = -1,
            [CallerFilePath] string path = null,
            [CallerMemberName] string name = null)
        {
            string str = $"Line:{line},path:{path},name:{name}!";
            textBox1.Text = str;
        }

        [Obsolete("Don't use Old method, use New method", false)]
        public void Old()
        {
            textBox1.Text = "111";
            textBox1.Text = "222";
            textBox1.Text = "333";

        }
        public void New() { }

        private void button1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            if (Convert.ToInt32(textBox1.Text)%2 == 0)
                button1.BackColor = Color.Red;
            else
            {
                button1.BackColor = Color.Green;
            }
        }
    }
}
