using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;

namespace Project.Views
{
    public partial class ManageMember : System.Web.UI.Page
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

                GVMember.DataSource = MemberController.getAllMember();
                GVMember.DataBind();
            }
        }

        protected void GVMember_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GVMember.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            MemberController.delete(id);
            Response.Redirect("~/Views/Member/ManageMember.aspx");
        }

        protected void GVMember_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GVMember.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            Response.Redirect("~/Views/Member/UpdateMember.aspx?id=" + id);
        }
    }
}