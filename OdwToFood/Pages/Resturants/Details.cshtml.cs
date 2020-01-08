using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Data;
using OdeToFoodCLib;

namespace OdwToFood.Pages.Resturants
{
    public class DetailsModel : PageModel
    {
        [TempData]
        public String Message { get; set; }
        public OdeToFoodCLib.Resturant Resturant { get; set; }
        private readonly IResturant resturants;
  
        public DetailsModel(  IResturant resturants)
        {
            this.resturants = resturants;
        }
        public void OnGet(int Id)
        {
            Resturant = resturants.GetById(Id);
        }
    }
}