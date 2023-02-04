using QFramework;
using UnityEngine;
using System;
using TMPro;

namespace SlayTheSpireM
{
    public enum BuffType
    {
        AllBattle,
        LastTurns
    }

    public class Buff
    {
        public Sprite Icon { get; }
        public BuffType Type { get; }
        public int Value { get; set; }
        public string Name { get; }

        public TextMeshProUGUI Text;

        public Buff(string name, BuffType type, int val)
        {
            Name = name;
            Icon = Resources.Load<Sprite>($"Icon/Buff/{name}");
            Type = type;
            Value = val;
        }

        public static Buff operator +(Buff a, Buff b)
        {
            if (a.Name != b.Name)
                throw new NotSupportedException($"不同类的Buff不能相加: {a.Name}, {b.Name}");

            a.Value += b.Value;
            return a;
        }
    }
}
