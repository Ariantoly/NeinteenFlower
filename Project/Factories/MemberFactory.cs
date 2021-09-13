using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Model;

namespace Project.Factories
{
    public class MemberFactory
    {
        public static MsMember create(string email, string password, string name, DateTime DOB, string gender, string phone, string address) 
        {
            MsMember member = new MsMember();
            member.MemberEmail = email;
            member.MemberPassword = password;
            member.MemberName = name;
            member.MemberDOB = DOB;
            member.MemberGender = gender;
            member.MemberPhone = phone;
            member.MemberAddress = address;

            return member;

        }

        public static TrHeader createHeader(int memberId, int employeeId, DateTime date, int discount)
        {
            TrHeader header = new TrHeader();
            header.MemberId = memberId;
            header.EmployeeId = employeeId;
            header.TransactionDate = date;
            header.DiscountPercentage = discount;

            return header;
        }

        public static TrDetail createDetail(int transactionId, int flowerId, int qty)
        {
            TrDetail detail = new TrDetail();
            detail.TransactionId = transactionId;
            detail.FlowerId = flowerId;
            detail.Quantity = qty;

            return detail;
        }

    }
}