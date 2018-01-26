
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
using System.Threading;

namespace XingYuTengFormsApp
{
    public partial class Form : System.Windows.Forms.Form ,INetworkResult
    {

        #region 窗体边框移动改变大小
        private float width;
        private float height;
        private bool isMax;//最大化为true,否则为false
        private bool isAdd;//添加设备true，否则为false
        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;
        private List<ItemPoint> items=new List<ItemPoint>();
        private string mDeviceId;//存储正在显示图表的设备id
        private string dialogDeviceId;//存储弹框里的设备id
        private int count;
        private Thread thread;
        delegate void DelegateCreateDatas(ItemPoint item);
        delegate void DelegateAddDevice(string deviceId);
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
            this.deviceList.ButtonClick += delegate (object sender, CellClickEventArgs e)
            {
                ItemPoint task = (ItemPoint)e.Model;
                DeviceDataDao.Instance.Delete(task.deviceId);
                items.Remove(task);
                if (mDeviceId != null && mDeviceId.Equals(task.deviceId))
                {
                    tabControl1.Controls.Clear();
                    mDeviceId = null;
                }
                deviceList.SetObjects(items);
                MessageBox.Show(task.title+"已删除");
            };
            this.detailObject.FormatCell += detailObject_FormatCell;
        }

        internal void UpdateList(string id,string deviceId,string typeId)
        {
            foreach(ItemPoint item in items)
            {
                if (item.deviceId.Equals(deviceId))
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (DataStreams dataStream in item.dataStreamsList)
                    {
                        RemarksID remarksID = RemarksDao.Instance.GetDeviceDataById(id);
                        foreach (DataPoints dataPoints in dataStream.datapoints)
                        {
                            dataPoints.at = dataPoints.at.Substring(0, dataPoints.at.Length - 4);
                        }
                        if (dataStream.id.Equals("P") || dataStream.id.Equals("T") || dataStream.id.Equals("H"))
                        {
                            //只获取最新的一个点在列表里显示
                            bool m = false;
                            foreach (DataPoints dataPoints in dataStream.datapoints)
                            {
                                if (m)
                                {
                                    break;
                                }
                                if (remarksID != null && !string.IsNullOrEmpty(remarksID.remarks)&& dataStream.id.Equals(typeId))
                                {
                                    builder.Append(remarksID.remarks + "=" + dataPoints.value);   
                                }
                                else
                                {
                                    builder.Append(dataStream.id + "=" + dataPoints.value);
                                }

                                foreach (DeviceDataStreams stream in item.deviceDatastreams)
                                {
                                    if (dataStream.id.Equals(stream.id))
                                    {
                                        builder.Append(stream.unit + "  ");
                                        m = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    item.dataStrams = builder.ToString();
                    deviceList.SetObjects(items);
                    break;
                }
            }
        }

        private void BackThread()
        {
            ShowLoading();
            items.Clear();
            isAdd = false;
            count = DeviceDataDao.Instance.Count();
            if (count == 0)
            {
                HideLoading();
            }
            else
            {
                thread = new Thread(new ThreadStart(CreateDeviceDatas));
                thread.Start();
            }
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
            ClearAddedcomponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.deviceList.SelectionChanged += delegate (object listSender, EventArgs args)
            {
                HandleSelectionChanged(deviceList);
            };

            this.Resize += new EventHandler(Form1_Resize);
            width = this.Width;
            height = this.Height;
            SetTag(this);
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
                    case HitTestLocation.Text:
                        detail.Visible = true;
                        Point point = deviceList.GetItem(args.HotRowIndex).Position;
                        if (point.Y < 2 + Panel.Height)
                        {
                            detail.Location = new Point(deviceList.Width, 2 + Panel.Height);
                        }
                        else if (point.Y + detail.Height > Height - 2)
                        {
                            detail.Location = new Point(deviceList.Width, Height - 2 - detail.Height);
                        }
                        else {
                            detail.Location = new Point(deviceList.Width, point.Y);
                        }

                        ItemPoint oLVListItem = (ItemPoint)deviceList.GetItem(args.HotRowIndex).RowObject;
                        detailInfo.Text = oLVListItem.title;
                        dialogDeviceId = oLVListItem.deviceId;
                        List<DetailValue> list = new List<DetailValue>();
                        string time = null;
                        foreach (DataStreams dataStream in oLVListItem.dataStreamsList)
                        {
                            //只获取最新的一个点在弹框中显示
                            bool m = false;
                            DetailValue detailValue = new DetailValue();
                            detailValue.ID= oLVListItem.deviceId;
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
            BackThread();
        }

        public void HandleSelectionChanged(ObjectListView listView)
        {
            if (listView.SelectedObject is ItemPoint oLVListItem)
            {
                mDeviceId = oLVListItem.deviceId;
                AddTabPages(oLVListItem);
            }
        }

        private void AddTabPages(ItemPoint oLVListItem)
        {
            tabControl1.Controls.Clear();
            foreach (DataStreams stream in oLVListItem.dataStreamsList)
            {
                TabPage tabPage1 = new TabPage(); ;
                tabPage1.BackColor = System.Drawing.Color.White;
                tabPage1.Location = new System.Drawing.Point(0, 0);
                tabPage1.Name = stream.id;
                tabPage1.Padding = new System.Windows.Forms.Padding(3);
                tabPage1.Size = new System.Drawing.Size(619, 472);
                tabPage1.TabIndex = 0;
                RemarksID remarksID = RemarksDao.Instance.GetDeviceDataById(oLVListItem.deviceId + stream.id);
                string title = null;
                if (remarksID!=null&&!string.IsNullOrEmpty(remarksID.remarks))
                {
                    title = remarksID.remarks + "曲线";
                }
                else
                {
                    title = stream.id + "曲线";
                }
                System.Windows.Media.Color fillColor,strokeColor;
                if (remarksID != null&&!string.IsNullOrEmpty(remarksID.A) && !string.IsNullOrEmpty(remarksID.R) && !string.IsNullOrEmpty(remarksID.G) && !string.IsNullOrEmpty(remarksID.B))
                {
                    fillColor = System.Windows.Media.Color.FromArgb(byte.Parse(remarksID.A), byte.Parse(remarksID.R), byte.Parse(remarksID.G), byte.Parse(remarksID.B));
                    strokeColor = System.Windows.Media.Color.FromArgb(byte.Parse(remarksID.A), byte.Parse(remarksID.R), byte.Parse(remarksID.G), byte.Parse(remarksID.B));
                }
                else
                {
                    fillColor = System.Windows.Media.Color.FromArgb(255, 0, 0, 0);
                    strokeColor = System.Windows.Media.Color.FromArgb(225, 0, 0, 0);
                }
                    tabPage1.Text = title;
                this.tabControl1.Controls.Add(tabPage1);


                // 
                // cartesianChart1
                // 
                LiveCharts.WinForms.CartesianChart cartesianChart1 = new LiveCharts.WinForms.CartesianChart
                {
                    Dock = System.Windows.Forms.DockStyle.Fill,
                    Location = new System.Drawing.Point(0, 0),
                    Name = "cartesianChart1",
                    Size = new System.Drawing.Size(619, 472),
                    TabIndex = 1,
                    Text = "cartesianChart1"
                };

                List<DataPoints> dataPointsList = stream.datapoints;
                double[] values = new double[dataPointsList.Count];
                string[] labels = new string[dataPointsList.Count];
                int m = dataPointsList.Count-1;
                foreach (DataPoints dataPoints in dataPointsList)
                {
                    values[m] = double.Parse(dataPoints.value);
                    labels[m] = dataPoints.at;
                    m--;
                }
                cartesianChart1.Series = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Title = title,
                            Values = new ChartValues<double>(values),
                             PointGeometry = DefaultGeometries.None,
                             Fill = new SolidColorBrush
                                    {
                                        Color = fillColor,
                                        Opacity = .4
                                    },
                             Stroke = new SolidColorBrush(strokeColor)

                        }
                    };

                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "时间",
                    Labels = labels
                });

                string unit = null;
                foreach (DeviceDataStreams devicestream in oLVListItem.deviceDatastreams)
                {
                    if (devicestream.id.Equals(stream.id))
                    {
                        unit = devicestream.unit;
                        break;
                    }
                }

                cartesianChart1.AxisY.Add(new Axis
                {
                    //Title = "Sales",
                    LabelFormatter = value => value.ToString("") + unit
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
                        SetTag(con);
                }
            }
        }

        public void UpdateDeviceList(string deviceId,string title) {
            foreach(ItemPoint itemPoint in items)
            {
                if (itemPoint.deviceId.Equals(deviceId))
                {
                    itemPoint.title = title;                 
                    break;
                }
            }
            deviceList.SetObjects(items);
        }

        /// <summary>
        /// 删除列表详细信息控件
        /// </summary>
        private void ClearAddedcomponent()
        {
            Point p = this.PointToClient(MousePosition);
            Point conPoint = detail.Location;
            if (p.X< conPoint.X||p.X > conPoint.X + detail.Width || p.Y < conPoint.Y || p.Y > conPoint.Y + detail.Height)
            {
                detail.Visible = false;
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.deviceID.Focus();
        }

        private void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    SetTag(con);
            }
        }

        private void SetControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                if (con.Name.Equals("detail")||con.Name.Equals("loading"))
                {
                    continue;
                }
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                Control parent = con.Parent;
                if(parent is Panel) {
                    con.Top = parent.Height/2-con.Height/2;
                    float a = System.Convert.ToSingle(mytag[2]) * newx;
                    con.Left = (int)(a);
                    a = System.Convert.ToSingle(mytag[0]) * newx;
                    con.Width = (int)a;
                } else
                {
                    if (con.Name.Equals("refresh") && refresh.Visible)
                    {
                        ShowRefresh();
                    }
                    else
                    {
                        float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
                        if (!con.Name.Equals("deviceList"))
                        {
                            if (con.Name.Equals("tabControl1"))
                            {
                                con.Width = Width - deviceList.Width - 4;
                            }
                            else if (con.Name.Equals("Panel"))
                            {
                                con.Width = Width - 4;
                            }
                            else
                            {
                                con.Width = (int)a;//宽度
                            }
                        }
                        a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                        if (!con.Name.Equals("Panel"))
                        {
                            if (con.Name.Equals("deviceList") || con.Name.Equals("tabControl1"))
                            {
                                con.Height = Height - Panel.Height - 4;
                            }
                            else
                            {
                                con.Height = (int)(a);
                            }
                        }
                        a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
                        if (con.Name.Equals("tabControl1"))
                        {
                            con.Left = 2 + deviceList.Width;
                        }
                        else
                        {
                            con.Left = (int)(a);
                        }
                        a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                        if (con.Name.Equals("deviceList") || con.Name.Equals("tabControl1"))
                        {
                            con.Top = 2 + Panel.Height;
                        }
                        else
                        {
                            con.Top = (int)(a);
                        }
                    }
                }
                
                if (con.Controls.Count > 0)
                {
                    SetControls(newx, newy, con);
                }
            }

        }

        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = this.Width / width;
            float newy = this.Height / height;
            SetControls(newx, newy, this);
        }

            private void SetupDescibedTaskColumn()
        {
            this.olvColumnDesk.Renderer = CreateDescribedTaskRenderer();
            this.olvColumnDesk.AspectName = "title";
            this.olvColumnDesk.CellPadding = new Rectangle(4, 2, 4, 2);
        }

        private DescribedTaskRenderer CreateDescribedTaskRenderer()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer
            {
                DescriptionAspectName = "dataStrams",
                TitleFont = new Font("Tahoma", 8),
                DescriptionFont = new Font("Tahoma", 10, FontStyle.Bold),
                ImageTextSpace = 8,
                TitleDescriptionSpace = 1,
                DescriptionColor = System.Drawing.Color.Black,
                UseGdiTextRendering = true
            };

            return renderer;
        }

        private void CreateDeviceDatas()
        {
            foreach (DeviceData deviceData in DeviceDataDao.Instance.GetAll()) {
                NetWorkUtil.Instance.GetDataPoints(deviceData, this,null,AllConstant.POINTS,null,null,null,null);
            }
        }

        private void PictureBoxLagest_Click(object sender, EventArgs e)
        {
            if (isMax)
            {
                isMax = false;
                WindowState = FormWindowState.Normal;//还原
                pictureBoxSize.Image = global::XingYuTengFormsApp.Properties.Resources.lagest;
            }
            else
            {
                isMax = true;
                WindowState = FormWindowState.Maximized;//最大化
                pictureBoxSize.Image = global::XingYuTengFormsApp.Properties.Resources.restore;
            }

            if (refresh.Visible)
            {
                ShowRefresh();
            }
        }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PictureBoxSmall_Click(object sender, EventArgs e)
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
                        AddDeviceThread(deviceId);
                    }
                }
                else {
                    MessageBox.Show("请输入7位有效ID");
                }
                               
            }
        }

        private void AddDeviceThread(string deviceId)
        {
            ShowLoading();
            isAdd = true;
            thread = new Thread(new ParameterizedThreadStart(AddDeviceInfo));
            thread.Start(deviceId);
        }

        private void AddDeviceInfo(object obj)
        {
            NetWorkUtil.Instance.AddDevice((string)obj, this);
        }

        private void ShowLoading()
        {
            Point point = tabControl1.Location;
            loading.Location = new Point(point.X+(tabControl1.Width-loading.Width)/2, point.Y +(tabControl1.Height-loading.Height)/2);
            loading.Visible = true;
        }

        private void ShowRefresh()
        {
            Point point = deviceList.Location;
            refresh.Location = new Point(point.X + (deviceList.Width - refresh.Width) / 2, point.Y + (deviceList.Height - refresh.Height) / 2);
            refresh.Visible = true;
        }

        private void HideLoading()
        {
            loading.Visible = false;
        }

        void INetworkResult.OnSuccess(ItemPoint item)
        {
            if (loading.InvokeRequired)
            {
                loading.BeginInvoke(new DelegateCreateDatas(ResultSuccess),item);
            }
            else
            {
                HideLoading();
            }   
        }

        private void ResultSuccess(ItemPoint item)
        {
            items.Add(item);
            if (mDeviceId != null && mDeviceId.Equals(item.deviceId))
            {
                AddTabPages(item);
            }
            if (!deviceList.IsDisposed)
            {
                if (isAdd)
                {
                    deviceList.SetObjects(items);
                }
                else
                {
                    count--;
                    if (count == 0)
                    {
                        refresh.Visible = false;
                        deviceList.SetObjects(items);
                    }
                }
            }
            HideLoading();
            WarningInfo(item.deviceId, item.title, item.dataStreamsList, item.deviceDatastreams);
        }

        private void WarningInfo(string deviceId, string title, List<DataStreams> dataStreamsList, List<DeviceDataStreams> deviceDatastreams)
        {
            Warning warning = WarningDao.Instance.GetWarningById(deviceId);
            if (warning != null && dataStreamsList != null && dataStreamsList.Count > 0)
            {
                foreach (DataStreams dataStreams in dataStreamsList) {
                    AlertLib.AlertForm af = new AlertLib.AlertForm();
                    if (dataStreams.id.Equals("T")) {
                        
                        foreach (DataPoints dataPoints in dataStreams.datapoints)
                        {
                            StringBuilder builder = new StringBuilder(dataPoints.at + "的温度为" + dataPoints.value);
                            foreach(DeviceDataStreams streams in deviceDatastreams)
                            {
                                if (streams.id.Equals("T"))
                                {
                                    builder.Append(streams.unit);
                                }
                            }
                            if (!string.IsNullOrEmpty(warning.temperatureMax) && double.Parse(dataPoints.value) > double.Parse(warning.temperatureMax)){
                                af.Show(deviceId, title, builder.ToString());
                            }

                            if (!string.IsNullOrEmpty(warning.temperatureMin) && double.Parse(dataPoints.value) < double.Parse(warning.temperatureMin))
                            {
                                af.Show(deviceId, title, builder.ToString());
                            }
                            break;
                        }
                    }

                    if (dataStreams.id.Equals("P"))
                    {
                        foreach (DataPoints dataPoints in dataStreams.datapoints)
                        {
                            StringBuilder builder = new StringBuilder(dataPoints.at + "的湿度为" + dataPoints.value);
                            foreach (DeviceDataStreams streams in deviceDatastreams)
                            {
                                if (streams.id.Equals("P"))
                                {
                                    builder.Append(streams.unit);
                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(warning.humidityMax) && double.Parse(dataPoints.value) > double.Parse(warning.humidityMax))
                            {
                                af.Show(deviceId, title, builder.ToString());
                            }

                            if (!string.IsNullOrEmpty(warning.humidityMin) && double.Parse(dataPoints.value) < double.Parse(warning.humidityMin))
                            {
                                af.Show(deviceId, title, builder.ToString());
                            }
                            break;
                        }
                    }
                }
            }
        }

        void INetworkResult.OnFailure(string error)
        {
            count--;
            if (loading.InvokeRequired)
            {
                loading.BeginInvoke(new DelegateAddDevice(ResultFailure),error);
            }
            else
            {
                HideLoading();
            }
           
        }

        private void ResultFailure(string error)
        {
            MessageBox.Show(error);
            if (count == 0)
            {
                if (items.Count > 0)
                {
                    deviceList.SetObjects(items);
                }
                else
                {
                    ShowRefresh();
                }
                HideLoading();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            detail.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            BackThread();
        }

        private void 修改设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 item =new Form2(dialogDeviceId,this);
            item.Location =Location;
            if (!item.IsDisposed)
            {
                item.Hide();
                item.Show();
            }
        }

        private void 备注信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 item = new Form3(dialogDeviceId, this);
            item.Location = Location;
            if (!item.IsDisposed)
            {
                item.Hide();
                item.Show();
            }
        }

        private void detailObject_FormatCell(object sender, FormatCellEventArgs e)
        {
            DetailValue detailValue = (DetailValue)e.Model;
            RemarksID remarksID = RemarksDao.Instance.GetDeviceDataById(detailValue.ID + detailValue.Name);
            if (remarksID!=null&&!string.IsNullOrEmpty(remarksID.remarks)&& e.SubItem.Text.Equals(remarksID.typeId))
            {
                e.SubItem.Text = remarksID.remarks;
            }
            if (remarksID != null&&!string.IsNullOrEmpty(remarksID.A) && !string.IsNullOrEmpty(remarksID.R) && !string.IsNullOrEmpty(remarksID.G) && !string.IsNullOrEmpty(remarksID.B))
            {
                e.SubItem.ForeColor = System.Drawing.Color.FromArgb(int.Parse(remarksID.A), int.Parse(remarksID.R), int.Parse(remarksID.G), int.Parse(remarksID.B));               
            }
            else
            {
                e.SubItem.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            refresh.Visible = false;
            items.Clear();
            isAdd = false;
            BackThread();
        }
    }

    /// <summary>
    /// 添加设备返回结果
    /// </summary>
    interface INetworkResult{
        void OnSuccess(ItemPoint item);

        void OnFailure(string error);
    }
}
