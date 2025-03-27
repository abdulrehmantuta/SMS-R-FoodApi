namespace SMS_R_FoodApi.Models
{
    public class Sale
    {

        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string SaleDate { get; set; }
        public string FoodCenterName { get; set; }
        public string FoodCenterAddress { get; set; }
        public List<SaleParameter> Items { get; set; }
    }

    public class SaleParameter
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Amount { get; set; }
    }
}
