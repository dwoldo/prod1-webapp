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
        
        public Car GetCar (int id)
        {
            Car[] allcars = (Car[])GetCars();
            return allcars.Where(car => car.IDNumber == id).FirstOrDefault();
        }

        public IEnumerable<Car> SearchCars(string make, string model)
        {
            Car[] allcars = (Car[])GetCars();
            return allcars.Where(car => car.Make == make && car.Model == model);
        }

        public void AddCar (Car car)
        {
            List<Car> allcars = (List<Car>)GetCars();
            allcars.Add(car);
            SaveCars(allcars);
        }

        public void SaveCars(List<Car> cars)
        {
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Car>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    cars
                );
            }
        }

        public void EditCar (Car editCar)
        {
            List<Car> allcars = (List<Car>)GetCars();
           int index = allcars.FindIndex(car => car.IDNumber == editCar.IDNumber);
            allcars[index] = editCar;
            SaveCars(allcars);
        }

        public void RemoveCar (int IDNumber)
        {
            List<Car> allcars = (List<Car>)GetCars();
            int index = allcars.FindIndex(car => car.IDNumber == IDNumber);
            allcars.RemoveAt(index);
            SaveCars(allcars);
        }

        /*
        private static int GetId(Car x)
        {
            return x.IDNumber;
        }*/
    }
    
}

