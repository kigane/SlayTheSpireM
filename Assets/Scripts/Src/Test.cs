using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SlayTheSpireM
{
    class A
    {
        public virtual void Hello()
        {
            Log.Debug("A Hello");
        }
    }

    class B : A
    {
        sealed public override void Hello()
        {
            Log.Debug("B Hello");
        }
    }

    class C : B
    {
        public void CHello()
        {
            Log.Debug("C Hello");
            Hello();
        }
    }


    public class Test : BaseController
    {
        IPlayerModel playerModel;
        public Transform windowLayer;
        public Transform StartWindow;

        private void Start()
        {
            // DoTest();
        }

        public GameObject LoadGO(string path)
        {
            var instance = Instantiate(Resources.Load<GameObject>(path));
            return instance;
        }
        private void DoTest()
        {
            // playerModel = this.GetModel<IPlayerModel>();
            // for (int i = 0; i < playerModel.Deck.Count; i++)
            // {
            //     // Log.Debug(playerModel.Deck[i]);
            // }

            // var c = new C();
            // c.CHello();
            Dictionary<string, int> dict = new()
            {
                { "hello", 1 },
                { "world", 2 }
            };
            int[] nums = new[] { 1, 2, 3, 4, 7 };
            Log.Debug(nums);
            Log.Info(nums);
            Log.Debug(dict);
            Log.Debug(Helper.GetAllConstFields("SlayTheSpireM.ScreenIds"));
            Log.Debug("Test End!");
        }
    }
}
