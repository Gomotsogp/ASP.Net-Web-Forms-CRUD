using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task2
{
    public partial class Student : System.Web.UI.Page
    {
        Datahandler dh = new Datahandler();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Default");
            }
        }


        protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        public void Edit()
        {

        }

        public void Delete(int id)
        {
            bool deleted = dh.DeleteUser(id);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Create");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = GridView2.SelectedIndex;
            
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {

        }
    }
}