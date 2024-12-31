namespace Core.ValueObjects;

public record Duration
{
    public int Minutes { get; init; }
    public int Seconds { get; init; }

    public Duration(int minutes, int seconds)
    {
       Minutes = minutes;
       Seconds = seconds;
    }
    
}

