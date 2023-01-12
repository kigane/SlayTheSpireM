using UnityEngine;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
