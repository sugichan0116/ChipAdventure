using My.GameSystem.Charactor;
using UnityEngine;

public class CharactorBehaviour : MonoBehaviour, ICharactorable
{
    [SerializeField]
    private ICharactor charactor;

    private void Awake()
    {
        Debug.Log("しね");
        Init();
    }

    private void Init()
    {
        if(charactor == null)
        charactor = new Human() { Name = "Slime" };
    }

    public ICharactor Charactor => charactor;

    public override string ToString() => Charactor?.ToString();
}
