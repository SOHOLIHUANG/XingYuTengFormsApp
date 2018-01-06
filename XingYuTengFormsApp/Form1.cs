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
        #region 窗体边框阴影动画效果移动改变大小
        private float X;
        private float Y;
        private bool isMax;//最大化为true,否则为false
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        /*

         * 函数功能：该函数能在显示与隐藏窗口时能产生特殊的效果。有两种类型的动画效果：滚动动画和滑动动画。

         * 函数原型：BOOL AnimateWindow（HWND hWnd，DWORD dwTime，DWORD dwFlags）；

         * hWnd：指定产生动画的窗口的句柄。

         * dwTime：指明动画持续的时间（以微秒计），完成一个动画的标准时间为200微秒。

         * dwFags：指定动画类型。这个参数可以是一个或多个下列标志的组合。

         * 返回值：如果函数成功，返回值为非零；如果函数失败，返回值为零。

         * 在下列情况下函数将失败：窗口使用了窗口边界；窗口已经可见仍要显示窗口；窗口已经隐藏仍要隐藏窗口。若想获得更多错误信息，请调用GetLastError函数。

         * 备注：可以将AW_HOR_POSITIVE或AW_HOR_NEGTVE与AW_VER_POSITVE或AW_VER_NEGATIVE组合来激活一个窗口。

         * 可能需要在该窗口的窗口过程和它的子窗口的窗口过程中处理WM_PRINT或WM_PRINTCLIENT消息。对话框，控制，及共用控制已处理WM_PRINTCLIENT消息，缺省窗口过程也已处理WM_PRINT消息。

         * 速查：WIDdOWS NT：5.0以上版本：Windows：98以上版本；Windows CE：不支持；头文件：Winuser.h；库文件：user32.lib。

         */

        //标志描述：

        public const int AW_SLIDE = 0x40000;//使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。

        public const int AW_ACTIVATE = 0x20000;//激活窗口。在使用了AW_HIDE标志后不要使用这个标志。

        public const int AW_BLEND = 0x80000;//使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。

        public const int AW_HIDE = 0x10000;//隐藏窗口，缺省则显示窗口。(关闭窗口用)

        public const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。

        public const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。

        public const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。

        public const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。

        public const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略。
        //需添加using System.Runtime.InteropServices
        [DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]

        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        //常量

        public const int WM_SYSCOMMAND = 0x0112;

        //窗体移动

        public const int SC_MOVE = 0xF010;

        public const int HTCAPTION = 0x0002;

        //改变窗体大小
        public const int WMSZ_LEFT = 0xF001;

        public const int WMSZ_RIGHT = 0xF002;

        public const int WMSZ_TOP = 0xF003;

        public const int WMSZ_TOPLEFT = 0xF004;

        public const int WMSZ_TOPRIGHT = 0xF005;

        public const int WMSZ_BOTTOM = 0xF006;

        public const int WMSZ_BOTTOMLEFT = 0xF007;

        public const int WMSZ_BOTTOMRIGHT = 0xF008;

        #endregion
        public Form()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
            this.SetupDescibedTaskColumn();
            // How much space do we want to give each row? Obviously, this should be at least
            // the height of the images used by the renderer
            this.deviceList.RowHeight = 54;
            this.deviceList.EmptyListMsg = "No tasks match the filter";
            this.deviceList.UseAlternatingBackColors = false;
            this.deviceList.UseHotItem = false;

            // Make and display a list of tasks
            List<ServiceTask> tasks = CreateTasks();
            this.deviceList.SetObjects(tasks);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //窗体加载动画效果
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_CENTER);
            this.deviceID.Focus();

            this.Resize += new EventHandler(Form1_Resize);
            X = this.Width;
            Y = this.Height;
            setTag(this);
            Form1_Resize(new object(), new EventArgs());//x,y可在实例化时赋值,最后这句是新加的，在MDI时有用
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
  
        /// <summary>
        /// 左边拉伸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceList_MouseMove(object sender, MouseEventArgs e)
        {
            Point p =deviceList.PointToClient(MousePosition);

            //Left
            if (p.Y > 2+panel.Height && p.Y < Height - 2 && p.X < 2)
            {
                this.Cursor = Cursors.SizeWE;
                wParam = (new IntPtr(WMSZ_LEFT)).ToInt32();
            }
            //Bottom
            else if (p.X > 2 && p.X < deviceList.Width - 2 && p.Y > deviceList.Height - 8)
            {
                this.Cursor = Cursors.SizeNS;
                wParam = (new IntPtr(WMSZ_BOTTOM)).ToInt32();
            }
            else
                this.Cursor = Cursors.Default;
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point p =listView2.PointToClient(MousePosition);
         
            //Bottom
            if (p.X > 2 && p.X < listView2.Width - 2 && p.Y > listView2.Height - 8)
            {
                this.Cursor = Cursors.SizeNS;
                wParam = (new IntPtr(WMSZ_BOTTOM)).ToInt32();
            }
            //Right
            else if (p.Y> 2 && p.Y < listView2.Height - 2 && p.X > listView2.Width - 8)
            {
                this.Cursor = Cursors.SizeWE;
                wParam = (new IntPtr(WMSZ_RIGHT)).ToInt32();
            }
            else
                this.Cursor = Cursors.Default;
        }

        private int wParam = 0;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = this.PointToClient(MousePosition);
            //Move
            if (p.X > 2 && p.X < Width - 2 && p.Y > 2 && p.Y < Height - 2)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
            else // ChangeSize
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, wParam, IntPtr.Zero.ToInt32());
            }
        }

        private void DeviceList_MouseDown(object sender, MouseEventArgs e)
        {
            // ChangeSize
            if(this.Cursor != Cursors.Default)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, wParam, IntPtr.Zero.ToInt32());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //窗体关闭动画效果
            AnimateWindow(this.Handle, 500, AW_HIDE | AW_BLEND | AW_CENTER);
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
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
