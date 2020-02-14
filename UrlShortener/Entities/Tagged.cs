using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Entities
{
    public class Tagged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Url Url { get; set; }
        public int UrlId { get; set; }
        
        public Tag Tag { get; set; }
        public int TagId { get; set; }


    }
}
