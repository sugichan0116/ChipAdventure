using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My.UI
{
    public class RichTextFormatter : MonoBehaviour
    {
        [SerializeField]
        private List<string> spriteTextKeys;
        [SerializeField]
        private List<string> spriteTextValues;
        [SerializeField]
        private string iconSet;
        private static string iconSetName;
        private static Dictionary<string, string> spriteTexts;

        private void Start()
        {
            Init();

            for (int i = 0; i < spriteTextKeys.Count; i++)
            {
                spriteTexts[spriteTextKeys[i]] = spriteTextValues[i];
            }
            iconSetName = iconSet;
        }

        private static void Init()
        {
            if (spriteTexts == null) spriteTexts = new Dictionary<string, string>();
        }

        public static string Replace(string t)
        {
            Init();

            foreach (KeyValuePair<string, string> e in spriteTexts)
            {
                //Debug.Log(e);
                int i;
                string attr = (int.TryParse(e.Value, out i)) ? "index" : "name";
                //Debug.Log(attr);
                t = t.Replace(e.Key, $"<sprite=\"{iconSetName}\" {attr}={e.Value}>");
            }

            return t;
        }
    }
}