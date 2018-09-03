using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ContactManager.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        [HttpGet]
        [Route("Customers")]
        public IHttpActionResult GetCustomers()
        {
            var cm = new BLL.ContactManager();
            return Json(cm.GetCustomers());
        }

        [HttpGet]
        [Route("Customer/{CustomerId}")]
        public IHttpActionResult GetCustomer(long CustomerId)
        {
            var cm = new BLL.ContactManager();
            return Json(cm.GetCustomer(CustomerId));
        }

        [HttpPost]
        [Route("Customer")]
        public IHttpActionResult AddCustomers([FromBody] Models.Contact.Customer customer)
        {
            var cs = new BLL.ContactManager();
            cs.AddCustomers(customer);
            return Ok();
        }

        [HttpPut]
        [Route("Customer")]
        public IHttpActionResult ModifyCustomer([FromBody] Models.Contact.Customer customer){
            var cs = new BLL.ContactManager();
            cs.ModifyCustomers(customer);
            return Ok();
        }

        [HttpDelete]
        [Route("Customer/{CustomerId}")]
        public IHttpActionResult DeleteCustomer(long CustomerId)
        {
            var cs = new BLL.ContactManager();
            cs.DeleteCustomers(CustomerId);
            return Ok();
        }

        // **** Suppliers *****

        [HttpGet]
        [Route("Suppliers")]
        public IHttpActionResult GetSuppliers()
        {
            var cs = new BLL.ContactManager();
            return Json(cs.GetSuppliers());

        }

        [HttpGet]
        [Route("Supplier/{SupplierId}")]
        public IHttpActionResult GetSupplier(long SupplierId)
        {
            var cs = new BLL.ContactManager();
            return Json(cs.GetSupplier(SupplierId));
        }



        [HttpDelete]
        [Route("Supplier/{SupplierId}")]
        public IHttpActionResult DeleteSupplier(long SupplierId)
        {
            var cs = new BLL.ContactManager();
            cs.DeleteSuppliers(SupplierId);
            return Ok();
        }

        [HttpPost]
        [Route("Supplier")]
        public IHttpActionResult AddSuppliers([FromBody] Models.Contact.Supplier supplier)
        {
            var cs = new BLL.ContactManager();
            cs.AddSuppliers(supplier);
            return Ok();
        }

        [HttpPut]
        [Route("Supplier")]
        public IHttpActionResult ModifySupplier([FromBody] Models.Contact.Supplier supplier)
        {
            var cs = new BLL.ContactManager();
            cs.ModifySuppliers(supplier);
            return Ok();
        }

    }
}
