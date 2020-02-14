using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Entities
{
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public String LongUrl { get; set; }

        [MaxLength(5)]
        [Required]
        public String ShortUrl { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateExpires { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<Tagged> Taggeds { get; private set; } = new HashSet<Tagged>();
        
    }
}
