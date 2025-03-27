namespace SMS_R_FoodApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemRate { get; set; }
        public string ItemDate { get; set; }
        //public string ItemImage { get; set; }

        // Foreign Key for Category
        public int CategoryId { get; set; }

        // Navigation Property (Optional)
        public ItemCategory Category { get; set; }
    }

}
