using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.DataSQL;
using OdeToFoodEntites;

namespace OdwToFood.Pages.Resturants
{
    public class ListModel : PageModel
    {
        private readonly IResturant resturants;

        public string Message { get; set; }
        public IConfiguration Config { get; }
        public IEnumerable<Resturant> ResturantData { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public void OnGet()
        {
            Message = Config["message"];
            ResturantData = resturants.GetByName(SearchTerm);
           
        }

        public ListModel(IConfiguration config ,IResturant resturants)
        {
            Config = config;
            this.resturants = resturants;
        }

    }
}
