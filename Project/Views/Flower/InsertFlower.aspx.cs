using Project.Controllers;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views.Flower
{
    public partial class InsertFlower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsEmployee employee = (MsEmployee)Session["employee"];
            if(employee == null)
            {
                Response.Redirect("~/Views/Auth/Login.aspx");
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string image = fileImage.FileName;
            string desc = txtDesc.Text;
            string type = txtType.Text;
            string price = txtPrice.Text;

            lblErr.Text = FlowerController.Insert(name, image, desc, type, price);

            if(lblErr.Text == "")
            {
                string filePath = HttpContext.Current.Server.MapPath("~/Images/" + image);
                fileImage.SaveAs(filePath);
                Response.Redirect("~/Views/Flower/ManageFlower.aspx");
            }

        }
    }
}