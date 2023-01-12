using System;
using UnityEngine;

public class DebugTool : MonoBehaviour
{
    private DebugTool() { }
    private static DebugTool instance;
    private static GameObject debugPoint;
    public static GameObject DebugPoint
    {
        get
        {
            if (debugPoint == null)
            {
                debugPoint = Instantiate(Resources.Load<GameObject>("Prefabs/DebugPoint"), Vector3.zero, Quaternion.identity, Instance.transform);
            }
            return debugPoint;
        }
    }

    public static DebugTool Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new("DebugTool");
                go.AddComponent<DebugTool>();
                go.AddComponent<DontDestroyOnLoadScript>();
                instance = go.GetComponent<DebugTool>();
                return instance;
            }
            return instance;
        }
    }
}
