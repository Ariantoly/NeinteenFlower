using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Model;

namespace Project.Repositories
{
    public class EmployeeRepository
    {
        public static MsEmployee login(string email, string password)
        {
            DatabaseEntities db = new DatabaseEntities();
            MsEmployee e = (from x in db.MsEmployees where x.EmployeeEmail.Equals(email) && x.EmployeePassword.Equals(password) select x).FirstOrDefault();
            return e;
        }

        public static void insert(MsEmployee employee)
        {
            DatabaseEntities db = new DatabaseEntities();

            db.MsEmployees.Add(employee);
            db.SaveChanges();
        }

        public static bool findUniqueEmail(string email)
        {
            DatabaseEntities db = new DatabaseEntities();

            return db.MsEmployees.Any(x => x.EmployeeEmail.Equals(email));
        }

        public static List<MsEmployee> getAllEmployee()
        {
            DatabaseEntities db = new DatabaseEntities();

            return db.MsEmployees.ToList();
        }

        public static void delete(int id)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsEmployee employee = db.MsEmployees.Find(id);

            db.MsEmployees.Remove(employee);
            db.SaveChanges();
        }

        public static MsEmployee findById(int id)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsEmployee employee = db.MsEmployees.Find(id);

            return employee;
        }

        public static void update(int id, string email, string password, string name, DateTime DOB, string gender, string phone, string address, int salary)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsEmployee employee = db.MsEmployees.Find(id);
            employee.EmployeeEmail = email;
            employee.EmployeePassword = password;
            employee.EmployeeName = name;
            employee.EmployeeDOB = DOB;
            employee.EmployeeGender = gender;
            employee.EmployeePhone = phone;
            employee.EmployeeAddress = address;
            employee.EmployeeSalary = salary;

            db.SaveChanges();
        }

        public static void ChangePassword(string email, string newPass)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsEmployee employee = db.MsEmployees.Where(x => x.EmployeeEmail == email).FirstOrDefault();
            employee.EmployeePassword = newPass;

            db.SaveChanges();
        }

        public static MsEmployee getFirst()
        {
            DatabaseEntities db = new DatabaseEntities();

            MsEmployee employee = db.MsEmployees.First();

            return employee;

        }

    }
}