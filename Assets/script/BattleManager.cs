using My.GameSystem.Event;
using My.GameSystem.Item;
using My.GameSystem.Law.Contact;
using My.UI;
using My.Util;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private MapManager manager;
    private IEventSituation eventSituation;
    [SerializeField]
    private StatusUI enemyUI;
    
    private void Awake()
    {
        manager = Finder.WithTag<MapManager>("Manager");
    }

    private void Start()
    {
        eventSituation = manager.EventSituation;
    }

    private void Update()
    {
        if(eventSituation.Status == EventStatus.BATTLE_BEFORE)
        {
            eventSituation.Status = EventStatus.BATTLE;
            enemyUI.Init(eventSituation.Target);
        }
    }

    public void OnClick(IArticle equipable)
    {
        if(eventSituation.Status == EventStatus.BATTLE)
        {
            new AttackCommand().Interact(eventSituation.Self, eventSituation.Target);
            if(eventSituation.Target.Status["DEAD"].Value == 1)
                eventSituation.Status = EventStatus.STANDBY;
        }
    }

}
