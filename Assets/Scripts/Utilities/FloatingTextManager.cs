using UnityEngine;
using TMPro;
using DG.Tweening;

namespace SlayTheSpireM
{
    public class FloatingTextManager : MonoBehaviour
    {
        public static FloatingTextManager Instance;
        GameObject textPrefab;

        private void Awake()
        {
            Instance = this;
            textPrefab = Resources.Load<GameObject>("FloatingTextContainer");
            DontDestroyOnLoad(gameObject);
        }

        public void ShowFloatingText(string content, Transform transform)
        {
            var go = Instantiate(textPrefab, transform.position, Quaternion.identity, transform);
            go.transform.position = transform.position;
            go.GetComponent<FloatingText>().ShowFloatingText(content, go.transform);
        }
    }
}
