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
    public partial class Form1 : Form
    {
        private Housing Hs;
        bool ok = false;
        string username;
        Months setMonth;
        private static UserDetails logeduser;
        private static int indexgrocery;
        public Form1()
        {
            InitializeComponent();
            this.Calenderlistrefresh();
            setMonth = (Months)(Assigndatetask.Value.Month - 1);
            lblMonth.Text = setMonth.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Hs = new Housing(3124);
            Hs.CreatUser("bob", "a");
            

        }

        private void comboboxrefresher()
        {
            cbUsers.Items.Clear();
            foreach(UserDetails ud in Hs.Displayusers())
            {
                cbUsers.Items.Add(ud.ShowUsername());
            }
        }

        /*
         Methods created
         ----------------------------------------------------------------------------------------------------------------------------------
        */

        private void rbFilter_Check(object sender, EventArgs e)
        {
            Calenderlistrefresh();
        }

        public void Grocerylistrefresh()
        {
            lbGroceries.Items.Clear();
            foreach (Groceries buyer in Hs.DisplayGroceries())
            {
                lbGroceries.Items.Add(buyer.Show());
            }
        }

        private void Calenderlistrefresh()
        {
            Lbhomecalender.Items.Clear();
  
            if(rbAllevent.Checked)
            {
                List<string> displayEvents = new List<string>();
                foreach (Activities act in Hs.DisplayActivities())
                {
                    if (act.month - 1 == Convert.ToInt32(setMonth))
                    { displayEvents.Add(act.GetActivityDetails()); }
                }

                displayEvents.Sort();
            
                foreach (string i in displayEvents)
                {
                    Lbhomecalender.Items.Add(i);
                }
            }
            else if(rbAlltask.Checked)
            {
                List<string> taskDisplay = new List<string>();
                foreach (Tasks ts in Hs.DisplayTasks())
                {
                    if (ts.month - 1 == Convert.ToInt32(setMonth))
                    {    
                        taskDisplay.Add(ts.GetTaskinfo());
                    }
                }

                taskDisplay.Sort();

                foreach (string i in taskDisplay)
                {
                    Lbhomecalender.Items.Add(i);
                }

            }
            else if(rbPersonal.Checked)
            {
                if (logeduser != null)
                {
                    List<string> personalTaskDisplay = new List<string>();
                    foreach (Tasks ts in logeduser.DisplayPersonalTasks())
                    {
                        if (ts.month - 1 == Convert.ToInt32(setMonth))
                        { personalTaskDisplay.Add(ts.GetTaskinfo()); }
                    }

                    personalTaskDisplay.Sort();

                    foreach (string i in personalTaskDisplay)
                    {
                        Lbhomecalender.Items.Add(i);
                    }
                }
            }
           
        }

        private void UpdateActivityGUI()
        {
            lbEventlist.Items.Clear();
            List<string> displayEvents = new List<string>();
            foreach (Activities act in Hs.DisplayActivities())
            {
               displayEvents.Add(act.FullActivityDetails()); 
            }

            displayEvents.Sort();

            foreach (string i in displayEvents)
            {
                lbEventlist.Items.Add(i);
            }
        }

        private void ShowNotification()
        {

            string message = "You have got stricked for :";
            foreach (UserDetails ud in Hs.Displayusers())
            {
                if (ud.ShowUsername() == logeduser.ShowUsername())
                {
                    foreach (string i in ud.Displaynotif())
                    {
                        message += " - (" + i + ")";

                    }


                }
            }
            if (message != "You have got stricked for :")
            {
                MessageBox.Show(message);
                logeduser.deletnotiflist();
            }

        }

        /*
        Loginscreen
        ----------------------------------------------------------------------------------------------------------------------------------
        */

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            string loginPassword = tbPassword.Text;
            username = tbUsername.Text;

            if (username.Contains("Admin") && loginPassword.Contains("AdminAdmin"))
            {
                tabAdmin.Enabled = true;
                loginPanel.Visible = false;
                btnSignOut.Visible = true;
                tabHomepage.Visible = true;
                panelHideAdmin.Visible = false;
                panelHideRules.Visible = false;
                gbHeader.Visible = true;
                lblLogedInUser.Text = "Admin";
                logeduser = null;
            }
            else
            {
                foreach (UserDetails user in Hs.Displayusers())
                {
                    if (username == user.ShowUsername() && loginPassword == user.ShowPassword())
                    {
                        tabAdmin.Enabled = false;
                        loginPanel.Visible = false;
                        btnSignOut.Visible = true;
                        tabHomepage.Visible = true;
                        panelHideAdmin.Visible = true;
                        panelHideRules.Visible = true;
                        ok = true;
                        logeduser = Hs.Getuser(tbUsername.Text);
                        lblLogedInUser.Text = logeduser.ShowlogedUser();
                        gbHeader.Visible = true;
                        ShowNotification();
                    }
                }
                if (ok != true)
                {
                    MessageBox.Show("Please, check your Username and Password!");
                }
            }
        }

        private void BtnSignOut_Click_1(object sender, EventArgs e)
        {
            tbPassword.Clear();
            tbUsername.Clear();
            loginPanel.Visible = true;
            btnSignOut.Visible = false;
            tabHomepage.Visible = false;
            gbHeader.Visible = false;
        }

        /*
        Home tab
        ----------------------------------------------------------------------------------------------------------------------------------
        */
        private void btnaddnotes_Click_1(object sender, EventArgs e)
        {
                string datetime = DateTime.Now.ToString("dd.MM.yyyy");
                lbnotes.Items.Clear();
                Hs.AddNotes(datetime, logeduser.ShowUsername(), tbnotes.Text);
                foreach (string n in Hs.DisplayNotes())
                {
                    lbnotes.Items.Add(n);
                }
                tbnotes.Clear();
            
        }

        private void lbnotes_DoubleClick(object sender, EventArgs e)
        {
            
            string chosenitem = "";
            if (lbnotes.SelectedItem != null)
            {
                chosenitem = lbnotes.SelectedItem.ToString();
                if (chosenitem.Contains(logeduser.ShowUsername()))
                {
                    lbnotes.Items.Remove(lbnotes.SelectedItem);
                    Hs.RemoveNotes(chosenitem);
                }
                else { MessageBox.Show("Unable to delete Others notes"); }
            }
            else { MessageBox.Show("No notes were chosen"); }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (setMonth != Months.DECEMBER)
            {
                setMonth++;
                lblMonth.Text = setMonth.ToString();
                Calenderlistrefresh();
            }
            else
            {
                MessageBox.Show("You have reached the end of the calendar!");
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (setMonth != Months.JANUARY)
            {
                setMonth--;
                lblMonth.Text = setMonth.ToString();
                Calenderlistrefresh();
            }
            else
            {
                MessageBox.Show("You have reached the end of the calendar!");
            }
        }

        /*
         Events
         ----------------------------------------------------------------------------------------------------------------------------------
         */

        private void BtnDisagree_Click(object sender, EventArgs e)
        {
            Hs.GetActivity(tbeventsub.Text).voteCount++;
            if(Hs.GetActivity(tbeventsub.Text).voteCount == lbUsers.Items.Count/2)
            {
                Hs.GetActivity(tbeventsub.Text).isCancelled = true;
            }

            UpdateActivityGUI();
            Calenderlistrefresh();
        }

        private void btncreateevent_Click(object sender, EventArgs e)
        {

            string subject = tbeventsub.Text;
            string description = tbeventdesc.Text;
            int day = assigneventdate.Value.Day;
            int month = assigneventdate.Value.Month;
            if (!Hs.CreateActivity(logeduser.ShowUsername(), subject, description, day, month))
            {
                MessageBox.Show("An activity with the same subject exists!");
            }
            else
            {
                UpdateActivityGUI();
            }
        }

        private void BtnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (logeduser.ShowUsername() == Hs.GetActivity(tbeventsub.Text).owner || logeduser == null)
            {
                Hs.GetActivity(tbeventsub.Text).isCancelled = true;
            }
            else
                MessageBox.Show("You are not the owner of the event!");
            UpdateActivityGUI();
            Calenderlistrefresh();
        }

            /*
             Groceries
             ----------------------------------------------------------------------------------------------------------------------------------
            */
            private void BtnPaid_Click(object sender, EventArgs e)
        {
            if (logeduser != null)
            {
                var isNumeric = Decimal.TryParse(tbAmount.Text, out decimal amount);
                decimal debtprice = amount / Hs.Displayusers().Count;
                Hs.AddGroceries(amount, logeduser.ShowUsername());
                int index = Convert.ToInt32(Hs.DisplayGroceries().Count) - 1;
                Hs.GetGroceries(index).addusers("amount Everyone Owns : " + debtprice.ToString() + "$");
                foreach (UserDetails ud in Hs.Displayusers())
                {
                    Hs.GetGroceries(index).addusers(ud.ShowUsername());
                }
                Grocerylistrefresh();
                tbAmount.Clear();
            }
        }

        private void lbGroceries_DoubleClick(object sender, EventArgs e)
        {
            if (lbGroceries.SelectedItem != null)
            {
                lbpayers.Items.Clear();
                foreach (string user in Hs.GetGroceries(lbGroceries.SelectedIndex).userlist())
                {
                    if (Hs.GetGroceries(lbGroceries.SelectedIndex).buyerName != user)
                    {
                        lbpayers.Items.Add(user);
                    }
                }
                indexgrocery = lbGroceries.SelectedIndex;
            }
        }

        private void lbpayers_DoubleClick(object sender, EventArgs e)
        {
            if (lbpayers.SelectedItem != null)
            {
                if (logeduser.ShowUsername() == Hs.GetGroceries(indexgrocery).buyerName)
                {
                    Hs.GetGroceries(indexgrocery).removeuser(lbpayers.SelectedItem.ToString());
                    lbpayers.Items.Remove(lbpayers.SelectedItem);
                    if (Hs.GetGroceries(indexgrocery).userlist().Count == 2)
                    {
                        Hs.RemoveGrocery(indexgrocery);
                        lbGroceries.Items.RemoveAt(indexgrocery);
                        lbpayers.Items.Clear();
                    }
                }
            }
        }

        /*
         AdminTab
         ----------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnAssigntask_Click(object sender, EventArgs e)
        {
            int day = Assigndatetask.Value.Day;
            int month = Assigndatetask.Value.Month;
            string user = cbUsers.Text;
            Hs.CreateTask(user,tbassigntask.Text,day,month);
            foreach (UserDetails ud in Hs.Displayusers())
            {
                if (ud.ShowUsername() == cbUsers.Text)
                {
                    ud.DeletePtasks();
                    foreach (Tasks t in Hs.DisplayTasks())
                    {
                        if (t.GetUser() == user)
                        {
                            ud.Assigntask(t);
                            MessageBox.Show(t.GetTaskinfo());
                        }
                    }
                }
            }
            Calenderlistrefresh();
            tbassigntask.Clear();
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (tbAddPassword.Text == "" || tbAddUsername.Text == "")
            {
                MessageBox.Show("Make sure you filled the Username and the password");
            }
            else
            {
                lbUsers.Items.Clear();
                Hs.CreatUser(tbAddUsername.Text, tbAddPassword.Text);
                foreach (UserDetails us in Hs.Displayusers())
                {
                    lbUsers.Items.Add(us.ShowUserDetails());
                }
            }
            comboboxrefresher();
            tbAddUsername.Clear();
            tbAddPassword.Clear();
        }

        private void BtnStrike_Click(object sender, EventArgs e)
        {
            if (tbAddUsername.Text != "" && tbreason.Text != "")
            {
                lbUsers.Items.Clear();
                Hs.Getuser(tbAddUsername.Text).Strikeuser();
                Hs.Getuser(tbAddUsername.Text).Addnotification(tbreason.Text);
                foreach (UserDetails us in Hs.Displayusers())
                {
                    lbUsers.Items.Add(us.ShowUserDetails());
                }
            }
            else { MessageBox.Show("Fill in the user/reportmessage"); }
            tbAddUsername.Clear();
            tbAddPassword.Clear();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            ReportForm Rf = new ReportForm(this.Hs, username);  //Open report
            Rf.Show();
        }

        private void BtnDelReport_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i <= Hs.DisplayReports().Count; i++)
            {
                if (lbReport.SelectedIndex == i)
                {
                    Hs.DeleteReport(i);
                }
            }
            UpdateReports();
        }

        public void UpdateReports()
        {
            lbReport.Items.Clear();
            foreach (string i in Hs.DisplayReports())
            {
                lbReport.Items.Add(i);
            }
        }

        private void TabHomepage_Click(object sender, EventArgs e)
        {
            UpdateReports();
        }

        /*
       Rules
       ----------------------------------------------------------------------------------------------------------------------------------
       */

        private void BtnAddRule_Click(object sender, EventArgs e)
        {
            if (tbRule.Text != "")
            {
                string rule = tbRule.Text;
                lbRules.Items.Add(rule);
                tbRule.Clear();
            }
            else
            {
                MessageBox.Show("Input a rule first");
            }
        }

        private void BtnRemoveRule_Click(object sender, EventArgs e)
        {
            if (lbRules.SelectedItem != null)
            {
                string rule = lbRules.SelectedItem.ToString();
                lbRules.Items.Remove(rule);
            }
            else
            {
                MessageBox.Show("Select a rule first");
            }
        }

       

        

    

        

        

 










    }
}
