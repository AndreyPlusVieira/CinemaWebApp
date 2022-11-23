namespace Entities.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Duration { get; set; }

        public bool Active { get; set; }

        public IList<Session>? Sessions { get; set; } = new List<Session>();
        public Movie() { }

        public Movie(int id, string title, string description, string image, int duration, bool active)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Duration = duration;
            Active = active;
        }

        public bool CheckSessionsMovies(List<Session> session)
        {
            var Today = DateTime.Now;
            bool cont = false;
            foreach (var item in session)
            {
                if (item.StartTime > Today)
                    cont = true;
            }
            return cont;
        }
    }
}