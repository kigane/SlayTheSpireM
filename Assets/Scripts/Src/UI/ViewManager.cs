using System.Collections.Generic;
using UnityEngine;

namespace SlayTheSpireM
{
    public class ViewManager : MonoBehaviour
    {
        public static ViewManager instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [SerializeField] private View startView;
        [SerializeField] private View[] views;
        private View currentView;
        private readonly Stack<View> viewHistory = new();

        public static T GetView<T>() where T : View
        {
            for (int i = 0; i < instance.views.Length; i++)
            {
                if (instance.views[i] is T tView)
                {
                    return tView;
                }
            }
            return null;
        }

        public static void Show<T>(bool remember) where T : View
        {
            for (int i = 0; i < instance.views.Length; i++)
            {
                if (instance.views[i] is T tView)
                {
                    if (instance.currentView != null)
                    {
                        if (remember)
                            instance.viewHistory.Push(instance.currentView);
                        instance.currentView.Hide();
                    }

                    tView.Show();
                    instance.currentView = tView;
                    break;
                }
            }
        }

        public static void Show(View view, bool remember = true)
        {
            if (instance.currentView != null)
            {
                if (remember)
                    instance.viewHistory.Push(instance.currentView);
                instance.currentView.Hide();
            }

            view.Show();
            instance.currentView = view;
        }

        public static void ShowLast()
        {
            if (instance.viewHistory.Count > 0)
            {
                Show(instance.viewHistory.Pop(), false);
            }
        }

        private void Start()
        {
            foreach (var view in views)
            {
                view.Init();
                view.Hide();
            }

            if (startView != null)
            {
                Show(startView);
            }
        }
    }
}
