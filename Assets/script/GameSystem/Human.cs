using My.GameSystem.Item;
using My.GameSystem.Law.Status;
using My.GameSystem.Status;
using My.UI;
using System.Collections.Generic;

namespace My.GameSystem.Charactor
{
    public enum OrderType
    {
        NONE,
        EVERY,
        PASS,
        ARRIVE
    }

    public class Human : ICharactor
    {
        private List<IArticle> items;
        private List<IStatusLaw> rules;

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
            rules = new List<IStatusLaw>
            {
                new LevelRule(),
                new DeadRule()
            };
        }

        public IStatus Status { get; private set; }
        public IEnumerable<IArticle> Items => items;

        public TextMessage Command(OrderType order)
        {
            string log = "";
            if(order == OrderType.EVERY)
            {
                foreach (var rule in rules)
                {
                    log += rule.Force(Status);
                }
            }

            return new TextMessage() {
                text = log
            };
        }

        public string Name { get; set; } = "defaultHumanName";

        public override string ToString()
        {
            return "[" + Name + "]\n" + Status;
        }

    }
}


