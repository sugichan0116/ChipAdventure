using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.GameSystem.Charactor;
using My.GameSystem.Status;

namespace My.UI
{
    public class StatusUI : MonoBehaviour
    {

        [SerializeField]
        private GameObject target;
        private TextGUI gui;

        // Use this for initialization
        void Start()
        {
            gui = GetComponent<TextGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            ICharactor c = target.GetComponent<ICharactorable>().Charactor();
            gui.SetText(c.ToString());
        }
    }
}