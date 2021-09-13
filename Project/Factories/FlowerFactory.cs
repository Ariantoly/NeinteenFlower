using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factories
{
    public class FlowerFactory
    {
        public static MsFlower Create(string name, string image, string desc, int typeId, int price)
        {
            return new MsFlower()
            {
                FlowerName = name,
                FlowerImage = image,
                FlowerDescription = desc,
                FlowerTypeId = typeId,
                FlowerPrice = price
            };
        }
    }
}