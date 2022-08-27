using System;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Models{
    public class Product{
        //"prop" + TAB Auto create properties with getters and setters
        public string Name { get; set; }
        public double Price { get; set; }
        
    }
}