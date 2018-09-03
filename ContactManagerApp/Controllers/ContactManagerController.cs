
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManagerApp.Controllers
{
    public class ContactManagerController : ApiController
    {
        public IHttpActionResult Get()
        {
            var cm = new ContactManager.BLL.ContactManager();
            return Json(cm.GetCustomers());
        }
        

    }
}
