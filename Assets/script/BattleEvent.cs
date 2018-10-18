using UnityEngine;

namespace My.GameSystem.Event
{
    public class BattleEvent : MonoBehaviour, IEvent
    {
        [SerializeField]
        private CharactorBehaviour enemy;

        public void Invoke(IEventSituation e)
        {
            e.Status = EventStatus.BATTLE;
            e.Log = ToString();
        }

        public override string ToString()
        {
            return $":battle: You encounted {enemy}!";
        }
    }
}