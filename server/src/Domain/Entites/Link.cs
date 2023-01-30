namespace Domain.Entites
{
    public class Link
    {
        public string OriginalUrl { get; set; }
        public string URI { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public string LockHash { get; set; }
        public string LockSalt { get; set; }
    }
}