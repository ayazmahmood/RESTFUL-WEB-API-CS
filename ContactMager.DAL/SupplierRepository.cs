using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactMager.DAL
{
    public class SupplierRepository
    {
        public List<Supplier> GetSuppliers()
        {
            using (var context = new ContactContext())
            {
                return (from s in context.Suppliers select s).ToList();
            }
        }


        public Supplier GetSupplier(long supplierId)
        {
            using (var context = new ContactContext())
            {
                return (from s in context.Suppliers where s.SupplierId == supplierId select s).FirstOrDefault();
            }
        }



        public void Deletesupplier(long cid)
        {
            using (var context = new ContactContext())
            {
                var supplier = context.Suppliers.Find(cid);
                if (supplier == null)
                {
                    throw new ApplicationException($"Could not find the supplier with Supplier Id: {cid}");
                }
                context.Suppliers.Remove(supplier);
                context.SaveChanges();
            }
        }
        public void InsertSupplier(string fname, string lname, string telephone)
        {
            using (var context = new ContactContext())
            {
                var supplier = new Supplier();
                supplier.FirstName = fname;
                supplier.LastName = lname;
                supplier.Telephone = telephone;
                context.Suppliers.Add(supplier);
                context.SaveChanges();
            }
        }

        public void ModifySupplier(long cid, string fname, string lname, string telephone)
        {
            using (var context = new ContactContext())
            {

                var supplier = context.Suppliers.Find(cid);

                if (supplier == null)
                {
                    throw new ApplicationException($"Could not find the cutomer with Supplier Id: {cid}");
                }

                supplier.FirstName = fname;
                supplier.LastName = lname;
                supplier.Telephone = telephone;
                context.SaveChanges();
            }

        }

    }
}