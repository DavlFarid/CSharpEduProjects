namespace GuessGame.Services;

public interface ISettings
{
    int NumberGuessingAttempts { get; }

    int MinValue { get; }

    int MaxValue { get; }
}
