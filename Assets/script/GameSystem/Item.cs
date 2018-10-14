using My.GameSystem.Status;

namespace My.GameSystem.Item
{
    public interface IArticle
    {
        IStatus Status { get; }
    }

    public interface IEquipable : IArticle
    {

    }

    public interface IWeapon : IEquipable
    {

    }

    public class Sword : IWeapon
    {
        public IStatus Status => throw new System.NotImplementedException();
    }
}