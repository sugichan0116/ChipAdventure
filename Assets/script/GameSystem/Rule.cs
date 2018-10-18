using My.GameSystem.Parameter;
using My.GameSystem.Status;
using System.Collections.Generic;

namespace My.GameSystem.Law.Status
{
    namespace Contact
    {
        //interact
        public interface IContactLaw
        {
            string Interact(IStatus me, IStatus you);
        }


    }

    namespace Status
    {
        public interface IStatusLaw
        {
            string Force(IStatus s);
        }

        public class RuleHelper
        {
            public static bool Require(IStatus s, List<string> list)
            {
                bool isLack = false;
                foreach (var item in list)
                {
                    if (s[item] == null)
                    {
                        isLack = true;
                        s[item] = new DefaultParameter(item, 0); //kokoyabai
                    }
                }
                return isLack;
            }
        }

        public class LevelRule : IStatusLaw
        {
            public string Force(IStatus s)
            {
                string log = null;
                
                Limited exp = s["EXP"] as Limited;
                if (exp != null)
                {
                    int levelup = 0;
                    while (exp.Max == exp.Value)
                    {
                        exp.Value -= exp.Max;
                        exp.Max += s["LV"].Value * 100;
                        s["LV"].Value++;
                        levelup++;
                    }

                    if (levelup > 0)
                        log = $":event: {levelup} Level UP! you are now {s["LV"]}.";
                }

                return log;
            }
        }

        public class AttackRule : IStatusLaw
        {
            public string Force(IStatus s)
            {
                string log = null;

                //RuleHelper.Require(s, new List<string> { "STR", "ATK" });

                s["ATK"].Value = s["STR"].Value;

                return log;
            }
        }
    }
    
}