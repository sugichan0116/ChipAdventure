using System.Collections;
using System.Collections.Generic;
using My.GameSystem.Parameter;

namespace My.GameSystem.Status
{
    public interface IStatus
    {
        IParameter this[string name] { get; set; }
        IEnumerable<string> Keys();
    }
    
    public class DefaultStatus : IStatus //IEnum?
    {
        private Dictionary<string, IParameter> list;

        public DefaultStatus()
        {
            Init();
        }

        public IParameter this[string name]
        {
            get
            {
                if (list.ContainsKey(name) == false)
                {
                    list.Add(name, new DefaultParameter(name));
                }
                return list[name];
            }

            set
            {
                list[name] = value;
            }
        }
        
        public IEnumerable<string> Keys()
        {
            foreach(string key in list.Keys)
            {
                yield return key;
            }
        }

        private void Init()
        {
            list = new Dictionary<string, IParameter>
            {
                { "LV", new DefaultParameter("LV", 1) },
                { "EXP", new Limited("EXP", 0, 0, 100) },
                { "HP", new Gauge("HP", 80, 0, 100) },
                { "STR", new DefaultParameter("STR", 3) },
                { "DB", new Dice("DB", 3, 2, 6) },
                { "R_PHS", new Magnification("R_PHS", 1.13f) }
            };
        }
        
        public override string ToString()
        {
            string text = "";
            foreach(string key in list.Keys)
            {
                text += list[key].ToString() + "\n";
            }
            return text;
        }

    }

}