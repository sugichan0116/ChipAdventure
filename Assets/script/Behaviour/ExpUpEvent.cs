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
        
        public void Invoke(IEventSituation e)
        {
            IParameter exp = e.Self.Status["EXP"];
            exp.Value += expVolume;
            e.Log = $":event: Get {expVolume} Exp. You are lucky boy.";
        }

        public override string ToString() => description;
    }
}