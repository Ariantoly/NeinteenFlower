using Project.Factories;
using Project.Model;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class FlowerHandler
    {
        public static MsFlower show(int id)
        {
            return FlowerRepository.show(id);
        }

        public static void Insert(string name, string image, string desc, int typeId, int price)
        {
            MsFlower newFlower = FlowerFactory.Create(name, image, desc, typeId, price);

            FlowerRepository.Insert(newFlower);
        }

        public static void Delete(int id)
        {
            FlowerRepository.Delete(id);
        }

        public static void Update(int id, string name, string image, string desc, int typeId, int price)
        {
            MsFlower updatedFlower = FlowerFactory.Create(name, image, desc, typeId, price);

            FlowerRepository.Update(id, updatedFlower);
        }

        public static List<MsFlower> GetAllFlower()
        {
            return FlowerRepository.GetAllFlower();
        }

        public static MsFlower FindById(int id)
        {
            return FlowerRepository.FindById(id);
        }

        public static int GetIdByName(string typeName)
        {
            return FlowerTypeRepository.GetIdByName(typeName);
        }

        public static string GetTypeName(int id)
        {
            return FlowerTypeRepository.GetTypeName(id);
        }
    }
}