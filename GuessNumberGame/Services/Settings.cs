namespace GuessGame.Services;

public class Settings : ISettings
{
    public int NumberGuessingAttempts => 3;

    public int MinValue => 1;

    public int MaxValue => 10;
}
