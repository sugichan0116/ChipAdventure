using My.GameSystem.Item;
using My.UI;
using My.Util;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private MapManager manager;

    private void Start()
    {
        manager = Finder.WithTag<MapManager>("Manager");
    }

    public void SetEquipable(IEquipable e)
    {
        
    }

    public void OnClick()
    {
        manager.UpdateText(new TextMessage() {
            key = "popup",
            locate = transform.localPosition,
            type = MessageType.SET,
            text = "clicked !"
        });
    }
}
