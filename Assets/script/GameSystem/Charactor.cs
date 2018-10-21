using My.GameSystem.Item;
using My.GameSystem.Status;
using My.UI;
using System.Collections.Generic;

namespace My.GameSystem.Charactor
{

    public interface ICharactor
    {
        string Name { get; set; }
        IStatus Status { get; }
        IEnumerable<IArticle> Items { get; }

        TextMessage Command(OrderType order);
        string ToString();
    }

    public interface ICharactorable
    {
        ICharactor Charactor { get; }
    }
    
}


