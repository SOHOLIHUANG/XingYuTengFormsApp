using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XingYuTengFormsApp
{
    public partial class Form1 : Form
    {

        private float X;
        private float Y;

        public Form1()
        {
            InitializeComponent();
            this.Resize += new EventHandler(Form1_Resize);
            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            setTag(this);

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
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                 con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
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
            tasks.Add(new ServiceTask("温湿度测试仪4656512   2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度+PM2.5传感器4656216  2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度+PM2.5传感器4656216  2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度测试仪4656512   2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度+PM2.5传感器4656216  2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度测试仪4656512   2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度+PM2.5传感器4656216  2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度测试仪4656512   2013-12-29", "P=25%   H=35%   T=65℃ "));
            tasks.Add(new ServiceTask("温湿度+PM2.5传感器4656216  2013-12-29", "P=25%   H=35%   T=65℃ "));

            return tasks;
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
