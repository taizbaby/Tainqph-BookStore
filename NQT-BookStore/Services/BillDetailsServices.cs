﻿using Microsoft.EntityFrameworkCore;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;

namespace NQT_BookStore.Services
{
    public class BillDetailsServices : IBillDetailsServices
    {
        ShoppingDbContext _context;

        public BillDetailsServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool CreateBillDetails(BillDetails p)
        {
            try
            {
                _context.BillDetails.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteBillDetails(Guid id)
        {
            try
            {
                var p = _context.BillDetails.Find(id);
                _context.BillDetails.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<BillDetails> GetAllBillDetails()
        {
            return _context.BillDetails.Include("Product").Include("Bill").ToList();
        }

        public BillDetails GetBillDetailsById(Guid id)
        {
            return _context.BillDetails.FirstOrDefault(p => p.ID == id);
        }

        public List<BillDetails> GetBillDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBillDetails(BillDetails p)
        {
            try
            {
                var a = _context.BillDetails.Find(p.ID);
                _context.BillDetails.Remove(a);
                a.BillID = p.ID;
                a.Product = p.Product;
                a.Quantity = p.Quantity;
                a.Price = p.Price;
                a.Status = p.Status;
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
