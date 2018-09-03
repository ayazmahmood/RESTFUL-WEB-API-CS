using ContactMager.DAL;
using ContactManager.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.BLL
{
    public class ContactManager
    {
        private readonly CustomerRepository crep;
        private readonly SupplierRepository srep;

        public ContactManager()
        {
            crep = new CustomerRepository();
            srep = new SupplierRepository();
        }

        public List<Models.Contact.Customer> GetCustomers()
        {
            List<Models.Contact.Customer> customers = new List<Models.Contact.Customer>();           
            foreach (var customer in crep.GetCustomers())
            {
                customers.Add(new Models.Contact.Customer()
                {
                    Person = new Models.Common.Person()
                    {
                        Id = customer.CustomerId,
                        Name = new Models.Common.Name()
                        {
                            First = customer.FirstName,
                            Last = customer.LastName
                        }
                    },
                    BirthDay = customer.BirthDay,
                    Email = customer.Email
                });
            }

            return customers;
        }

        public Models.Contact.Customer GetCustomer(long CustomerId)
        {
            Models.Contact.Customer customer = new Models.Contact.Customer();

            var dalcustomer = crep.GetCustomer(CustomerId);

            customer = new Models.Contact.Customer()
            {
                Person = new Models.Common.Person()
                {
                    Id = dalcustomer.CustomerId,
                    Name = new Models.Common.Name()
                    {
                        First = dalcustomer.FirstName,
                        Last = dalcustomer.LastName
                    }
                },
                BirthDay = dalcustomer.BirthDay,
                Email = dalcustomer.Email
            };

            return customer;
        }
        public List<Models.Contact.Supplier> GetSuppliers()
        {
            List<Models.Contact.Supplier> suppliers = new List<Models.Contact.Supplier>();

            foreach (var supplier in srep.GetSuppliers())
            {
                suppliers.Add(new Models.Contact.Supplier()
                {
                    Person = new Models.Common.Person()
                    {
                        Id = supplier.SupplierId,
                        Name = new Models.Common.Name()
                        {
                            First = supplier.FirstName,
                            Last = supplier.LastName
                        }
                    },
                    Telephone = supplier.Telephone
                });
            }
            return suppliers;
        }
        public Models.Contact.Supplier GetSupplier(long SupplierId)
        {
            Models.Contact.Supplier customer = new Models.Contact.Supplier();

            
            var dalsupplier = srep.GetSupplier(SupplierId);

            customer = new Models.Contact.Supplier()
            {
                Person = new Models.Common.Person()
                {
                    Id = dalsupplier.SupplierId,
                    Name = new Models.Common.Name()
                    {
                        First = dalsupplier.FirstName,
                        Last = dalsupplier.LastName
                    }
                },
                Telephone = dalsupplier.Telephone,
            };

            return customer;
        }




        public void AddCustomers(Models.Contact.Customer customer)
        {            
            crep.InsertCustomer(customer.Person.Name.First, customer.Person.Name.Last, customer.BirthDay, customer.Email);
        }

        public void ModifyCustomers(Models.Contact.Customer customer)
        {
            crep.ModifyCusotmer(customer.Person.Id, customer.Person.Name.First, customer.Person.Name.Last, customer.BirthDay, customer.Email);
        }
        public void DeleteCustomers(long CustomerId)
        {
            crep.Deletecustomer(CustomerId);

        }
        public void DeleteSuppliers(long SupplierId)
        {
            srep.Deletesupplier(SupplierId);

        }
        public void AddSuppliers(Models.Contact.Supplier supplier)
        {
            srep.InsertSupplier(supplier.Person.Name.First, supplier.Person.Name.Last, supplier.Telephone);
        }

        public void ModifySuppliers(Models.Contact.Supplier supplier)
        {
            srep.ModifySupplier(supplier.Person.Id, supplier.Person.Name.First, supplier.Person.Name.Last, supplier.Telephone);
        }


    }
}