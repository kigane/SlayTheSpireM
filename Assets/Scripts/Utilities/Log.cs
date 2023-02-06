using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Log
{
    private static void LogWithColorAndSize(object obj, string color, int size)
    {
        if (obj is null)
            Error("输入对象为空!");
        if (size == -1)
            UnityEngine.Debug.Log($"<color={color}>" + ConstructMessage(obj) + "</color>");
        else
            UnityEngine.Debug.Log($"<size={size}><color={color}>" + ConstructMessage(obj) + "</color></size>");
    }

    private static string ConstructMessage(object obj)
    {
        string message = obj.ToString();

        if (obj is Array)
        {
            var lst = (IList)obj;
            message = "Array [";
            for (int i = 0; i < lst.Count; i++)
            {
                if (i == lst.Count - 1)
                    message += lst[i].ToString() + "]";
                else
                    message += lst[i].ToString() + ", ";
            }
        }
        else if (obj.GetType().IsGenericType)
        {
            var type = obj.GetType().GetGenericTypeDefinition();
            if (type == typeof(List<>))
            {
                message = "List [";
                var enumerator = ((IEnumerable)obj).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    message += enumerator.Current.ToString() + ", ";
                }
                message = message.Remove(message.Length - 2);
                message += "]";
            }
            else if (type == typeof(Dictionary<,>))
            {
                message = "{\n";
                foreach (DictionaryEntry entry in (IDictionary)obj)
                {
                    message += entry.Key + ": " + entry.Value + ",\n";
                }
                message = message.Remove(message.Length - 2);
                message += "\n}";
            }
        }

        return message;
    }

    [Conditional("Debug")]
    public static void Debug(object message, int size = -1)
    {
        LogWithColorAndSize(message, "cyan", size);
    }

    [Conditional("Debug")]
    public static void Debug(string header, object message, int size = -1)
    {
        LogWithColorAndSize(header + ": " + ConstructMessage(message), "cyan", size);
    }

    [Conditional("Debug"), Conditional("Info")]
    public static void Info(object message, int size = -1)
    {
        LogWithColorAndSize(message, "green", size);
    }

    [Conditional("Debug"), Conditional("Info")]
    public static void Info(string header, object message, int size = -1)
    {
        LogWithColorAndSize(header + ": " + ConstructMessage(message), "green", size);
    }

    [Conditional("Debug"), Conditional("Info"), Conditional("Warning")]
    public static void Warning(object message, int size = -1)
    {
        LogWithColorAndSize(message, "yellow", size);
    }

    [Conditional("Debug"), Conditional("Info"), Conditional("Warning")]
    public static void Warning(string header, object message, int size = -1)
    {
        LogWithColorAndSize(header + ": " + ConstructMessage(message), "yellow", size);
    }

    [Conditional("Debug"), Conditional("Info"), Conditional("Warning"), Conditional("Error")]
    public static void Error(object message, int size = -1)
    {
        LogWithColorAndSize(message, "red", size);
    }

    [Conditional("Debug"), Conditional("Info"), Conditional("Warning"), Conditional("Error")]
    public static void Error(string header, object message, int size = -1)
    {
        LogWithColorAndSize(header + ": " + ConstructMessage(message), "red", size);
    }
}
