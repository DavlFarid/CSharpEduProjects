namespace GuessGame.Services;

public interface IValidation
{
    bool Validate(int validatedNumber, int comparisonNumber);
}