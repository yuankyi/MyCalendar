using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCalendar
{
    public class DateItem
    {
        public DateTime Date { get; set; }

        public DayStatus Status { get; set; }

        public Color StatusColor
        {
            get { return Color.FromName(((DayStatusColor)this.Status).ToString()); }
        }
    }

    public enum DayStatus
    {
        未安排 = 0,
        上班 = 1,
        放假,
    }

    public enum DayStatusColor
    {
        LightGray = 0,
        LightGreen = 1,
        LightYellow = 2,
    }
}
