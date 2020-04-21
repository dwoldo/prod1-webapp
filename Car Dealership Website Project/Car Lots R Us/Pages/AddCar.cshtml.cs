using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Lots_R_Us.Models;
using Car_Lots_R_Us.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Car_Lots_R_Us.Pages
{
    public class AddCarModel : PageModel
    {
        public JsonFileProductService CarService;
        public IEnumerable<Car> Cars { get; private set; }

        public AddCarModel(JsonFileProductService carService)
        {
            CarService = carService;
        }

        [BindProperty]
        public Car NewCar { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CarService.AddCar(NewCar);

            return RedirectToPage("./Index");
        }

        public void OnGet()
        {
            Car car = new Car();
            //car.IDNumber = IDN.Value;
        }
    }
}