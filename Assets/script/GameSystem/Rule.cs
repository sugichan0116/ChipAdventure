using My.GameSystem.Charactor;
using My.GameSystem.Parameter;
using My.GameSystem.Status;
using System.Collections.Generic;

namespace My.GameSystem.Law
{
    namespace Contact
    {
        //interact
        public interface IContactLaw
        {
            string Interact(ICharactor me, ICharactor you);
        }

        public class AttackCommand : IContactLaw
        {
            public string Interact(ICharactor me, ICharactor you)
            {
                new Status.AttackRule().Force(me.Status);

                you.Status["DAMAGE"].Value = me.Status["DAMAGE"].Value;

                return you.Name + new Status.DiffenceRule().Force(you.Status);
            }
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
                s["DAMAGE"].Value = s["STR"].Value * 10;

                return null;
            }
        }

        public class DiffenceRule : IStatusLaw
        {
            public string Force(IStatus s)
            {
                s["HP"].Value = s["DAMAGE"].Value;

                return $" injured in {s["DAMAGE"].Value} points!";
            }
        }

        public class DeadRule : IStatusLaw
        {
            public string Force(IStatus s)
            {
                if(s["HP"].Value <= 0) s["DEAD"].Value = 1;
                return null;
            }
        }
    }
    
}