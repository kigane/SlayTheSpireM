using UnityEngine;

public static class RandomExtension
{
    public static T[] GetRandomElements<T>(this T[] arr, int n)
    {
        T[] ret = new T[n];

        for (int i = 0; i < n; i++)
        {
            int index = Random.Range(i, arr.Length);
            ret[i] = arr[index];
            (arr[i], arr[index]) = (arr[index], arr[i]);
        }

        return ret;
    }
}
