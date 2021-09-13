using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Handlers;
using Project.Model;

namespace Project.Controllers
{
    public class MemberController
    {
        public static MsMember login(string email, string password)
        {
            return MemberHandler.login(email, password);
        }

        public static string RandomizeCaptcha()
        {
            Random rand = new Random();
            string str1 = "", str2;

            for (int i = 0; i < 3; i++)
            {
                if (rand.Next(2) == 0)
                {
                    str1 += Char.ConvertFromUtf32(rand.Next(26) + 65);
                }
                else
                {
                    str1 += Char.ConvertFromUtf32(rand.Next(26) + 97);
                }
            }

            str2 = (rand.Next(900) + 100).ToString();

            return str1 + str2;
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
                MemberHandler.ChangePassword(email, password);
            }

            return lblErr;

        }
        public static string informationValidation(string email, string password, string name, string DOB, string gender, string phone, string address)
        {
            // check buat email unik
            if (MemberHandler.findUniqueEmail(email))
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
            if (phone == "")
            {
                return "Phone must not be empty";
            }

            // check address
            if (!address.Contains("Street"))
            {
                return "Address must contain the word 'Street'";
            }

            return "";

        }

        public static string insert(string email, string password, string name, string DOB, string gender, string phone, string address)
        {

            string validate = MemberController.informationValidation(email, password, name, DOB, gender, phone, address);

            if (validate == "")
            {
                DateTime dateOfBirth = Convert.ToDateTime(DOB);
                MemberHandler.insert(email, password, name, dateOfBirth, gender, phone, address);
            }
             
            return validate;

        }

        public static List<MsMember> getAllMember()
        {
            return MemberHandler.getAllMember();
        }

        public static void delete(int id)
        {
            MemberHandler.delete(id);
        }

        public static MsMember findById(int id)
        {
            return MemberHandler.findById(id);
        }

        public static bool IsExist(string email)
        {
            return MemberHandler.findUniqueEmail(email);
        }

        public static string update(int id, string email, string password, string name, string DOB, string gender, string phone, string address)
        {
            string validate = MemberController.informationValidation(email, password, name, DOB, gender, phone, address);

            MsMember member = MemberHandler.findById(id);

            if (validate == "")
            {
                DateTime dateOfBirth = Convert.ToDateTime(DOB);
                MemberHandler.update(id, email, password, name, dateOfBirth, gender, phone, address);
            }

            return validate;
        }

        public static List<TrDetail> history(int id)
        {
            return MemberHandler.history(id);
        }

        public static string preorder(int memberId, int flowerId, int qty)
        {
            if(qty < 1 || qty > 100)
            {
                return "Quantity must be between 1-100";
            }

            MemberHandler.preorder(memberId, flowerId, qty);

            return "Success";

        }

    }
}