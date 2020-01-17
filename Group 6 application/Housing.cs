using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_6_application
{
    public class Housing
    {
        private int housenumber;
        
        private List<UserDetails> user;
        private List<Tasks> tasks;
        private List<Groceries> groceries;
        private List<Activities> activities;
        private List<string> notes;
        private List<string> Reports;

        public Housing(int housenum)
        {
            this.housenumber = housenum;
            this.user= new List<UserDetails>();
            this.tasks = new List<Tasks>();
            this.activities = new List<Activities>();
            this.groceries = new List<Groceries>();
            this.notes = new List<string>();
            this.Reports = new List<string>();
        }

        public void CreatUser(string username, string password)
        {
            this.user.Add(new UserDetails(username, password));

        }
        public void CreateTask(string user,string task,int day,int month)
        {
            this.tasks.Add(new Tasks(user, task,day,month));

        }

        public void AddNotes(string datetime,string user, string Message)
        {
            this.notes.Add( datetime+" - "+ user + " : " + Message);
        }

        public void AddGroceries(decimal amount,string buyer)
        {
            this.groceries.Add(new Groceries(amount, buyer));
            
        }

 

        public Groceries GetGroceries(int index)
        {
            for (int i = 0; i < DisplayGroceries().Count; ++i)
            {
                if (index == i)
                {
                    return groceries[i];
                }
            }
            return null;

        }


        public bool CreateActivity(string owner, string subject, string description, int day, int month)
        {
            foreach (Activities act in this.activities)
            {
                if (act.subject == subject)
                    return false;
            }
            this.activities.Add(new Activities(owner, subject, description, day, month));
            return true;
        }

  

 


        public void AddReport(string user, string report)
        {
            this.Reports.Add(user + " : " + report);
        }

        public Activities GetActivity(string subject)
        {
            foreach (Activities act in this.activities)
            {
                if (act.subject == subject)
                {
                    return act;
                }
            }
            return null;
        }




        public UserDetails Getuser(string username)
        {
            foreach(UserDetails ud in user)
            {
                if(ud.ShowUsername() == username)
                {
                    return ud;
                }
            }
            return null;
        }

        public void DeleteReport(int index)
        {
            for (int i = 0; i <= Reports.Count; i++)
            {
                if (i == index)
                {
                    Reports.RemoveAt(index);
                }
            }
        }


        public void RemoveGrocery(int index)
        {
            for (int i = 0; i < DisplayGroceries().Count; ++i)
            {
                if (index == i)
                {
                    groceries.RemoveAt(index);
                }
            }
        }

        public void RemoveNotes(string note)
        {
            for (int i = 0; i < notes.Count; ++i)
            {
                if (notes[i] == note)
                {
                    this.notes.Remove(notes[i]);
                }
            }

        }

        public void RemoveReport(string report)
        {
            for (int i = 0; i < Reports.Count; ++i)
            {
                if (notes[i] == report)
                {
                    this.Reports.Remove(Reports[i]);
                }
            }
        }

        public Activities[] DisplayActivities()
        {
            List<Activities> Act = new List<Activities>();
            foreach (Activities act in activities)
            {
                Act.Add(act);
            }
            return Act.ToArray();
        }

        public List<string> DisplayReports()
        {
            return Reports;
        }
        public List<string> DisplayNotes()
        {
            return notes;
        }

        public Tasks[] DisplayTasks()
        {
            List<Tasks> Task = new List<Tasks>();
            foreach (Tasks t in tasks)
            {
                Task.Add(t);
            }
            return Task.ToArray();
        }

        public List<UserDetails> Displayusers()
        {
            List<UserDetails> User = new List<UserDetails>();
            foreach(UserDetails user in user)
            {
                User.Add(user);
            }
            return User;
        }

        public List<Groceries> DisplayGroceries()
        {
            return groceries;
        }


    }
}
