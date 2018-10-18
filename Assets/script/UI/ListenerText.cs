using My.Util;
using UniRx;
using UnityEngine;
using System.Linq;

namespace My.UI
{
    public class ListenerText : TextGUI
    {
        [SerializeField]
        private string key;
        private MapManager manager;

        // Start is called before the first frame update
        void Start()
        {
            manager = Finder.WithTag<MapManager>("Manager");

            if (manager) manager.OnTextChanged
                 .Where(message => message.key == key)
                 .Subscribe(message =>
                 {
                     if (message.type == MessageType.ADD)
                     {
                         AddText(message.text);
                     }
                     if (message.type == MessageType.SET)
                     {
                         SetText(message.text);
                     }
                 });
        }
        
    }

}

namespace My.Util
{
    public class Finder
    {
        public static T WithTag<T>(string tag)
        {
            return GameObject
                .FindGameObjectsWithTag(tag)
                .FirstOrDefault(g => g.GetComponent<T>() != null)
                .GetComponent<T>();
        }
    }
}
