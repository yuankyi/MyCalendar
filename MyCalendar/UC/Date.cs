using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCalendar.UC
{
    public partial class Date : UserControl
    {
        private DateItem _di;
        private Font fDate, fDesc;

        public Date(DateItem di)
        {
            InitializeComponent();
            this._di = di;
            Init();
        }

        private void lbl_click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
            this.Focus();
        }

        private void lbl_doubleClick(object sender, EventArgs e)
        {
            if (_di != null)
                MessageBox.Show(this._di.Date.ToShortDateString());
        }

        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = _di.StatusColor;
        }

        private void Init()
        {
            if (_di != null)
            {
                fDate = new Font("宋体", 15);
                lblDate.Text = _di.Date.Day.ToString();
                lblDate.Font = fDate;

                fDesc = new Font("宋体", 8);
                lblDesc.Text = _di.Status.ToString();
                lblDesc.Font = fDesc;

                this.BackColor = _di.StatusColor;
            }
            else
            {
                lblDate.Text = "";
                lblDesc.Text = "";
            }
        }

    }
}
