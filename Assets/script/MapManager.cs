using UnityEngine;
using My.UI;
using My.Behaviour.Chip;
using UniRx;

public class MapManager : MonoBehaviour {
    [SerializeField]
    private Player player;
    [SerializeField]
    private ChipsetFactory factory;
    [SerializeField]
    private TextPoolBehaviour popupText;
    private Subject<TextMessage> textSubject;

    private void Awake()
    {
        textSubject = new Subject<TextMessage>();
    }

    // Use this for initialization
    void Start () {
        Debug.Log( popupText.Create(new Vector2(300, 0), "This is Cute Yukarisan!"));

        ChipBehaviour c = factory.Init();
        player.SetChip(c);
    }
	
    public void BuildMapFrom(ChipBehaviour origin) 
        => factory.BuildMapFrom(origin);

    public System.IObservable<TextMessage> OnTextChanged
    {
        get => textSubject;
    }

    public void UpdateText(TextMessage t) => textSubject.OnNext(t);
    
    public void ChipListener(ChipBehaviour c)
    {
        player.ManagerListener(c);
        if (c.IsLeafChip()) BuildMapFrom(c);
    }
}
