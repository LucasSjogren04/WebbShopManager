﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopManager.Entities
{
    public class Advertisement
    {
        public int AdvertisementID { get; set; }
        public string Title { get; set; }
        public string DescriptionColumn { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }


        public Advertisement(int advertisementID, string title, string descriptionColumn, decimal price, int categoryID)
        {
            AdvertisementID = advertisementID;
            Title = title;
            DescriptionColumn = descriptionColumn;
            Price = price;
            CategoryID = categoryID;
        }

        public Advertisement()
        {

        }
    }
}
