using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;

namespace Project.Views
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
          
            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            string name = nameTxt.Text;
            string DOB = DOBTxt.Text;
            string gender = RBGender.SelectedValue;
            string phone = phoneTxt.Text; 
            string address = addressTxt.Text;

            errLbl.Text = MemberController.insert(email, password, name, DOB, gender, phone, address);

            // redirect to login
            if (errLbl.Text == "")
            {
                Response.Redirect("~/Views/Auth/Login.aspx");
            }

        }
    }
}