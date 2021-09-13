using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class FlowerTypeRepository
    {
        public static int GetIdByName(string typeName)
        {
            DatabaseEntities db = new DatabaseEntities();

            return db.MsFlowerTypes.Where(x => x.FlowerTypeName == typeName).Select(x => x.FlowerTypeId).FirstOrDefault();
        }

        public static string GetTypeName(int id)
        {
            DatabaseEntities db = new DatabaseEntities();

            return db.MsFlowerTypes.Where(x => x.FlowerTypeId == id).Select(x => x.FlowerTypeName).FirstOrDefault();
        }
    }
}