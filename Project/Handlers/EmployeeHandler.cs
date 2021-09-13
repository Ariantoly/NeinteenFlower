using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Factories;
using Project.Repositories;
using Project.Model;

namespace Project.Handlers
{
    public class EmployeeHandler
    {
        public static MsEmployee login(string email, string password)
        {
            return EmployeeRepository.login(email, password);
        }

        public static void insert(string email, string password, string name, DateTime DOB, string gender, string phone, string address, int salary)
        {

            MsEmployee employee = EmployeeFactory.create(email, password, name, DOB, gender, phone, address, salary);

            EmployeeRepository.insert(employee);
        }

        public static bool findUniqueEmail(string email)
        {
            return EmployeeRepository.findUniqueEmail(email);
        }

        public static List<MsEmployee> getAllEmployee()
        {
            return EmployeeRepository.getAllEmployee();
        }

        public static void delete(int id)
        {
            EmployeeRepository.delete(id);
        }

        public static MsEmployee findById(int id)
        {
            return EmployeeRepository.findById(id);
        }

        public static void update(int id, string email, string password, string name, DateTime DOB, string gender, string phone, string address, int salary)
        {
            EmployeeRepository.update(id, email, password, name, DOB, gender, phone, address, salary);
        }

        public static void ChangePassword(string email, string newPass)
        {
            EmployeeRepository.ChangePassword(email, newPass);
        }
    }
}