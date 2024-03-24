namespace GuessGame.Services;

public class Validation(IComparer comparer) : IValidation
{
    private readonly IComparer _comparer = comparer;

    public bool Validate(int validatedNumber, int comparisonNumber)
    {
        int compareResult = _comparer.Compare(validatedNumber, comparisonNumber);

        if (compareResult == 0)
        {
            Console.WriteLine("Вы отгадали загаданное число!");
            return true;
        }

        if (compareResult == 1)
        {
            Console.WriteLine("Ваше число больше загаданного.");
        }

        if (compareResult == -1)
        {
            Console.WriteLine("Ваше число меньше загаданного.");
        }

        return false;
    }
}
