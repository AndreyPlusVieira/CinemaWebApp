namespace Entities.Entities
{
    public class Session : Notifies
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTIme { get; set; }

        public decimal EntryValue { get; set; }

        public string AnimationType { get; set; }

        public string AudioType { get; set; }

        public Rooms Rooms { get; set; }
        public int RoomsId { get; set; }

        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public Session()
        {
        }

        public Session(int id, DateTime startTime, DateTime endTIme, decimal entryValue, string animationType, string audioType, int roomsId, int movieId)
        {
            Id = id;
            StartTime = startTime;
            EndTIme = endTIme;
            EntryValue = entryValue;
            AnimationType = animationType;
            AudioType = audioType;
            RoomsId = roomsId;
            MovieId = movieId;
        }

        public bool CheckSessions(List<Session> sessions, Session session)
        {
            bool cont = false;

            if (sessions == null)
                return cont = true;

            foreach (var item in sessions)
            {

                if (session.StartTime >= item.StartTime && session.StartTime <= item.EndTIme)
                    cont = true;
            }

            return cont;
        }

        public bool CheckForDelete(Session session)
        {
            if (session == null)
                return true;


            if (session.StartTime > DateTime.Now & session.StartTime < DateTime.Now.AddDays(10))
                return true;

            return false;
        }
    }
}