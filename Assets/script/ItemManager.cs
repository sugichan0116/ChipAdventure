using My.GameSystem.Charactor;
using My.GameSystem.Item;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private ItemBehaviour prefab;
    [SerializeField]
    private BattleManager battle;
    private ICharactor charactor;

    void Start()
    {
        charactor = player.Charactor;
        foreach (var item in charactor.Items)
        {
            if(item is IEquipable e)
            {
                ItemBehaviour obj = Instantiate(prefab);
                obj.transform.SetParent(transform);
                obj.SetEquipable(e);
            }
        }
    }

    public void OnClick(IArticle equipable)
    {
        battle.OnClick(equipable);
    }
}
