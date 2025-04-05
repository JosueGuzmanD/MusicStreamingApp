namespace Core.ValueObjects;

public record Duration
{
    public Duration(int minutes, int seconds)
    {
        if (minutes < 0 || seconds < 0)
        {
            throw new ArgumentException("Duration must be greater than or equal to 0.");
        }

        var totalSeconds = (minutes * 60) + seconds;
        Minutes = totalSeconds / 60;
        Seconds = totalSeconds % 60;
    }
    private Duration() { }

    public int Minutes { get; init; }
    public int Seconds { get; init; }

    public override string ToString()
    {
        return $"{Minutes}:{Seconds:D2}";
    }
}