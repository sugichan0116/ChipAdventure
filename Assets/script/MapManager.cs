using System.Collections.Generic;
using UnityEngine;
using My.UI;
using My.Behaviour.Chip;

public class MapManager : MonoBehaviour {
    public Player player;
    [SerializeField]
    private ChipFactory factory;

    [SerializeField]
    private List<string> uiTextKeys;
    [SerializeField]
    private List<TextGUI> uiTextValues;
    [SerializeField]
    private Dictionary<string, TextGUI> uiTexts;

    // Use this for initialization
    void Start () {
        uiTexts = new Dictionary<string, TextGUI>();
        for (int i = 0; i < uiTextKeys.Count; i++)
        {
            uiTexts[uiTextKeys[i]] = uiTextValues[i];
        }

        ChipBehaviour c = factory.Init();
        player.SetChip(c);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void BuildMapFrom(ChipBehaviour origin) 
        => factory.BuildMapFrom(origin);

    public void SetText(string key, string text)
        => uiTexts[key].SetText(text);

    public void AddText(string key, string text)
        => uiTexts[key].AddText(text);

    public void ChipListener(ChipBehaviour c)
    {
        player.ManagerListener(c);
        if (c.IsLeafChip()) BuildMapFrom(c);
    }
}
