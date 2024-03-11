namespace GuessGame;

public class ComparerFactory
{
    public static IComparer CreateComparer()
    {
        return new NumberComparer();
    }
}
