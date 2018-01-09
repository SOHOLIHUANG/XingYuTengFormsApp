using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XingYuTengFormsApp
{
    public partial class Form : System.Windows.Forms.Form
    {

        #region 窗体边框移动改变大小
        private float X;
        private float Y;
        private bool isMax;//最大化为true,否则为false
        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;
        #endregion

        #region
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        #endregion

        public Form()
        {
            InitializeComponent();
            this.SetupDescibedTaskColumn();
            // How much space do we want to give each row? Obviously, this should be at least
            // the height of the images used by the renderer
            this.deviceList.RowHeight = 54;
            this.deviceList.UseAlternatingBackColors = false;

            // Make and display a list of tasks
            List<ServiceTask> tasks = CreateTasks();
            this.deviceList.SetObjects(tasks);
        }

        /// <summary>
        /// 拉伸压缩窗体
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201:                //鼠标左键按下的消息   
                    m.Msg = 0x00A1;         //更改消息为非客户区按下鼠标   
                    m.LParam = IntPtr.Zero; //默认值   
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内   
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// 拖动窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Resize += new EventHandler(Form1_Resize);
            X = this.Width;
            Y = this.Height;
            setTag(this);
            Form1_Resize(new object(), new EventArgs());//x,y可在实例化时赋值,最后这句是新加的，在MDI时有用

            // Make the hot item show an overlay when it changes
            if (this.deviceList.UseTranslucentHotItem)
            {
                this.deviceList.HotItemStyle.Overlay = new BusinessCardOverlay();
                this.deviceList.HotItemStyle = this.deviceList.HotItemStyle;
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.deviceID.Focus();
        }

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }

        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {

                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                //con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                //con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                //con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }

        }

        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
        }

        private void SetupDescibedTaskColumn()
        {
            // Setup a described task renderer, which draws a large icon
            // with a title, and a description under the title.
            // Almost all of this configuration could be done through the Designer
            // but I've done it through code that make it clear what's going on.

            // Create and install an appropriately configured renderer 
            this.olvColumnDesk.Renderer = CreateDescribedTaskRenderer();

            // Now let's setup the couple of other bits that the column needs

            // Tell the column which property should be used to get the title
            this.olvColumnDesk.AspectName = "Task";
            // Put a little bit of space around the task and its description
            this.olvColumnDesk.CellPadding = new Rectangle(4, 2, 4, 2);
        }

        private DescribedTaskRenderer CreateDescribedTaskRenderer()
        {

            // Let's create an appropriately configured renderer.
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();

            // Tell the renderer which property holds the text to be used as a description
            renderer.DescriptionAspectName = "Description";

            // Change the formatting slightly
            renderer.TitleFont = new Font("Tahoma", 9);
            renderer.DescriptionFont = new Font("Tahoma", 11, FontStyle.Bold);
            renderer.ImageTextSpace = 8;
            renderer.TitleDescriptionSpace = 1;
            renderer.TitleColor = Color.Gray;
            renderer.DescriptionColor = Color.Black;

            // Use older Gdi renderering, since most people think the text looks clearer
            renderer.UseGdiTextRendering = true;

            // If you like colours other than black and grey, you could uncomment these
            //            renderer.TitleColor = Color.DarkBlue;
            //            renderer.DescriptionColor = Color.CornflowerBlue;

            return renderer;
        }

        private static List<ServiceTask> CreateTasks()
        {
            List<ServiceTask> tasks = new List<ServiceTask>();

            tasks.Add(new ServiceTask("温湿度测试仪4656512   2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度+PM2.5传感器4656216  2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度测试仪4656512   2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度+PM2.5传感器4656216  2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度测试仪4656512   2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度+PM2.5传感器4656216  2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度测试仪4656512   2013-12-29", "P=25%   H=35%   T=65℃ "));

            return tasks;
        }

        private void pictureBoxLagest_Click(object sender, EventArgs e)
        {
            if (isMax)
            {
                isMax = false;
                WindowState = FormWindowState.Normal;//还原
                string Path=GetPath();
                Path += @"\lagest.png";
                pictureBoxSize.Image = Image.FromFile(Path);
            }
            else
            {
                isMax = true;
                WindowState = FormWindowState.Maximized;//最大化
                string Path = GetPath();
                Path += @"\restore.png";
                pictureBoxSize.Image = Image.FromFile(Path);
            }
        }

        /// <summary>
        /// 获取路径,该路径为源码根路径
        /// </summary>
        /// <returns></returns>
        private string GetPath()
        {
            return Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\")); ;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxSmall_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;//最小化
        }

        private void AddDevice_Click(object sender, EventArgs e)
        {
            string DeviceId = deviceID.Text;
            if (!String.IsNullOrEmpty(DeviceId))
            {
                MessageBox.Show(DeviceId);
            }
        }
    }

    /// <summary>
    /// Dumb model class
    /// </summary>
    public class ServiceTask
    {
        private string task;
        private string description;

        public ServiceTask(string task, string description)
        {
            this.Task = task;
            this.Description = description;
        }

        public string Task
        {
            get { return this.task; }
            set { this.task = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}
