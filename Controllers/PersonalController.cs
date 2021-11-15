using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using firstApp.Models;

namespace firstApp.Controllers
{
    public class PersonalController : Controller
    {
        public IActionResult Index()
        {
            Personal personal = new Personal();
            personal.name ="Eliezer";
            personal.lastname ="Diaz";
            personal.age=18;
            personal.phone="7544-7557";
            personal.direccion= "San Miguel, San Miguel"; 
            return View(personal);
        }
    }
}