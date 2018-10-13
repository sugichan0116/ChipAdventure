using System;
using System.Collections.Generic;
using UnityEngine;

namespace My.GameSystem.Parameter
{
    public interface IParameter
    {
        float Get();
        bool Set(float value);
        bool Add(float value);
    }

    public class Parameters
    {
        private static Dictionary<string, string> name;

        public static string Name(string id)
        {
            if(name == null)
            {
                name = new Dictionary<string, string>
                {
                    { "LV", "Lv" },
                    { "EXP", ":exp:Exp" },
                    { "R_PHS", "物理耐性" }
                };
            }
            return (name.ContainsKey(id)) ? name[id] : id;
        }

        public static float Constrain(float origin, float min, float max)
        {
            return (origin < min) ? min :
                    (origin > max) ? max :
                    origin;
        }
    }

    public class DefaultParameter : IParameter
    {
        private float para;
        private string id;

        public DefaultParameter(string ID, float Value = 0f)
        {
            id = ID;
            para = Value;
        }

        public float Get() => para;

        public bool Set(float value)
        {
            para = value;
            return Validate();
        }

        public bool Add(float value)
        {
            para += value;
            return Validate();
        }

        protected virtual bool Validate() => false;

        protected string Header() => Parameters.Name(id) + " : ";

        public override string ToString() => Header() + para.ToString();
    }

    public class Limited : DefaultParameter
    {
        private float min = 0f, max = 1f;

        public Limited(string ID, float Value = 0f, float Min = 0f, float Max = 1f)
            : base(ID, Value)
        {
            min = Min;
            max = Max;
        }

        public float Min() => min;
        public float Max() => max;
        public void Min(float value) => min = value;
        public void Max(float value) => max = value;

        public new float Get()
        {
            return Parameters.Constrain(GetRow(), Min(), Max());
        }

        public float GetRow()
        {
            return base.Get();
        }

        public override string ToString() =>
            Header() + GetRow().ToString() + "/" + max.ToString();
    }

    public class Gauge : DefaultParameter
    {
        private float min = 0f, max = 1f;

        public Gauge(string ID, float Value = 0f, float Min = 0f, float Max = 1f)
            : base(ID, Value)
        {
            min = Min;
            max = Max;
        }

        public float Min() => min;
        public float Max() => max;
        public void Min(float value) => min = value;
        public void Max(float value) => max = value;

        protected override bool Validate()
        {
            float old = Get();
            Set(Parameters.Constrain(old, min, max));

            return old != Get();
        }

        public override string ToString() =>
            Header() + Get().ToString() + "/" + max.ToString();
    }
    
    public class Magnification : DefaultParameter
    {
        public Magnification(string ID, float Value = 0f)
            : base(ID, Value)
        {

        }

        public override string ToString() => Header() + Get().ToString("##%");
    }

    public class Dice : DefaultParameter
    {
        private int number, surface;

        public Dice(string ID, int Value = 0, int Number = 1, int Surface = 6)
            : base(ID, Value)
        {
            number = Number;
            surface = (Surface > 1) ? Surface : 2;
        }

        public new float Get()
        {
            float sum = base.Get();
            for (int i = 0; i < Math.Abs(number); i++)
            {
                sum += UnityEngine.Random.Range(1, surface) * number / Math.Abs(number);
            }

            return sum;
        }

        public override string ToString() => 
            Header() + $"{number}d{surface}{base.Get().ToString("+#;-#;")}";
    }
}