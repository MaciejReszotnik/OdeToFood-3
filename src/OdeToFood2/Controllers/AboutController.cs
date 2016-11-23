using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToFood2.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController : Controller
    {
        // GET: /<controller>/

        public string Phone()
        {
            return "1+555-555-5555";
        }

        public string Address()
        {
            return "USA";
        }
    }
}
