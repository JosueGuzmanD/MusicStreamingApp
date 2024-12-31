using Core.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class ApplicationUser: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Address Address { get; set; }
    public List<Album> Albums { get; set; }
    public List<Song> FavouriteSongs { get; set; }
    public List<Artist> FollowedArtists { get; set; }
}