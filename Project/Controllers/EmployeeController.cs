using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Model;
using Project.Handlers;

namespace Project.Controllers
{
    public class EmployeeController
    {
        public static MsEmployee login(string email, string password)
        {
            return EmployeeHandler.login(email, password);
        }

        public static string ForgotPasswordValidation(string email, string captcha, string password)
        {
            string lblErr = "";

            bool isExist = IsExist(email);

            if (!isExist)
            {
                lblErr += "Your email doesn't exist in database!";
            }
            else if (password != captcha)
            {
                lblErr += "New Password should be the same as captcha!";
            }
            else
            {
                EmployeeHandler.ChangePassword(email, password);
            }

            return lblErr;

        }

        public static string informationValidation(string email, string password, string name, string DOB, string gender, string phone, string address, int salary)
        {
            // check buat email unik
            if (EmployeeHandler.findUniqueEmail(email))
            {
                return "Email must be unique";
            }

            // check buat email format
            if (!email.EndsWith("@gmail.com") || email.StartsWith("@gmail.com"))
            {
                return "Incorrect email format, must end with '@gmail.com' ";
            }

            // check password length
            if (password.Length < 3 || password.Length > 20)
            {
                return "Password must be between 3-20 characters";
            }

            // check name length
            if (name.Length < 3 || name.Length > 20)
            {
                return "Name must be between 3-20 characters";
            }

            // check if name contains only letter
            if (!name.Replace(" ", "").All(char.IsLetter))
            {
                return "Name must be all letter";
            }

            //check apakah DOBTxt kosong
            if (DOB == "")
            {
                return "Date of Birth cannot be empty";
            }

            // check date of birth harus minimum 17 tahun
            DateTime dateOfBirth = Convert.ToDateTime(DOB);
            DateTime now = DateTime.Now;
            DateTime minimum = now.AddYears(-17);

            if (DateTime.Compare(dateOfBirth, minimum) > 0)
            {
                return "Must be 17 years old or higher";
            }

            // check gender
            if (gender == "")
            {
                return "Gender must be choosen";
            }

            // check phone number
            if (phone.Any(char.IsLetter) || phone.Length > 15)
            {
                return "Phone number must be numeric";
            }

            //check phone empty
            if(phone == "")
            {
                return "Phone must not be empty";
            }

            // check address
            if (!address.Contains("Street"))
            {
                return "Address must contain the word 'Street'";
            }

            //check salary
            if (salary < 100 || salary > 1000)
            {
                return "Salary must be 100-1000";
            }

            return "";

        }

        public static string insert(string email, string password, string name, string DOB, string gender, string phone, string address, int salary)
        {
            string validate = EmployeeController.informationValidation(email, password, name, DOB, gender, phone, address, salary);

            if (validate == "")
            {
                DateTime dateOfBirth = Convert.ToDateTime(DOB);
                EmployeeHandler.insert(email, password, name, dateOfBirth, gender, phone, address, salary);
            }

            return validate;
        }

        public static List<MsEmployee> getAllEmployee()
        {
            return EmployeeHandler.getAllEmployee();
        }

        public static void delete(int id)
        {
            EmployeeHandler.delete(id);
        }

        public static MsEmployee findById(int id)
        {
            return EmployeeHandler.findById(id);
        }

        public static bool IsExist(string email)
        {
            return EmployeeHandler.findUniqueEmail(email);
        }

        public static string update(int id, string email, string password, string name, string DOB, string gender, string phone, string address, int salary)
        {
            string validate = EmployeeController.informationValidation(email, password, name, DOB, gender, phone, address, salary);

            MsEmployee employee = EmployeeHandler.findById(id);

            if (validate == "")
            {
                DateTime dateOfBirth = Convert.ToDateTime(DOB);
                EmployeeHandler.update(id, email, password, name, dateOfBirth, gender, phone, address, salary);
            }

            return validate;
        }

    }
}