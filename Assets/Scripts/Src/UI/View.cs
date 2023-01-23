using UnityEngine;

namespace SlayTheSpireM
{
    public abstract class View : BaseController
    {
        public abstract void Init();
        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}
