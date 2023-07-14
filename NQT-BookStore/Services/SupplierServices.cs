﻿using NQT_BookStore.IServices;
using NQT_BookStore.Models;

namespace NQT_BookStore.Services
{
    public class SupplierServices : ISupplierServices
    {
        ShoppingDbContext _context;

        public SupplierServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool CreateSupplier(Supplier p)
        {
            try
            {
                _context.Suppliers.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSupplier(Guid id)
        {
            try
            {
                var p = _context.Suppliers.Find(id);
                _context.Suppliers.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier GetSupplierById(Guid id)
        {
            return _context.Suppliers.FirstOrDefault(p => p.ID == id);
        }

        public List<Supplier> GetSupplierByName(string name)
        {
            return _context.Suppliers.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateSupplier(Supplier p)
        {
            try
            {
                var a = _context.Suppliers.Find(p.ID);
                a.Name = p.Name;
                a.Status = p.Status;

                _context.Suppliers.Update(a);
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
