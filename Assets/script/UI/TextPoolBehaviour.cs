using UnityEngine;
using UniRx.Toolkit;
using System.Collections.Generic;
using UniRx;

namespace My.UI
{
    public class TextPoolBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        private TextPool pool;

        private void Start()
        {
            pool = new TextPool() { prefab = prefab };
        }
        
        public TextGUI Create(Vector3 locate, string text)
        {
            TextGUI obj = pool.Rent();
            obj.SetText(text);
            obj.transform.SetParent(transform);
            TranslateBehaviour trans = obj.GetComponent<TranslateBehaviour>();
            trans.SetStartPosition(locate);
            trans.OnDispose?.Where(x => x).Subscribe(_ => {
                pool.Return(obj);
                Debug.Log("return");
            });

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