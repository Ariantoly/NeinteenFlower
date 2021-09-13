using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Factories;
using Project.Repositories;
using Project.Model;

namespace Project.Handlers
{
    public class MemberHandler
    {
        public static MsMember login(string email, string password)
        {
            return MemberRepository.login(email, password);
        }

        public static void insert(string email, string password, string name, DateTime DOB, string gender, string phone, string address)
        {
            MsMember member = MemberFactory.create(email, password, name, DOB, gender, phone, address);

            MemberRepository.insert(member);
        }

        public static bool findUniqueEmail(string email)
        {
            return MemberRepository.findUniqueEmail(email);
        }

        public static List<MsMember> getAllMember()
        {
            return MemberRepository.getAllMember();
        }

        public static void delete(int id)
        {
            MemberRepository.delete(id);
        }

        public static MsMember findById(int id)
        {
            return MemberRepository.findById(id);
        }
        public static void update(int id, string email, string password, string name, DateTime DOB, string gender, string phone, string address)
        {
            MemberRepository.update(id, email, password, name, DOB, gender, phone, address);
        }

        public static void ChangePassword(string email, string newPass)
        {
            MemberRepository.ChangePassword(email, newPass);
        }

        public static List<TrDetail> history(int id)
        {
            return MemberRepository.history(id);
        }

        public static void preorder(int memberId, int flowerId, int qty)
        {

            MsEmployee employee = EmployeeRepository.getFirst();
            int employeeId = employee.EmployeeId;

            TrHeader header = MemberFactory.createHeader(memberId, employeeId, new DateTime(), 0);
            TrDetail detail = MemberFactory.createDetail(header.TransactionId, flowerId, qty);

            MemberRepository.preorder(header, detail);

        }

    }
}