using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class FlowerRepository
    {
        public static MsFlower show(int id)
        {
            DatabaseEntities db = new DatabaseEntities();
            //show yang product id yang aku select
            MsFlower p = db.MsFlowers.Find(id);
            return p;
        }

        public static void Insert(MsFlower newFlower)
        {
            DatabaseEntities db = new DatabaseEntities();

            db.MsFlowers.Add(newFlower);
            db.SaveChanges();
        }

        public static void Delete(int id)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsFlower flower = db.MsFlowers.Find(id);

            db.MsFlowers.Remove(flower);
            db.SaveChanges();
        }

        public static void Update(int id, MsFlower updatedFlower)
        {
            DatabaseEntities db = new DatabaseEntities();

            MsFlower flower = db.MsFlowers.Find(id);

            flower.FlowerName = updatedFlower.FlowerName;
            flower.FlowerImage = updatedFlower.FlowerImage;
            flower.FlowerDescription = updatedFlower.FlowerDescription;
            flower.FlowerTypeId = updatedFlower.FlowerTypeId;
            flower.FlowerPrice = updatedFlower.FlowerPrice;

            db.SaveChanges();
        }

        public static List<MsFlower> GetAllFlower()
        {
            DatabaseEntities db = new DatabaseEntities();

            return db.MsFlowers.ToList();
        }

        public static MsFlower FindById(int id)
        {
            DatabaseEntities db = new DatabaseEntities();

            return db.MsFlowers.Find(id);
        }
    }
}