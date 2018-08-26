using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task2
{
    public partial class Create : System.Web.UI.Page
    {
        Datahandler dh = new Datahandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Default");
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            int time = 0;

            if (fulltime.Checked)
            {
                time = 1;
            }
            bool created = dh.CreateNewStudent(name.Text,surname.Text,
                dob.SelectedDate, int.Parse(age.Text), time);

            if (created)
            {
                Response.Redirect("/Student");
            }
        }
    }
}