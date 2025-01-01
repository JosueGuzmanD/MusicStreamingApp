namespace Core.ValueObjects;

public record Duration
{
    public Duration(int minutes, int seconds)
    {
        Minutes = minutes < 0 ? 0 : minutes;
        Seconds = seconds < 0 ? 0 : seconds;

        if (minutes < 0|| seconds < 0)
        {
            throw new ArgumentException("Duration must be greater than or equal to 0.");
        }
    }

    public int Minutes { get; init; }
    public int Seconds { get; init; }

    public override string ToString()
    {
        return $"{Minutes}:{Seconds:D2}";
    }
}