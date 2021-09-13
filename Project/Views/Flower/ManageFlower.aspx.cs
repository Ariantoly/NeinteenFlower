using Project.Controllers;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views
{
    public partial class ManageFlower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MsEmployee employee = (MsEmployee)Session["employee"];
                if (employee == null)
                {
                    Response.Redirect("~/Views/Auth/Login.aspx");
                }

                gvFlower.DataSource = FlowerController.GetAllFlower();
                gvFlower.DataBind();
            }
        }

        protected void gvFlower_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvFlower.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            FlowerController.Delete(id);
            Response.Redirect("~/Views/Flower/ManageFlower.aspx");
        }

        protected void gvFlower_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gvFlower.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            Response.Redirect("~/Views/Flower/UpdateFlower.aspx?id=" + id);
        }
    }
}