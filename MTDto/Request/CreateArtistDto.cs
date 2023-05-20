using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDto.Request
{
    public class CreateArtistDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title cannot be above 100 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(300,ErrorMessage = "Biography should not be more than 300 characters")]
        public string Biography { get; set; }
        [Required]
        public string ImageURL{ get; set; }
        [Required]
        public string HeroURL { get; set; }
    }
}
