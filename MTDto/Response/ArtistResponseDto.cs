using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDto.Response
{
    public class ArtistResponseDto
    {
        public int ArtistID { get; set; }
        public DateTime DateCreation { get; set; }
        public string Title { get; set; }
        public string Biography { get; set; }
        public string ImageURL { get; set; }
        public string HeroURL { get; set; }
    }
}
