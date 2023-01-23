using QFramework;
using UnityEngine;
using System;
using TMPro;

namespace SlayTheSpireM
{
    public enum BuffType
    {
        EFFECT,
        NUMBER,
        SPECIAL
    }

    public class Buff
    {
        public Sprite Icon { get; }
        public BuffType Type { get; }
        public int LastTurns;
        public int Number;
        public int Value
        {
            get
            {
                if (Type == BuffType.EFFECT)
                    return LastTurns;
                else if (Type == BuffType.NUMBER)
                    return Number;
                else
                    throw new NotSupportedException();
            }

            set
            {
                if (Type == BuffType.EFFECT)
                    LastTurns = value;
                else if (Type == BuffType.NUMBER)
                    Number = value;
                else
                    throw new NotSupportedException();
            }
        }
        public string Name;

        public TextMeshProUGUI Text;

        public Buff(string name, BuffType type, int lastTurns, int number)
        {
            Name = name;
            Icon = Resources.Load<Sprite>($"Icon/Buff/{name}");
            Type = type;
            LastTurns = lastTurns;
            Number = number;
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
