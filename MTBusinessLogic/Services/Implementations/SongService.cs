using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using MTBusinessLogic.Repository.Interface;
using MTBusinessLogic.Services.Interfaces;

using MTDomain.Entities;

using MTDto.Response;

namespace MTBusinessLogic.Services.Implementations
{
    public class SongService : ISongService
    {
        private readonly IGenericRepo<Song> _songRepo;
        public SongService(IGenericRepo<Song> songRepo)
        {
            _songRepo = songRepo;
        }
        public async Task<Response<List<GetSongsDto>>> GetAllSongs(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = 10;
            }

            try
            {
                var page = await _songRepo.GetAllByPagination(pageNumber, pageSize);

                if (page.TotalItems == 0)
                {
                    return new Response<List<GetSongsDto>>()
                    {
                        Message = "No record of songs found",
                        Success = false,
                        Data = null,
                        Errors = "No record found"
                    };
                }

                var songDto = page.Items.Select(song => new GetSongsDto()
                {
                    AlbumID = song.AlbumID,
                    ArtistID = song.ArtistID,
                    Bpm = song.Bpm,
                    Chart = song.Chart,
                    CustomMix = song.CustomMix,
                    DateCreation = song.DateCreation,
                    Multitracks = song.Multitracks,
                    Patches = song.Patches,
                    ProPresenter = song.ProPresenter,
                    RehearsalMix = song.RehearsalMix,
                    SongID = song.SongID,
                    SongSpecificPatches = song.SongSpecificPatches,
                    TimeSignature = song.TimeSignature,
                    Title = song.Title
                }).ToList();

                return new Response<List<GetSongsDto>>()
                {
                    Data = songDto,
                    Message = "Successful",
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new Response<List<GetSongsDto>>()
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
