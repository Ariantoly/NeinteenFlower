using Project.Handlers;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controllers
{
    public class FlowerController
    {
        public static MsFlower show(int id)
        {
            return FlowerHandler.show(id);
        }

        public static List<MsFlower> GetAllFlower()
        {
            return FlowerHandler.GetAllFlower();
        }

        public static void Delete(int id)
        {
            FlowerHandler.Delete(id);
        }

        public static string isValidate(string name, string image, string desc, string type, string strPrice)
        {
            int price = 0;

            if (name.Equals(""))
            {
                return "Name should be filled!";
            }
            else if (name.Length < 5)
            {
                return "Name should be more than or equals 5 characters!";
            }

            if(image == "")
            {
                return "Please select the image!";
            }
            else if (!image.EndsWith(".jpg"))
            {
                return "Image Extension should be .jpg!";
            }

            if (desc.Length <= 50)
            {
                return "Description should be longer than 50 characters!";
            }

            if (type != "Daisies" && type != "Lilies" && type != "Roses")
            {
                return "Type must be either Daisies, Lilies or Roses!";
            }

            try
            {
                price = int.Parse(strPrice);
                if (price < 20 || price > 100)
                {
                    return "Price must be between 20 and 100!";
                }
            }
            catch
            {
                return "Price must be numeric!";
            }

            return "";

        }

        public static string Insert(string name, string image, string desc, string type, string strPrice)
        {
            string validation = isValidate(name, image, desc, type, strPrice);

            if (validation.Equals(""))
            {
                int price = int.Parse(strPrice);
                int typeId = FlowerHandler.GetIdByName(type);
                string imagePath = "~/Images/" + image;
                FlowerHandler.Insert(name, imagePath, desc, typeId, price);
            }

            return validation;
        }

        public static string Update(int id, string name, string image, string desc, string type, string strPrice)
        {
            string validation = isValidate(name, image, desc, type, strPrice);

            if (validation.Equals(""))
            {
                int price = int.Parse(strPrice);
                int typeId = FlowerHandler.GetIdByName(type);
                string imagePath = "~/Images/" + image;
                FlowerHandler.Update(id, name, imagePath, desc, typeId, price);
            }

            return validation;
        }

        public static MsFlower FindById(int id)
        {
            return FlowerHandler.FindById(id);
        }

        public static string GetTypeName(int id)
        {
            return FlowerHandler.GetTypeName(id);
        }
    }
}