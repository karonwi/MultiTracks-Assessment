using MTDto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBusinessLogic.Services.Interfaces
{
    public interface ISongService
    {
        Task<Response<List<GetSongsDto>>> GetAllSongs(int pageNumber,int pageSize);
    }
}
