using My.GameSystem.Charactor;
using My.GameSystem.Event;
using System.Collections.Generic;
using UnityEngine;

namespace My.Behaviour.Chip
{
    public class ChipBehaviour : MonoBehaviour
    {
        //ui
        [SerializeField]
        private MapManager manager;

        [SerializeField]
        private List<ChipBehaviour> nexts;
        private IChipEvent chipEvent;

        // Use this for initialization
        void Start()
        {
            chipEvent = new ExpUpEvent();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool IsNextChip(ChipBehaviour c)
        {
            foreach (var next in nexts)
            {
                if (c == next) return true;
            }

            return false;
        }

        public bool IsLeafChip()
        {
            return nexts?.Count == 0;
        }

        public void PushNextChip(ChipBehaviour c)
        {
            if (nexts == null) nexts = new List<ChipBehaviour>();
            nexts.Add(c);
        }

        public IEnumerable<Vector3> NextPositions()
        {
            foreach (var next in nexts)
            {
                yield return next.transform.position;
            }
        }

        public IChipEvent Event() => chipEvent;

        public void InvokeEvent(ICharactor c)
        {
            string outText = chipEvent.HappenEvent(c);
            PublishMessageLog(outText);
        }


        //ui
        public void SetManager(MapManager m) => manager = m;

        public Vector3 GetPosition() => transform.position;

        public void PublishManager() => manager.ChipListener(this);

        public void PublishDetail() => manager.SetText("detail", "[ChipEvent]\n" + ToString());

        public void PublishMessageLog(string text)
        {
            if (text == null) return;
            manager.AddText("log", text);
        }

        public override string ToString()
        {
            return name + "\n" +
                transform.position + "\n" +
                chipEvent;
        }

        public string ToStringDebug()
        {
            string log = "";
            foreach (var next in nexts)
            {
                log += $"<{next.transform.position}>,";
            }
            return ToString() + log;
        }
    }
}
