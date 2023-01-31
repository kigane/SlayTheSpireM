using System.Collections.Generic;
using System;
using System.Reflection;

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

    public static List<string> GetAllConstFields(string className)
    {
        List<string> rets = new();
        Type t = Type.GetType(className, true);
        foreach (var fi in t.GetFields(BindingFlags.Public |
                 BindingFlags.Static | BindingFlags.FlattenHierarchy)) // FlattenHierarchy表示考虑父类
        {
            // IsLiteral表示编译时确定且不可改变 const | readonly
            // fi.IsInitOnly其值可以在构造器中设置 readonly
            if (fi.IsLiteral && !fi.IsInitOnly)
            {
                rets.Add(fi.GetRawConstantValue() as string);
            }
        }
        return rets;
    }

}
