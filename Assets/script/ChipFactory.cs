using My.Behaviour.Chip;
using UnityEngine;

public class ChipFactory : MonoBehaviour
{
    [SerializeField]
    private ChipBehaviour body;
    [SerializeField]
    private EventContainer events;
    [SerializeField]
    private SymbolContainer symbols;
    [SerializeField]
    private TableContainer tables;

    [Header("ForInitialize")]
    [SerializeField]
    private ChipPool chipPool;
    [SerializeField]
    private MapManager manager;

    [Header("Debug")]
    [SerializeField]
    private ChipBehaviour preAssebmledChip;
    
    private ChipBehaviour FinishedProduct()
    {
        return preAssebmledChip;
    }

    private Vector3 ExchangeVector2To3(Vector2 v)
    {
        return new Vector3(v.x, 0, v.y);
    }

    public ChipBehaviour CreateFrom(ChipBehaviour origin, Vector2 v)
    {
        Vector3 locate = origin.transform.position + ExchangeVector2To3(v);
        ChipBehaviour c = Create(locate);
        origin.PushNext(c);
        return c;
    }

    public ChipBehaviour Create(Vector3 v)
    {
        ChipBehaviour c = AssembleParts();
        c.transform.localPosition = v;
        c.transform.parent = chipPool.transform;
        return c;
    }

    private ChipBehaviour AssembleParts()
    {
        ChipBehaviour c = Instantiate(body);
        Instantiate(tables.Random()).transform.parent = c.transform;
        Instantiate(symbols.Random()).transform.parent = c.transform;
        c.SetEvent(events.Random());
        c.SetManager(manager);
        return c;
    }
}
