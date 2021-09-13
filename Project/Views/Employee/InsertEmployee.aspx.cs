using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Controllers;
using Project.Model;

namespace Project.Views
{
    public partial class InsertEmployee : System.Web.UI.Page
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
            int salary = 0;

            try
            {
                salary = Convert.ToInt32(salaryTxt.Text.ToString());
            }
            catch
            {
                errLbl.Text = "Salary must be numeric";
            }

            errLbl.Text = EmployeeController.insert(email, password, name, DOB, gender, phone, address, salary);

            // redirect to manage employee
            if (errLbl.Text == "") Response.Redirect("~/Views/Employee/ManageEmployee.aspx");

        }
    }
}