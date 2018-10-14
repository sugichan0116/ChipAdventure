using My.GameSystem.Charactor;
using My.GameSystem.Event;
using UnityEngine;

public class BattleEvent : MonoBehaviour, IEvent
{
    [SerializeField]
    private CharactorBehaviour enemy;

    public string Invoke(IEventSituation c)
    {
        return this.ToString();
    }

    public override string ToString()
    {
        return $":battle: You encounted {enemy}!";
    }
}
