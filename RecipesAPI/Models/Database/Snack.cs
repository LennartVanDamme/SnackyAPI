namespace SnackyAPI.Models.Database
{

    public class Snack
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }

        public List<SnackCategory>? Categories { get; set; }
    }
}


