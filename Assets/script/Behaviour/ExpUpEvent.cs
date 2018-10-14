using My.GameSystem.Charactor;
using My.GameSystem.Parameter;
using UnityEngine;

namespace My.GameSystem.Event
{
    public class ExpUpEvent : MonoBehaviour, IEvent
    {
        [SerializeField]
        private int expVolume = 3000;
        [SerializeField]
        private string description;
        
        public string Invoke(IEventSituation e)
        {
            IParameter exp = e.Player.Status()["EXP"];
            exp.Value += expVolume;
            return $":event: Get {expVolume} Exp. You are lucky boy.";
        }

        public override string ToString() => description;
    }
}