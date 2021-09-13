using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsMember member = (MsMember)Session["member"];
            MsEmployee employee = (MsEmployee)Session["employee"];
            string admin = (string)Session["admin"];

            //kalau tidak ada session balik ke login biar gabisa ditembak(tinggal copas di page lain)
            if (member == null && employee == null && admin == null)
            {
                Response.Redirect("~/Views/Auth/Login.aspx");
            }
        }

        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            // destroy semua cookies dan session
            // redirect ke login
            Session.Clear();
            Response.Redirect("~/Views/Auth/Login.aspx");
        }
    }
}