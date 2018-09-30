using UnityEngine;
using UnityEngine.UI;

namespace My.UI
{
    public class ScrollGUI : MonoBehaviour
    {

        private bool isWaiting;
        private float widthOffset;
        private Vector2 prePos;
        [SerializeField]
        private RectTransform parent;

        // Use this for initialization
        void Start()
        {
            widthOffset = SizeDelta().x;
            isWaiting = false;
        }

        // Update is called once per frame
        void Update()
        {
            CheckSizeChange();
        }

        private void CheckSizeChange()
        {
            if (isWaiting && prePos != SizeDelta())
            {
                transform.Translate(new Vector3(0, SizeDelta().y, 0));
                parent.sizeDelta = new Vector2(
                    parent.sizeDelta.x + SizeDelta().x - widthOffset,
                    parent.sizeDelta.y
                );
                isWaiting = false;
            }
        }

        public void ScrollUpdate()
        {
            isWaiting = true;
            prePos = SizeDelta();
        }

        private Vector2 SizeDelta()
        {
            return (GetComponent(typeof(RectTransform)) as RectTransform).sizeDelta;
        }
    }
}