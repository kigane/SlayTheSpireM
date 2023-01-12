using System;
using System.Diagnostics;

public class Log
{
    private static string ConstructArrayMessage(object[] arr)
    {
        string msg = "[ ";
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == arr.Length - 1)
                msg += arr[i].ToString() + " ]";
            else
                msg += arr[i].ToString() + ", ";
        }
        return msg;
    }

    private static void LogWithColorAndSize(object message, string color, int size)
    {
        if (message is null)
            Error("输入对象为空!");
        if (size == -1)
            UnityEngine.Debug.Log($"<color={color}>" + message.ToString() + "</color>");
        else
            UnityEngine.Debug.Log($"<size={size}><color={color}>" + message.ToString() + "</color></size>");
    }

    [Conditional("Debug")]
    public static void Debug(object message, int size = -1)
    {
        LogWithColorAndSize(message, "cyan", size);
    }

    [Conditional("Debug")]
    public static void Debug(object[] message, int size = -1)
    {
        LogWithColorAndSize(ConstructArrayMessage(message), "cyan", size);
    }

    [Conditional("Debug"), Conditional("Info")]
    public static void Info(object message, int size = -1)
    {
        LogWithColorAndSize(message, "green", size);
    }

    [Conditional("Debug"), Conditional("Info")]
    public static void Info(object[] message, int size = -1)
    {
        LogWithColorAndSize(ConstructArrayMessage(message), "green", size);
    }

    [Conditional("Debug"), Conditional("Info"), Conditional("Warning")]
    public static void Warning(object message, int size = -1)
    {
        LogWithColorAndSize(message, "yellow", size);
    }

    [Conditional("Debug"), Conditional("Info"), Conditional("Warning")]
    public static void Warning(object[] message, int size = -1)
    {
        LogWithColorAndSize(ConstructArrayMessage(message), "yellow", size);
    }

    [Conditional("Debug"), Conditional("Info"), Conditional("Warning"), Conditional("Error")]
    public static void Error(object message, int size = -1)
    {
        LogWithColorAndSize(message, "red", size);
    }

    [Conditional("Debug"), Conditional("Info"), Conditional("Warning"), Conditional("Error")]
    public static void Error(object[] message, int size = -1)
    {
        LogWithColorAndSize(ConstructArrayMessage(message), "red", size);
    }
}
