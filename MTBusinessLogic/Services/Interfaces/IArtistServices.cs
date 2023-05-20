using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using MTDto.Request;
using MTDto.Response;

namespace MTBusinessLogic.Services.Interfaces
{
    public interface IArtistServices
    {
        Task<Response<ArtistResponseDto>> GetArtistByName(string artistName);
        Task<Response<string>> CreateArtist(CreateArtistDto createArtist);
    }
}
