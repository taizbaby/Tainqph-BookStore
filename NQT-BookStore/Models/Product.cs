namespace NQT_BookStore.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public Guid SupplierID { get; set; }
        public Guid CategoryID { get; set; }
        public Guid TypeID { get; set; }
        public Guid ProducerID { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }

        public string Images { get; set; }
        public string Describe { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual Types Types { get; set; }
        public virtual List<CartDetails> CartDetails { get; set; }
        public virtual List<BillDetails> BillDetails { get; set; }
    }
}
