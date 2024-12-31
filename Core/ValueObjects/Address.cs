namespace Core.ValueObjects
{
    public record Address
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string PostalCode { get; init; }

        public Address(string street, string city, string state, string country, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(street) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentException("Address fields cannot be null or empty");
            }

            Street = street;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
        }

        public override string ToString() => $"{Street}, {City}, {Country}";
    }
}