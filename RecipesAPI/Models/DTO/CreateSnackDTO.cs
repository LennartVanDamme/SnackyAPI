namespace SnackyAPI.Models.DTO
{
    public class CreateSnackDTO
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }
    }
}
