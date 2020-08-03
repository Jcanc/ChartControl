using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Windows.Forms;

namespace ChartControl
{
    public partial class Form1 : Form
    {
        private const int _pointsCount = 15;  //固定保留15个点
        private int _hour = 0;
        private int _minute = 0;
        private SeriesPointCollection _points;

        public Form1()
        {
            InitializeComponent();
            var series = chartControl1.Series[0];
            _points = series.Points;

            #region 常用属性，可按需求设置
            series.ArgumentScaleType = ScaleType.Qualitative;     //使用自定义时间
            //chartControl1.ToolTipEnabled = DefaultBoolean.True; //显示曲线端点值
            //chartControl1.ToolTipOptions.ShowForSeries = true;  //显示曲线名称
            //chartControl1.CrosshairEnabled = DefaultBoolean.False;//隐藏十字线

            //XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            ////设定曲线图缩放
            //diagram.EnableAxisXScrolling = true;
            //diagram.EnableAxisXZooming = true;
            //diagram.EnableAxisYScrolling = true;
            //diagram.EnableAxisYZooming = true;
            ////设定曲线图视野，注意要先设置WholeRange
            //diagram.AxisY.WholeRange.SetMinMaxValues(-10, 30);
            //diagram.AxisY.VisualRange.SetMinMaxValues(-10, 30);
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_minute >= 60)
            {
                _hour += 1;
                _minute = 0;
            }
            if (_hour == 24)
            {
                _hour = 0;
            }
            if (_points.Count >= _pointsCount)
            {
                _points.RemoveAt(0);
            }
            var argument = $"{_hour.ToString().PadLeft(2, '0')}:{_minute.ToString().PadLeft(2, '0')}";  // X轴数据
            var value = Math.Round(new Random().NextDouble() * 20, 2);  // Y轴数据
            var seriesPoint = new SeriesPoint(argument, value);
            _points.Add(seriesPoint);
            _minute += 1;
        }
    }
}
