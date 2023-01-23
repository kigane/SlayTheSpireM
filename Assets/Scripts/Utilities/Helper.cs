using System.Collections.Generic;

public class Helper
{
    public static void Swap<T>(T[] arr, int i, int j)
    {
        (arr[j], arr[i]) = (arr[i], arr[j]);
    }

    public static void Swap<T>(List<T> lst, int i, int j)
    {
        (lst[j], lst[i]) = (lst[i], lst[j]);
    }

}
