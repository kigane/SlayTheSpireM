using System.Collections.Generic;

public class Helper
{
    public static void Swap<T>(T[] arr, int i, int j)
    {
        T temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void Swap<T>(List<T> lst, int i, int j)
    {
        T temp = lst[i];
        lst[i] = lst[j];
        lst[j] = temp;
    }

}
