namespace JustApps.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
    }
}

