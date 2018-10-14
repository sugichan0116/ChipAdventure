using My.GameSystem.Charactor;
using My.GameSystem.Event;
using My.Util;
using System.Collections.Generic;
using UnityEngine;

namespace My.Behaviour.Chip
{
    interface INode<T>
    {
        void PushNext(T t);
        bool IsNext(T t);
        bool IsLeaf();
    }

    public class ChipBehaviour : MonoBehaviour, INode<ChipBehaviour>, IEventable
    {
        private MapManager manager;

        [SerializeField]
        private List<ChipBehaviour> nexts;

        private void Awake() => manager = Finder.WithTag<MapManager>("Manager");

        public bool IsNext(ChipBehaviour c)
        {
            foreach (var next in nexts)
            {
                if (c == next) return true;
            }

            return false;
        }

        public bool IsLeaf() => nexts?.Count == 0;

        public void PushNext(ChipBehaviour c)
        {
            if (nexts == null) nexts = new List<ChipBehaviour>();
            nexts.Add(c);
        }

        //??????
        public IEnumerable<Vector3> NextPositions()
        {
            foreach (var next in nexts)
            {
                yield return next.transform.position;
            }
        }

        public IEvent Event { get; private set; }

        public void InvokeEvent()
        {
            string outText = Event.Invoke(manager.EventSituation);
            PublishMessageLog(outText);
        }


        //ui
        public void SetManager(MapManager m) => manager = m;
        public void SetEvent(IEvent e) => Event = e;
        
        public void OnClick() => manager.OnClick(this);

        public void OnHover() => manager.UpdateText(
            new UI.TextMessage() {
                key = "event",
                type = UI.MessageType.SET,
                text = ":event:\n" + ToString()
            }
        );

        public void PublishMessageLog(string text)
        {
            if (text == null) return;
            manager.UpdateText(
                 new UI.TextMessage()
                 {
                     key = "log",
                     type = UI.MessageType.ADD,
                     text = text + ":attack::exp:"
                 }
            );
            //manager.UpdateText(
            //      new UI.TextMessage()
            //      {
            //          key = "popup",
            //          text = text,
            //          locate = new Vector3(-200, 0)
            //      }
            // );
        }

        public override string ToString() => Event.ToString();

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
