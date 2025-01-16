using Application.DTOs;

namespace Core.Interfaces;

public interface IArtistService
{ 
    Task<ArtistDto> GetArtistByIdAsync(int id);
    Task<List<ArtistDto>> GetAllArtistsAsync();
    Task<List<ArtistDto>> GetAllArtistsByNameAsync(string name);
    Task<List<ArtistDto>> GetFollowedArtistsAsync();
    Task<List<ArtistDto>> GetVerifiedArtistsAsync();
    Task<List<ArtistDto>> GetArtistByAlbumIdAsync(int id);
    Task<List<ArtistDto>> GetArtistBySongIdAsync(int id);
}