using My.GameSystem.Event;
using My.GameSystem.Item;
using My.Util;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private MapManager manager;
    private IEventSituation eventSituation;
    
    private void Awake()
    {
        manager = Finder.WithTag<MapManager>("Manager");
    }

    private void Start()
    {
        eventSituation = manager.EventSituation;
    }

    public void OnClick(IArticle equipable)
    {
        if(eventSituation.Status == EventStatus.BATTLE)
        eventSituation.Status = EventStatus.STANDBY;
    }

}
