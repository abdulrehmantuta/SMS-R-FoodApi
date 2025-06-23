namespace SMS_R_FoodApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemRate { get; set; }
        public string ItemDate { get; set; }
        public int CategoryId { get; set; }
    }
}
