using System;
using System.Collections.Generic;

namespace My.GameSystem.Parameter
{
    public interface IParameter
    {
        float Value { get; set; }
    }

    public interface IGauge
    {
        float NormalizedValue { get; }
        float Value { get; }
        float Min { get; }
        float Max { get; }
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
                    { "HP", ":life:HP" },
                    { "STR", ":attack:STR" },
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
        private float value;
        private string id;

        public float Value {
            get => value;
            set {
                this.value = value;
                Validate();
            }
        }

        public DefaultParameter(string ID, float Value = 0f)
        {
            id = ID;
            value = Value;
        }
        
        protected virtual bool Validate() => false;

        protected string Header() => Parameters.Name(id) + " : ";

        public override string ToString() => Header() + Value;
    }

    public class Limited : DefaultParameter, IGauge
    {
        public float NormalizedValue { get => Value / Max; }
        public new float Value { get => Parameters.Constrain(RowValue, Min, Max); }
        public float RowValue { get => base.Value; }
        public float Min { get; set; } = 0f;
        public float Max { get; set; } = 1f;

        public Limited(string ID, float Value = 0f, float Min = 0f, float Max = 1f)
            : base(ID, Value)
        {
            this.Min = Min;
            this.Max = Max;
        }
        
        public override string ToString() => Header() + $"{RowValue} / {Max}";
    }

    public class Gauge : DefaultParameter, IGauge
    {
        public float NormalizedValue { get => Value / Max; }
        public float Min { get; set; } = 0f;
        public float Max { get; set; } = 1f;

        public Gauge(string ID, float Value = 0f, float Min = 0f, float Max = 1f)
            : base(ID, Value)
        {
            this.Min = Min;
            this.Max = Max;
        }
        
        protected override bool Validate()
        {
            float old = Value;
            Value = Parameters.Constrain(old, Min, Max);

            return old != Value;
        }

        public override string ToString() => Header() + $"{Value} / {Max}";
    }
    
    public class Magnification : DefaultParameter
    {
        public Magnification(string ID, float Value = 0f)
            : base(ID, Value)
        {

        }

        public override string ToString() => Header() + Value.ToString("##%");
    }

    public class Dice : DefaultParameter
    {
        private int number, surface;

        public new float Value { get
            {
                float sum = base.Value;
                for (int i = 0; i < Math.Abs(number); i++)
                {
                    sum += UnityEngine.Random.Range(1, surface) * number / Math.Abs(number);
                }

                return sum;
            }
        }

        public Dice(string ID, int Value = 0, int Number = 1, int Surface = 6)
            : base(ID, Value)
        {
            number = Number;
            surface = (Surface > 1) ? Surface : 2;
        }
        
        public override string ToString() => 
            Header() + $"{number}d{surface}{base.Value.ToString("+#;-#;")}";
    }
}