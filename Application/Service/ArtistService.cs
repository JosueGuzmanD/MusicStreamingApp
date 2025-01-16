using Application.DTOs;
using Core.Entities;
using Core.Interfaces;

namespace Application.Service;

public class ArtistService: IArtistService
{
    private readonly IRepository<Artist> _repository;

    public ArtistService(IRepository<Artist> repository)
    {
        _repository = repository;
    }
    
    public async Task<ArtistDto> GetArtistByIdAsync(int id)
    {
        var artist= await _repository.GetAsync(id);

        var dto = new ArtistDto
        {
            Id = artist.Id,
            Description = artist.ArtistDescription,
            Following = artist.Following,
            Name = artist.ArtistName,
            IsVerified = artist.isVerified
        };

        return dto;
    }

    public async Task<List<ArtistDto>> GetAllArtistsAsync()
    {
        var allArtists = await _repository.GetAllAsync();
        var dtoList = new List<ArtistDto>();

        foreach (var artist in allArtists)
        {
            var dto = new ArtistDto
            {
                Id = artist.Id,
                Description = artist.ArtistDescription,
                Following = artist.Following,
                Name = artist.ArtistName,
                IsVerified = artist.isVerified
            };
            dtoList.Add(dto);
        }
        return dtoList;
    }

    public Task<List<ArtistDto>> GetAllArtistsByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<ArtistDto>> GetFollowedArtistsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<ArtistDto>> GetVerifiedArtistsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<ArtistDto>> GetArtistByAlbumIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ArtistDto>> GetArtistBySongIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}