using Project.Controllers;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Views.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if(email == "admin" && password == "admin")
            {
                Session["admin"] = "admin";
                Response.Redirect("~/Views/Home.aspx");
            }

            MsMember member = MemberController.login(email, password);
            MsEmployee employee = EmployeeController.login(email, password);

            if (member == null)
            {
                if(employee == null)
                {
                    lblErrMsg.Text = "Username / Password doesn't exists";
                    return;
                }
            }
            
            if (member != null)
            {
                Session["member"] = member;
                //Cookie remember me
                if (rememberChck.Checked)
                {
                    HttpCookie cookie = new HttpCookie("member", member.MemberId.ToString());
                    cookie.Expires.AddDays(1);
                    Response.Cookies.Set(cookie);
                }
            }
            else
            {
                Session["employee"] = employee;
                //Cookie remember me
                if (rememberChck.Checked)
                {
                    HttpCookie cookie = new HttpCookie("employee", employee.EmployeeId.ToString());
                    cookie.Expires.AddDays(1);
                    Response.Cookies.Set(cookie);
                }
            }

            Response.Redirect("~/Views/Home.aspx");
        }

        protected void RegisBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Auth/Register.aspx");
        }

        protected void ForgetBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Auth/ForgotPassword.aspx");
        }
    }
}