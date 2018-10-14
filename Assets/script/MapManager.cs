using UnityEngine;
using My.UI;
using My.Behaviour.Chip;
using UniRx;
using My.GameSystem.Charactor;
using My.GameSystem.Event;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private BattleManager battle;
    [SerializeField]
    private Player player;
    [SerializeField]
    private ChipsetFactory factory;
    private Subject<TextMessage> textSubject;

    private void Awake()
    {
        textSubject = new Subject<TextMessage>();
        EventSituation = new EventSituation()
        {
            Player = player.Charactor()
        };
    }

    // Use this for initialization
    void Start () {
        ChipBehaviour c = factory.Init();
        player.SetChip(c);
    }
	
    public void BuildMapFrom(ChipBehaviour origin) 
        => factory.BuildMapFrom(origin);

    public System.IObservable<TextMessage> OnTextChanged
    {
        get => textSubject;
    }
    public IEventSituation EventSituation { get; internal set; }

    public void UpdateText(TextMessage t) => textSubject.OnNext(t);
    
    public void OnClick(ChipBehaviour c)
    {
        player.OnInvokeEvent(c);
        if (c.IsLeaf()) BuildMapFrom(c);
    }
}
