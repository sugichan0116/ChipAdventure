using My.Behaviour.Chip;
using UnityEngine;

public class ChipFactory : MonoBehaviour
{
    [SerializeField]
    private EventContainer events;
    [SerializeField]
    private SymbolContainer symbols;

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

    public ChipBehaviour CreateFrom(ChipBehaviour origin, Vector2 v)
    {
        Vector3 locate = origin.transform.position;
        locate.x += v.x;
        locate.z += v.y;
        ChipBehaviour c = Create(locate);
        origin.PushNextChip(c);
        return c;
    }

    public ChipBehaviour Create(Vector3 v)
    {
        GameObject c;
        c = Instantiate(FinishedProduct().gameObject);
        c.transform.Translate(v);
        c.transform.parent = chipPool.transform;
        ChipBehaviour inner = c.GetComponent<ChipBehaviour>();
        inner.SetManager(manager);
        return inner;
    }
}
