namespace reactminapi.dataAccess.Models
{
    public enum EnumFeel
    {
        Incredible,
        Good,
        Roughly,
        Weak,
        Injured

    }
    public class Training
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Location { get; set; }
        public float Distance { get; set; }
        public string? Duration { get; set; }
        public string? StartHour{ get; set; }
        public string? Date { get; set; }
        public EnumFeel Feel { get; set; }
        public User? User { get; set; }

    }
}
