using System.Text.RegularExpressions;

namespace Core.ValueObjects;

public record Email
{
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be null or empty", nameof(value));

        if (!IsValidEmail(value)) throw new ArgumentException("Invalid email format", nameof(value));

        Value = value;
    }

    public string Value { get; }

    private static bool IsValidEmail(string email)
    {
        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Simple email regex
        return Regex.IsMatch(email, emailRegex);
    }

    public override string ToString()
    {
        return Value;
    }
}