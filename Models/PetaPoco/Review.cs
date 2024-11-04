namespace umbraco_assignment.Models.PetaPoco
{
    public class Review
    {
        public string Name { get; set; }

        public string Comment { get; set; }

        public int RestaurantId { get; set; }

        public int Rating { get; set; }

        public DateTime Date { get; set; }
    }
}