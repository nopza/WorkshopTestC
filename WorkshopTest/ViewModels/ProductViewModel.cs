using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkshopTest.ViewModels
{
    public class ProductViewModel
    {
        //[Required (ErrorMessage = "Search cannot be null")]
        public string SearchProductName { get; set; }
        public List<ProductModel> ProductModelList { get; set; }

        public string Days { get; set; }
    }

    public class ProductModel
    {
        public int Idp { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public DateTime ExpDate { get; set; }
    }
}


