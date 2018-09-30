using My.GameSystem.Status;

namespace My.GameSystem.Charactor
{

    public interface ICharactor
    {
        string Name { get; set; }
        IStatus Status();
        string Command(string order);
    }

    public interface ICharactorable
    {
        ICharactor Charactor();
    }
    
}


