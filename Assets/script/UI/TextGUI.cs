using TMPro;
using UnityEngine;

namespace My.UI
{
    public class TextGUI : MonoBehaviour
    {
        private TextMeshProUGUI textRenderer;
        private TranslateBehaviour trans;

        void Awake()
        {
            trans = GetComponent<TranslateBehaviour>();
            textRenderer = GetComponent<TextMeshProUGUI>();
            SetText("New World");
        }
        
        public void SetText(string t)
        {
            textRenderer.text = RichTextFormatter.Replace(t);
        }

        public void AddText(string t)
        {
            textRenderer.text += RichTextFormatter.Replace(t) + "\n";
        }

        public bool IsValid()
        {
            return (trans?.IsStop() ?? false) == false;
        }
    }

    public enum MessageType
    {
        ERROR,
        UPDATE,
        SET,
        ADD,
        RESET
    }
    
    public class TextMessage
    {
        public string key, text;
        public MessageType type;
    }
}