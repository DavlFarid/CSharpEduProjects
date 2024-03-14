namespace GuessGame.Services;

public class NumberComparer : IComparer
{
    public int Compare(object x, object y)
    {
        int x1 = (int)x;
        int y1 = (int)y;

        if (x1 > y1)
        {
            return 1;
        }

        if (x1 < y1)
        {
            return -1;
        }

        return 0;
    }
}
