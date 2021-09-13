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
    public partial class UpdateEmployee : System.Web.UI.Page
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
                MsEmployee employee = EmployeeController.findById(id);

                emailTxt.Text = employee.EmployeeEmail;
                passwordTxt.Text = employee.EmployeePassword;
                nameTxt.Text =employee.EmployeeName;
                DOBTxt.Text = employee.EmployeeDOB.ToString("yyyy-MM-dd");
                RBGender.SelectedValue = employee.EmployeeGender;
                phoneTxt.Text = employee.EmployeePhone;
                addressTxt.Text = employee.EmployeeAddress;
                salaryTxt.Text = employee.EmployeeSalary.ToString();
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["id"]);

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

            errLbl.Text = EmployeeController.update(id, email, password, name, DOB, gender, phone, address, salary);

            //redirect ke manage employee
            if (errLbl.Text == "") Response.Redirect("~/Views/Employee/ManageEmployee.aspx");
        }
    }
}