using My.GameSystem.Item;
using My.GameSystem.Status;
using System.Collections.Generic;

namespace My.GameSystem.Charactor
{

    public interface ICharactor
    {
        string Name { get; set; }
        IStatus Status { get; }
        IEnumerable<IArticle> Items { get; }

        string Command(string order);
        string ToString();
    }

    public interface ICharactorable
    {
        ICharactor Charactor { get; }
    }
    
}


