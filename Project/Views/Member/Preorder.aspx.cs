using Project.Controllers;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views.Member
{
    public partial class Preorder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MsMember member = (MsMember)Session["member"];
                if (member == null)
                {
                    Response.Redirect("~/Views/Auth/Login.aspx");
                }

                int id = int.Parse(Request["id"]);
                MsFlower flower = FlowerController.show(id);
                imageFlower.ImageUrl = flower.FlowerImage;
                nameFlower.Text = "Name: " + flower.FlowerName;
                descFlower.Text = "Desc: " + flower.FlowerDescription;
                priceFlower.Text = "Price: " + flower.FlowerPrice.ToString();
            }
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            int flowerId = int.Parse(Request["id"]); // flowerId
            MsMember member = (MsMember)Session["member"];
            int memberId = member.MemberId;
            int qty = 0;

            ErrorMsg.Text = "";

            try
            {
                qty = Convert.ToInt32(qtyValue.Text.ToString());
            }
            catch
            {
                ErrorMsg.Text = "Salary must be numeric";
            }

            string res = MemberController.preorder(memberId, flowerId, qty);
            ErrorMsg.Text = res;
        }
    }
}