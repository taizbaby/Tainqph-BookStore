﻿using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface IBillDetailsServices
    {
        public bool CreateBillDetails(BillDetails p);
        public bool UpdateBillDetails(BillDetails p);
        public bool DeleteBillDetails(Guid id);
        public List<BillDetails> GetAllBillDetails();
        public BillDetails GetBillDetailsById(Guid id);
        public List<BillDetails> GetBillDetailsByName(string name);
    }
}
