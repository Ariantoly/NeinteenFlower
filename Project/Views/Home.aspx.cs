using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;
using Project.Model;

namespace Project.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsMember member = (MsMember)Session["member"];
            MsEmployee employee = (MsEmployee)Session["employee"];
            string admin = (string) Session["admin"];

            //kalau tidak ada session balik ke login biar gabisa ditembak(tinggal copas di page lain)
            if (member == null && employee == null && admin == null)
            {
                Response.Redirect("~/Views/Auth/Login.aspx");
            }

            //cuma buat welcome:)
            if(admin != null)
            {
                WelcomeMsg.Text = "Welcome, admin";
                gvFlower.Visible = false;
                historyBtn.Visible = false;
                flowerBtn.Visible = false;
            }
            else if(member != null)
            {
                string nameMember = member.MemberName;
                WelcomeMsg.Text = "Welcome, " + nameMember;
                flowerBtn.Visible = false;
                memberBtn.Visible = false;
                employeeBtn.Visible = false;
            }
            else
            {
                string nameEmployee = employee.EmployeeName;
                WelcomeMsg.Text = "Welcome, " + nameEmployee;
                gvFlower.Visible = false;
                historyBtn.Visible = false;
                memberBtn.Visible = false;
                employeeBtn.Visible = false;
            }

            if (!IsPostBack)
            {
                // flower gridview for member
                gvFlower.DataSource = FlowerController.GetAllFlower();
                gvFlower.DataBind();
            }
        }

        protected void gvFlower_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Preorder")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvFlower.Rows[index];

                int id = Convert.ToInt32(row.Cells[0].Text.ToString()); // flowerid

                // redirect ke preorder dengan query id dari flower
                Response.Redirect("~/Views/Member/Preorder.aspx?id=" + id);
            }
        }

        protected void historyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/History.aspx");
        }

        protected void flowerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Flower/ManageFlower.aspx");
        }

        protected void memberBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/ManageMember.aspx");
        }

        protected void employeeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Employee/ManageEmployee.aspx");
        }
    }
}