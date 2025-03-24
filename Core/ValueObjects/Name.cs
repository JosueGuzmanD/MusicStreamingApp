namespace Core.ValueObjects;

public sealed class Name : IEquatable<Name>
{
    public string FirstName { get; }
    public string LastName { get; }

    public Name(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty.", nameof(lastName));

        if (firstName.Length is < 2 or > 50)
            throw new ArgumentException("First name must be between 2 and 50 characters.", nameof(firstName));

        if (lastName.Length is < 2 or > 50)
            throw new ArgumentException("Last name must be between 2 and 50 characters.", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString() => $"{FirstName} {LastName}";

    public override bool Equals(object? obj)
    {
        if (obj is Name name)
        {
            return FirstName == name.FirstName && LastName == name.LastName;
        }
        return false;
    }

    public bool Equals(Name? other)
    {
        return other is not null &&
               FirstName == other.FirstName &&
               LastName == other.LastName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName);
    }
}