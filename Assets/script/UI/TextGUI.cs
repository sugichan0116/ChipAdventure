using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace My.UI
{
    public class TextGUI : MonoBehaviour
    {

        private TextMeshProUGUI textRenderer;
        [SerializeField]
        private UnityEvent onChanged;
        [SerializeField]
        private List<string> spriteTextKeys;
        [SerializeField]
        private List<string> spriteTextValues;
        private Dictionary<string, string> spriteTexts;

        // Use this for initialization
        void Start()
        {
            spriteTexts = new Dictionary<string, string>();
            for (int i = 0; i < spriteTextKeys.Count; i++)
            {
                spriteTexts[spriteTextKeys[i]] = spriteTextValues[i];
            }

            textRenderer = GetComponent<TextMeshProUGUI>();
            SetText("New World");
        }

        // Update is called once per frame
        void Update()
        {

        }

        private string ReplaceSprite(string t)
        {
            foreach (KeyValuePair<string, string> e in spriteTexts)
            {
                //Debug.Log(e);
                int i;
                string attr = (int.TryParse(e.Value, out i)) ? "index" : "name";
                //Debug.Log(attr);
                t = t.Replace(e.Key, $"<sprite=\"christmasdeco\" {attr}={e.Value}>");
            }

            return t;
        }

        public void SetText(string t)
        {
            textRenderer.text = ReplaceSprite(t);
            onChanged.Invoke();
        }

        public void AddText(string t)
        {
            textRenderer.text += ReplaceSprite(t) + "\n";
            onChanged.Invoke();
        }
    }

}