﻿
using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XingYuTengFormsApp.Entity;
using XingYuTengFormsApp.Util.SQLiteUtil;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace XingYuTengFormsApp
{
    public partial class Form : System.Windows.Forms.Form ,InetworkResult
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
        private List<ItemPoint> items;
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
            CreateDeviceDatas();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Point p = this.PointToClient(MousePosition);
            Point conPoint = detail.Location;
            if (!(p.X >= deviceList.Width + 2 && p.X < deviceList.Width + 2 + detail.Width && p.Y >= conPoint.Y && p.Y <= conPoint.Y + detail.Height))
            {
                detail.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.deviceList.SelectionChanged += delegate (object listSender, EventArgs args)
            {
                HandleSelectionChanged(deviceList);
            };


            this.Resize += new EventHandler(Form1_Resize);
            X = this.Width;
            Y = this.Height;
            setTag(this);
            Form1_Resize(new object(), new EventArgs());//x,y可在实例化时赋值,最后这句是新加的，在MDI时有用

            this.deviceList.HotItemChanged += delegate (object msender, HotItemChangedEventArgs args) {
                if (sender == null)
                {
                    return;
                }
                switch (args.HotCellHitLocation)
                {
                    case HitTestLocation.Nothing:

                        ClearAddedcomponent();
                        break;
                    case HitTestLocation.Header:
                    case HitTestLocation.HeaderCheckBox:
                    case HitTestLocation.HeaderDivider:
                        //textBox1.Text = String.Format("Over {0} of column #{1}", "fdfdff", args.HotColumnIndex);
                        break;
                    case HitTestLocation.Group:
                        //textBox1.Text = String.Format("Over group '{0}', {1}", args.HotGroup.Header, args.HotCellHitLocationEx);
                        break;
                    case HitTestLocation.GroupExpander:
                        //textBox1.Text = String.Format("Over group expander of '{0}'", args.HotGroup.Header);
                        break;
                    default:
                        ClearAddedcomponent();
                        detail.Visible = true;
                        Point point = deviceList.GetItem(args.HotRowIndex).Position;
                        if (point.Y < 2 + Panel.Height)
                        {
                            detail.Location = new Point(2 + deviceList.Width, 2 + Panel.Height);
                        }
                        else if (point.Y + detail.Height > Height - 2)
                        {
                            detail.Location = new Point(2 + deviceList.Width, Height - 2 - detail.Height);
                        }
                        else {
                            detail.Location = new Point(2 + deviceList.Width, point.Y);
                        }

                        ItemPoint oLVListItem = (ItemPoint)deviceList.GetItem(args.HotRowIndex).RowObject;
                        detailInfo.Text = oLVListItem.title;
                        List<DetailValue> list = new List<DetailValue>();
                        string time = null;
                        foreach (DataStreams dataStream in oLVListItem.dataStreamsList)
                        {
                            //只获取最新的一个点在弹框中显示
                            bool m = false;
                            DetailValue detailValue = new DetailValue();
                            foreach (DataPoints dataPoints in dataStream.datapoints)
                            {
                                if (m) {
                                    break;
                                }
                                detailValue.Name = dataStream.id;
                                StringBuilder builder = new StringBuilder();
                                if (time == null)
                                {
                                    time = dataPoints.at;
                                }
                                else
                                {
                                    if (time.CompareTo(dataPoints.at) < 0) {
                                        time = dataPoints.at;
                                    }
                                }
                                builder.Append(dataPoints.value);
                                foreach (DeviceDataStreams stream in oLVListItem.deviceDatastreams)
                                {
                                    if (dataStream.id.Equals(stream.id))
                                    {
                                        builder.Append(stream.unit);
                                        detailValue.Value =builder.ToString();
                                        list.Add(detailValue);
                                        m = true;
                                        break;
                                    }
                                }
                            }
                            
                        }
                        updateTime.Text=time;
                        detailObject.SetObjects(list);
                        break;
                }
            };
        }

        public void HandleSelectionChanged(ObjectListView listView)
        {
            ItemPoint oLVListItem = listView.SelectedObject as ItemPoint;
            if (oLVListItem != null)
            {
                tabControl1.Controls.Clear();
                foreach (DataStreams stream in oLVListItem.dataStreamsList)
                {
                    TabPage tabPage1 = new TabPage(); ;
                    tabPage1.BackColor = System.Drawing.Color.White;
                    tabPage1.Location = new System.Drawing.Point(4, 25);
                    tabPage1.Name = stream.id;
                    tabPage1.Padding = new System.Windows.Forms.Padding(3);
                    tabPage1.Size = new System.Drawing.Size(611, 443);
                    tabPage1.TabIndex = 0;
                    tabPage1.Text = stream.id + "曲线";
                    this.tabControl1.Controls.Add(tabPage1);


                    // 
                    // cartesianChart1
                    // 
                    LiveCharts.WinForms.CartesianChart cartesianChart1= new LiveCharts.WinForms.CartesianChart();
                    cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
                    cartesianChart1.Location = new System.Drawing.Point(0, 0);
                    cartesianChart1.Name = "cartesianChart1";
                    cartesianChart1.Size = new System.Drawing.Size(734, 435);
                    cartesianChart1.TabIndex = 1;
                    cartesianChart1.Text = "cartesianChart1";

                    List<DataPoints> dataPointsList = stream.datapoints;
                    double[] values= new double [dataPointsList.Count];
                    string[] labels = new string[dataPointsList.Count];
                    int m = 0;
                    foreach(DataPoints dataPoints in dataPointsList) {
                        values[m] = double.Parse(dataPoints.value);
                        labels[m] = dataPoints.at;
                        m++;
                    }
                    cartesianChart1.Series = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Title = stream.id + "曲线",
                            Values = new ChartValues<double>(values),
                             PointGeometry = DefaultGeometries.None,
                             Fill = new SolidColorBrush
                                    {
                                        Color = System.Windows.Media.Color.FromRgb(105,204,104),
                                        Opacity = .4
                                    },
                             Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(248, 213, 72)),

                        }
                    };

                    cartesianChart1.AxisX.Add(new Axis
                    {
                        Title = "时间",
                        Labels = labels
                    });

                    string unit=null;
                    foreach (DeviceDataStreams devicestream in oLVListItem.deviceDatastreams)
                    {
                        if (devicestream.id.Equals(stream.id))
                        {
                            unit=devicestream.unit;
                            break;
                        }
                    }

                    cartesianChart1.AxisY.Add(new Axis
                    {
                        //Title = "Sales",
                        LabelFormatter = value => value.ToString("")+unit
                    });

                    cartesianChart1.LegendLocation = LegendLocation.Top;
                    tabPage1.Controls.Add(cartesianChart1);
                }
                foreach (Control con in this.Controls)
                {
                    if (!con.Name.Equals("Panel"))
                    {
                        con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                        if (con.Controls.Count > 0)
                            setTag(con);
                    }
                }
            }
        }

        /// <summary>
        /// 删除列表详细信息控件
        /// </summary>
        private void ClearAddedcomponent()
        {
            Point p = this.PointToClient(MousePosition);
            Point conPoint = detail.Location;
            if (p.X >= deviceList.Width + 2 && p.X < deviceList.Width + 2 + detail.Width && p.Y >= conPoint.Y && p.Y <= conPoint.Y + detail.Height)
            {
                detail.MouseLeave += new EventHandler(Panel_MouseLeave);
            }
            else
            {
                detail.Visible = false;
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
                if (con.Name.Equals("deviceList")|| con.Name.Equals("detail")) {
                    continue;
                }
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
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
            tabControl1.Location = new Point(2 + deviceList.Width, tabControl1.Location.Y);
            tabControl1.Width = Width - deviceList.Width - 4;
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
            this.olvColumnDesk.AspectName = "title";
            // Put a little bit of space around the task and its description
            this.olvColumnDesk.CellPadding = new Rectangle(4, 2, 4, 2);
        }

        private DescribedTaskRenderer CreateDescribedTaskRenderer()
        {

            // Let's create an appropriately configured renderer.
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();

            // Tell the renderer which property holds the text to be used as a description
            renderer.DescriptionAspectName = "dataStrams";

            // Change the formatting slightly
            renderer.TitleFont = new Font("Tahoma", 9);
            renderer.DescriptionFont = new Font("Tahoma", 11, FontStyle.Bold);
            renderer.ImageTextSpace = 8;
            renderer.TitleDescriptionSpace = 1;
            renderer.TitleColor = System.Drawing.Color.Gray;
            renderer.DescriptionColor = System.Drawing.Color.Black;

            // Use older Gdi renderering, since most people think the text looks clearer
            renderer.UseGdiTextRendering = true;

            // If you like colours other than black and grey, you could uncomment these
            //            renderer.TitleColor = Color.DarkBlue;
            //            renderer.DescriptionColor = Color.CornflowerBlue;

            return renderer;
        }

        private void CreateDeviceDatas()
        {
            foreach (DeviceData deviceData in DeviceDataDao.Instance.GetAll()) {
                NetWorkUtil.Instance.GetDataPoints(deviceData, this,null,AllConstant.POINTS,null,null,null,null);
            }
        }

        private void pictureBoxLagest_Click(object sender, EventArgs e)
        {
            string Path = Util.Utils.GetPath();
            if (isMax)
            {
                isMax = false;
                WindowState = FormWindowState.Normal;//还原
                Path += @"\lagest.png";
                pictureBoxSize.Image = Image.FromFile(Path);
            }
            else
            {
                isMax = true;
                WindowState = FormWindowState.Maximized;//最大化
                Path += @"\restore.png";
                pictureBoxSize.Image = Image.FromFile(Path);
            }
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
            string deviceId = deviceID.Text;
            if (!String.IsNullOrEmpty(deviceId))
            {
                if (Regex.IsMatch(deviceId, @"\d{7}"))
                {
                    if (DeviceDataDao.Instance.HasId(deviceId))
                    {
                        MessageBox.Show("该设备已存在");
                    }
                    else
                    {
                        NetWorkUtil.Instance.addDevice(deviceId, this);
                    }
                }
                else {
                    MessageBox.Show("请输入7位有效ID");
                }
                               
            }
        }

        void InetworkResult.onSuccess(ItemPoint item)
        {
            if (items == null) {
                items = new List<ItemPoint>();
            }
            items.Add(item);
            deviceList.SetObjects(items);
        }

        void InetworkResult.onFailure(string error)
        {
            MessageBox.Show(error);
        }
    }

    /// <summary>
    /// 添加设备返回结果
    /// </summary>
    interface InetworkResult{
        void onSuccess(ItemPoint item);

        void onFailure(string error);
    }
}
