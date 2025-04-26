using Application.DTOs;
using Core.Entities;
using Core.Interfaces;

namespace Application.Service;

public class ArtistService : IArtistService
{
    private readonly IRepository<Artist> _repository;
    private readonly IRepository<Album> _repositoryAlbum;
    private readonly IRepository<Song> _repositorySong;

    public ArtistService(IRepository<Artist> repository)
    {
        _repository = repository;
    }

    public async Task<ArtistDto> GetArtistByIdAsync(int id)
    {
        var artist = await _repository.GetAsync(id);

        var dto = new ArtistDto
        {
            Id = artist.Id,
            Description = artist.ArtistDescription,
            Name = artist.ArtistName,
            IsVerified = artist.IsVerified
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
                Name = artist.ArtistName,
                IsVerified = artist.IsVerified
            };
            dtoList.Add(dto);
        }

        return dtoList;
    }

    public async Task<List<ArtistDto>> GetAllArtistsByNameAsync(string name)
    {
        var artists = await _repository.FindAsync(a => a.ArtistName.Contains(name, StringComparison.OrdinalIgnoreCase));

        return artists.Select(x => new ArtistDto
        {
            Id = x.Id,
            Description = x.ArtistDescription,
            Name = x.ArtistName,
            IsVerified = x.IsVerified
        }).ToList();
    }
    

    public async Task<List<ArtistDto>> GetVerifiedArtistsAsync()
    {
        var verifiedArtist= await _repository.FindAsync(x=> x.IsVerified == true);

        return verifiedArtist.Select(x => new ArtistDto
        {
            Id = x.Id,
            Description = x.ArtistDescription,
            Name = x.ArtistName,
            IsVerified = x.IsVerified
        }).ToList();
    }

    public async Task<List<ArtistDto>> GetArtistByAlbumIdAsync(Guid id)
    {
        var album = await _repositoryAlbum.GetAsync(id);
        
        if (album == null)
        {
            throw new KeyNotFoundException($"Not album found with id {id}.");
        }

        var artist = await _repository.FindAsync(x => x.Id == album.ArtistId);

        return artist.Select(x => new ArtistDto
        {
            Id = x.Id,
            Description = x.ArtistDescription,
            Name = x.ArtistName,
            IsVerified = x.IsVerified
        }).ToList();

    }

    public async Task<List<ArtistDto>> GetArtistBySongIdAsync(Guid id)
    {
        var song = await _repositorySong.GetAsync(id);

        if (song == null)
        {
            throw new KeyNotFoundException($"Not song found with id {id}.");
        }
        
        var artist= await _repository.FindAsync(x=> x.Id== song.MainArtistId);

        return artist.Select(x => new ArtistDto
        {
            Id = x.Id,
            Description = x.ArtistDescription,
            Name = x.ArtistName,
            IsVerified = x.IsVerified
        }).ToList();
    }
}