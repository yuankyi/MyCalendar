using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace MyCalendar.UC
{
    public partial class Calendar : UserControl
    {
        DateTime monthFirstDay;

        public Calendar()
        {
            InitializeComponent();
            var month = DateTime.Now.ToString("yyyy/MM");
            monthFirstDay = Convert.ToDateTime(month);
            GenDate();
        }

        /// <summary>
        /// yyyy-mm
        /// </summary>
        /// <param name="month"></param>
        public Calendar(string month)
        {
            InitializeComponent();
            monthFirstDay = Convert.ToDateTime(month);
            GenDate();
        }

        private void GenDate()
        {
            lblMonth.Text = monthFirstDay.ToString("yyyy年MM月");

            var firstDay = (int)monthFirstDay.DayOfWeek;
            var month = monthFirstDay.AddMonths(1) - monthFirstDay;
            var days = month.Days;

            var items = Get();

            for (var i = 0; i < 35; i++)
            {
                if (i < firstDay) continue;
                if ((i - firstDay) >= days) continue;

                DateItem di = items.FirstOrDefault(m => m.Date == monthFirstDay.AddDays(i - firstDay));
                if (di == null) di = new DateItem() { Date = monthFirstDay.AddDays(i - firstDay) };

                Date date = new Date(di);
                date.Dock = DockStyle.Fill;
                date.Name = "date" + i;
                tableLayoutPanel1.Controls.Add(date, i % 7, (i / 7) + 2);
            }
        }

        private List<DateItem> Get()
        {
            var items = new List<DateItem>();
            var month = monthFirstDay.AddMonths(1) - monthFirstDay;
            var days = month.Days;

            for (var i = 0; i < days; i++)
            {
                if (i == 5 || i == 13 || i == 22) continue;

                var date = monthFirstDay.AddDays(i);
                items.Add(new DateItem
                {
                    Date = date,
                    Status = date.DayOfWeek == 0 ? DayStatus.放假 : DayStatus.上班
                });
            }

            return items;
        }
    }
}
