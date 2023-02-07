using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlayTheSpireM
{
    public class MyButton : MonoBehaviour
    {
        RectTransform rectTransform;
        Button button;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            FloatingTextManager.Instance.ShowFloatingText("开创", transform, Color.white);
        }
    }
}
