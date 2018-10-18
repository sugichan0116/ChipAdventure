using My.GameSystem.Item;
using My.UI;
using My.Util;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private MapManager manager;
    private ItemManager itemManager;
    private IArticle item;

    private void Start()
    {
        manager = Finder.WithTag<MapManager>("Manager");
        itemManager = Finder.WithTag<ItemManager>("Manager");
    }

    public void SetEquipable(IEquipable e)
    {
        item = e;
    }

    public void OnClick()
    {
        manager.UpdateText(new TextMessage() {
            key = "popup",
            locate = transform.localPosition,
            type = MessageType.SET,
            text = "clicked !"
        });

        itemManager.OnClick(item);
    }
}
