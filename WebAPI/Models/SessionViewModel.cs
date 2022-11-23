namespace WebAPI.Models
{
    public record SessionViewModelRequest(DateTime StartTime, DateTime EndTIme, decimal EntryValue, string AnimationType, string AudioType, string RoomId, string MovieId) { }
    public class SessionViewModel
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; } 

        public DateTime EndTIme { get; set; }

        public decimal EntryValue { get; set; }

        public string AnimationType { get; set; }

        public string AudioType { get; set; }

        public int RoomsId { get; set; }

        public int MovieId { get; set; }
    }
}
