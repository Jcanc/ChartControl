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
            _points = chartControl1.Series[0].Points;
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
