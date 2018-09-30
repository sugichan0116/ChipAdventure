using My.GameSystem.Parameter;
using My.GameSystem.Status;
using System.Collections.Generic;

namespace My.GameSystem.Rule
{
    public interface IRule
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

    public class LevelRule : IRule
    {
        public string Force(IStatus s)
        {
            string log = null;

            //RuleHelper.Require(s, new List<string> { "LV", "EXP" });

            Limited exp = s["EXP"] as Limited;
            if(exp != null)
            {
                int levelup = 0;
                while(exp.Max() == exp.Get())
                {
                    exp.Add(-exp.Max());
                    exp.Max(exp.Max() + s["LV"].Get() * 100);
                    s["LV"].Add(1);
                    levelup++;
                }

                if(levelup > 0)
                log = $":event: {levelup} Level UP! you are now {s["LV"]}.";
            }

            return log;
        }
    }

    public class AttackRule : IRule
    {
        public string Force(IStatus s)
        {
            string log = null;

            //RuleHelper.Require(s, new List<string> { "STR", "ATK" });
            
            s["ATK"].Set(s["STR"].Get());

            return log;
        }
    }
}