namespace SnackyAPI.Models.Database
{
    public class SnackCategory
    {
        public int SnackId { get; set; }
        public required Snack Snack { get; set; }
        public Category Category { get; set; }
    }
}
