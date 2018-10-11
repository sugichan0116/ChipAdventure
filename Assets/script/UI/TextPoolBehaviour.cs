using UnityEngine;
using UniRx.Toolkit;
using System.Collections.Generic;

namespace My.UI
{
    public class TextPoolBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        private TextPool pool;
        private List<TextGUI> list;

        private void Start()
        {
            list = new List<TextGUI>();
            pool = new TextPool() { prefab = prefab };
        }

        private void Update()
        {
            foreach (var item in list)
            {
                if (item.IsValid() == false) pool.Return(item);
            }
        }

        public TextGUI Create(Vector3 locate, string text)
        {
            TextGUI obj = pool.Rent();
            
            obj.GetComponent<TranslateBehaviour>().SetStartPosition(locate);
            obj.SetText(text);
            obj.transform.SetParent(transform);

            list.Add(obj);

            return obj;
        }
    }

    public class TextPool : ObjectPool<TextGUI>
    {
        public GameObject prefab;

        // オブジェクトが空のときにInstantiateする関数
        protected override TextGUI CreateInstance()
        {
            return Object.Instantiate(prefab).GetComponent<TextGUI>();
        }
    }
}