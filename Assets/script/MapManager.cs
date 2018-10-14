using UnityEngine;
using My.UI;
using My.Behaviour.Chip;
using UniRx;
using My.GameSystem.Charactor;

public class MapManager : MonoBehaviour {
    [SerializeField]
    private Player player;
    [SerializeField]
    private ChipsetFactory factory;
    private Subject<TextMessage> textSubject;

    private void Awake()
    {
        textSubject = new Subject<TextMessage>();
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

    public void UpdateText(TextMessage t) => textSubject.OnNext(t);
    
    public void ChipListener(ChipBehaviour c)
    {
        player.ManagerListener(c);
        if (c.IsLeafChip()) BuildMapFrom(c);
    }
}
