using Core.Interfaces;
using Core.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class ApplicationUser : IdentityUser, IHasDomainEvents
{
    public Name FullName { get; set; }
    public DateTime? BirthDate { get; set; }
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Address Address { get; set; }
    public List<Album> Albums { get; set; } = new List<Album>();
    public List<Song> FavouriteSongs { get; set; } = new List<Song>();
    public List<Artist> FollowedArtists { get; set; } = new List<Artist>();
    private List<IDomainEvent> _domainEvents { get; } = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;


    public ApplicationUser(string firstName, string lastName, string email, string phoneNumber, Address address)
    {
        FullName = new Name(firstName, lastName);
        Email = new Email(email);
        PhoneNumber = new PhoneNumber(phoneNumber);
        Address = address;
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}