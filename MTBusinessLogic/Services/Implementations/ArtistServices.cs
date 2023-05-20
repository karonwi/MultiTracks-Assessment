using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using MTBusinessLogic.Repository.Interface;
using MTBusinessLogic.Services.Interfaces;

using MTDomain.Entities;

using MTDto.Request;
using MTDto.Response;

namespace MTBusinessLogic.Services.Implementations
{
    public class ArtistServices : IArtistServices
    {
        private readonly IGenericRepo<Artist> _artistRepoRepo;
        public ArtistServices(IGenericRepo<Artist> artistRepoRepo)
        {
            _artistRepoRepo = artistRepoRepo;
        }
        public async Task<Response<ArtistResponseDto>> GetArtistByName(string artistName)
        {
            
            if (string.IsNullOrEmpty(artistName))
            {
                throw new ArgumentException("Artist Name is null");
            }

            try
            {
                var artist = await _artistRepoRepo.GetByStringAysnc(artistName.Trim());
                if (artist == null)
                {
                    return new Response<ArtistResponseDto>()
                    {
                        Data = null,
                        Errors = "No Record found",
                        Message = "Failed to get artist",
                        Success = false
                    };
                }
                var response = new ArtistResponseDto()
                {
                    ArtistID = artist.ArtistID,
                    Biography = artist.Biography,
                    DateCreation = artist.DateCreation,
                    HeroURL = artist.HeroURL,
                    ImageURL = artist.ImageURL,
                    Title = artist.Title
                };
                return new Response<ArtistResponseDto>()
                {
                    Data = response,
                    Message = "Successful",
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new Response<ArtistResponseDto>()
                {
                    Data = null,
                    Errors = HttpStatusCode.InternalServerError.ToString(),
                    Message = exception.Message,
                    Success = false
                };
            }
            
        }

        public async Task<Response<string>> CreateArtist(CreateArtistDto createArtist)
        {
            try
            {
                Artist newArtist = new Artist()
                {
                    
                    DateCreation = DateTime.Now,
                    Title = createArtist.Title,
                    Biography = createArtist.Biography,
                    HeroURL = createArtist.HeroURL,
                    ImageURL = createArtist.ImageURL
                    
                };

                var artistId = await _artistRepoRepo.InsertAsync(newArtist);

                newArtist.ArtistID = Convert.ToInt32(artistId);

                return new Response<string>
                {
                    Data = newArtist.ArtistID.ToString(),
                    Message = "Artist successfully created",
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new Response<string>()
                {
                    Data = null,
                    Errors = HttpStatusCode.InternalServerError.ToString(),
                    Message = exception.Message,
                    Success = false
                };
            }
            


        }
    }
}
