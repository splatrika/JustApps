#nullable disable
using System.ComponentModel.DataAnnotations;

namespace JustApps.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int AppId { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Content { get; set; }
    }
}

