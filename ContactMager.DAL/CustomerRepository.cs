using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactMager.DAL
{
    public class CustomerRepository // calss for method for CRUD Operation on Customer Table
    {
        public List<Customer> GetCustomers()
        {
            using (var context = new ContactContext())
            {
                return (from c in context.Customers select c).ToList();
            }
        }

        public Customer GetCustomer(long customerId)
        {
            using (var context = new ContactContext())
            {
                return (from c in context.Customers where c.CustomerId == customerId select c).FirstOrDefault();
            }
        }



        public void InsertCustomer(string fname, string lname, DateTime? dt, string email)
        {
            using (var context = new ContactContext())
            {
                var customer = new Customer();
                customer.FirstName = fname;
                customer.LastName = lname;
                customer.BirthDay = dt;
                customer.Email = email;
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void ModifyCusotmer(long cid, string fname, string lname, DateTime? dt, string email)
        {
            using (var context = new ContactContext())
            {

                var customer = context.Customers.Find(cid);

                if (customer == null)
                {
                    throw new ApplicationException($"Could not find the cutomer with Customer Id: {cid}");
                }

                customer.FirstName = fname;
                customer.LastName = lname;
                customer.BirthDay = dt;
                customer.Email = email;
                context.SaveChanges();
            }

        }

        public void Deletecustomer(long cid)
        {
            using (var context = new ContactContext())
            {
                var customer = context.Customers.Find(cid);
                if (customer == null)
                {
                    throw new ApplicationException($"Could not find the cutomer with Customer Id: {cid}");
                }
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }
    }
}