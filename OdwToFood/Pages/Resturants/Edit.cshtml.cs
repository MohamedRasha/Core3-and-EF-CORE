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
    public class EditModel : PageModel
    {
        private readonly IResturant resturant;
        private readonly IHtmlHelper htmlHelper;
    
        [BindProperty]
        public OdeToFoodCLib.Resturant Resturant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IResturant resturant, IHtmlHelper htmlHelper)
        {
            this.resturant = resturant;
            this.htmlHelper = htmlHelper;

        }
        public IActionResult OnGet(int? id)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (id.HasValue)
            {
                Resturant = resturant.GetById(id.Value);

            }
            else
            {
                Resturant = new Resturant();
                
            }

            if (Resturant == null)
            {
                return RedirectToPage("../Error");
            }
           
                return Page();
        }



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

                return Page();
            }


            if (Resturant.Id>0)
            {

                resturant.Update(Resturant);
              TempData["Message"] = "New Resturant has been edited";

            }
            else
            {
                resturant.Add(Resturant);
                TempData["Message"] = "New Resturant has been Added";

            }
            return RedirectToPage("./Details", new {Id=Resturant.Id });

        }
    }
}