using Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views.Auth
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                lblRandom.Text = MemberController.RandomizeCaptcha();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string captcha = lblRandom.Text;
            string password = txtPassword.Text;

            string lblErr = MemberController.ForgotPasswordValidation(email, captcha, password);

            if (lblErr.Contains("email"))
            {
                lblErr = EmployeeController.ForgotPasswordValidation(email, captcha, password);
            }

            lblErrMsg.Text = lblErr;
            
            if(lblErr == "")
            {
                Response.Redirect("~/Views/Auth/Login.aspx");
            }
            
        }
    }
}