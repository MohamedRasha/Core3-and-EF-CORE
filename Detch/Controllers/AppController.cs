using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreatVTwo.Data;
using Microsoft.AspNetCore.Mvc;

namespace Detch.Controllers
{
    public class AppController : Controller
    {
        private readonly DutchContext context;

        public AppController(DutchContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.products.OrderBy(c => c.Category).ToList();
            return View(result);
        }
    }
}