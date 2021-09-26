using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyCalendar.UC;

namespace MyCalendar
{
    public partial class FormYear : Form
    {
        int offset = 10;

        public FormYear()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            init();
        }

        private void init()
        {
            var firstDay = Convert.ToDateTime("2021/01");

            for (var i = 0; i < 12; i++)
            {
                var col = 4;//列数

                var month = firstDay.AddMonths(i);

                var mc = new Calendar(month.ToString("yyyy/MM"));
                mc.Location = new Point(offset + (i % col) * (mc.Width + offset), offset + (i / col) * (mc.Height + offset));

                this.Controls.Add(mc);
            }
        }
    }
}
