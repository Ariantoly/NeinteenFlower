using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Model;

namespace Project.Repositories
{
    public class MemberRepository
    {
        public static MsMember login(string email, string password)
        {
            DatabaseEntities db = new DatabaseEntities();
            MsMember m = (from x in db.MsMembers where x.MemberEmail.Equals(email) && x.MemberPassword.Equals(password) select x).FirstOrDefault();
            return m;
        }

        public static void insert(MsMember member)
        {
            DatabaseEntities db = new DatabaseEntities();

            db.MsMembers.Add(member);
            db.SaveChanges();
        }

        public static bool findUniqueEmail(string email)
        {
            DatabaseEntities db = new DatabaseEntities();

            return db.MsMembers.Any(x => x.MemberEmail.Equals(email) );
        }

        public static List<MsMember> getAllMember()
        {
            DatabaseEntities db = new DatabaseEntities();

            return db.MsMembers.ToList();
        }

        public static void delete(int id)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsMember member = db.MsMembers.Find(id);

            db.MsMembers.Remove(member);
            db.SaveChanges();
        }
           
        public static MsMember findById(int id)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsMember member = db.MsMembers.Find(id);
            return member;
        }

        public static void update(int id, string email, string password, string name, DateTime DOB, string gender, string phone, string address)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsMember member = db.MsMembers.Find(id);
            member.MemberEmail = email;
            member.MemberPassword = password;
            member.MemberName = name;
            member.MemberDOB = DOB;
            member.MemberGender = gender;
            member.MemberPhone = phone;
            member.MemberAddress = address;

            db.SaveChanges();
        }

        public static void ChangePassword(string email, string newPass)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsMember member = db.MsMembers.Where(x => x.MemberEmail == email).FirstOrDefault();
            member.MemberPassword = newPass;

            db.SaveChanges();
        }

        public static List<TrDetail> history(int id)
        {
            DatabaseEntities db = new DatabaseEntities();

            var currentId = db.TrHeaders.Where(x => x.MemberId == id).Select(x => x.TransactionId);
            return db.TrDetails.Where(x => currentId.Contains(x.TransactionId)).ToList();
        }

        public static void preorder(TrHeader header, TrDetail detail)
        {
            DatabaseEntities db = new DatabaseEntities();

            db.TrHeaders.Add(header);
            db.TrDetails.Add(detail);

            db.SaveChanges();
        }


    }
}