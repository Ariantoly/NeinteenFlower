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
    public partial class UpdateFlower : System.Web.UI.Page
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

                int id = Convert.ToInt32(Request["id"]);
                MsFlower flower = FlowerController.FindById(id);
                string flowerType = FlowerController.GetTypeName(flower.FlowerTypeId);

                txtName.Text = flower.FlowerName;
                txtDesc.Text = flower.FlowerDescription;
                txtType.Text = flowerType;
                txtPrice.Text = flower.FlowerPrice.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["id"]);
            string name = txtName.Text;
            string image = fileImage.FileName;
            string desc = txtDesc.Text;
            string type = txtType.Text;
            string price = txtPrice.Text;

            lblErr.Text = FlowerController.Update(id, name, image, desc, type, price);

            if (lblErr.Text == "")
            {
                string filePath = HttpContext.Current.Server.MapPath("~/Images/" + image);
                fileImage.SaveAs(filePath);
                Response.Redirect("~/Views/Flower/ManageFlower.aspx");
            }
        }
    }
}