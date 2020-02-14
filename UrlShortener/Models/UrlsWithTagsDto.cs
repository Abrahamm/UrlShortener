using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Entities;

namespace UrlShortener.Models
{
    public class UrlsWithTagsDto
    {
        public int Id { get; set; }

        public String LongUrl { get; set; }

        public String ShortUrl { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateExpires { get; set; }

        public int UserId { get; set; }

        public ICollection<Tag> tags { get; set; }
            = new List<Tag>();
    }
}
