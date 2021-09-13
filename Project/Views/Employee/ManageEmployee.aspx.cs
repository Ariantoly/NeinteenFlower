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
    public partial class ManageEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string admin = (string)Session["admin"];
                if (admin == null)
                {
                    Response.Redirect("~/Views/Auth/Login.aspx");
                }

                GVEmployee.DataSource = EmployeeController.getAllEmployee();
                GVEmployee.DataBind(); 
            }
        }

        protected void GVEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GVEmployee.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            EmployeeController.delete(id);
            Response.Redirect("~/Views/Employee/ManageEmployee.aspx");
        }

        protected void GVEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GVEmployee.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            Response.Redirect("~/Views/Employee/UpdateEmployee.aspx?id=" + id);
        }
    }
}