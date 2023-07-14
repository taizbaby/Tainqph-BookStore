﻿namespace NQT_BookStore.Models
{
    public class Category
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}
