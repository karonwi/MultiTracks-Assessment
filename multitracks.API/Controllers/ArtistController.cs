using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MTBusinessLogic.Services.Interfaces;

using MTDto.Request;
using System.Xml.Linq;

namespace multitracks.API.Controllers
{
    [Route("api.multitracks.com/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistServices _artistServices;

        public ArtistController(IArtistServices artistServices)
        {
            _artistServices = artistServices;
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchArtistByName(string name)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState);
            }

            var result =await  _artistServices.GetArtistByName(name);
            if (result.Success)
            {
                return Ok(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateArtist(CreateArtistDto model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState);
            }

            var result = await _artistServices.CreateArtist(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return Ok(result);
        }

    }
}
