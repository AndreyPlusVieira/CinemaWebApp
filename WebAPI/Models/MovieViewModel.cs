namespace WebAPI.Models
{
    public record MovieViewModelRequest(string Title, string Description, string Image, int Duration, bool Active = true) { }

    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public int Duration { get; set; }
        public bool Active { get; set; } = true;
    }
}