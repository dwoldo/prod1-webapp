using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Lots_R_Us.Models;
using Car_Lots_R_Us.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Car_Lots_R_Us.Pages
{
    public class CarListModel : PageModel
    {
        private readonly ILogger<CarListModel> _logger;
        public JsonFileProductService CarService;
        public IEnumerable<Car> Cars { get; private set; }

        public CarListModel(ILogger<CarListModel> logger, JsonFileProductService carService)
        {
            _logger = logger;
            CarService = carService;
        }

        public void OnGet()
        {
            Cars = CarService.GetCars();
        }
    }
}