using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Model;
using Project.Controllers;

namespace Project.Views
{
    public partial class UpdateMember : System.Web.UI.Page
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

                int id = Convert.ToInt32(Request["id"]);
                MsMember member = MemberController.findById(id);

                emailTxt.Text = member.MemberEmail;
                passwordTxt.Text = member.MemberPassword;
                nameTxt.Text = member.MemberName;
                DOBTxt.Text = member.MemberDOB.ToString("yyyy-MM-dd");
                RBGender.SelectedValue = member.MemberGender;
                phoneTxt.Text = member.MemberPhone;
                addressTxt.Text = member.MemberAddress;
            }

        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["id"]);

            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            string name = nameTxt.Text;
            string DOB = DOBTxt.Text;
            string gender = RBGender.SelectedValue;
            string phone = phoneTxt.Text;
            string address = addressTxt.Text;

            errLbl.Text = MemberController.update(id, email, password, name, DOB, gender, phone, address);
        
            //redirect ke manage member
            if (errLbl.Text == "") Response.Redirect("~/Views/Member/ManageMember.aspx");
        }
    }
}