using My.GameSystem.Charactor;
using My.GameSystem.Event;
using UnityEngine;

public class BattleEvent : MonoBehaviour, IEvent
{
    [SerializeField]
    private ICharactorable enemy;

    public string Invoke(IEventSituation c)
    {
        return "";
    }
}
