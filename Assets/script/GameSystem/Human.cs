using My.GameSystem.Item;
using My.GameSystem.Rule;
using My.GameSystem.Status;
using System.Collections.Generic;

namespace My.GameSystem.Charactor
{
    
    public class Human : ICharactor
    {
        private List<IArticle> items;
        private List<IRule> rules;

        public Human() => Init();

        private void Init()
        {
            Status = new DefaultStatus();
            items = new List<IArticle>()
            {
                new Sword(),
                new Sword(),
                new Sword(),
                new Sword(),
                new Sword(),
            };
            rules = new List<IRule>
            {
                new LevelRule(),
                new AttackRule()
            };
        }

        public IStatus Status { get; private set; }
        public IEnumerable<IArticle> Items => items;

        public string Command(string order)
        {
            string log = "";
            if(order == "UPDATE")
            {
                foreach (var rule in rules)
                {
                    log += rule.Force(Status);
                }
            }

            return (log == "") ? null : log;
        }

        public string Name { get; set; } = "defaultHumanName";

        public override string ToString()
        {
            return "[" + Name + "]\n" + Status;
        }

    }
}


