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
            Debug.Log(enemy.Charactor);
            e.Target = enemy.Charactor;
            e.Log = ToString();
        }

        public override string ToString()
        {
            return $":battle: You encounted {enemy}!";
        }
    }
}