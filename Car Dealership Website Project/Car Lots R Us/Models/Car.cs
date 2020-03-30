namespace Car_Lots_R_Us.Models
{
    public class Car
    {
        public int IDNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int PurchasePrice { get; set; }
        public int Miles { get; set; }
        public int SellingPrice { get; set; }
        public int SoldPrice { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public string InventoryStatus { get; set; }
        public bool IsNew { get; set; }

    }
}