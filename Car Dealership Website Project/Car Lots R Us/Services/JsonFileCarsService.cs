using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Car_Lots_R_Us.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace Car_Lots_R_Us.Services
{
    public class JsonFileProductService
    {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "datacars.json"); }
        }

        public IEnumerable<Car> GetCars()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Car[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /*public void AddRating(int productId, int rating)
        {
            var products = GetProducts();

            if (products.First(x => x.IDNumber == productId).Ratings == null)
            {
                products.First(x => GetId(x) == productId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = products.First(x => x.IDNumber == productId).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.IDNumber == productId).Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Car>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }*/
        /*
        public Car GetCar (int id)
        {

        }

        public IEnumerable<Car> SearchCars(string make, string model)
        {

        }
        public void AddCar (Car car)
        {

        }
        public void EditCar (Car car)
        {

        }
        public void RemoveCar (Car car)
        {

        }
        */

        private static int GetId(Car x)
        {
            return x.IDNumber;
        }
    }

}

