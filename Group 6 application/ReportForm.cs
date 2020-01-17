using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_6_application
{
    public partial class ReportForm : Form
    {
        private Housing Hs;
        private string username;
        public ReportForm(Housing Hs, string username)
        {
            InitializeComponent();
            this.Hs = Hs;
            this.username = username;
        }

        private void BtnSendReport_Click(object sender, EventArgs e)
        {
            if (TbreportDescription.Text != "")
            {
                Hs.AddReport(username, TbreportDescription.Text);
                MessageBox.Show("Your message has been sent to the Administrator.");
            }
            else
            {
                MessageBox.Show("Please, input a message first.");
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
