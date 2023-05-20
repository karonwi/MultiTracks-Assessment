using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MTBusinessLogic.Services.Interfaces;
using MTBusinessLogic.Services.Implementations;
using System.Xml.Linq;

namespace multitracks.API.Controllers
{
    [Route("api.multitracks.com/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllSongs(int pageNumber, int pageSize)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState);
            }

            var result = await _songService.GetAllSongs(pageNumber,pageSize);
            if (result.Success)
            {
                return Ok(result);
            }

            return Ok(result);
        }
    }
}
