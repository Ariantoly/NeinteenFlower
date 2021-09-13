using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;

namespace Project.Views
{
    public partial class InsertMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string admin = (string)Session["admin"];
            if (admin == null)
            {
                Response.Redirect("~/Views/Auth/Login.aspx");
            }
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {

            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            string name = nameTxt.Text;
            string DOB = DOBTxt.Text;
            string gender = RBGender.SelectedValue;
            string phone = phoneTxt.Text;
            string address = addressTxt.Text;

            errLbl.Text = MemberController.insert(email, password, name, DOB, gender, phone, address);

            // redirect to manage member
            if(errLbl.Text == "")Response.Redirect("~/Views/Member/ManageMember.aspx");
        }
    }
}