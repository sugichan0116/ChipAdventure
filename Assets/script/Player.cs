using UnityEngine;
using My.GameSystem.Charactor;
using My.Behaviour.Chip;

public class Player : MonoBehaviour, ICharactorable {

    ICharactor p;
    private ChipBehaviour nowChip;

    private Vector3 target;
    [SerializeField]
    private readonly float speed = 3;
    [SerializeField]
    private GameObject mainCamera;
    private Vector3 offset;

    // Use this for initialization
    void Awake () {
        p = new Human
        {
            Name = "Player"
        };

        target = transform.position;
        offset = mainCamera.transform.position - target;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(
            transform.position,
            target,
            speed * Time.deltaTime
            );
        mainCamera.transform.position = transform.position + offset;
    }
    
    public void OnInvokeEvent(ChipBehaviour c)
    {
        Debug.Log($"player transition. {nowChip.ToStringDebug()} => {c}");
        if (nowChip.IsNext(c))
        {
            SetChip(c);
            nowChip.InvokeEvent();
            nowChip.PublishMessageLog(p.Command(OrderType.EVERY).text);
        }
    }

    public void SetChip(ChipBehaviour c)
    {
        target = c.transform.position;
        nowChip = c;
    }

    public ICharactor Charactor => p;
}
